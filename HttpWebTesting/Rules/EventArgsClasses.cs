using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using System;
using System.Net.Http;

namespace HttpWebTesting.Rules
{
    /// <summary>
    /// The argument collection passed into any event handlers based on
    /// the <see cref="PreWebTestRule"/> event.
    /// </summary>
    public class PreWebtestEventArgs : EventArgs
    {
        public HttpWebTest webTest { get; set; }
    }

    /// <summary>
    /// The argument collection passed into any event handlers based on
    /// the <see cref="PreRequestRule"/> event.
    /// </summary>
    public class PreRequestEventArgs : EventArgs
    {
        public HttpWebTest webTest { get; set; }
        public WTI_Request requestItem { get; set; }
    }

    /// <summary>
    /// The argument collection passed into any event handlers based on
    /// the <see cref="PostRequestRule"/> event.
    /// </summary>
    public class PostRequestEventArgs : EventArgs
    {
        public HttpWebTest webTest { get; set; }
        public WTI_Request requestItem { get; set; }
        public HttpResponseMessage response { get; set; }
    }

    /// <summary>
    /// The argument collection passed into any event handlers based on
    /// the <see cref="ExtractionRule"/> event or the <see cref="ValidationRule"/> event.
    /// </summary>
    public class RuleEventArgs : EventArgs
    {
        public HttpWebTest webTest { get; set; }
        
        public WTI_Request requestItem { get; set; }
        
        public HttpResponseMessage response { get; set; }

        public RuleResult ruleResult { get; set; }
    }

    /// <summary>
    /// The argument collection passed into any event handlers based on
    /// the <see cref="PostWebTestRule"/> event.
    /// </summary>
    public class PostWebtestEventArgs : EventArgs
    {
        public HttpWebTest webTest { get; set; }
    }

}
