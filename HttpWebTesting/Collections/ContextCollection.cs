using HttpWebTesting.CoreObjects;
using System.Collections.Generic;
using System.Linq;

namespace HttpWebTesting.Collections
{
    public class ContextCollection : BaseCollection<Property>
    {
        public void Add(string propertyName, string propertyValue)
        {
            base.Add(new Property(propertyName, propertyValue));
        }

        public string this[string propertyName]
        {
            get
            {
                foreach (Property contextProperty in this)
                {
                    if (contextProperty.Name == propertyName)
                    {
                        return contextProperty.Value;
                    }
                }
                return null;
            }
            set
            {
                foreach (Property contextProperty in this)
                {
                    if (contextProperty.Name == propertyName)
                    {
                        contextProperty.Value = value;
                        return;
                    }
                }
                base.Add(new Property(propertyName, value));
            }
        }

        /// <summary>
        /// This method is used to add or update context values that
        /// are derived from data sources.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="DataSourceName"></param>
        public void AddDataSourceRow(Dictionary<string, string> values, string DataSourceName)
        {
            foreach(var kvp in values)
            {
                string contextName = $"{DataSourceName}.{kvp.Key}";
                var prop = this.Where(p => p.Name == contextName).FirstOrDefault();
                if (prop == null)
                    base.Add(new Property(contextName, kvp.Value));
                else
                    prop.Value = kvp.Value;
            }
        }

        public string GetValue(string contextName)
        {
            foreach(Property property in base.Items)
            {
                if (property.Name == contextName)
                    return property.Value;
            }
            return string.Empty;
        }

    }
}
