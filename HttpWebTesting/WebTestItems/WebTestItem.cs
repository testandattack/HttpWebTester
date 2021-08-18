using System;
using System.ComponentModel;
using HttpWebTesting.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HttpWebTesting.WebTestItems
{
    /// <summary>
    /// The base class from which the test level object classes are derived. This class enforces the need to have an object type and position for all classes
    /// </summary>
    public abstract class WebTestItem
    {
        internal WebTestItem() { }

        /// <summary>
        /// Defines what type of test object is housed in the given instance of the class. It is based on the <see cref="WebTestItemType"/> ENUM
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [Browsable(false)]
        public WebTestItemType objectItemType { get; set; }

        /// <summary>
        /// If this is set to false, this item is ignored during playback. Default is TRUE
        /// </summary>
        public bool Enabled = true;

        /// <summary>
        /// A field to maintain a comment that can be seen in the UI
        /// </summary>
        public string itemComment { get; set; }

        /// <summary>
        /// A unique identifier that allows every item to be uniquely tracked.
        /// </summary>
        [Browsable(false)]
        public Guid guid { get; set; }
    }
}
