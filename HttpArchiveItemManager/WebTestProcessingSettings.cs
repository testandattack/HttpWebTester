//*********************************************************
// Copyright (c) Gray Test Consulting. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GTC.Utilities.WebTestProcessing
{
    public static class LoadWebTestProcessingSettings
    {
        public static WebTestProcessingSettings LoadRecorderSettings(string filePath)
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(WebTestProcessingSettings));
                reader = new StreamReader(filePath);
                return (WebTestProcessingSettings)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }

    [Serializable]
    public class WebTestProcessingSettings
    {
        #region -- Properties --------------------------------------------
        public List<string> UnwantedItems { get; set; }
        public List<string> UnwantedPages { get; set; }
        public List<string> UnwantedReferers { get; set; }
        public List<ContextParam> ContextParamsToAdd { get; set; }
        public List<RulesCollectionEntry> RulesCollection { get; set; }
        public List<string> headersToSkipDuringMissingHeaderProcessing { get; set; }

        public CoreSettings coreSettings { get; set; }
        public GlobalSettings globalSettings { get; set; }
        public LoggingLevel loggingLevel { get; set; }
        public bool RunExtraRoutines { get; set; }
        public int startingNumberForWebServerParameterization { get; set; }
        public class CoreSettings
        {
            [XmlAttribute]
            public bool RunInDebugMode { get; set; }
            [XmlAttribute]
            public bool remove404Requests { get; set; }
            [XmlAttribute]
            public bool bAddCommentForEachChange { get; set; }
            [XmlAttribute]
            public bool bAddSummaryComments { get; set; }
            [XmlAttribute]
            public bool ShortenRefererHeaders { get; set; }
        }
        public class GlobalSettings
        {
            [XmlAttribute]
            public bool setStopOnErrorToTrue { get; set; }
            [XmlAttribute]
            public bool setPreAuthenticateToFalse { get; set; }
            [XmlAttribute]
            public bool RemoveExpectedResponseUrlValidationRule { get; set; }
        }
        #endregion

        public WebTestProcessingSettings()
        {
            UnwantedItems = new List<string>();
            UnwantedPages = new List<string>();
            coreSettings = new CoreSettings();

            ContextParamsToAdd = new List<ContextParam>();
            RulesCollection = new List<RulesCollectionEntry>();
        }
    }

    [Serializable]
    public class ContextParam
    {
        [XmlAttribute]
        public string Name = "";

        [XmlAttribute]
        public string Value = "";

        [XmlAttribute]
        public bool IsWebUrl = false;

        [XmlAttribute]
        public bool AutoSearchReplace = true;
    }

    [Serializable]
    public class RulesCollectionEntry
    {
        [XmlAttribute]
        public RuleType ruleType { get; set; }
        
        /// <summary>
        /// This description is used solely for the settings XML file to help manage the entries in there.
        /// </summary>
        [XmlAttribute]
        public string ruleDescription { get; set; }

        public RuleInfo ruleInfo { get; set; }
    }

    #region -- Enums ---------------------------------------------------
    public enum RuleType
    {
        ExtractTextRule = 1,
        ExtractHtmlSelectTagRule = 2,
        ExtractRegularExpressionRule = 3,
        ExtractHttpHeaderRule = 4,
        ExtractFormFieldRule = 5,
        ExtractHtmlTagInnerTextRule = 6,
        ExtractAttributeValueRule = 7,
        ExtractHiddenFields = 10,
        FindTextValidationRule = 8,
        ContextParameters = 9
    };

    [Flags]
    public enum RequestInfoFlags
    {
        NoFlag = 0,

        HasQueryStringParameters = 1,
        HasHeaders = 2,
        HasRedirects = 4,
        //PlaceHolder = 8,
        //PlaceHolder = 16,

        BodyIsFormPostParameters = 32,
        BodyIsStringHttpBody = 64,
        BodyIsBinaryHttpBody = 128,
        BodyIsUnknownBodyType = 256,
        //PlaceHolder = 512,

        MethodIsGET = 1024,
        MethodIsPUT = 2048,
        MethodIsPOST = 4096,
        MethodIsOPTIONS = 8192,
        MethodIsUnknown = 16384,

        ResponseRequiresUrlDecode = 32768,
        NamedUrlIsRedirect = 65536,
        //PlaceHolder = 131072,
        //PlaceHolder = 262144,
        //PlaceHolder = 524288,
        //PlaceHolder = 1048576,
        //PlaceHolder = 2097152,
        //PlaceHolder = 4194304,
        //PlaceHolder = 8388608,
        //PlaceHolder = 16777216,
        //PlaceHolder = 33554432,
        //PlaceHolder = 67108864,
        //PlaceHolder = 134217728,
        //PlaceHolder = 268435456,
        //PlaceHolder = 536870912,
        //PlaceHolder = 1073741824,
        //PlaceHolder = 2147483648,
    };

    [Flags]
    public enum RoutinesToExecute
    {
        RemoveUnwantedRequests = 1,
        RemoveMalformedRequests = 2,
        Remove404Requests = 4,
        AddContextParameters = 8,
        AddExtractionRules = 16,
        ParameterizeRuleValues = 32,
        AddMissingHeaders = 64,
        SetGlobalProperties = 128,
        ParameterizeAllWebServerUrls = 256,
        ShortenRefererHeaders = 512,
        item = 1024,

    };
    #endregion
}
