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
    public interface IRequestBody<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiOperation"></param>
        /// <param name="parentItemName"></param>
        /// <returns></returns>
        RequestBody GetRequestBody(T apiOperation, string parentItemName);
    }
}
