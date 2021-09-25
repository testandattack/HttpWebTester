using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using HttpWebTesting.SampleTest;
using HttpWebTesting;
using WebTestItemManager;
using WebTestExecutionEngine;

namespace HttpWebTester
{
    class Program
    {

        static void Main(string[] args)
        {
            //Build and Serialize a webtest
            //Sample sample = new Sample(@"c:\temp\sampleContosoTestFromUI.csv");
            //HttpWebTestSerializer.SerializeAndSaveTest(sample.httpWebTest, @"c:\temp\sampleContosoTestFromUI.json");

            // Make sure the test will deserialize
            HttpWebTest newWebTest = HttpWebTestSerializer.DeserializeTest(@"c:\temp\sampleContosoTestFromUI.json");

            ExecutionEngine execute = new ExecutionEngine(newWebTest);
            execute.ExecuteTheTests();
        }
    }
}
