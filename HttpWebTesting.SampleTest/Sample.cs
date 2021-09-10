using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using HttpWebTesting;
using HttpWebTesting.Collections;
using HttpWebTesting.CoreObjects;
using HttpWebTesting.DataSources;
using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using WebTestRules;
using WebTestItemManager;

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
            cds.csvDataSourceFile = @"ExampleCsvDataSource.csv";
            cds.Name = "ExampleCsvDataSource";
            cds.dataSourceCursorType = DataSourceCursorType.Sequential;
            httpWebTest.DataSources.Add(cds);

            // Add a couple of context properties
            Property property = new Property("Context1", "Value1");
            httpWebTest.ContextProperties.Add(property);
            httpWebTest.ContextProperties.Add(new Property("Context2", "Value2"));

            var trans =  ItemManager.CreateNewTransaction("Crud Stuff", "Calling CRUD operations on the Contoso model");
            var request1 = ItemManager.CreateNewJsonPostRequest("http://localhost:5000/api/contoso", "{\"Description\": \"Third ContosoModel\"}");
            request1.Rules.Add(new ExtractCreationId("CreatedId"));
            trans.webTestItems.Add(request1);

            trans.webTestItems.Add(ItemManager.CreateNewRequest("http://localhost:5000/api/contoso", HttpMethod.Get));
            trans.webTestItems.Add(ItemManager.CreateNewRequest("http://localhost:5000/api/contoso/{{CreatedId}}", HttpMethod.Get));
            trans.webTestItems.Add(ItemManager.CreateNewJsonPutRequest("http://localhost:5000/api/contoso", "{\"Id\": {{CreatedId}},\"Description\": \"Updated ContosoModel\"}"));
            trans.webTestItems.Add(ItemManager.CreateNewRequest("http://localhost:5000/api/contoso/{{CreatedId}}", HttpMethod.Delete));

            httpWebTest.WebTestItems.Add(trans);

        }
    }
}
