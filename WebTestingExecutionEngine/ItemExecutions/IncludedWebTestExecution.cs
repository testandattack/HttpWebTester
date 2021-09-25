using HttpWebTesting;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
using System;
using System.Threading.Tasks;

namespace WebTestExecutionEngine
{
    public class IncludedWebTestExecution
    {
        public HttpWebTest httpWebTest { get; set; }

        public WTI_IncludedWebTest includedWebTest { get; set; }
        public bool inheritParentTestSettings { get; set; }

        public IncludedWebTestExecution(WTI_IncludedWebTest iWT, HttpWebTest webTest) 
        {
            includedWebTest = iWT;
            inheritParentTestSettings = includedWebTest.InheritParentSettings;
            httpWebTest = webTest;
        }

        public async Task<WebTestResultsItem> ProcessIncludedWebTest()
        {
            WTRI_IncludedWebTest includedWebTestResults = new WTRI_IncludedWebTest(includedWebTest.guid);
            throw new NotImplementedException("We ain't quite ready for this yet... But we'll get there soon.");
        }

    }
}
