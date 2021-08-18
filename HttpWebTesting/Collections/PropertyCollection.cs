using HttpWebTesting.CoreObjects;

namespace HttpWebTesting.Collections
{
    public class PropertyCollection : BaseCollection<Property>
    {
        public void Add(string propertyName, string propertyValue)
        {
            base.Add(new Property(propertyName, propertyValue));
        }

        public string this[string propertyName]
        {
            get
            {
                foreach(Property property in this)
                {
                    if(property.Name == propertyName)
                    {
                        return property.Value;
                    }
                }
                return null;
            }
            set
            {
                foreach (Property property in this)
                {
                    if (property.Name == propertyName)
                    {
                        property.Value = value;
                        return;
                    }
                }
                base.Add(new Property(propertyName, value));
            }
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }
}
