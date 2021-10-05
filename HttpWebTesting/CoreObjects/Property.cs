using System;

namespace HttpWebTesting.CoreObjects
{
    public class Property : ICloneable
    {
        #region -- Properties -----
        public string Name { get; set; }
        public object Value
        {
            get
            {
                if (this.IsPassword)
                    return (_value as Password).pwdValue;
                else
                    return this._value;
            }
            set
            {
                if (this.IsPassword)
                    this._value = new Password(value.ToString());
                else
                    this._value = value;
            }
        }
        private object _value;

        public Type Type { get; set; }
        public bool IsPassword { get; set; }
        #endregion

        #region -- Constructors -----
        public Property()
        {
            Name = string.Empty;
            Value = string.Empty;
            Type = typeof(object);
            IsPassword = false;
        }

        public Property(string name, string value)
        {
            this.Name = name;
            this.Value = value;
            this.Type = typeof(System.String);
            IsPassword = false;
        }

        public Property(string name, object value)
        {
            this.Name = name;
            this.Value = value.ToString();
            this.Type = value.GetType();
            IsPassword = false;
        }

        public Property(string name, string value, Type type)
        {
            this.Name = name;
            this.Value = value;
            this.Type = type;
            IsPassword = false;
        }

        public Property(string name, string value, bool isPassword)
        {
            IsPassword = isPassword;
            this.Name = name;
            this.Value = new Password(value);
            this.Type = typeof(Password);
        }

        public Property(string name, string value, Type type, bool isPassword)
        {
            IsPassword = isPassword;
            this.Name = name;
            this.Value = value;
            this.Type = type;
        }
        #endregion

        #region -- ICloneable  methods -----
        private Property(Property copy)
        {
            this.Name = copy.Name;
            this.Value = copy.Value;
            this.Type = copy.Type;
            this.IsPassword = copy.IsPassword;
        }

        public object Clone()
        {
            return new Property(this);
        }
        #endregion

        public string GetPwdValue()
        {
            if (this.IsPassword)
                return (_value as Password).GetPwd();
            else
                return _value.ToString();
        }

        //public bool ShouldSerializeValue()
        //{
        //    // Serialize the value property if it is NOT a password.
        //    return !IsPassword;
        //}
    }

    internal class Password
    {
        internal string pwdValue
        {
            get
            {
                return "********";
            }
            set
            {
                _pwdValue = value;
            }
        }
        private string _pwdValue;

        #region -- Constructors -----
        internal Password() { }

        internal Password(string value)
        {
            _pwdValue = value;
        }
        #endregion

        internal string GetPwd()
        {
            return _pwdValue;
        }


    }
}
