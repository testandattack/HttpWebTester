using HttpWebTesting.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using HttpWebTesting.CoreObjects;
using System.ComponentModel;

namespace HttpWebTestingEditor
{
    /// <summary>
    /// This class is a collection of <see cref="PropertyDisplayInfo"/> entries, one entry
    /// for each publicly exposed property of the owning object 
    /// </summary>
    /// <remarks>
    /// To Use:
    /// <code language="csharp">
    /// displayInfo = new PropertyDisplayInfoCollection();
    /// displayInfo.AddAllItems(this, "Request Object");
    /// </code>
    /// </remarks>
    public class PropertyDisplayInfoCollection : BaseCollection<PropertyDisplayInfo>
    {
        /// <summary>
        /// The name of the collection.
        /// </summary>
        public string CollectionName { get; set; }

        /// <summary>
        /// The Type of the object that this collection is for.
        /// </summary>
        public Type ParentItemType { get; set; }

        /// <summary>
        /// This method uses Reflection to walk the passed in object and build all of the 
        /// collection items.
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="nameOfParentItem"></param>
        public void AddAllItems(object myObject, string nameOfParentItem)
        {
            CollectionName = nameOfParentItem;
            ParentItemType = myObject.GetType();

            PropertyInfo[] props = ParentItemType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var prop in props)
            {
                var itemDisplayProperties = new PropertyDisplayInfo(prop);
                this.Add(itemDisplayProperties);
            }
            Console.WriteLine("");
        }




        }

    }
