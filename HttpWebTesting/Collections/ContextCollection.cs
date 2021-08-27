using HttpWebTesting.CoreObjects;

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
    }
}
