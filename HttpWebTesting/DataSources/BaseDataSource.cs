using HttpWebTesting.Collections;
using HttpWebTesting.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;

namespace HttpWebTesting.DataSources
{
    /// <summary>
    /// Data Sources will read data from a defined backing store and 
    /// load it into a DataTable. It stores the entire data set and keeps
    /// a pointer to the current data record being used. Any data for the
    /// test to consume is loaded properly into the <see cref="ContextCollection"/>
    /// for the test.
    /// </summary>
    /// <remarks>
    /// The reason for this design is to allow a Data Source to 
    /// (eventually) be shared among multiple instances of a webtest. This
    /// functionality will be added as part of a future Feature for Load 
    /// Testing.
    /// </remarks>
    public abstract class BaseDataSource : ICloneable
    {
        /// <summary>
        /// The Name of the data source.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// A brief description of the data source
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The type of data source (ADO.NET or CSV File, etc.)
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DataSourceType dataSourceType { get; set; }

        /// <summary>
        /// Represents how the test engine should walk through
        /// the data each time it advances the cursor.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DataSourceCursorType dataSourceCursorType { get; set; }

        /// <summary>
        /// This flag is used to signal the test engine that the
        /// data source ran out of data to use.
        /// </summary>
        /// <remarks>
        /// The only time thos flag will be true is if
        /// <list type="bullet">
        /// <item>The <see cref="DataSourceCursorType"/> is set to "Unique"</item>
        /// <item>AND the data source has already run through every item in the data.</item>
        /// </list>
        /// </remarks>
        public bool endOfDataSetReached = false;

        /// <summary>
        /// The table that holds all of the data for the test.
        /// </summary>
        public DataTable dataTable { get; set; }

        protected BaseDataSource() { }

        protected int currentIndex = 0;

        protected BaseDataSource(BaseDataSource copy)
        {
            this.Name = copy.Name;
            this.Description = copy.Description;
            this.dataSourceType = copy.dataSourceType;
            this.dataSourceCursorType = copy.dataSourceCursorType;
            this.currentIndex = copy.currentIndex;
            
            if(copy.dataTable != null)
                this.dataTable = copy.dataTable.Copy();            
        }

        public abstract object Clone();

        /// <summary>
        /// This method retrieves the next row of data (based on the 
        /// cursor type) and updates the <see cref="ContextCollection"/>
        /// with the values. It also updates the <see cref="currentIndex"/>
        /// value.
        /// </summary>
        /// <param name="properties"></param>
        public void GetNextRow(ContextCollection properties)
        {
            Dictionary<string, string> dataRow = DataSourceValueRetrieval
                .GetNextValueSet(dataSourceCursorType, dataTable, ref currentIndex);
            
            if (dataRow == null && currentIndex == -1)
            {
                endOfDataSetReached = true;
                return;
            }

            properties.AddDataSourceRow(dataRow, Name);
        }
    }
}
