using ApiSet.Models.ApiDocs;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSet.Engines.Interfaces
{
    public interface IEndpoint
    {
        int ParseEndpoint(Controller controller, string pathUri, int startingId, OpenApiPathItem item);
    }
}
