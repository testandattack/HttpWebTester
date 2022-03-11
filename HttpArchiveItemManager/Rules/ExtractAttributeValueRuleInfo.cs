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
using System;

namespace GTC.Utilities.WebTestProcessing
{

    public class ExtractAttributeValueRuleInfo : RuleInfo
    {
        public ExtractAttributeValueRuleInfo()
        {
            Extracted_Values = new List<string>();
        }

        #region -- Properties ----------------------------------------------------
        public string StartsWith = @"";
        public string EndsWith = @"";

        public string TagName = @"";
        public string AttributeName = @"";
        public string MatchAttributeName = @"";
        public string MatchAttributeValue = @"";
        public string HtmlDecode = "True";
        public string Required = "True";
        public string Index = "0";
        #endregion

        #region -- Methods -------------------------------------------------------
        public new bool AddRule(WebTestRequest request)
        {
            if (request != null)
            {
                ExtractionRuleReference extractionRuleReference = new ExtractionRuleReference();
                extractionRuleReference.Type = typeof(Microsoft.VisualStudio.TestTools.WebTesting.Rules.ExtractAttributeValue);
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("TagName", this.TagName));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("AttributeName", this.AttributeName));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("MatchAttributeName", this.MatchAttributeName));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("MatchAttributeValue", this.MatchAttributeValue));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("HtmlDecode", this.HtmlDecode));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("Required", this.Required));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("Index", this.Index));
                extractionRuleReference.ContextParameterName = this.ContextParameterName;
                request.ExtractionRuleReferences.Add(extractionRuleReference);
                return true;
            }
            return false;
        }

        public new string FindExtractableValue(WebTestResultPage page)
        {
            if (this.searchWithinNamedRequestsOnly && !page.RequestResult.Request.Url.Contains(this.NamedRequestUrl))
                return String.Empty;

            // BUG - Currently does not account for the HtmlDecode property in the main rule
            string returnValue = "";

            //            int iIndex = 0;
            WebTestResponse response = page.RequestResult.Response;

            //            this.Extracted_Values.Add(returnValue);
            return returnValue;
        }
        #endregion
    }
}
