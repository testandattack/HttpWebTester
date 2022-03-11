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

    public class ExtractRegularExpressionRuleInfo : RuleInfo
    {
        public ExtractRegularExpressionRuleInfo()
        {
            Extracted_Values = new List<string>();
        }

        #region -- Properties ----------------------------------------------------
        public string RegularExpression = @"";
        public string Index = "0";
        public string IgnoreCase = "False";
        public string HtmlDecode = "True";
        public string Required = "True";
        public string UseGroups = "False";
        #endregion

        #region -- Methods -------------------------------------------------------
        public new bool AddRule(WebTestRequest request)
        {
            if (request != null)
            {
                ExtractionRuleReference extractionRuleReference = new ExtractionRuleReference();
                extractionRuleReference.Type = typeof(Microsoft.VisualStudio.TestTools.WebTesting.Rules.ExtractRegularExpression);
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("RegularExpression", this.RegularExpression));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("IgnoreCase", this.IgnoreCase));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("Required", this.Required));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("Index", this.Index));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("HtmlDecode", this.HtmlDecode));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("UseGroups", this.UseGroups));
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
