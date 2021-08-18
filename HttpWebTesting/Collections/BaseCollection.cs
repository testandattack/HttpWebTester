using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HttpWebTesting.Collections
{
    public abstract class BaseCollection<T> : Collection<T>
    {
        protected BaseCollection() { }

        public void AddRange(IEnumerable<T> items)
        {
            if(items == null)
            {
                throw new ArgumentNullException("items");
            }
            foreach(T local in items)
            {
                base.Add(local);
            }
        }
    }
}
