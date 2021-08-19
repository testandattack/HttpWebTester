using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using HttpWebTesting.SampleTest;
using HttpWebTesting;

namespace HttpWebTester
{
    class Program
    {

        static void Main(string[] args)
        {
            Sample sample = new Sample();
            HttpWebTestSerializer.SerializeTest(sample.httpWebTest, @"c:\temp\sampleHttpWebTest.json");
        }
    }
}
