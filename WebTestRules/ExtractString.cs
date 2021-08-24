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
    public class ExtractString : ExtractionRule
    {
        #region -- Properties -----
        /// <summary>
        /// The string that occurs just before the start of the text you wish to extract.
        /// </summary>
        [DisplayName("Starts After")]
        [Description("The string that occurs just before the start of the text you wish to extract.")]
        public string StartsAfter { get; set; }

        /// <summary>
        /// The string that occurs just after the end of the text you wish to extract.
        /// </summary>
        [DisplayName("Ends With")]
        [Description("The string that occurs just after the end of the text you wish to extract.")]
        public string EndsWith { get; set; }

        /// <summary>
        /// A number describing which instance of the phrase should be extracted. To extract the first instance found, the value should be 1
        /// </summary>
        [DisplayName("Instance to Extract")]
        [Description("A number describing which instance of the phrase should be extracted. To extract the first instance found, the value should be 1")]
        [DefaultValue(1)]
        public int Instance { get; set; }

        /// <summary>
        /// If true, the rulw will ignore UPPER/lower case when searching for a match.
        /// </summary>
        [DisplayName("Ignore Case")]
        [Description("If true, the rulw will ignore UPPER/lower case when searching for a match.")]
        [DefaultValue(false)]
        public bool IgnoreCase { get; set; }

        /// <summary>
        /// If true, the rule will find all matches and then randomly choose one of those to extract.
        /// </summary>
        [DisplayName("Find Random Instance")]
        [Description("If true, the rule will find all matches and then randomly choose one of those to extract.")]
        [DefaultValue(false)]
        public bool FindRandomInstance { get; set; }

        /// <summary>
        /// If true, the rule will fail if a value is not found to extract.
        /// </summary>
        [DisplayName("Is Required")]
        [Description("If true, the rule will fail if a value is not found to extract.")]
        [DefaultValue(true)]
        public bool IsRequired { get; set; }
        #endregion

        
        #region -- Constructor -----
        public ExtractString()
        {
            Name = "Extract String";
            Description = "Extracts a string from the response based on the properties set for the rule instance.";
            type = typeof(ExtractString);
            RuleResult = RuleResult.NotEvaluatedYet;
        }
        #endregion

        public override void Extract(object sender, RuleEventArgs e)
        {
            Log.ForContext("SourceContext", "Rules").Debug("entering ExtractString-Extract for {request}", e.requestItem.guid);
            
            string responseString = e.response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            StringComparison comparison;
            if (IgnoreCase)
                comparison = StringComparison.CurrentCultureIgnoreCase;
            else
                comparison = StringComparison.CurrentCulture;

            // First, get the value
            string extractedValue;
            if (FindRandomInstance == true)
            {
                List<string> possibleValues = FindSubStrings(responseString, StartsAfter, EndsWith, comparison);
                if (possibleValues.Count == 0)
                {
                    extractedValue = string.Empty;
                }
                else
                {
                    Random rnd = new Random();
                    int index = rnd.Next(0, possibleValues.Count - 1);
                    extractedValue = possibleValues[index];
                }
            }
            else
            {
                extractedValue = responseString.FindSubString(StartsAfter, EndsWith, Instance, comparison);
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

        // NOTE: I need to update the GTC Extensions to do a list method that takes a StringComparison. When I publish that, remove this call.
        public List<string> FindSubStrings(string source, string startsAfter, string endsWith, StringComparison comparison)
        {
            int x = 0;
            int loopCounter = 1;
            string item = "";
            List<string> items = new List<string>();

            item = source.FindSubString(startsAfter, endsWith, loopCounter, comparison, ref x, false);

            while (item != string.Empty)
            {
                items.Add(item);
                loopCounter++;
                item = source.FindSubString(startsAfter, endsWith, loopCounter, comparison, ref x, false);
            }
            return items;
        }

    }
}
