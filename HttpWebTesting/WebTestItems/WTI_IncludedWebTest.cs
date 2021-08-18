namespace HttpWebTesting.WebTestItems
{
    public class WTI_IncludedWebTest : WebTestItem
    {
        /// <summary>
        /// The friendly name of the web test to include. This is what 
        /// will be displayed in the webtest viewer
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A description that summarizes the purpose of the web test.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// A flag that tells the test execution engine whether to 
        /// execute the embedded webtest or ignore it.
        /// </summary>
        public bool IsEnabled { get; set; }
        
        /// <summary>
        /// A flag that tells the test engine whether the embedded test 
        /// should override any local test settings with the parent test's 
        /// values (if the parent test has the same settings).
        /// </summary>
        public bool InheritParentSettings { get; set; }
        
        /// <summary>
        /// A flag that tells the test engine whether the results of the 
        /// execution of the embedded test should be saved and shown in 
        /// the final reports.
        /// </summary>
        public bool ReportResults { get; set; }
        
        /// <summary>
        /// A copy of the actual webtest to be embedded in the parent test.
        /// </summary>
        public HttpWebTest HttpWebTest { get; set; }
    }
}
