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
    public class ResponseObjectEngine : IResponseObjectEngine
    {
        #region -- Properties -----
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly IAbbreviatedResponseObjectEngine _abbreviatedResponseObjectEngine;

        #endregion

        #region -- Constructors -----
        public ResponseObjectEngine(ILogger logger
                            , ISettings settings
                            , IAbbreviatedResponseObjectEngine abbreviatedResponseObjectEngine)
        {
            _settings = settings;
            _logger = logger;
            _abbreviatedResponseObjectEngine = abbreviatedResponseObjectEngine;
        }
        #endregion

        #region -- Methods -----
        public ResponseObject GetResponseObject(OpenApiOperation apiOperation)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
