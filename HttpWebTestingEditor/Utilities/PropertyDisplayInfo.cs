using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace HttpWebTestingEditor
{
    public class PropertyDisplayInfo
    {
        public bool Browsable { get; private set; }

        public bool JsonIgnore { get; private set; }

        public string DisplayName { get; private set; }
        
        public string Description { get; private set; }
        
        public string Category { get; private set; }

        public object DefaultValue { get; private set; }

        public Type type { get; private set; }

        public List<string> unknownCustomAttributes { get; private set; }

        public PropertyDisplayInfo(PropertyInfo prop)
        {
            Browsable = true;
            JsonIgnore = false;
            DisplayName = "";
            Description = "";
            Category = "";
            DefaultValue = null;
            unknownCustomAttributes = new List<string>();
            GetPropertyValues(prop);
        }

        private void GetPropertyValues(PropertyInfo prop)
        {
            var customProps = prop.GetCustomAttributesData();
            if (customProps != null && customProps.Count > 0)
            {
                SetAttributeValues(customProps);
            }
            else
            {
                SetAttributeValues(prop);
            }
            SetType(prop.PropertyType);
        }

        private void SetAttributeValues(IList<CustomAttributeData> attributes)
        {
            foreach (var attribute in attributes)
            {
                if (attribute.AttributeType.Name == "BrowsableAttribute")
                {
                    Browsable = (bool)attribute.ConstructorArguments[0].Value;
                }
                else if(attribute.AttributeType.Name == "DisplayNameAttribute")
                {
                    DisplayName = (string)attribute.ConstructorArguments[0].Value;
                }
                else if (attribute.AttributeType.Name == "DescriptionAttribute")
                {
                    Description = (string)attribute.ConstructorArguments[0].Value;
                }
                else if (attribute.AttributeType.Name == "CategoryAttribute")
                {
                    Category = (string)attribute.ConstructorArguments[0].Value;
                }
                else if (attribute.AttributeType.Name == "DefaultValueAttribute")
                {
                    DefaultValue = attribute.ConstructorArguments[0].Value;
                }
                else if (attribute.AttributeType.Name == "JsonIgnoreAttribute")
                {
                    JsonIgnore = true;
                }
                else
                {
                    unknownCustomAttributes.Add(attribute.AttributeType.Name);
                }
            }
        }

        private void SetAttributeValues(PropertyInfo prop)
        {
            DisplayName = prop.Name;
        }

        private void SetType(Type itemType)
        {
            type = itemType;
        }
    }
}
