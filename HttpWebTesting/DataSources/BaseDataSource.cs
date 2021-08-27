using HttpWebTesting.Collections;
using HttpWebTesting.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HttpWebTesting.DataSources
{
    public abstract class BaseDataSource : ICloneable
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public DataSourceType dataSourceType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DataSourceCursorType dataSourceCursorType { get; set; }
        
        /// <summary>
        /// The collection of Key/Value pairs for the current "row" of data
        /// </summary>
        public PropertyCollection currentDataProperties { get; set; }


        protected BaseDataSource() { }

        protected BaseDataSource(BaseDataSource copy)
        {
            this.Name = copy.Name;
            this.Description = copy.Description;
            this.dataSourceType = copy.dataSourceType;
            this.dataSourceCursorType = copy.dataSourceCursorType;
            
            if (copy.currentDataProperties != null)
                this.currentDataProperties = copy.currentDataProperties;
        }

        public abstract object Clone();
    }
}
