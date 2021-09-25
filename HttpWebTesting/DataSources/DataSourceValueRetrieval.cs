using HttpWebTesting.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HttpWebTesting.DataSources
{
    /// <summary>
    /// This class manages retrieving the next row of data from any data source passed in.
    /// </summary>
    /// <remarks>
    /// Since all data sources eventually load data into a <see cref="DataTable"/>, we can 
    /// use the same methods safely with all data sources.
    /// </remarks>
    public static class DataSourceValueRetrieval
    {
        public static Dictionary<string, string> GetNextValueSet(DataSourceCursorType cursorType, DataTable data, ref int currentIndex)
        {
            if (cursorType == DataSourceCursorType.Sequential)
                return GetNextSequentialItem(data, ref currentIndex);
            else if (cursorType == DataSourceCursorType.Unique)
                return GetNextUniqueItem(data, ref currentIndex);
            else
                return GetNextRandomItem(data);
        }

        private static Dictionary<string, string> GetNextSequentialItem(DataTable data, ref int currentIndex)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            if (currentIndex >= data.Rows.Count)
                throw new IndexOutOfRangeException("The datasource index passed in was larger than the dataset itself.");
            // if we are at the end, wrap around
            else if (currentIndex == data.Rows.Count - 1)
                currentIndex = 0;
            // not at the end, so advance the cursor
            else
                currentIndex++;

            // Now get the values
            foreach (DataColumn column in data.Columns)
            {
                values.Add(column.ColumnName, data.Rows[currentIndex][column].ToString());
            }
            return values;
        }

        private static Dictionary<string, string> GetNextUniqueItem(DataTable data, ref int currentIndex)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            if (currentIndex >= data.Rows.Count)
                throw new IndexOutOfRangeException("The datasource index passed in was larger than the dataset itself.");
            // if we are at the end, wrap around
            else if (currentIndex == data.Rows.Count - 1)
            {
                currentIndex = -1;
                return null;
            }
            // not at the end, so advance the cursor
            else
                currentIndex++;

            // Now get the values
            foreach (DataColumn column in data.Columns)
            {
                values.Add(column.ColumnName, data.Rows[currentIndex][column].ToString());
            }
            return values;
        }

        private static Dictionary<string, string> GetNextRandomItem(DataTable data)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            Random rnd = new Random();
            int iIndex = rnd.Next(0, data.Rows.Count - 1);


            // Now get the values
            foreach (DataColumn column in data.Columns)
            {
                values.Add(column.ColumnName, data.Rows[iIndex][column].ToString());
            }
            return values;
        }
    }
}
