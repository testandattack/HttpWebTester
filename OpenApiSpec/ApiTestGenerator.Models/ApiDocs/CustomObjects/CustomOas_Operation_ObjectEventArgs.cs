using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.OpenApi.Models;

namespace ApiTestGenerator.Models.ApiDocs
{

    public class CustomOas_Operation_ObjectEventArgs : EventArgs
    {
        public OpenApiOperation operation { get; set; }

        public OperationType operationType { get; set; } 
    }
}
