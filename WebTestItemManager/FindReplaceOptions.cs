using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace WebTestItemManager
{
    public class FindReplaceOptions
    {
        public bool InRequestHeaders { get; set; }
        public bool InRequestQueryParams { get; set; }
        public bool InRequestFormPostParams { get; set; }
        public bool InRequestStringBodies { get; set; }
        public bool InRequestUrl { get; set; }
        public bool InRequestRules { get; set; }
        public bool InRequestReportingName { get; set; }
        public bool InComment { get; set; }
        public bool InLoop { get; set; }
        public bool InTransaction { get; set; }
        public bool InTestContextParameters { get; set; }
        public bool InTestDataSources { get; set; }
        public bool InTestRules { get; set; }

        public void LoadFindReplaceOptions()
        {
            using(StreamReader sr = new StreamReader($"{Environment.CurrentDirectory}\\findReplaceOptions.json"))
            {
                CopyValues(JsonConvert.DeserializeObject<FindReplaceOptions>(sr.ReadToEnd()));
            }
        }

        public void SaveFindReplaceOptions()
        {
            using(StreamWriter sw = new StreamWriter($"{Environment.CurrentDirectory}\\findReplaceOptions.json"))
            {
                sw.Write(JsonConvert.SerializeObject(this));
            }
        }

        public void CopyValues(FindReplaceOptions options)
        {
            InRequestHeaders = options.InRequestHeaders;
            InRequestQueryParams = options.InRequestQueryParams;
            InRequestFormPostParams = options.InRequestFormPostParams;
            InRequestStringBodies = options.InRequestStringBodies;
            InRequestUrl = options.InRequestUrl;
            InRequestRules = options.InRequestRules;
            InRequestReportingName = options.InRequestReportingName;
            InComment = options.InComment;
            InLoop = options.InLoop;
            InTransaction = options.InTransaction;
            InTestContextParameters = options.InTestContextParameters;
            InTestDataSources = options.InTestDataSources;
            InTestRules = options.InTestRules;
        }
    }
}
