using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    /// <summary>
    /// Generic class to handle Json objects that are of type "oneOf" where
    /// the choices are "String", "Integer", or null.
    /// </summary>
    public class StringOrNumber
    {
        public string StringValue { get; set; }
        
        public Int32? NumberValue { get; set; }
    }
}
