using ApiTestGenerator.Models.ApiDocs;
using ApiSet.Engines.Interfaces;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace ApiSet.Engines
{
    public class ParameterEngine : IParameterEngine
    {
        private readonly ILogger _logger;

        public ParameterEngine(ILogger logger)
        {
            _logger = logger;
        }

        public Parameter GetParameter(OpenApiParameter parameter, string controllerName, string uriPath, string method)
        {
            _logger.ForContext<EndPoint>().Verbose("[{method}]: Adding {@parameterName}", "AddParameters", parameter.Name);
            Parameter gtcParam = new Parameter(controllerName);

            gtcParam.Name = parameter.Name;
            gtcParam.Type = parameter.Schema.Type;
            gtcParam.Required = parameter.Required;
            gtcParam.ShowsUpIn = parameter.In.HasValue ? parameter.In.ToString() : string.Empty;
            gtcParam.uriPath = uriPath;
            gtcParam.uriMethod = method;

            gtcParam.GetDescriptionAndCustomObjects(parameter);

            if (parameter.Schema.Format != null)
            {
                gtcParam.Format = parameter.Schema.Format;
            }

            if (gtcParam.Type == "array")
            {
                gtcParam.IsArray = true;
                gtcParam.arrayType = parameter.Schema.Items.Type;
                if (parameter.Schema.Items.Format != null)
                {
                    gtcParam.Format = parameter.Schema.Items.Format;
                }
            }

            // Since the two items below are mutually exclusive in the OpenApiSchema
            // and since the plural takes precidence over the singular, we will populate 
            // the singular from the plural (if it exists), so we must call the plural
            // processor first.
            gtcParam.GetParameterExamples(parameter);
            gtcParam.GetParameterExample(parameter);

            return gtcParam;
        }
    }
}
