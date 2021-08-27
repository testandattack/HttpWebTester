using HttpWebTesting;
using HttpWebTestingResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestExecutionEngine
{
    public class BaseExecution
    {
        public HttpWebTest httpWebTest { get; set; }

        public WebTestResultsItem ExecutionResults { get; set; }
    }
}
