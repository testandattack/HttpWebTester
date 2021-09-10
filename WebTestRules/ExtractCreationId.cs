using GTC.Extensions;
using HttpWebTesting.CoreObjects;
using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebTestRules
{
    public class ExtractCreationId : ExtractionRule
    {
        #region -- Properties -----
        /// <summary>
        /// If true, the rule will fail if a value is not found to extract.
        /// </summary>
        [DisplayName("Is Required")]
        [Description("If true, the rule will fail if a value is not found to extract.")]
        [DefaultValue(true)]
        public bool IsRequired { get; set; }
        #endregion

        
        #region -- Constructor -----
        public ExtractCreationId()
        {
            Name = "Extract Creation Id";
            Description = "Extracts the Id of an object from the 'Location' header of a 201 response.";
            type = typeof(ExtractCreationId);
            RuleResult = RuleResult.NotEvaluatedYet;
        }

        public ExtractCreationId(string ContextName)
        {
            Name = "Extract Creation Id";
            Description = "Extracts the Id of an object from the 'Location' header of a 201 response.";
            type = typeof(ExtractCreationId);
            this.ContextName = ContextName; 
            RuleResult = RuleResult.NotEvaluatedYet;
        }
        #endregion

        public override void Extract(object sender, RuleEventArgs e)
        {
            Log.ForContext("SourceContext", "Rules").Debug("entering ExtractCreationId-Extract for {request}", e.requestItem.guid);

            string extractedValue = string.Empty;

            if (e.response.StatusCode != System.Net.HttpStatusCode.Created)
            {

                string location = e.response.Headers.Location.AbsolutePath;
                string originalUri = e.requestItem.requestItem.RequestUri.AbsolutePath;

                int x = location.IndexOf(originalUri);
                if (x != -1)
                {
                    int iStart = x + originalUri.Length + 1;
                    extractedValue = location.Substring(iStart);
                }
                // First, get the value
            }

            // Second, evaluate the value
            if(extractedValue != string.Empty)
            {
                Log.ForContext("SourceContext", "Rules").Debug("Extract for {request} found {value} {@RuleInfo}", e.requestItem.guid, extractedValue, this);
                e.webTest.ContextProperties.Add(new Property(ContextName, extractedValue));
                RuleResult = RuleResult.Passed;
                return;
            }
            else if (IsRequired == false)
            {
                Log.ForContext("SourceContext", "Rules").Debug("Extract for {request} did not find a value, but passed. {@RuleInfo}", e.requestItem.guid, this);
                RuleResult = RuleResult.Passed;
                return;
            }
            else
            {
                Log.ForContext("SourceContext", "Rules").Debug("Extract for {request} did not find a value and failed. {@RuleInfo}", e.requestItem.guid, this);
                RuleResult = RuleResult.Failed;
                return;
            }
        }
    }
}
