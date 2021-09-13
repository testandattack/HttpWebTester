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
using System.Data;
using System.IO;
using GTC.Extensions;
using System.Linq;

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

        public Sample(string csvFileName)
        {
            httpWebTest = new HttpWebTest("Sample Web Test");
            BuildWebtest(csvFileName.Substring(csvFileName.LastIndexOf("\\") + 1));
            CreateAndSavePopulatedDataSource(csvFileName);
        }

        private void BuildWebtest(string CsvFile = "ExampleCsvDataSource.csv")
        {
            // Add a data source
            CsvDataSource cds = new CsvDataSource();
            cds.csvDataSourceFile = CsvFile;
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

        public void CreateAndSavePopulatedDataSource(string fileName)
        {
            DataTable table = CreateCsvData();

            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                List<string> columns = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);
                }
                sw.WriteLine(columns.ToString(","));
                foreach (DataRow row in table.Rows)
                {
                    sw.WriteLine(row.ItemArray.Select(e => e.ToString()).ToList().ToString(","));
                }
            }
        }

        private DataTable CreateCsvData()
        {
            DataTable table = new DataTable();

            table.Columns.Add("StringColumn", typeof(System.String));
            table.Columns.Add("IntColumn", typeof(System.Int32));
            table.Columns.Add("BoolColumn", typeof(System.Boolean));

            table.Rows.Add("Text", 1, true);
            table.Rows.Add("More Text", 2, false);
            table.Rows.Add(string.Empty, 3, true);
            table.Rows.Add("The previous row has an empty string", 4, true);
            return table;
        }
    }
}
