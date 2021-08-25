using HttpWebTesting.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using HttpWebTesting.CoreObjects;
using System.ComponentModel;

namespace HttpWebTesting.CoreObjects
{
    public class PropertyDisplayInfoCollection : BaseCollection<PropertyDisplayInfo>
    {
        public string CollectionName { get; set; }

        public Type ParentItemType { get; set; }

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
