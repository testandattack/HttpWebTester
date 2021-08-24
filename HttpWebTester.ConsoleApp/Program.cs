using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using HttpWebTesting.SampleTest;
using HttpWebTesting;
using WebTestItemManager;

namespace HttpWebTester
{
    class Program
    {

        static void Main(string[] args)
        {
            // Build and Serialize a webtest
            Sample sample = new Sample();
            HttpWebTestSerializer.SerializeTest(sample.httpWebTest, @"c:\temp\sampleHttpWebTest.json");

            // Make sure the test will deserialize
            HttpWebTest newWebTest = HttpWebTestSerializer.DeserializeTest(@"c:\temp\sampleHttpWebTest.json");
            Console.WriteLine("");
            //ExecuteTests execute = new ExecuteTests();
            //execute.ExecuteTheTests();
        }
    }
}
