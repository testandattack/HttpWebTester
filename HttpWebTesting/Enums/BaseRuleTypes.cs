using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTesting.Enums
{
    /// <summary>
    /// Lists the rule's scope and the location where a given rule should be executed
    /// </summary>
    /// <include file='Documentation/xml_include_tag.xml' path='MyDocs/MyMembers[@name="RuleExecutionOrder"]'/>
    public enum BaseRuleTypes
    {

        PreTest = 1,

        PreRequest = 2,
        
        Validation = 4,
        
        Extraction = 6,

        PostRequest = 8,

        PostTest = 10
    };
}
