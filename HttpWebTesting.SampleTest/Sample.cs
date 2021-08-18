using System;
using HttpWebTesting;
using HttpWebTesting.Collections;
using HttpWebTesting.CoreObjects;
using HttpWebTesting.DataSources;
using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using HttpWebTesting.WebTestItems;

namespace HttpWebTesting.SampleTest
{
    public class Sample
    {
        public HttpWebTest httpWebTest { get; set; }

        public Sample()
        {
            httpWebTest = new HttpWebTest("Sample Web Test");
            BuildWebtest();
        }

        private void BuildWebtest()
        {
            // Add a data source
            CsvDataSource cds = new CsvDataSource();
            cds.Name = "ExampleCsvDataSource";
            cds.dataSourceCursorType = DataSourceCursorType.Sequential;
            httpWebTest.DataSources.Add(cds);

            // Add a couple of context properties
            Property property = new Property("Context1", "Value1");
            httpWebTest.ContextProperties.Add(property);
            httpWebTest.ContextProperties.Add(new Property("Context2", "Value2"));

            // Add a comment
            httpWebTest.WebTestItems.Add(new WTI_Comment("Sample Comment"));

        }

        private void AddTransactionToSample(string tranName)
        {

        }
    }
}
