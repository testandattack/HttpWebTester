using Microsoft.OpenApi.Models;
using System;

namespace ApiSet.Models.Enums
{
    /// <summary>
    /// Enumerates the types of data objects that can be found in
    /// an <see cref="OpenApiSchema"/> object
    /// </summary>
    public enum ObjectTypeEnum
    {
        #region -- Parant level items for handling nested types -----
        /// <summary>
        /// A <see cref="List"/> of items, referred to as arrays in the openApi spec
        /// </summary>
        List,

        /// <summary>
        /// A list of <see cref="List"/> of items, referred to as arrays in the openApi spec
        /// </summary>
        List_List,

        /// <summary>
        /// The endpoint does not return any data.
        /// </summary>
        none,
        #endregion

        #region -- single items -----
        /// <summary>
        /// A class-based response object
        /// </summary>
        Object,

        /// <summary>
        /// A binary string (usually a downloadable file, etc)
        /// </summary>
        BinaryString,

        /// <summary>
        /// A plain old <see cref="String"/>.
        /// </summary>
        String,

        /// <summary>
        /// A plain old <see cref="Int32"/>
        /// </summary>
        Integer,

        /// <summary>
        /// A <see cref="bool"/>
        /// </summary>
        Boolean,

        /// <summary>
        /// A <see cref="double"/>
        /// </summary>
        Double,

        /// <summary>
        /// A <see cref="DateTime"/>
        /// </summary>
        DateTime,

        /// <summary>
        /// The Date portion of a <see cref="DateTime"/>
        /// </summary>
        Date,

        /// <summary>
        /// An <see cref="Int64"/>
        /// </summary>
        Long,

        /// <summary>
        /// A <see cref="Byte"/>
        /// </summary>
        Byte,
        #endregion

        #region -- List of items -----
        /// <summary>
        /// A list of <see cref="Object"/> items
        /// </summary>
        List_Objecgt,

        /// <summary>
        /// A list of <see cref="BinaryString"/> items
        /// </summary>
        List_BinaryString,

        /// <summary>
        /// A list of <see cref="String"/> items
        /// </summary>
        List_String,

        /// <summary>
        /// A list of <see cref="Integer"/> items
        /// </summary>
        List_Integer,

        /// <summary>
        /// A list of<see cref="Boolean"/> items
        /// </summary>
        List_Boolean,

        /// <summary>
        /// A list of <see cref="Double"/> items
        /// </summary>
        List_Double,

        /// <summary>
        /// A list of <see cref="DateTime"/>
        /// </summary>
        List_DateTime,

        /// <summary>
        /// A list of The Date portion of a <see cref="DateTime"/>
        /// </summary>
        List_Date,

        /// <summary>
        /// A list of <see cref="Int64"/>
        /// </summary>
        List_Long,

        /// <summary>
        /// A list of <see cref="Byte"/>
        /// </summary>
        List_Byte,
        #endregion

        #region -- List of lists of items -----
        /// <summary>
        /// A list of lists of <see cref="Object"/> items
        /// </summary>
        List_List_Object,

        /// <summary>
        /// A list of lists of <see cref="BinaryString"/> items
        /// </summary>
        List_List_BinaryString,

        /// <summary>
        /// A list of lists of <see cref="String"/> items
        /// </summary>
        List_List_String,

        /// <summary>
        /// A list of lists of <see cref="Integer"/> items
        /// </summary>
        List_List_Integer,

        /// <summary>
        /// A list of lists of <see cref="Boolean"/> items
        /// </summary>
        List_List_Boolean,

        /// <summary>
        /// A list of lists of <see cref="Double"/> items
        /// </summary>
        List_List_Double,

        /// <summary>
        /// A list of lists of <see cref="DateTime"/>
        /// </summary>
        List_List_DateTime,

        /// <summary>
        /// A list of lists of The Date portion of a <see cref="DateTime"/>
        /// </summary>
        List_List_Date,

        /// <summary>
        /// A list of lists of <see cref="Int64"/>
        /// </summary>
        List_List_Long,

        /// <summary>
        /// A list of lists of <see cref="Byte"/>
        /// </summary>
        List_List_Byte,
        #endregion

        /// <summary>
        /// The ApiDoc parser was not able to determine the response object type.
        /// </summary>
        FailedToParse
    }

}
