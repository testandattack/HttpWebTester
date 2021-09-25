using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using GTC.Extensions;

namespace WebTestExecutionEngine
{
    public static class CsvDataSourceLoader
    {
        public static DataTable LoadDataSource(string fileLocation)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(fileLocation))
            {
                dt.Columns.AddRange(GetHeaders(sr.ReadLine()));
                while(sr.Peek() != -1)
                {
                    string csvRow = sr.ReadLine();
                    dt.Rows.Add(csvRow.CsvStrToList().ToArray());                    
                }
            }
            return dt;
        }

        private static DataColumn[] GetHeaders(string headerRow)
        {
            var items = headerRow.CsvStrToList();
            List<DataColumn> columns = new List<DataColumn>();
            foreach(string header in items)
            {
                columns.Add(new DataColumn(header, typeof(System.String)));
            }
            return columns.ToArray();
        }
    }
}
