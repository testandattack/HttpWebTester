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

    public class FindTextValidationRuleInfo : RuleInfo
    {
        public FindTextValidationRuleInfo()
        {
            Extracted_Values = new List<string>();
        }

        #region -- Properties ----------------------------------------------------
        public bool IsGlobalValidationRule = false;

        public string TextToFind = @"";
        [XmlAttribute]
        public string passIfTextFound = "true";
        [XmlAttribute]
        public string ignoreCase = "false";
        [XmlAttribute]
        public string useRegularExpression = "false";
        [XmlAttribute]
        public ValidationLevel level = ValidationLevel.High;
        [XmlAttribute]
        public RuleExecutionOrder order = RuleExecutionOrder.BeforeDependents;
        #endregion

        #region -- Methods -------------------------------------------------------
        public new bool AddRule(WebTestRequest request)
        {
            if (request != null)
            {
                ValidationRuleReference findTextReference = new ValidationRuleReference();
                findTextReference.Type = typeof(Microsoft.VisualStudio.TestTools.WebTesting.Rules.ValidationRuleFindText);
                findTextReference.ValidationLevel = this.level;
                findTextReference.ExecutionOrder = this.order;
                findTextReference.Properties.Add(new PluginOrRuleProperty("FindText", this.TextToFind));
                findTextReference.Properties.Add(new PluginOrRuleProperty("IgnoreCase", this.ignoreCase));
                findTextReference.Properties.Add(new PluginOrRuleProperty("UseRegularExpression", this.useRegularExpression));
                findTextReference.Properties.Add(new PluginOrRuleProperty("PassIfTextFound", this.passIfTextFound));
                request.ValidationRuleReferences.Add(findTextReference);
                return true;
            }
            return false;
        }

        public bool AddRule(DeclarativeWebTest webTest)
        {
            if (webTest != null)
            {
                ValidationRuleReference findTextReference = new ValidationRuleReference();
                findTextReference.Type = typeof(Microsoft.VisualStudio.TestTools.WebTesting.Rules.ValidationRuleFindText);
                findTextReference.ValidationLevel = this.level;
                findTextReference.ExecutionOrder = this.order;
                findTextReference.Properties.Add(new PluginOrRuleProperty("FindText", this.TextToFind));
                findTextReference.Properties.Add(new PluginOrRuleProperty("IgnoreCase", this.ignoreCase));
                findTextReference.Properties.Add(new PluginOrRuleProperty("UseRegularExpression", this.useRegularExpression));
                findTextReference.Properties.Add(new PluginOrRuleProperty("PassIfTextFound", this.passIfTextFound));
                webTest.ValidationRuleReferences.Add(findTextReference);
                return true;
            }
            return false;
        }
        #endregion
    }
}
