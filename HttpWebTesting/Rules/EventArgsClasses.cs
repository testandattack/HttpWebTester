using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using System;
using System.Net.Http;

namespace HttpWebTesting.Rules
{
    /// <summary>
    /// The argument collection passed into any event handlers for 
    /// </summary>
    public class PreWebtestEventArgs : EventArgs
    {
        public HttpWebTest webTest { get; set; }
    }

    public class PreRequestEventArgs : EventArgs
    {
        public HttpWebTest webTest { get; set; }
        public WTI_Request requestItem { get; set; }
    }

    public class PostRequestEventArgs : EventArgs
    {
        public HttpWebTest webTest { get; set; }
        public WTI_Request requestItem { get; set; }
        public HttpResponseMessage response { get; set; }
    }

    public class LoopControlEventArgs : EventArgs
    {
        public HttpWebTest webTest { get; set; }
    }

    public class RuleEventArgs : EventArgs
    {
        public HttpWebTest webTest { get; set; }
        
        public WTI_Request requestItem { get; set; }
        
        public HttpResponseMessage response { get; set; }

        public RuleResult ruleResult { get; set; }
    }

    public class PostWebtestEventArgs : EventArgs
    {
        public HttpWebTest webTest { get; set; }
    }

}
