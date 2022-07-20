using ApiTestGenerator.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// 
    /// </summary>
    [JsonObject(Title = "apiSetError")]
    public class ApiSetError : Error
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="objectWithError"></param>
        public ApiSetError(string msg, object objectWithError)
        {
            ErrorMessage = msg;
            ObjectWithError = objectWithError;
        }
    }
}
