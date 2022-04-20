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

    //BUG: Need to add extractable and other logic to this.
    public class ExtractHiddenFieldsRuleInfo : RuleInfo
    {
        public ExtractHiddenFieldsRuleInfo()
        {
            Extracted_Values = new List<string>();
            HiddenFieldsCollection = new List<HiddenFieldsItem>();
        }

        #region -- Properties ----------------------------------------------------
        // These are all of the built in properties of the extraction rule
        public string HtmlDecode = "True";
        public string Required = "True";
        #endregion

        #region -- Methods -------------------------------------------------------
        public new bool AddRule(WebTestRequest request)
        {
            if (request != null)
            {
                ExtractionRuleReference extractionRuleReference = new ExtractionRuleReference();
                extractionRuleReference.Type = typeof(Microsoft.VisualStudio.TestTools.WebTesting.Rules.ExtractHiddenFields);
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("HtmlDecode", this.HtmlDecode));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("Required", this.Required));
                extractionRuleReference.ContextParameterName = this.ContextParameterName;
                request.ExtractionRuleReferences.Add(extractionRuleReference);
                return true;
            }
            return false;
        }

        private bool FindHiddenValues(WebTestResultPage page)
        {
            bool foundHiddenItem = false;
            HiddenFieldsItem item = new HiddenFieldsItem();

            foreach (HtmlTag tag in page.RequestResult.Response.HtmlDocument.GetFilteredHtmlTags("input"))
            {
                if (tag.GetAttributeValue("type").Value.ToLower() == "hidden")
                {
                    item.Extracted_HiddenValues.Add(
                        new KeyValuePair<string, string>(tag.GetAttributeValueAsString("name"), tag.GetAttributeValueAsString("value")));
                }
            }
            if (foundHiddenItem)
            {
                item.requestGuid = page.RequestResult.Request.Guid;
                item.HiddenContextName = "$HIDDEN" + this.ContextParameterName + ".";
            }
            return foundHiddenItem;
        }
        #endregion
    }
}
