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

    public class ExtractHtmlTagInnerTextRuleInfo : RuleInfo
    {
        public ExtractHtmlTagInnerTextRuleInfo()
        {
            Extracted_Values = new List<string>();
        }

        #region -- Properties ----------------------------------------------------
        public string TagName = @"";
        public string AttributeName = @"";
        public string AttributeValue = @"";
        public string RemoveInnerTags = "True";
        public string HasClosingTags = "True";
        public string CollapseWhiteSpace = "True";
        public string Index = "-1";
        #endregion

        #region -- Methods -------------------------------------------------------
        public new bool AddRule(WebTestRequest request)
        {
            if (request != null)
            {
                ExtractionRuleReference extractionRuleReference = new ExtractionRuleReference();
                extractionRuleReference.Type = typeof(Microsoft.VisualStudio.TestTools.WebTesting.ExtractHtmlTagInnerText);
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("TagName", this.TagName));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("AttributeName", this.AttributeName));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("AttributeValue", this.AttributeValue));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("RemoveInnerTags", this.RemoveInnerTags));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("HasClosingTags", this.HasClosingTags));
                extractionRuleReference.Properties.Add(new PluginOrRuleProperty("CollapseWhiteSpace", this.CollapseWhiteSpace));
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

            int iIndex = 0;
            WebTestResponse response = page.RequestResult.Response;

            foreach (HtmlTag tag in response.HtmlDocument.GetFilteredHtmlTags(new string[] { this.TagName }))
            {
                HtmlAttribute myAttrib = new HtmlAttribute(this.AttributeName, this.AttributeValue);
                if (tag.Attributes.Contains(myAttrib))
                {
                    if (iIndex < Int32.Parse(this.Index))
                    {
                        iIndex++;
                    }
                    else
                    {
                        returnValue = tag.GetAttributeValueAsString(this.TagName);
                        break;
                    }
                }
            }
            this.Extracted_Values.Add(returnValue);
            return returnValue;
        }
        #endregion
    }
}
