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
    public interface IAbbreviatedResponseObject<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="endPointName"></param>
        /// <returns></returns>
        public AbbreviatedResponseObject GetAbbreviatedResponseObject(T property, string endPointName);
    }
}
