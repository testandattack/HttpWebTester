using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// A class that contains a collection of custom objects added to the OAS documentation.
    /// </summary>
    public class CustomOasObjectCollection : IEnumerable
    {
        /// <summary>
        /// ther dictionary that contains the collection of custom object.
        /// </summary>
        public Dictionary<string, CustomOasObject> collection { get; set; }

        /// <summary>
        /// The default constructor
        /// </summary>
        public CustomOasObjectCollection()
        {
            collection = new Dictionary<string, CustomOasObject>();
        }

        #region -- Enumeration -----------------------------------------------------
        /// <summary>
        /// Gets the enumerator for the dictionary of objects making up this collection.
        /// </summary>
        public IEnumerator GetEnumerator() { return new CollectionEnumerator(collection); }

        private class CollectionEnumerator : IEnumerator, IDisposable
        {
            private Dictionary<string, CustomOasObject>.Enumerator _Enumerator;

            public object Current { get { return _Enumerator.Current.Value; } }
            public void Dispose() { _Enumerator.Dispose(); }
            public bool MoveNext() { return _Enumerator.MoveNext(); }
            public void Reset() { throw new NotImplementedException("Reset not implmented"); }


            public CollectionEnumerator(Dictionary<string, CustomOasObject> dictionary)
            {
                _Enumerator = dictionary.GetEnumerator();
            }

        } // end class 
        #endregion
    }
}
