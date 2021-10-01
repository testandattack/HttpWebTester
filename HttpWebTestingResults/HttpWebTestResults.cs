using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Serilog;
using GTC.Extensions;
using HttpWebTesting;
using System.Data;

namespace HttpWebTestingResults
{
    public class HttpWebTestResults
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string TestAgent { get; set; }

        public DateTime executionTime { get; set; }

        public bool ContainsFailedExecutionItem = false;

        [JsonProperty(PropertyName = "TestResultsItems")]
        public WebTestResultsItemCollection webTestResultsItems { get; set; }

        [JsonProperty(PropertyName = "Original Web Test")]
        public HttpWebTest originalWebTest { get; set; }

        private char corner = (char)0xc0;


        public HttpWebTestResults()
        {
            webTestResultsItems = new WebTestResultsItemCollection();
            executionTime = DateTime.UtcNow;
            // Results design still under construction
            //throw new NotImplementedException();
        }

        public void SaveTestResults(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                sw.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
                Log.ForContext<HttpWebTestResults>().Information("aved Test results to {fileName}");
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);//base.ToString();
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine($"Results for test '{Name}'");
        //    sb.AppendLine($"Executed on {executionTime.ToString()}");
        //    foreach(var item in webTestResultsItems)
        //    {
        //        sb.Append(item.ToString());
        //    }

        //    return sb.ToString();
        //}


        public DataTable GetResultsAsTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Item Type", typeof(System.String)));
            dt.Columns.Add(new DataColumn("Result", typeof(System.String)));
            dt.Columns.Add(new DataColumn("Method", typeof(System.String)));
            dt.Columns.Add(new DataColumn("Item", typeof(System.String)));
            dt.Columns.Add(new DataColumn("Duration", typeof(System.String)));

            ParseResultsToTable(webTestResultsItems, dt, GetPrecursorString(""));
            return dt;
        }

        private void ParseResultsToTable(WebTestResultsItemCollection items, DataTable table, string precursor)
        {
            foreach(var item in items)
            {
                if(item.objectItemType == WebTestResultItemType.Wtri_CommentItem)
                {
                    table.Rows.Add($"{precursor} Comment", "N/A", "", "", "");
                }
                else if (item.objectItemType == WebTestResultItemType.Wtri_IncludedWebTestItem)
                {
                    throw new NotImplementedException("Not yet parsing inherited Web Test Results");
                }
                else if (item.objectItemType == WebTestResultItemType.Wtri_LoopControlItem)
                {
                    var result = item as WTRI_LoopControl;
                    foreach(var iteration in result.loopIterations)
                    {
                        table.Rows.Add($"{precursor} LoopControl", (!result.ItemExecutionFailed).ToString(), "", iteration, result.totalElapsedTime.ToString());
                        ParseResultsToTable(result.loopResultsItems.loopResultsItems[iteration], table, GetPrecursorString(precursor));
                    }
                }
                else if (item.objectItemType == WebTestResultItemType.Wtri_RequestObject)
                {
                    var result = item as WTRI_Request;
                    table.Rows.Add($"{precursor} Request", (!result.ItemExecutionFailed).ToString(), result.response.RequestMessage.Method, result.response.RequestMessage.RequestUri.AbsoluteUri, result.ResponseTime.ToString());
                }
                else if (item.objectItemType == WebTestResultItemType.Wtri_SkippedItem)
                {
                    continue;
                }
                else if (item.objectItemType == WebTestResultItemType.Wtri_TransactionItem)
                {
                    var result = item as WTRI_Transaction;
                    table.Rows.Add($"{precursor} Transaction", (!result.ItemExecutionFailed).ToString(), "", "", result.totalElapsedTime.ToString());
                    ParseResultsToTable(result.webTestResultsItems, table, GetPrecursorString(precursor));
                }
            }
        }

        private string GetPrecursorString(string previousPrecursor)
        {
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < previousPrecursor.Length; x++)
                sb.Append(" ");
            sb.Append($"    ");
            return sb.ToString();
        }
    }
}
