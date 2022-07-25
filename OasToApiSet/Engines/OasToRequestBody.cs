using ApiSet.Engines.Interfaces;
using ApiSet.Models.ApiDocs;
using ApiSet.Models.Consts;
using GTC.Extensions;
using GTC.HttpWebTester.Settings;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Collections.Generic;

namespace ApiSet.Engines
{
    public class OasToRequestBody : IRequestBody<OpenApiOperation>
    {
        #region -- Properties -----
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly IProperty<OpenApiSchema> _propertyEngine;
        #endregion

        #region -- Constructors -----
        public OasToRequestBody(ILogger logger, ISettings settings, IProperty<OpenApiSchema> propertyEngine)
        {
            _settings = settings;
            _logger = logger;
            _propertyEngine = propertyEngine;
        }
        #endregion

        #region -- Methods -----
        public RequestBody GetRequestBody(OpenApiOperation openApiOperation, string parentItemName)
        {
            RequestBody requestBody = new RequestBody();
            if (openApiOperation.RequestBody != null && openApiOperation.RequestBody.Content.Count > 0)
            {
                if (openApiOperation.RequestBody.Content.ContainsKey(ParserTokens.OAS_JsonContentType))
                {
                    Add_ApplicationJson_RequestBody(ref requestBody, openApiOperation);
                }
                else if (openApiOperation.RequestBody.Content.ContainsKey(ParserTokens.OAS_FormDataContentType))
                {
                    Add_FormData_RequestBody(ref requestBody, openApiOperation, parentItemName);
                }
                else
                {
                    requestBody.RequestBodyContentType = openApiOperation.RequestBody.Content.Keys.ToString(",");
                }
            }
            else
            {
                requestBody.RequestBodyContentType = ParserTokens.OAS_NoContentFound;
            }
            return requestBody;
        }

        private void Add_ApplicationJson_RequestBody(ref RequestBody requestBody, OpenApiOperation openApiOperation)
        {
            if (openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema != null)
            {
                requestBody.RequestBodyContentType = ParserTokens.OAS_JsonContentType;

                if (openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Items != null)
                {
                    if (openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Items.Type == "object")
                    {
                        requestBody.RequestBodyJsonObject = openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Items.Reference.Id;
                    }
                    else
                    {
                        requestBody.RequestBodyJsonObject = openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Items.Type;
                    }
                }
                else
                {
                    if (openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Type == "object")
                    {
                        if (openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Reference == null)
                        {
                            requestBody.RequestBodyJsonObject = openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.AdditionalProperties.Type;
                        }
                        else
                        {
                            requestBody.RequestBodyJsonObject = openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Reference.Id;
                        }
                    }
                    else
                    {
                        requestBody.RequestBodyJsonObject = openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Type;
                    }
                }
                requestBody.RequestBodySchemaType = openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Type;
            }
            else
            {
                requestBody.RequestBodyString = "The RequestBody.Content.Schema was null.";
            }
        }

        private void Add_FormData_RequestBody(ref RequestBody requestBody, OpenApiOperation openApiOperation, string endpointName)
        {
            requestBody.RequestBodyContentType = ParserTokens.OAS_FormDataContentType;

            if (openApiOperation.RequestBody.Content[ParserTokens.OAS_FormDataContentType].Schema.Type != null)
            {
                requestBody.RequestBodyFormObjectOrType = openApiOperation.RequestBody.Content[ParserTokens.OAS_FormDataContentType].Schema.Type;
            }

            if (openApiOperation.RequestBody.Content[ParserTokens.OAS_FormDataContentType].Schema.Properties != null)
            {
                requestBody.properties = new Dictionary<string, Property>();
                foreach (var prop in openApiOperation.RequestBody.Content[ParserTokens.OAS_FormDataContentType].Schema.Properties)
                {
                    requestBody.properties.Add("", _propertyEngine.GetPropertyItem(prop.Value, prop.Key, endpointName));
                }
            }
        }
        #endregion
    }
}
