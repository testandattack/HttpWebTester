using HttpWebTesting.Collections;

namespace HttpWebTesting.WebTestItems
{
    public class WTI_Transaction : WebTestItem
    {
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

    }
}
