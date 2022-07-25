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
    public interface IExampleValue<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Dictionary<string, ExampleValue> GetExampleValues(T parameter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        ExampleValue GetExampleValue(T parameter);
    }
}
