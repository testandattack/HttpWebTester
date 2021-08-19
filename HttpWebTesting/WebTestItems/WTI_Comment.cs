using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTesting.WebTestItems
{
    /// <summary>
    /// A Comment object allows comments to be added to the heirarchy of items in a web test.
    /// </summary>
    public class WTI_Comment : WebTestItem
    {
        /// <summary>
        /// The comment text to be displayed in the test viewer
        /// </summary>
        public string Comment { get; set; }

        public WTI_Comment()
        {
            InitializeObject();
        }

        public WTI_Comment(string comment)
        {
            InitializeObject();
            Comment = comment;
        }

        private void InitializeObject()
        {
            objectItemType = Enums.WebTestItemType.Wti_Comment;
            Enabled = true;
            guid = Guid.NewGuid();
            itemComment = string.Empty;
        }
    }
}
