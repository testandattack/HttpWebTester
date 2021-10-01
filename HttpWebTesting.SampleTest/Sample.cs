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
            BuildSampleWebtest();
        }

        public Sample(string csvFileName)
        {
            httpWebTest = new HttpWebTest("Sample Web Test");
            //BuildSampleWebtest(csvFileName.Substring(csvFileName.LastIndexOf("\\") + 1));
            //CreateAndSavePopulatedDataSource(csvFileName);
            BuildAwinTest();
        }

        private void BuildAwinTest()
        {
            // set test level properties
            httpWebTest.Description = "Web test for testing the execution engine.";
            httpWebTest.StopOnError = true;
            httpWebTest.SuppressAllCommentsInResults = true;

            // Add a couple of context properties
            Property property = new Property("WebServer1", "dp-awin-api.caerodp-qa.com/v1");
            httpWebTest.ContextProperties.Add(property);
            httpWebTest.ContextProperties.Add(new Property("token", ""));

            var requestItem = ItemManager.CreateNewRequest("https://{{WebServer1}}/help", HttpMethod.Get);
            requestItem.Rules.Add(new ValidateResponseText("\"response\": \"help\""));
            requestItem.ReportingName = "AWIN API: Help";
            requestItem.Headers = CreateAwinHeaders();
            httpWebTest.WebTestItems.Add(requestItem);

            var requestItem2 = ItemManager.CreateNewRequest("https://{{WebServer1}}/version?appkey=testKey", HttpMethod.Get);
            requestItem2.Rules.Add(new ValidateResponseText("\"API Version\": \"1.0.0\""));
            requestItem2.ReportingName = "AWIN API: version";
            requestItem2.Headers = CreateAwinHeaders();
            requestItem2.RequestUri = requestItem2.QueryCollection.AddParametersFromUrl(requestItem2.RequestUri);
            httpWebTest.WebTestItems.Add(requestItem2);

            var requestItem3 = ItemManager.CreateNewRequest("https://{{WebServer1}}/status?appkey=testKey", HttpMethod.Get);
            requestItem3.Rules.Add(new ValidateResponseText("\"traffic_light_indicator\":"));
            requestItem3.ReportingName = "AWIN API: status";
            requestItem3.Headers = CreateAwinHeaders();
            requestItem3.RequestUri = requestItem3.QueryCollection.AddParametersFromUrl(requestItem3.RequestUri);
            httpWebTest.WebTestItems.Add(requestItem3);

            var requestItem4 = ItemManager.CreateNewRequest("https://{{WebServer1}}/aircraft?appkey=testKey", HttpMethod.Get);
            requestItem4.Rules.Add(new ValidateResponseText("\"\": \"\""));
            requestItem4.ReportingName = "AWIN API: aircraft";
            requestItem4.Headers = CreateAwinHeaders();
            requestItem4.RequestUri = requestItem4.QueryCollection.AddParametersFromUrl(requestItem4.RequestUri);
            httpWebTest.WebTestItems.Add(requestItem4);

            var requestItem5 = ItemManager.CreateNewRequest("https://{{WebServer1}}/activity_history?appkey=testKey", HttpMethod.Get);
            requestItem5.Rules.Add(new ValidateResponseText("\"activity_sequence_number\": "));
            requestItem5.ReportingName = "AWIN API: activity history";
            requestItem5.Headers = CreateAwinHeaders();
            requestItem5.RequestUri = requestItem5.QueryCollection.AddParametersFromUrl(requestItem5.RequestUri);
            httpWebTest.WebTestItems.Add(requestItem5);

            var requestItem6 = ItemManager.CreateNewRequest("https://{{WebServer1}}/flight?appkey=testKey&regid=B-6322&begin=2021-08-31&end=2021-09-01", HttpMethod.Get);
            requestItem6.Rules.Add(new ValidateResponseText("\"flight_number\": "));
            requestItem6.ReportingName = "AWIN API: flights";
            requestItem6.Headers = CreateAwinHeaders();
            requestItem6.RequestUri = requestItem6.QueryCollection.AddParametersFromUrl(requestItem6.RequestUri);
            httpWebTest.WebTestItems.Add(requestItem6);

            var requestItem7 = ItemManager.CreateNewRequest("https://{{WebServer1}}/operator-utilization-monthly?appkey=testKey&group=A220&operator=AIR MANAS&begin=2021-08&end=2021-0901", HttpMethod.Get);
            requestItem7.Rules.Add(new ValidateResponseText("\"operator_icao_code\": "));
            requestItem7.ReportingName = "AWIN API: operator utilization monthly";
            requestItem7.Headers = CreateAwinHeaders();
            requestItem7.RequestUri = requestItem7.QueryCollection.AddParametersFromUrl(requestItem7.RequestUri);
            httpWebTest.WebTestItems.Add(requestItem7);

            var requestItem8 = ItemManager.CreateNewRequest("https://{{WebServer1}}/aircraft-group?appkey=testKey", HttpMethod.Get);
            requestItem8.Rules.Add(new ValidateResponseText("\"aircraft_group\": "));
            requestItem8.ReportingName = "AWIN API: aircraft group";
            requestItem8.Headers = CreateAwinHeaders();
            requestItem8.RequestUri = requestItem8.QueryCollection.AddParametersFromUrl(requestItem8.RequestUri);
            httpWebTest.WebTestItems.Add(requestItem8);

            var requestItem9 = ItemManager.CreateNewRequest("https://{{WebServer1}}/operator-by-aircraft-group?appkey=testKey&group=B90", HttpMethod.Get);
            requestItem9.Rules.Add(new ValidateResponseText("\"operator_icao_code\": "));
            requestItem9.ReportingName = "AWIN API: operator by aircraft group";
            requestItem9.Headers = CreateAwinHeaders();
            requestItem9.RequestUri = requestItem9.QueryCollection.AddParametersFromUrl(requestItem9.RequestUri);
            httpWebTest.WebTestItems.Add(requestItem9);

            var requestItem10 = ItemManager.CreateNewRequest("https://{{WebServer1}}/aircraft-utilization-monthly?appkey=testKey&awacid=155506&begin=2021-08&end=2021-09", HttpMethod.Get);
            requestItem10.Rules.Add(new ValidateResponseText("\"aw_ac_id\": \"155506\""));
            requestItem10.ReportingName = "AWIN API: aircraft utilization monthly";
            requestItem10.Headers = CreateAwinHeaders();
            requestItem10.RequestUri = requestItem10.QueryCollection.AddParametersFromUrl(requestItem10.RequestUri);
            httpWebTest.WebTestItems.Add(requestItem10);

            var requestItem11 = ItemManager.CreateNewRequest("https://{{WebServer1}}/aircraft-utilization-monthly?appkey=testKey&awacid=155506&begin=2021-08-01&end=2021-09-01", HttpMethod.Get);
            requestItem11.Rules.Add(new ValidateResponseText("\"aw_ac_id\": \"155506\""));
            requestItem11.ReportingName = "AWIN API: aircraft utilization daily";
            requestItem11.Headers = CreateAwinHeaders();
            requestItem11.RequestUri = requestItem11.QueryCollection.AddParametersFromUrl(requestItem11.RequestUri);
            httpWebTest.WebTestItems.Add(requestItem11);

            var requestItem12 = ItemManager.CreateNewRequest("https://{{WebServer1}}/api/docs", HttpMethod.Get);
            requestItem12.Rules.Add(new ValidateResponseText("x-administrator-emailaddress"));
            requestItem12.ReportingName = "AWIN API: OAS Document";
            requestItem12.Headers = CreateAwinHeaders();
            httpWebTest.WebTestItems.Add(requestItem12);

            // Add test end comments. These are solely for ease of reading the test in the tree view            
            httpWebTest.WebTestItems.Add(new WTI_Comment(""));
            httpWebTest.WebTestItems.Add(new WTI_Comment("-- End of Test Items -----"));
        }

        public Dictionary<string, IEnumerable<string>> CreateAwinHeaders()
        {
            Dictionary<string, IEnumerable<string>> headers = new Dictionary<string, IEnumerable<string>>();
            headers.Add("X-api-key", new string[] { "dp-awin-api-gateway-api-key" });
            headers.Add("Content-Type", new string[] { "application/json" });
            headers.Add("Authorization", new string[] { "Bearer {{token}}" });
            return headers;
        }

        private void BuildSampleWebtest(string CsvFile = "ExampleCsvDataSource.csv")
        {
            // set test level properties
            httpWebTest.Description = "Web test for testing the execution engine.";
            httpWebTest.StopOnError = true;
            httpWebTest.SuppressAllCommentsInResults = true;

            // Add a data source
            CsvDataSource cds = new CsvDataSource();
            cds.csvDataSourceFile = CsvFile;
            cds.Name = "ExampleCsvDataSource";
            cds.dataSourceCursorType = DataSourceCursorType.Sequential;
            httpWebTest.DataSources.Add(cds);

            // Add a couple of context properties
            Property property = new Property("WebServer1", "localhost:5000");
            httpWebTest.ContextProperties.Add(property);
            httpWebTest.ContextProperties.Add(new Property("MaxCreatedId", 25));
            //httpWebTest.ContextProperties.Add(new Property("Password", "P@ssw0rd", true));
            httpWebTest.Rules.Add(new ValidateSuccessStatusCode());

            // Add a comment
            httpWebTest.WebTestItems.Add(new WTI_Comment("Root Level Request"));

            // Add a request
            var newHeaders = ItemManager.CreateApiHeaders();
            var requestItem = ItemManager.CreateNewRequest("http://{{WebServer1}}/api/contoso/{{ExampleCsvDataSource.IntColumn}}", HttpMethod.Get, newHeaders);
            requestItem.Rules.Add(new ValidateResponseText("Original ContosoModel"));
            httpWebTest.WebTestItems.Add(requestItem);

            // Add a spacer comment
            httpWebTest.WebTestItems.Add(new WTI_Comment(""));

            // Add a comment
            httpWebTest.WebTestItems.Add(new WTI_Comment("Sample Transaction"));

            // Add a transaction with some requests
            var trans =  ItemManager.CreateNewTransaction("Crud Stuff", "Calling CRUD operations on the Contoso model");
            trans.webTestItems.Add(new WTI_Comment("Create a new item and extract the Id from the call"));
            var request1 = ItemManager.CreateNewJsonPostRequest("http://{{WebServer1}}/api/contoso", "{\"Description\": \"Third ContosoModel\"}");
            request1.Rules.Add(new ExtractCreationId("CreatedId"));
            request1.Rules.Add(new ValidateStatusCodeValue(System.Net.HttpStatusCode.Created));
            trans.webTestItems.Add(request1);
            trans.webTestItems.Add(ItemManager.CreateNewRequest("http://{{WebServer1}}/api/contoso", HttpMethod.Get));
            trans.webTestItems.Add(ItemManager.CreateNewRequest("http://{{WebServer1}}/api/contoso/{{CreatedId}}", HttpMethod.Get));
            trans.webTestItems.Add(ItemManager.CreateNewJsonPutRequest("http://{{WebServer1}}/api/contoso", "{\"Id\": {{CreatedId}},\"Description\": \"Updated ContosoModel\"}"));
            trans.webTestItems.Add(ItemManager.CreateNewRequest("http://{{WebServer1}}/api/contoso/{{CreatedId}}", HttpMethod.Delete));
            httpWebTest.WebTestItems.Add(trans);

            // Add a spacer comment
            httpWebTest.WebTestItems.Add(new WTI_Comment(""));

            // Create a couple of items to add to a loop control
            var request2 = ItemManager.CreateNewJsonPostRequest("http://{{WebServer1}}/api/contoso", "{\"Description\": \"Random ContosoModel\"}");
            request2.Rules.Add(new ExtractCreationId("CreatedId"));
            request2.Rules.Add(new ValidateStatusCodeValue(System.Net.HttpStatusCode.Created));
            var ifLoop = ItemManager.CreateNew_IF_LoopControl(new RuleProperty("{{CreatedId}}"), ComparisonType.IsLessThan, new RuleProperty("{{MaxCreatedId}}"));
            ifLoop.webTestItems.Add(ItemManager.CreateNewRequest("http://{{WebServer1}}/api/contoso/{{CreatedId}}", HttpMethod.Get));

            // Add a Loop Control and add the above items to it
            var forLoop = ItemManager.CreateNew_FOR_LoopControl(1, 5, 2);
            forLoop.webTestItems.Add(request2);
            forLoop.webTestItems.Add(ItemManager.CreateNewRequest("http://{{WebServer1}}/api/contoso", HttpMethod.Get));
            forLoop.webTestItems.Add(ifLoop);
            forLoop.webTestItems.Add(ItemManager.CreateNewJsonPutRequest("http://{{WebServer1}}/api/contoso", "{\"Id\": {{CreatedId}},\"Description\": \"Updated ContosoModel\"}"));
            forLoop.webTestItems.Add(ItemManager.CreateNewRequest("http://{{WebServer1}}/api/contoso/{{CreatedId}}", HttpMethod.Delete));
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
