using HttpWebTesting.Collections;
using HttpWebTesting.Enums;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;

namespace HttpWebTesting
{
    public class HttpWebTest
    {
        #region -- Test Level Properties -----
        /// <summary>
        /// The Name of the webtest.
        /// </summary>
        [DisplayName("Name")]
        [Description("The Name of the webtest.")]
        [Category(PropertyCategories.General)]
        public string Name { get; set; }

        /// <summary>
        /// A brief description of the webtest.
        /// </summary>
        [DisplayName("Description")]
        [Description("A brief description of the webtest.")]
        [Category(PropertyCategories.General)]
        public string Description { get; set; }
        
        /// <summary>
        /// A unique Id for the test.
        /// </summary>
        [Browsable(false)]
        public Guid Id { get; private set; }
        
        [DisplayName("Stop On Error")]
        [Description("If true, the webtest execution will stop the first time it encounters a request failure.")]
        [Category(PropertyCategories.Behavior)]
        [DefaultValue(true)]
        public bool StopOnError { get; set; }


        [DisplayName("Suppress All Comments In Results")]
        [Description("")]
        [Category(PropertyCategories.Behavior)]
        [DefaultValue(true)]
        public bool SuppressAllCommentsInResults { get; set; }
        #endregion

        #region -- Test Level Collections -----
        [Browsable(false)]
        public WebTestItemCollection WebTestItems { get; set; }

        [Browsable(false)]
        public ContextCollection ContextProperties { get; set; }

        [Browsable(false)]
        public DataSourceCollection DataSources { get; set; }

        [Browsable(false)]
        public RuleCollection Rules { get; set; }
        #endregion

        #region -- Constructors -----
        public HttpWebTest() 
        {
            InitializeObject();
        }

        public HttpWebTest(string WebtestName)
        {
            Name = WebtestName;
            InitializeObject();
        }

        private void InitializeObject()
        {
            Id = new Guid();
            StopOnError = true;
            SuppressAllCommentsInResults = false;

            WebTestItems = new WebTestItemCollection();
            ContextProperties = new ContextCollection();
            DataSources = new DataSourceCollection();
            Rules = new RuleCollection();
        }
        #endregion
    }
}
