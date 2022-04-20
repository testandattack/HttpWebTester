//*********************************************************
// Copyright (c) Gray Test Consulting. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using Microsoft.VisualStudio.TestTools.WebTesting;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GTC.Utilities.WebTestProcessing
{
    public class ExtractTextRuleInfo : RuleInfo
    {
        public ExtractTextRuleInfo()
        {
            Extracted_Values = new List<string>();
        }

        #region -- Properties ----------------------------------------------------
        // These are all of the built in properties of the extraction rule
        public string StartsWith = @"";
        public string EndsWith = @"";

        [XmlAttribute]
        public string Index = "0";
        [XmlAttribute]
        public string IgnoreCase = "False";
        [XmlAttribute]
        public string UseRegularExpression = "False";
        [XmlAttribute]
        public string HtmlDecode = "True";
        [XmlAttribute]
        public string Required = "True";
        [XmlAttribute]
        public string ExtractRandomMatch = "False";
        [XmlAttribute]
        public string SearchInHeaders = "False";
        #endregion

        #region -- Methods -------------------------------------------------------
        public new bool AddRule(WebTestRequest request)
        {
            if (request != null)
            {
                ExtractionRuleReference extractionRuleReference = new ExtractionRuleReference();
                extractionRuleReference.Type = typeof(Microsoft.VisualStudio.TestTools.WebTesting.Rules.ExtractText);
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("StartsWith", this.StartsWith));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("EndsWith", this.EndsWith));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("Index", this.Index));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("IgnoreCase", this.IgnoreCase));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("UseRegularExpression", this.UseRegularExpression));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("HtmlDecode", this.HtmlDecode));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("Required", this.Required));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("ExtractRandomMatch", this.ExtractRandomMatch));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("SearchInHeaders", this.SearchInHeaders));
                extractionRuleReference.ContextParameterName = this.ContextParameterName;
                request.ExtractionRuleReferences.Add(extractionRuleReference);
                return true;
            }
            return false;
        }

        //public new string FindExtractableValue(WebTestResultPage page)
        //{
        //    if (this.searchWithinNamedRequestsOnly && !page.RequestResult.Request.Url.Contains(this.NamedRequestUrl))
        //        return String.Empty;
        //    StringComparison comp = this.IgnoreCase.ToLower() == "true" ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

        //    string mainStr = GetResponseBodyAsString(page);
        //    string extractedValue = ParsingMethods.FindSubString(mainStr,this.StartsWith, this.EndsWith, Int32.Parse(this.Index), StringComparison.InvariantCulture);
        //    if (extractedValue != String.Empty)
        //        AddExtractedValue(extractedValue);
        //    return extractedValue;
        //}

        //private void AddExtractedValue(string value)
        //{
        //    if (!this.Extracted_Values.Contains(value))
        //        this.Extracted_Values.Add(value);
        //}

        //private string GetResponseBodyAsString(WebTestResultPage page)
        //{
        //    // NOTE: Need to see if this routine is necessary.
        //    if (page.RequestResult.Response.IsBodyEmpty)
        //        return String.Empty;

        //    if (page.RequestResult.Request.Body is StringHttpBody)
        //    {
        //        StringHttpBody body = page.RequestResult.Request.Body as StringHttpBody;
        //        return body.BodyString;
        //    }
        //    else if (page.RequestResult.Request.Body is BinaryHttpBody)
        //    {
        //        BinaryHttpBody body = page.RequestResult.Request.Body as BinaryHttpBody;
        //        return System.Text.Encoding.UTF8.GetString(body.Data);
        //    }
        //    else
        //        return String.Empty;
        //}
        #endregion
    }
}
