using HttpWebTesting.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HttpWebTesting.WebTestItems
{
    /// <summary>
    /// Represents a placeholder in the Web Test Results for any item that is skipped during execution.
    /// </summary>
    [Browsable(false)]
    public class WTI_SkippedItem : WebTestItem
    {
        /// <summary>
        /// The name of the item that was skipped during test execution
        /// </summary>
        public string NameOfSkippedItem { get; set; }

        public WebTestItemType skippedObjectItemType { get; set; }

        public WTI_SkippedItem()
        {
            InitializeObject();
        }

        public WTI_SkippedItem(string name, WebTestItemType type)
        {
            InitializeObject();
            NameOfSkippedItem = name;
            skippedObjectItemType = type;
        }

        private void InitializeObject()
        {
            objectItemType = WebTestItemType.Wti_SkippedItem;
            Enabled = true;
            guid = Guid.NewGuid();
            NameOfSkippedItem = string.Empty;
            skippedObjectItemType = WebTestItemType.Wti_Unknown;
        }
    }
}
