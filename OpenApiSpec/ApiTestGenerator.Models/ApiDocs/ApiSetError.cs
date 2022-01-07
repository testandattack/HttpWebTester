using ApiTestGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.ApiDocs
{
    public class ApiSetError : Error
    {
        public ApiSetError(string msg, object objectWithError)
        {
            ErrorMessage = msg;
            ObjectWithError = objectWithError;
        }
    }
}
