using HttpWebTesting.Collections;
using HttpWebTesting.Enums;
using System;

namespace HttpWebTesting
{
    public class HttpWebTest
    {
        #region -- Test Level Properties -----
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public Guid Id { get; private set; }
        
        public bool StopOnError { get; set; }
        
        public bool SuppressAllCommentsInResults { get; set; }
        #endregion

        #region -- Test Level Collections -----
        public WebTestItemCollection WebTestItems { get; set; }
        
        public ContextCollection ContextProperties { get; set; }
        
        public DataSourceCollection DataSources { get; set; }
        
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

        #region -- public methods -----
        public void Load(string webTestFileName)
        {
            throw new NotImplementedException();
        }

        public void Save(string webTestFileName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
