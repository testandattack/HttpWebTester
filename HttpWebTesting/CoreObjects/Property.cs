using System;

namespace HttpWebTesting.CoreObjects
{
    public class Property : ICloneable
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Property()
        {
            Name = string.Empty;
            Value = string.Empty;
        }

        private Property(Property copy)
        {
            this.Name = copy.Name;
            this.Value = copy.Value;
        }

        public Property(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public object Clone()
        {
            return new Property(this);
        }
    }
}
