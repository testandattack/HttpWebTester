using HttpWebTesting.Collections;

namespace HttpWebTesting.Enums
{
    /// <summary>
    /// This enum describes the type of datasource that is associated with an entry
    /// in the <see cref="DataSourceCollection"/>
    /// </summary>
    public enum DataSourceType
    {
        /// <summary>
        /// The data for this datasource is stored in a standard CSV file.
        /// </summary>
        CSV = 1,

        /// <summary>
        /// The data for this datasource is stored in a Tab Separated text file.
        /// </summary>
        TSV = 2,

        /// <summary>
        /// The data for this datasource is stored in a backing store that can
        /// be accessed by using ADO.NET. 
        /// </summary>
        ADO = 3
    };
}
