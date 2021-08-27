using HttpWebTesting.WebTestItems;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HttpWebTestingResults
{
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
        public WebTestItem webTestItem { get; set; }
    }
}
