using HttpWebTesting.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

namespace HttpWebTesting.CoreObjects
{
    public class PropertyDisplayInfoCollection : BaseCollection<PropertyDisplayInfo>
    {
        public string CollectionName { get; set; }

        public Type ParentItemType { get; set; }


        public void AddItem(IEnumerable<Attribute> attributes, Type type)
        {
            var pdi = new PropertyDisplayInfo(attributes);
            pdi.SetType(type);

            this.Add(pdi);
        }

        public void AddAllItems(object myObject, string nameOfParentItem)
        {
            CollectionName = nameOfParentItem;
            ParentItemType = myObject.GetType();

            PropertyInfo[] props = ParentItemType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            Console.WriteLine("");
        }
    }
}
