//*********************************************************
// Copyright (c) Gray Test Consulting. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using Microsoft.VisualStudio.TestTools.WebTesting;
using Microsoft.VisualStudio.TestTools.WebTesting.Rules;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using GTC.Utilities;

namespace GTC.Utilities.WebTestProcessing
{

    [XmlInclude(typeof(ExtractTextRuleInfo))]
    [XmlInclude(typeof(ExtractHiddenFieldsRuleInfo))]
    [XmlInclude(typeof(ExtractHtmlSelectTagRuleInfo))]
    [XmlInclude(typeof(ExtractRegularExpressionRuleInfo))]
    [XmlInclude(typeof(ExtractHttpHeaderRuleInfo))]
    [XmlInclude(typeof(ExtractFormFieldRuleInfo))]
    [XmlInclude(typeof(ExtractHtmlTagInnerTextRuleInfo))]
    [XmlInclude(typeof(ExtractAttributeValueRuleInfo))]
    [XmlInclude(typeof(FindTextValidationRuleInfo))]
    [Serializable]
    public abstract class RuleInfo
    {
        internal RuleInfo() { }

        #region -- Properties ----------------------------------------------------
        public string ContextParameterName = @"";
        public bool searchWithinNamedRequestsOnly = true;
        public string NamedRequestUrl = @"";
        public RequestInfoFlags ruleConditionals = 0;

        // This list will hold all the unique values found in the test for later replacement 
        [XmlIgnore]
        public List<string> Extracted_Values;

        [XmlIgnore]
        public List<HiddenFieldsItem> HiddenFieldsCollection;
        #endregion

        #region -- Methods -------------------------------------------------------
        internal bool AddRule(WebTestRequest request) { return false; }

        internal string FindExtractableValue(WebTestResultPage page) { return String.Empty; }
        #endregion
    }

    public class HiddenFieldsItem
    {
        public HiddenFieldsItem()
        {
            Extracted_HiddenValues = new List<KeyValuePair<string, string>>();
        }
        public List<KeyValuePair<string, string>> Extracted_HiddenValues;
        public string HiddenContextName { get; set; }
        public Guid requestGuid { get; set; }
    }

}
