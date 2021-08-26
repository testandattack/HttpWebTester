namespace HttpWebTesting.Enums
{
    /// <summary>
    /// Describes the behavior of the cursor for the data source.
    /// </summary>
    public enum DataSourceCursorType
    {
        /// <summary>
        /// Every time the cursor advances, it moves to the next record in the data set. 
        /// When the end of the recordset is reached, the cursor moves back to the first
        /// record in the set.
        /// </summary>
        Sequential = 1,

        /// <summary>
        /// Every time the cursor advances, it moves to a random record in the data set. 
        /// It is possible for the same record to get used multiple times before all records get used.
        /// </summary>
        Random = 2,

        /// <summary>
        /// Every time the cursor advances, it moves to the next record in the data set. 
        /// When the end of the recordset is reached, the Data source will no longer 
        /// provide data and the test will be stopped.
        /// </summary>
        Unique = 3,
    }
}
