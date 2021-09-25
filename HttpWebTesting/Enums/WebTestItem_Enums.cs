namespace HttpWebTesting.Enums
{
    /// <summary>
    /// Flags used by the parser on its initial pass of building the test objects.
    /// </summary>
    /// <remarks>
    /// When the parser starts working, it makes an initial pass whose purpose is to break the text into the representative queries, test level objects or query level objects.
    /// These flags are used to denote queries and test level objects.
    /// </remarks>
    public enum WebTestItemType
    {
        /// <summary>
        /// This is either the main test root item, or it is a call to a sub item of the same type.
        /// </summary>
        Wti_IncludedWebTestItem = 1,

        /// <summary>
        /// Indicates that this object represents a request object
        /// </summary>
        Wti_RequestObject = 2,

        /// <summary>
        /// Indicates that this object is a transaction timer and all requests inside it will have their times summarized.
        /// </summary>
        Wti_Transactiontimer = 3,

        /// <summary>
        /// Indicates that this object houses a series of requests that will be executed multiple times in a loop.
        /// </summary>
        Wti_LoopControl = 4,

        /// <summary>
        /// Indicates that this object represents a Comment object
        /// </summary>
        Wti_Comment = 5,

        /// <summary>
        /// This indicates an unknown item type and is used to handle parsing errors by the WebTestItemManager.
        /// </summary>
        Wti_Unknown = 6,

        /// <summary>
        /// This item type is used only for webTestResults. It indicated that the particular item in the test
        /// had the property <see cref="HttpWebTesting.WebTestItems.WebTestItem.Enabled"/> set to false.
        /// </summary>
        Wti_SkippedItem = 7
    };


}
