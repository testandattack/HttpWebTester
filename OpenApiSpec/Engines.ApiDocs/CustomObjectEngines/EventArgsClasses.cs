using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.OpenApi.Models;

namespace Engines.ApiDocs
{
    public class OpenApiOperationEventArgs : EventArgs
    {
        public KeyValuePair<OperationType, OpenApiOperation> operation { get; set; }
    }

    public class OpenApiParameterEventArgs : EventArgs
    {
        public OpenApiParameter parameter { get; set; }
    }
}
