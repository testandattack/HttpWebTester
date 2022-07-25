using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ApiSet.Models.Enums
{
    /// <summary>
    /// Describes the type of object returned from the API.
    /// </summary>
    /// <remarks>
    /// This is used by the test generation software to 
    /// determine what extraction and validation rule types 
    /// can be used with the response.
    /// </remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResponseTypeEnum
    {
        /// <summary>
        /// A class-based response object
        /// </summary>
        Object = 1,

        /// <summary>
        /// A binary string (usually a downloadable file, etc)
        /// </summary>
        BinaryString = 2,

        /// <summary>
        /// A plain old <see cref="String"/>.
        /// </summary>
        String = 3,

        /// <summary>
        /// A plain old <see cref="Int32"/>
        /// </summary>
        Integer = 4,

        /// <summary>
        /// A list of <see cref="Object"/> items
        /// </summary>
        List_Object = 5,

        /// <summary>
        /// A list of <see cref="BinaryString"/> items
        /// </summary>
        List_BinaryString = 6,

        /// <summary>
        /// A list of <see cref="String"/> items
        /// </summary>
        List_String = 7,

        /// <summary>
        /// A list of <see cref="Integer"/> items
        /// </summary>
        List_Integer = 8,
        
        /// <summary>
        /// The endpoint does not return any data.
        /// </summary>
        none = 9,
        
        /// <summary>
        /// The ApiDoc parser was not able to determine the response object type.
        /// </summary>
        FailedToParse = 10
    }
}
