using HttpWebTesting.CoreObjects;
using System;
using System.Collections.Generic;

namespace HttpWebTesting.Collections
{
    public class PropertyCollection : BaseCollection<Property>
    {
        public void Add(string propertyName, string propertyValue)
        {
            base.Add(new Property(propertyName, propertyValue));
        }

        public void Add(string propertyName, string propertyValue, Type type)
        {
            base.Add(new Property(propertyName, propertyValue, type));
        }

        public void Add(string propertyName, object propertyValue, Type type)
        {
            base.Add(new Property(propertyName, propertyValue));
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public void AddKeyValuePairs(Dictionary<string, string> dictionary)
        {
            foreach(var pair in dictionary)
            {
                base.Add(new Property(pair.Key, pair.Value));
            }
        }

        public void AddKeyValuePairs(Dictionary<string, object> dictionary)
        {
            foreach (var pair in dictionary)
            {
                base.Add(new Property(pair.Key, pair.Value));
            }
        }
    }
}
