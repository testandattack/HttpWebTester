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
    /// <typeparam name="T"></typeparam>
    public interface IResponseObject<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiOperation"></param>
        /// <returns></returns>
        Dictionary<string, ResponseObject> GetResponseObjects(T apiOperation);
    }
}
