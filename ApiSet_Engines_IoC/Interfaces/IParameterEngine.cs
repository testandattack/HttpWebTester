﻿using ApiTestGenerator.Models.ApiDocs;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSet.Engines.Interfaces
{
    public interface IParameterEngine
    {
        Parameter GetParameter(OpenApiParameter parameter, string controllerName, string uriPath, string method);
    }
}
