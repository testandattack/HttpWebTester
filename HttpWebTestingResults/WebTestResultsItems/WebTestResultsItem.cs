using HttpWebTesting.WebTestItems;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HttpWebTestingResults
{
    [JsonConverter(typeof(JsonSubtypes), "objectItemType")]
    [JsonSubtypes.KnownSubType(typeof(WTRI_Comment), WebTestResultItemType.Wtri_CommentItem)]
    [JsonSubtypes.KnownSubType(typeof(WTRI_IncludedWebTest), WebTestResultItemType.Wtri_IncludedWebTestItem)]
    [JsonSubtypes.KnownSubType(typeof(WTRI_LoopControl), WebTestResultItemType.Wtri_LoopControlItem)]
    [JsonSubtypes.KnownSubType(typeof(WTRI_Request), WebTestResultItemType.Wtri_RequestObject)]
    [JsonSubtypes.KnownSubType(typeof(WTRI_SkippedItem), WebTestResultItemType.Wtri_SkippedItem)]
    [JsonSubtypes.KnownSubType(typeof(WTRI_Transaction), WebTestResultItemType.Wtri_TransactionItem)]
    public abstract class WebTestResultsItem
    {
        internal WebTestResultsItem() { }

        /// <summary>
        /// Defines what type of test object is housed in the given instance of the class. It is based on the <see cref="WebTestItemType"/> ENUM
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [Browsable(false)]
        public WebTestResultItemType objectItemType { get; set; }

        /// <summary>
        /// The item in the webtest that this result is for
        /// </summary>
        [JsonProperty(PropertyName = "Original Item Id")]
        public Guid? webTestItemId { get; set; }

        public bool ItemExecutionFailed = false;

        public string ItemResult
        {
            get
            {
                if (ItemExecutionFailed)
                    return "Failed";
                else
                    return "Passed";
            }

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
