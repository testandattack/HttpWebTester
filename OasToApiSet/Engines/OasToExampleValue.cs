using ApiSet.Models.ApiDocs;
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
    public class OasToExampleValue : IExampleValue<OpenApiParameter>
    {
        #region -- Properties -----
        private readonly ISettings _settings;
        private readonly ILogger _logger;

        #endregion

        #region -- Constructors -----
        public OasToExampleValue(ILogger logger, ISettings settings)
        {
            _settings = settings;
            _logger = logger;
        }
        #endregion

        #region -- Methods -----
        public ExampleValue GetExampleValue(OpenApiParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, ExampleValue> GetExampleValues(OpenApiParameter parameter)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
