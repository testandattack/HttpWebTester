using HttpWebTesting.Collections;
using System;

namespace HttpWebTesting.WebTestItems
{
    public class WTI_Transaction : WebTestItem
    {
        #region -- Properties -----
        /// <summary>
        /// The name of the transaction
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A description of the transaction
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// This is a collection of the <see cref="WebTestItem"/> items that will be executed
        /// for each iteration of this loop control.
        /// </summary>
        public WebTestItemCollection webTestItems { get; set; }
        #endregion

        #region -- Constructors -----

        public WTI_Transaction()
        {
            webTestItems = new WebTestItemCollection();
            InitializeObject();
        }

        private void InitializeObject()
        {
            objectItemType = Enums.WebTestItemType.Wti_Transactiontimer;
            Enabled = true;
            guid = Guid.NewGuid();
            itemComment = string.Empty;
        }

        #endregion
    }
}
