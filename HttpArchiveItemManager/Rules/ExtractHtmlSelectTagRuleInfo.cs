﻿//*********************************************************
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

    public class ExtractHtmlSelectTagRuleInfo : RuleInfo
    {
        public ExtractHtmlSelectTagRuleInfo()
        {
            Extracted_Values = new List<string>();
        }

        #region -- Properties ----------------------------------------------------
        public string StartsWith = @"";
        public string EndsWith = @"";

        public string SelectTagName = @"";
        public string Index = "0";
        #endregion

        #region -- Methods -------------------------------------------------------
        public new bool AddRule(WebTestRequest request)
        {
            if (request != null)
            {
                ExtractionRuleReference extractionRuleReference = new ExtractionRuleReference();
                extractionRuleReference.Type = typeof(Microsoft.VisualStudio.TestTools.WebTesting.ExtractHtmlSelectTag);
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("SelectTagName", this.SelectTagName));
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
