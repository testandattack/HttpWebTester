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
using HttpWebTesting.Rules;

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
            httpWebTest.ContextProperties.Add(new Property("MaxCreatedId", "25"));
            httpWebTest.Rules.Add(new ValidateSuccessStatusCode());

            // Add a comment
            httpWebTest.WebTestItems.Add(new WTI_Comment("Sample Comment"));

            // Add a transaction with some requests
            var trans =  ItemManager.CreateNewTransaction("Crud Stuff", "Calling CRUD operations on the Contoso model");
            trans.webTestItems.Add(new WTI_Comment("Create a new item and extract the Id from the call"));
            var request1 = ItemManager.CreateNewJsonPostRequest("http://localhost:5000/api/contoso", "{\"Description\": \"Third ContosoModel\"}");
            request1.Rules.Add(new ExtractCreationId("CreatedId"));
            request1.Rules.Add(new ValidateStatusCodeValue(System.Net.HttpStatusCode.Created));
            trans.webTestItems.Add(request1);
            trans.webTestItems.Add(ItemManager.CreateNewRequest("http://localhost:5000/api/contoso", HttpMethod.Get));
            trans.webTestItems.Add(ItemManager.CreateNewRequest("http://localhost:5000/api/contoso/{{CreatedId}}", HttpMethod.Get));
            trans.webTestItems.Add(ItemManager.CreateNewJsonPutRequest("http://localhost:5000/api/contoso", "{\"Id\": {{CreatedId}},\"Description\": \"Updated ContosoModel\"}"));
            trans.webTestItems.Add(ItemManager.CreateNewRequest("http://localhost:5000/api/contoso/{{CreatedId}}", HttpMethod.Delete));
            httpWebTest.WebTestItems.Add(trans);

            // Add a spacer comment
            httpWebTest.WebTestItems.Add(new WTI_Comment(""));

            // Create a couple of items to add to a loop control
            var request2 = ItemManager.CreateNewJsonPostRequest("http://localhost:5000/api/contoso", "{\"Description\": \"Third ContosoModel\"}");
            request2.Rules.Add(new ExtractCreationId("CreatedId"));
            request2.Rules.Add(new ValidateStatusCodeValue(System.Net.HttpStatusCode.Created));
            var ifLoop = ItemManager.CreateNew_IF_LoopControl(new RuleProperty("{{CreatedId}}"), ComparisonType.IsLessThan, new RuleProperty("{{MaxCreatedId}}"));
            ifLoop.webTestItems.Add(ItemManager.CreateNewRequest("http://localhost:5000/api/contoso/{{CreatedId}}", HttpMethod.Get));

            // Add a Loop Control and add the above items to it
            var forLoop = ItemManager.CreateNew_FOR_LoopControl(1, 5, 2);
            forLoop.webTestItems.Add(request2);
            forLoop.webTestItems.Add(ItemManager.CreateNewRequest("http://localhost:5000/api/contoso", HttpMethod.Get));
            forLoop.webTestItems.Add(ifLoop);
            forLoop.webTestItems.Add(ItemManager.CreateNewJsonPutRequest("http://localhost:5000/api/contoso", "{\"Id\": {{CreatedId}},\"Description\": \"Updated ContosoModel\"}"));
            forLoop.webTestItems.Add(ItemManager.CreateNewRequest("http://localhost:5000/api/contoso/{{CreatedId}}", HttpMethod.Delete));
            httpWebTest.WebTestItems.Add(forLoop);

            // Add test end comments. These are solely for ease of reading the test in the tree view            
            httpWebTest.WebTestItems.Add(new WTI_Comment(""));
            httpWebTest.WebTestItems.Add(new WTI_Comment("-- End of Test Items -----"));
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
