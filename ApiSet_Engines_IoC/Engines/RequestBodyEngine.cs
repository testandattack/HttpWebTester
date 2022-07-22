using ApiTestGenerator.Models.ApiDocs;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using GTC.HttpWebTester.Settings;
using ApiDocs.CustomObjects;
using ApiSet.Engines.Interfaces;

namespace ApiSet.Engines
{
    public class RequestBodyEngine : IRequestBodyEngine
    {
        #region -- Properties -----
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly IPropertyEngine _propertyEngine;
        #endregion

        #region -- Constructors -----
        public RequestBodyEngine(ILogger logger, ISettings settings, IPropertyEngine propertyEngine)
        {
            _settings = settings;
            _logger = logger;
            _propertyEngine = propertyEngine;
        }
        #endregion

        #region -- Methods -----
        public RequestBody GetRequestBody(OpenApiOperation apiOperation)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
