using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HttpWebTesting.CoreObjects
{
    public class PropertyDisplayInfo
    {
        public string DisplayName { get; private set; }
        
        public string Description { get; private set; }
        
        public string Category { get; private set; }

        public object DefaultValue { get; private set; }

        public Type type { get; private set; }

        public PropertyDisplayInfo(IEnumerable<Attribute> attributes)
        {
            DisplayName = "";
            Description = "";
            Category = "";
            DefaultValue = null;
            SetAttributeValues(attributes);
        }

        public void SetAttributeValues(IEnumerable<Attribute> attributes)
        {
            foreach(var attribute in attributes)
            {
                if(attribute.GetType() == typeof(DisplayNameAttribute))
                {
                    DisplayName = ((DisplayNameAttribute)attribute).DisplayName;
                }
                else if (attribute.GetType() == typeof(DescriptionAttribute))
                {
                    Description = ((DescriptionAttribute)attribute).Description;
                }
                else if (attribute.GetType() == typeof(CategoryAttribute))
                {
                    Category = ((CategoryAttribute)attribute).Category;
                }
                else if (attribute.GetType() == typeof(DefaultValueAttribute))
                {
                    DefaultValue = ((DefaultValueAttribute)attribute).Value;
                }

            }
        }

        public void SetType(Type itemType)
        {
            type = itemType;
        }
    }
}
