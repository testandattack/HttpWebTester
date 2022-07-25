using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ApiSet.Models.ApiDocs
{
    /// <summary>
    /// A class that contains a collection of custom objects added to the OAS documentation.
    /// </summary>
    public class CustomOasObjectCollection : IEnumerable
    {
        /// <summary>
        /// ther dictionary that contains the collection of custom object.
        /// </summary>
        public List<CustomOasObject> collection { get; set; }

        /// <summary>
        /// The default constructor
        /// </summary>
        public CustomOasObjectCollection()
        {
            collection = new List<CustomOasObject>();
        }

        #region -- Enumeration -----------------------------------------------------
        /// <summary>
        /// Gets the enumerator for the dictionary of objects making up this collection.
        /// </summary>
        public IEnumerator GetEnumerator() { return new CollectionEnumerator(collection); }

        private class CollectionEnumerator : IEnumerator, IDisposable
        {
            private List<CustomOasObject>.Enumerator _Enumerator;

            public object Current { get { return _Enumerator.Current; } }
            public void Dispose() { _Enumerator.Dispose(); }
            public bool MoveNext() { return _Enumerator.MoveNext(); }
            public void Reset() { throw new NotImplementedException("Reset not implmented"); }


            public CollectionEnumerator(List<CustomOasObject> list)
            {
                _Enumerator = list.GetEnumerator();
            }

        } // end class 
        #endregion
    }
}
