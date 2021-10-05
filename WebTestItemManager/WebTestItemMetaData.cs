using System;
using System.Collections.Generic;
using System.Text;
using HttpWebTesting.Enums;

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

        public WebTestItemType wtit { get; set; }

        public WTItemSubType wtist { get; set; }

        public Guid guid { get; set; }

        public string Url { get; set; }

        public WebTestItemMetaData() { }
    }
}
