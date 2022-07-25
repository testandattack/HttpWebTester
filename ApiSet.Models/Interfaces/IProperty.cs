using ApiSet.Models.ApiDocs;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSet.Engines.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProperty<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propertyName"></param>
        /// <param name="parentItemName"></param>
        /// <returns></returns>
        Property GetPropertyItem(T property, string propertyName, string parentItemName);
    }
}
