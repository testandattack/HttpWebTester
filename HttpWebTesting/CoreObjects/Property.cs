using System;

namespace HttpWebTesting.CoreObjects
{
    public class Property : ICloneable
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Type Type { get; set; }

        public Property()
        {
            Name = string.Empty;
            Value = string.Empty;
            Type = typeof(object);
        }

        public Property(string name, string value)
        {
            this.Name = name;
            this.Value = value;
            this.Type = typeof(System.String);
        }

        public Property(string name, string value, Type type)
        {
            this.Name = name;
            this.Value = value;
            this.Type = type;
        }

        private Property(Property copy)
        {
            this.Name = copy.Name;
            this.Value = copy.Value;
            this.Type = copy.Type;
        }

        public object Clone()
        {
            return new Property(this);
        }
    }
}
