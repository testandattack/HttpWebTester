using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestItemManager
{
    public class WebTestItemMetaData
    {
        /// <summary>
        /// format = "Root.x.y.z"
        /// </summary>
        public string sTreeLoc { get; set; }
        /// <summary>
        /// ZERO-based depth for the node in the tree, not including the Root element. (for Root.x.y.z, the depth = 2)
        /// </summary>
        public int iTreeDepth { get; set; }

        public WTItemType wtit { get; set; }
        public WTItemSubType wtist { get; set; }
        public Guid guid { get; set; }

        public Uri Uri { get; set; }
        public WebTestItemMetaData() { }
    }
}
