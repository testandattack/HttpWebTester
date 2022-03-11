//*********************************************************
// Copyright (c) Gray Test Consulting. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using GTC.Extensions;
using Microsoft.VisualStudio.TestTools.WebTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace GTC.Utilities
{
    public class WebtestReplacer
    {
        #region --- Public properties -------------------------------------------
        public WebTestReplacerSettings settings {get; set; }
        public bool UseRegex { get; set; }

        public mLogMsg logMsg { get; set; }

        #endregion

        #region --- Private properties ------------------------------------------
        private string WebTestReplacerSettingsFileName = "wtfarSettings.xml";
        private int logStrLen = 64;
        #endregion

        #region --- Constructors ------------------------------------------------
        public WebtestReplacer(string fileLocation, mLogMsg loggingMsg, LoggingLevel loggingLevel)
        {
            settings = LoadWtrSettings(fileLocation);
            logMsg = loggingMsg;
            logMsg.globalLevel = loggingLevel;
        }
        #endregion

        #region --- Methods -----------------------------------------------------
        public int ProcessWebTest(DeclarativeWebTest webtest, string sFind, string sReplace, string fileName = "")
        {
            int nCount = 0;
            nCount = ProcessItems_FindReplace(webtest.Items, sFind, sReplace);

            if (settings.replaceOptions.HasFlag(ReplaceOptions.AddCommentToWebTest))
            {
                //Adds a new comment at the top of the test to let people know this file has been modified 
                webtest.Items.Insert(0, (new Comment("WebTest was modified via Global Find and Replace Proccessing:" + DateTime.Now.ToString())));
                webtest.Items.Insert(1, (new Comment("Find:'" + sFind.Shortened(logStrLen) + "'  Replace:'" + sReplace + "' Items modified:" + nCount)));
                webtest.Items.Insert(2, (new Comment("Options:" + settings.replaceOptions.ToString())));
                webtest.Items.Insert(3, (new Comment("---------------------------------------------------------------------------------")));
            }
            logMsg.Write(LoggingLevel.Detailed, "WebTestReplacer: Find:'{0}'  Replace:'{1}' Items modified:{2}", sFind.Shortened(logStrLen), sReplace, nCount);
            return nCount; // How many lines did it fix up
        }

        private int ProcessItems_FindReplace(WebTestItemCollection items, string sFind, string sReplace)
        {
            int nCount = 0;
            bool bIgnoreCase = !settings.replaceOptions.HasFlag(ReplaceOptions.MatchCase);
            for (int nIndex = 0; nIndex < items.Count; nIndex++)
            {
                if (items[nIndex] is WebTestRequest)
                {
                    WebTestRequest webRequest = items[nIndex] as WebTestRequest;

                    nCount += FindReplace_URL(sFind, sReplace, bIgnoreCase, webRequest);
                    nCount += FindReplace_ReportingName(sFind, sReplace, bIgnoreCase, webRequest);
                    nCount += FindReplace_ExpectedResponse(sFind, sReplace, bIgnoreCase, webRequest);
                    nCount += FindReplace_QueryStrings(sFind, sReplace, bIgnoreCase, webRequest);
                    nCount += FindReplace_Headers(sFind, sReplace, bIgnoreCase, webRequest);
                    nCount += FindReplace_FormPost(sFind, sReplace, bIgnoreCase, webRequest);
                    nCount += FindReplace_StringBody(sFind, sReplace, bIgnoreCase, webRequest);
                }
                else if (items[nIndex] is Comment)
                {
                    Comment comment = items[nIndex] as Comment;
                    nCount += FindReplace_Comment(sFind, sReplace, bIgnoreCase, comment);
                }
                else if (items[nIndex] is TransactionTimer)
                {
                    TransactionTimer transaction = items[nIndex] as TransactionTimer;
                    nCount += FindReplace_TransactionTimer(sFind, sReplace, bIgnoreCase, transaction);
                }
                else if (items[nIndex] is WebTestLoop)
                {
                    WebTestLoop loop = items[nIndex] as WebTestLoop;
                    nCount += ProcessItems_FindReplace(loop.Items, sFind, sReplace);
                }
                else if (items[nIndex] is WebTestCondition)
                {
                    WebTestCondition condition = items[nIndex] as WebTestCondition;
                    nCount += ProcessItems_FindReplace(condition.Items, sFind, sReplace);
                }
                else if (items[nIndex] is IncludedWebTest)
                {
                    IncludedWebTest webTest = items[nIndex] as IncludedWebTest;
                    logMsg.Write(LoggingLevel.Detailed, "Found IncludedWebTest: {0} Currently nested webtests are not processed, so no changes were made to the included webtest.", webTest.Name);
                }
                else
                {
                    logMsg.Write(LoggingLevel.Detailed, "WARNING: Unknown Item of type {0}-{1}",items[nIndex].ToString());
                }
            } 
            return nCount; 
        }

        #region -- Replace methods for each object type -------------------------
        private int FindReplace_TransactionTimer(string sFind, string sReplace, bool bIgnoreCase, TransactionTimer transaction)
        {
            int nCount = 0;
            if (settings.replaceOptions.HasFlag(ReplaceOptions.TransactionName))
            {
                if (transaction.Name != null)
                {
                    string s = transaction.Name;
                    if (Replace(ref s, sFind, sReplace, bIgnoreCase))
                    {
                        logMsg.Write(LoggingLevel.Debug, "\tFound in Transaction Timer Name. Item:{0}-{1}", transaction.ItemId, transaction.Name);
                        if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly)) transaction.Name = s;
                        nCount++;
                    }
                }
            }

            nCount += ProcessItems_FindReplace(transaction.Items, sFind, sReplace);
            return nCount;
        }

        private int FindReplace_Comment(string sFind, string sReplace, bool bIgnoreCase, Comment comment)
        {
            int nCount = 0;
            if (settings.replaceOptions.HasFlag(ReplaceOptions.Comment))
            {
                if (comment.CommentText != null)
                {
                    string s = comment.CommentText;
                    if (Replace(ref s, sFind, sReplace, bIgnoreCase))
                    {
                        if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly)) comment.CommentText = s;
                        logMsg.Write(LoggingLevel.Debug, "\tFound in Comment. Item:{0}-{1}",comment.ItemId, comment.CommentText);
                        nCount++;
                    }
                }
            }
            return nCount;
        }

        private int FindReplace_StringBody(string sFind, string sReplace, bool bIgnoreCase, WebTestRequest webRequest)
        {
            int nCount = 0;
            if ((webRequest.Body is StringHttpBody) && (settings.replaceOptions.HasFlag(ReplaceOptions.StringBody)))
            {
                StringHttpBody body = ((StringHttpBody)(webRequest.Body));

                if (body != null)
                {
                    string s = body.BodyString;
                    if (Replace(ref s, sFind, sReplace, bIgnoreCase))
                    {
                        if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly)) body.BodyString = s;
                        logMsg.Write(LoggingLevel.Debug, "\tFound {0} in StringBody. Replaced with {1}. Request:{2}"
                            , sFind.Shortened(logStrLen), sReplace, webRequest.ItemId + "-" + webRequest.Url);
                        nCount++;
                    }
                }
            }
            return nCount;
        }

        private int FindReplace_FormPost(string sFind, string sReplace, bool bIgnoreCase, WebTestRequest webRequest)
        {
            int nCount = 0;
            if ((settings.replaceOptions.HasFlag(ReplaceOptions.FormPostName) | settings.replaceOptions.HasFlag(ReplaceOptions.FormPostValue)) && (webRequest.Body is FormPostHttpBody))
            {

                FormPostHttpBody httpBody = webRequest.Body as FormPostHttpBody;
                int nStartingCount = nCount;

                if (httpBody != null)
                {
                    for (int n = 0; n < httpBody.FormPostParameters.Count; n++)
                    {

                        if (settings.replaceOptions.HasFlag(ReplaceOptions.FormPostName))
                        {
                            string s = httpBody.FormPostParameters[n].Name;
                            if (Replace(ref s, sFind, sReplace, bIgnoreCase))
                            {
                                if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly)) httpBody.FormPostParameters[n].Name = s;
                                logMsg.Write(LoggingLevel.Debug, "\tFound {0} in Form Post Name. Replaced with {1}. Request:{2}"
                                    , sFind.Shortened(logStrLen), sReplace, webRequest.ItemId + "-" + webRequest.Url);
                                nCount++;
                            }
                        }
                        if (settings.replaceOptions.HasFlag(ReplaceOptions.FormPostValue))
                        {
                            string s = httpBody.FormPostParameters[n].Value;
                            if (Replace(ref s, sFind, sReplace, bIgnoreCase))
                            {
                                if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly)) httpBody.FormPostParameters[n].Value = s;
                                logMsg.Write(LoggingLevel.Debug, "\tFound {0} in Form Post Value. Replaced with {1}. Request:{2}"
                                    , sFind.Shortened(logStrLen), sReplace, webRequest.ItemId + "-" + webRequest.Url);
                                nCount++;
                            }
                        }
                    }
                } 
            }
            return nCount;
        }

        private int FindReplace_Headers(string sFind, string sReplace, bool bIgnoreCase, WebTestRequest webRequest)
        {
            int nCount = 0;
            if (settings.replaceOptions.HasFlag(ReplaceOptions.Headers) && webRequest.HasHeaders)
            {
                for (int n = 0; n < webRequest.Headers.Count; n++)
                {
                    string s = webRequest.Headers[n].Name;
                    if (Replace(ref s, sFind, sReplace, bIgnoreCase))
                    {
                        if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly)) webRequest.Headers[n].Name = s;
                        logMsg.Write(LoggingLevel.Debug, "\tFound {0} in Header Name. Replaced with {1}. Request:{2}"
                            , sFind.Shortened(logStrLen), sReplace, webRequest.ItemId + "-" + webRequest.Url);
                        nCount++;
                    }

                    s = webRequest.Headers[n].Value;
                    if (Replace(ref s, sFind, sReplace, bIgnoreCase))
                    {
                        if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly)) webRequest.Headers[n].Value = s;
                        logMsg.Write(LoggingLevel.Debug, "\tFound {0} in Header Value. Replaced with {1}. Request:{2}"
                            , sFind.Shortened(logStrLen), sReplace, webRequest.ItemId + "-" + webRequest.Url);
                        nCount++;
                    }
                }
            }
            return nCount;
        }

        private int FindReplace_QueryStrings(string sFind, string sReplace, bool bIgnoreCase, WebTestRequest webRequest)
        {
            int nCount = 0;
            if (settings.replaceOptions.HasFlag(ReplaceOptions.QueryStringName) | settings.replaceOptions.HasFlag(ReplaceOptions.QueryStringValue))
            {
                for (int n = 0; n < webRequest.QueryStringParameters.Count; n++)
                {
                    if (settings.replaceOptions.HasFlag(ReplaceOptions.QueryStringName))
                    {
                        string s = webRequest.QueryStringParameters[n].Name;
                        if (Replace(ref s, sFind, sReplace, bIgnoreCase))
                        {
                            if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly)) webRequest.QueryStringParameters[n].Name = s;
                            logMsg.Write(LoggingLevel.Debug, "\tFound {0} in Query String Name. Replaced with {1}. Request:{2}"
                                , sFind.Shortened(logStrLen), sReplace, webRequest.ItemId + "-" + webRequest.Url);
                            nCount++;
                        }
                    }
                    if (settings.replaceOptions.HasFlag(ReplaceOptions.QueryStringValue))
                    {
                        string s = webRequest.QueryStringParameters[n].Value;
                        if (Replace(ref s, sFind, sReplace, bIgnoreCase))
                        {
                            if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly)) webRequest.QueryStringParameters[n].Value = s;
                            logMsg.Write(LoggingLevel.Debug, "\tFound {0} in Query String Value. Replaced with {1}. Request:{2}"
                                , sFind.Shortened(logStrLen), sReplace, webRequest.ItemId + "-" + webRequest.Url);
                            nCount++;
                        }
                    }
                }
            }
            return nCount;
        }

        private int FindReplace_ExpectedResponse(string sFind, string sReplace, bool bIgnoreCase, WebTestRequest webRequest)
        {
            int nCount = 0;
            if (settings.replaceOptions.HasFlag(ReplaceOptions.ExpectedResponseURL))
            {
                if (webRequest.ExpectedResponseUrl != null)
                {
                    string s = webRequest.ExpectedResponseUrl;
                    if (Replace(ref s, sFind, sReplace, bIgnoreCase))
                    {
                        if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly)) webRequest.ExpectedResponseUrl = s;
                        logMsg.Write(LoggingLevel.Debug, "\tFound {0} in Expected Response URL. Replaced with {1}. Request:{2}"
                            , sFind.Shortened(logStrLen), sReplace, webRequest.ItemId + "-" + webRequest.Url);
                        nCount++;
                    }
                }
            }
            return nCount;
        }

        private int FindReplace_ReportingName(string sFind, string sReplace, bool bIgnoreCase, WebTestRequest webRequest)
        {
            int nCount = 0;
            if (settings.replaceOptions.HasFlag(ReplaceOptions.ReportingName))
            {
                if (webRequest.ReportingName != null)
                {
                    string s = webRequest.ReportingName;
                    if (Replace(ref s, sFind, sReplace, bIgnoreCase))
                    {
                        if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly)) webRequest.ReportingName = s;
                        logMsg.Write(LoggingLevel.Debug, "\tFound {0} in Reporting Name. Replaced with {1}. Request:{2}"
                            , sFind.Shortened(logStrLen), sReplace, webRequest.ItemId + "-" + webRequest.Url);
                        nCount++;
                    }
                }
            }
            return nCount;
        }

        private int FindReplace_URL(string sFind, string sReplace, bool bIgnoreCase, WebTestRequest webRequest)
        {
            int nCount = 0;
            if (settings.replaceOptions.HasFlag(ReplaceOptions.URL))
            {
                if (webRequest.Url != null)
                {
                    string s = webRequest.Url;
                    if (Replace(ref s, sFind, sReplace, bIgnoreCase))
                    {
                        if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly)) webRequest.Url = s;
                        logMsg.Write(LoggingLevel.Debug, "\tFound {0} in URL. Replaced with {1}. Request:{2}"
                            , sFind.Shortened(logStrLen), sReplace, webRequest.ItemId + "-" + webRequest.Url);
                        nCount++;
                    }
                }
            }
            return nCount;
        }
        #endregion

        private bool Replace(ref string sOriginal, string sFind, string sReplace, bool bIgnoreCase)
        {
            // This method exists solely to help with the "Find Only" option. Without it, we'd need two copies of every method above.
            if (!String.IsNullOrEmpty(sOriginal))
            {
                string sNew = string.Empty;
                if (UseRegex)
                {
                    Regex regEx = new Regex(sFind);
                    sNew = regEx.Replace(sOriginal, sReplace);
                }
                else
                {
                    sNew = ReplaceEx(sOriginal, sFind, sReplace, bIgnoreCase);
                }

                // First see if we actually found and replaced anything
                if (sNew.Equals(sOriginal))
                    return false;

                // if we made a change AND we are NOT in FindOnly mode, then set the original to the new value
                if (!settings.replaceOptions.HasFlag(ReplaceOptions.FindOnly))
                    sOriginal = sNew;
                return true;
            }
            return false;
        }

        private string ReplaceEx(string sOriginal, string sFind, string sReplace, bool bIgnoreCase)
        {
            try
            {
                int nCount, nPosition0, nPosition1;
                nCount = nPosition0 = nPosition1 = 0;
                int inc = (sOriginal.Length / sFind.Length) *
                        (sReplace.Length - sFind.Length);
                char[] chars = new char[sOriginal.Length + Math.Max(0, inc)];
                while ((nPosition1 = sOriginal.IndexOf(sFind,
                    nPosition0, (bIgnoreCase) ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture)) != -1)
                {
                    for (int i = nPosition0; i < nPosition1; ++i)
                        chars[nCount++] = sOriginal[i];
                    for (int i = 0; i < sReplace.Length; ++i)
                        chars[nCount++] = sReplace[i];
                    nPosition0 = nPosition1 + sFind.Length;
                }
                if (nPosition0 == 0) return sOriginal;
                for (int i = nPosition0; i < sOriginal.Length; ++i)
                    chars[nCount++] = sOriginal[i];
                return new string(chars, 0, nCount);
            }
            catch(DivideByZeroException ex)
            {
                logMsg.Write(LoggingLevel.Error, "WebTestReplacer: Divide By Zero exception in ReplaceEx: sFind={0}, sReplace={1}", sFind, sReplace);
                return sOriginal;
            }
        }
        #endregion

        #region -- Settings methods ---------------------------------------------
        public void SaveReplacerDefaultSettings()
        {
            WriteToXmlFile<WebTestReplacerSettings>(WebTestReplacerSettingsFileName, this.settings);
        }

        public void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public WebTestReplacerSettings LoadWtrSettings(string filePath)
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(WebTestReplacerSettings));
                reader = new StreamReader(filePath);
                return (WebTestReplacerSettings)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        #endregion
    }

    [Flags]
    public enum ReplaceOptions
    {
        URL = 1,
        QueryStringName = 2,
        QueryStringValue = 4,
        FormPostName = 8,
        FormPostValue = 16,
        StringBody = 32,
        TransactionName = 64,
        ReportingName = 128,
        Comment = 256,
        ExpectedResponseURL = 512,
        MatchCase = 1024,
        AddCommentToWebTest = 2048,
        UseRegex = 4096,
        FindOnly = 8192,
        Headers = 16384
    };

    [Serializable]
    public class WebTestReplacerSettings
    {
        public WebTestReplacerSettings() { }

        public List<string> previousFinds { get; set; }
        public List<string> previousReplaces { get; set; }
        public ReplaceOptions replaceOptions { get; set; }
    }

}
