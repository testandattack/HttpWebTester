using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTestingResults
{
    /// <summary>
    /// Flags used by the parser on its initial pass of building the test objects.
    /// </summary>
    /// <remarks>
    /// When the parser starts working, it makes an initial pass whose purpose is to break the text into the representative queries, test level objects or query level objects.
    /// These flags are used to denote queries and test level objects.
    /// </remarks>
    public enum WebTestResultItemType
    {
        /// <summary>
        /// This is either the main test root item, or it is a call to a sub item of the same type.
        /// </summary>
        Wtri_IncludedWebTestItem = 1,

        /// <summary>
        /// Indicates that this object represents a request object
        /// </summary>
        Wtri_RequestObject = 2,

        /// <summary>
        /// Indicates that this object is a transaction timer and all requests inside it will have their times summarized.
        /// </summary>
        Wtri_TransactionItem = 3,

        /// <summary>
        /// Indicates that this object houses a series of requests that will be executed multiple times in a loop.
        /// </summary>
        Wtri_LoopControlItem = 4,

        /// <summary>
        /// Indicates that this object represents a Comment object
        /// </summary>
        Wtri_CommentItem = 5
    };


}
