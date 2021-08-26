using System;
using System.ComponentModel;

namespace HttpWebTesting.WebTestItems
{
    public class WTI_IncludedWebTest : WebTestItem
    {
        /// <summary>
        /// The friendly name of the web test to include. This is what 
        /// will be displayed in the webtest viewer
        /// </summary>
        [DisplayName("Name")]
        [Description("The name of the included webtest")]
        [Category("General")]
        public string Name { get; set; }

        /// <summary>
        /// A description that summarizes the purpose of the web test.
        /// </summary>
        [DisplayName("Description")]
        [Description("The description of the included webtest")]
        [Category("General")]
        public string Description { get; set; }

        /// <summary>
        /// A flag that tells the test engine whether the embedded test 
        /// should override any local test settings with the parent test's 
        /// values (if the parent test has the same settings).
        /// </summary>
        [DisplayName("Inherit Parent Settings")]
        [Description("Should this test use the parent test's settings")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool InheritParentSettings { get; set; }

        /// <summary>
        /// A flag that tells the test engine whether the results of the 
        /// execution of the embedded test should be saved and shown in 
        /// the final reports.
        /// </summary>
        [DisplayName("Description")]
        [Description("The description of the included webtest")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool ReportResults { get; set; }
        
        /// <summary>
        /// A copy of the actual webtest to be embedded in the parent test.
        /// </summary>
        [Browsable(false)]
        public HttpWebTest HttpWebTest { get; set; }

        public WTI_IncludedWebTest()
        {
            HttpWebTest = new HttpWebTest();
            InitializeObject();
        }

        public WTI_IncludedWebTest(HttpWebTest httpWebTest)
        {
            HttpWebTest = httpWebTest;
            Name = httpWebTest.Name;
            InitializeObject();
        }

        private void InitializeObject()
        {
            objectItemType = Enums.WebTestItemType.Wti_IncludedWebTestItem;
            Enabled = true;
            guid = Guid.NewGuid();
            itemComment = string.Empty;

            InheritParentSettings = true;
            ReportResults = true;
        }
    }
}
