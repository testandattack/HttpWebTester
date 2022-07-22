using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// An object the contains information about input parameters for OpenApi endpoint calls
    /// It is based on the <see href="https://spec.openapis.org/oas/v3.0.0#parameter-object"/> OAS object.
    /// </summary>
    public class Parameter : IComparable
    {
        #region -- properties -----
        #region -- Items that also show up in the Property object -----
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
        /// A list of <see cref="CustomOasObjectCollection"/> items that may be added to the parameter.
        /// </summary>
        public CustomOasObjectCollection customEndPointObjects { get; set; }
        #endregion


        /// <summary>
        /// Represents an <see cref="http://spec.openapis.org/oas/v3.0.3#example-object">
        /// OpenApi Example</see> entry.
        /// </summary>
        /// <remarks>
        /// Example of the parameter’s potential value. The example SHOULD match the 
        /// specified schema and encoding properties if present. The example field is 
        /// mutually exclusive of the examples field. Furthermore, if referencing a schema 
        /// that contains an example, the example value SHALL override the example provided 
        /// by the schema. To represent examples of media types that cannot naturally be 
        /// represented in JSON or YAML, a string value can contain the example with escaping 
        /// where necessary.
        /// </remarks>
        [AllowNull]
        [JsonProperty(PropertyName = "example")]
        public ExampleValue ExampleValue { get; set; }

        /// <summary>
        /// Represents a list of <see cref="http://spec.openapis.org/oas/v3.0.3#example-object">
        /// OpenApi Example</see> entries.
        /// </summary>
        /// <remarks>
        /// Examples of the parameter’s potential value. Each example SHOULD contain a value 
        /// in the correct format as specified in the parameter encoding. The examples field 
        /// is mutually exclusive of the example field. Furthermore, if referencing a schema 
        /// that contains an example, the examples value SHALL override the example provided 
        /// by the schema.
        /// </remarks>
        [AllowNull]
        [JsonProperty(PropertyName = "examples")]
        public Dictionary<string, ExampleValue> ExampleValues { get; set; }

        /// <summary>
        /// describes the location where the parameter can appear
        /// </summary>
        /// <remarks>Possible values are:
        /// <list type="bullet">
        /// <item>query</item>
        /// <item>header</item>
        /// <item>path</item>
        /// <item>cookie</item>
        /// </list></remarks>
        [JsonRequired]
        [JsonProperty(PropertyName = "in")]
        public string ShowsUpIn { get; set; }

        /// <summary>
        /// Shows whether the parameter is mandatory
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "required")]
        public bool Required { get; set; }

        // These are properties added to the ApiDoc to allow easier building of test objects.
        // In many cases these items are OpenApi schema extensions or are embedded levels below 
        // the main level. Moving them here and adding some calculated fields allows easier
        // overall manipulation.

        /// <summary>
        /// Allows for a link back to the parent endpoint through 
        /// <see cref="controllerName"/> + <see cref="uriMethod"/> + <see cref="uriPath"/>
        /// </summary>
        public string uriPath { get; set; }

        /// <summary>
        /// Allows for a link back to the parent endpoint through 
        /// <see cref="controllerName"/> + <see cref="uriMethod"/> + <see cref="uriPath"/>
        /// </summary>
        public string uriMethod { get; set; }

        /// <summary>
        /// Allows for a link back to the parent endpoint through 
        /// <see cref="controllerName"/> + <see cref="uriMethod"/> + <see cref="uriPath"/>
        /// </summary>
        public string controllerName { get; set; }

        ///// <summary>
        ///// This is a sequentially assigned Id that shows the order in which the endpoint
        ///// shows up within the controller.
        ///// </summary>
        //public int operationId { get; set; }

        /// <summary>
        /// Stores the value of a custom token <see cref="ParseTokens.TKN_GetsInputFrom"/> that
        /// references what response object to use when getting test values for this parameter.
        /// </summary>
        public string inputProvider { get; set; }
        #endregion

        #region -- Constructors -----
        /// <summary>
        /// Creates a new instance of the <see cref="Parameter"/> object
        /// </summary>
        public Parameter()
        {
            Name = string.Empty;
            Type = string.Empty;
            Description = string.Empty;
            Reference = string.Empty;
            Format = string.Empty;
            IsArray = false;
            customEndPointObjects = new CustomOasObjectCollection();

            //ExampleValue - null allowed
            //ExampleValues - null allowed

            uriPath = string.Empty;
            uriMethod = string.Empty;
            controllerName = string.Empty;
q
            inputProvider = string.Empty;
            Required = false;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Parameter"/> object
        /// and initializes the <see cref="controllerName"/> properties
        /// </summary>
        /// <param name="ControllerName"><see cref="controllerName"/></param>
        public Parameter(string ControllerName)
        {
            Name = string.Empty;
            Type = string.Empty;
            Description = string.Empty;
            Required = false;
            IsArray = false;
            uriPath = string.Empty;
            uriMethod = string.Empty;
            controllerName = ControllerName;
            customEndPointObjects = new CustomOasObjectCollection();
        }
        #endregion

        #region -- IComparable overrides ----------------------------------
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != typeof(Parameter))
            {
                return false;
            }
            Parameter parameter = obj as Parameter;

            if (Name.ToUpper() == parameter.Name.ToUpper()
                && IsArray == parameter.IsArray
                && ShowsUpIn == parameter.ShowsUpIn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int hash = 19;
            hash = hash * 31 + Name.ToUpper().GetHashCode();
            hash = hash * 31 + IsArray.GetHashCode();
            hash = hash * 31 + ShowsUpIn.GetHashCode();
            return hash;
        }

        int IComparable.CompareTo(object obj)
        {
            Parameter p1 = (Parameter)this;
            Parameter p2 = (Parameter)obj;
            //if (p1.operationId < p2.operationId)
            //    return -1;
            //if (p1.operationId > p2.operationId)
            //    return 1;
            //else
                return string.Compare(p1.Name, p2.Name, true);
        }
        #endregion
    }
}
