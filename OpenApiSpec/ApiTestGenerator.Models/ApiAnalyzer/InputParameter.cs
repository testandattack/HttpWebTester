using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiTestGenerator.Models.ApiAnalyzer
{
    /// <summary>
    /// 
    /// </summary>
    public class InputParameter
    {
        #region -- Properties -----
        /// <summary>
        /// The name of the item
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The <see cref="http://spec.openapis.org/oas/v3.0.3#data-types">OpenApi defined Type</see> 
        /// of the property.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The description of the parameter
        /// </summary>
        /// <remarks>The text that shows up in the Description 
        /// is any text added through XML Comments to the parameter 
        /// in the API code</remarks>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// A string pointing to another object to be referenced.
        /// <see cref="http://spec.openapis.org/oas/v3.0.3#fixed-fields-18"/> 
        /// for more information.
        /// </summary>
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }

        /// <summary>
        /// If array is of an OpenApi primitive type, this field describes the
        /// format of the type contained in the array.
        /// </summary>
        /// <remarks>
        /// Primitives have an optional modifier property: format. OAS uses several known formats 
        /// to define in fine detail the data type being used. However, to support documentation 
        /// needs, the format property is an open string-valued property, and can have any value. 
        /// Formats such as "email", "uuid", and so on, MAY be used even though undefined by this 
        /// specification. Types that are not accompanied by a format property follow the type 
        /// definition in the JSON Schema. Tools that do not recognize a specific format MAY default 
        /// back to the type alone, as if the format is not specified.
        /// </remarks>
        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }

        /// <summary>
        /// True if the parameter is an array of items
        /// </summary>
        public bool IsArray { get; set; }

        /// <summary>
        /// If <see cref="IsArray"/> = true, this tells the type of items in the array
        /// </summary>
        /// <remarks>
        /// Primitive data types in the OAS are based on the types supported by the JSON Schema 
        /// Specification Wright Draft 00. Note that integer as a type is also supported and is 
        /// defined as a JSON number without a fraction or exponent part. null is not supported 
        /// as a type (see nullable for an alternative solution). Models are defined using the 
        /// Schema Object, which is an extended subset of JSON Schema Specification Wright Draft 00.
        /// </remarks>
        public string arrayType { get; set; }

        /// <summary>
        /// If array is of an OpenApi primitive type, this field describes the
        /// format of the type contained in the array.
        /// </summary>
        /// <remarks>
        /// Primitives have an optional modifier property: format. OAS uses several known formats 
        /// to define in fine detail the data type being used. However, to support documentation 
        /// needs, the format property is an open string-valued property, and can have any value. 
        /// Formats such as "email", "uuid", and so on, MAY be used even though undefined by this 
        /// specification. Types that are not accompanied by a format property follow the type 
        /// definition in the JSON Schema. Tools that do not recognize a specific format MAY default 
        /// back to the type alone, as if the format is not specified.
        /// </remarks>
        public string arrayFormat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string InputProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> NameVariations { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public List<string> MatchesTheseComponents { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> UsedByTheseEndpoints { get; set; }
        #endregion

        #region -- Constructors -----
        /// <summary>
        /// 
        /// </summary>
        public InputParameter()
        {
            Name = string.Empty;
            Type = string.Empty;
            IsArray = false;
            arrayType = string.Empty;
            Format = string.Empty;
            Required = false;
            InputProvider = string.Empty;

            MatchesTheseComponents = new List<string>();
            UsedByTheseEndpoints = new List<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <param name="isArray"></param>
        /// <param name="ArrayType"></param>
        /// <param name="format"></param>
        /// <param name="required"></param>
        /// <param name="inputProvider"></param>
        public InputParameter(string name, string description, string type, bool isArray,
            string ArrayType, string format, bool required, string inputProvider)
        {
            Name = name;
            Type = type;
            IsArray = isArray;
            arrayType = ArrayType;
            Format = format;
            Required = required;
            InputProvider = inputProvider;

            MatchesTheseComponents = new List<string>();
            UsedByTheseEndpoints = new List<string>();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 19;
            hash = hash * 31 + Name.ToUpper().GetHashCode();
            hash = hash * 31 + IsArray.GetHashCode();
            hash = hash * 31 + Type.GetHashCode();
            hash = hash * 31 + Required.GetHashCode();
            return hash;
        }
    }
}
