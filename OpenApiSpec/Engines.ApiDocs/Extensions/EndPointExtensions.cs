using ApiTestGenerator.Models.ApiDocs;
using ApiTestGenerator.Models.Consts;
using ApiTestGenerator.Models.Enums;
using GTC.Extensions;
//using GTC.OpenApiUtilities;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using OpenApiUtilities;

namespace Engines.ApiDocs.Extensions
{
    /// <summary>
    /// An object that is based on the <see cref="http://spec.openapis.org/oas/v3.0.3#operation-object"/>
    /// object, but is enhanced with extra information to help with test generation.
    /// The 'Name' of the object is stored in the Key of the KeyValuePair and is made 
    /// by combining the <see cref="Method"/> and <see cref="UriPath"/> objects
    /// </summary>
    public static class EndPointExtensions
    {

        #region -- Methods -----
        /// <summary>
        /// Adds the input parameters to the object
        /// </summary>
        /// <param name="openApiOperation"></param>
        /// <param name="operationId"></param>
        public static void AddParameters(this EndPoint source, OpenApiOperation openApiOperation, int operationId)
        {
            foreach (var parameter in openApiOperation.Parameters)
            {
                source.AddParameter(operationId, parameter);
            }
        }

        public static void AddParameter(this EndPoint source, int operationId, OpenApiParameter parameter)
        {
            Log.ForContext<EndPoint>().Verbose("[{method}]: Adding {@parameterName}", "AddParameters", parameter.Name);
            Parameter gtcParam = new Parameter(operationId, source.controllerName);

            gtcParam.Name = parameter.Name;
            gtcParam.Type = parameter.Schema.Type;
            gtcParam.Required = parameter.Required;
            gtcParam.ShowsUpIn = parameter.In.HasValue ? parameter.In.ToString() : string.Empty;
            gtcParam.uriPath = source.UriPath;
            gtcParam.uriMethod = source.Method;

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

            source.parameters.Add(parameter.Name, gtcParam);
        }

        ///// <summary>
        ///// Adds any <see cref="RestrictTo"/> items to the endpoint.
        ///// </summary>
        ///// <param name="openApiOperation">the <see cref="OpenApiOperation"/> that might contain user defined extensions.</param>
        //public static void AddRestrictions(this EndPoint source, OpenApiOperation openApiOperation)
        //{
        //    if (openApiOperation.Extensions != null && openApiOperation.Extensions.Count > 0)
        //    {
        //        foreach (var operationExtension in openApiOperation.Extensions)
        //        {
        //            if (operationExtension.Key == ParserTokens.TKN_RestrictTo && ((OpenApiString)(operationExtension.Value)).Value != "")
        //            {
        //                RestrictTo endPointObject = new RestrictTo();
        //                endPointObject.RestrictToRoles.AddRange(((OpenApiString)(operationExtension.Value)).Value.Split(',', StringSplitOptions.RemoveEmptyEntries));
        //                source.customEndPointObjects.Add(endPointObject);
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Adds any <see cref="ProvidesValuesFor"/> items to the endpoint
        ///// </summary>
        ///// <param name="openApiOperation">the <see cref="OpenApiOperation"/> that might contain user defined extensions.</param>
        //public static void AddMethodsThatUseThisResponse(this EndPoint source, OpenApiOperation openApiOperation)
        //{
        //    if (openApiOperation.Extensions != null && openApiOperation.Extensions.Count > 0)
        //    {
        //        foreach (var operationExtension in openApiOperation.Extensions)
        //        {
        //            if (operationExtension.Key == ParserTokens.TKN_ProvidesValuesFor && ((OpenApiString)(operationExtension.Value)).Value != "")
        //            {
        //                ProvidesValuesFor endPointObject = new ProvidesValuesFor();
        //                endPointObject.ProvidesValuesForTheseMethods.AddRange(((OpenApiString)(operationExtension.Value)).Value.Split(',', StringSplitOptions.RemoveEmptyEntries));
        //                source.customEndPointObjects.Add(endPointObject);
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Adds the <see cref="MethodName"/> items to the endpoint
        ///// </summary>
        ///// <param name="openApiOperation">the <see cref="OpenApiOperation"/> that might contain user defined extensions.</param>
        //public static void AddSourceMethodName(this EndPoint source, OpenApiOperation openApiOperation)
        //{
        //    if (openApiOperation.Extensions != null && openApiOperation.Extensions.Count > 0)
        //    {
        //        foreach (var operationExtension in openApiOperation.Extensions)
        //        {
        //            if (operationExtension.Key == ParserTokens.TKN_MethodName)
        //            {
        //                MethodName endPointObject = new MethodName((((OpenApiString)(operationExtension.Value)).Value));
        //                source.customEndPointObjects.Add(endPointObject);
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Adds any <see cref="TestDataFilter"/> items to the endpoint
        ///// </summary>
        ///// <param name="openApiOperation">the <see cref="OpenApiOperation"/> that might contain user defined extensions.</param>
        //public static void AddTestDataFilter(this EndPoint source, OpenApiOperation openApiOperation)
        //{
        //    if (openApiOperation.Description != null && openApiOperation.Description.Contains(ParserTokens.TKN_TestDataFilter))
        //    {
        //        TestDataFilter endPointObject =
        //            new TestDataFilter(openApiOperation.Description.FindSubString(ParserTokens.TKN_TestDataFilter, ")"));
        //        source.customEndPointObjects.Add(endPointObject);
        //    }
        //}

        /// <summary>
        /// Adds any <see cref="ParserTokens.PARAM_StartDate"/> or 
        /// <see cref="ParserTokens.PARAM_EndDate"/> items to parameters that
        /// have the same name.
        /// </summary>
        /// <param name="openApiOperation">the <see cref="OpenApiOperation"/> that might contain user defined extensions.</param>
        public static void CheckForDynamicDates(this EndPoint source, OpenApiOperation openApiOperation)
        {
            if (openApiOperation.Description != null && openApiOperation.Description.Contains(ParserTokens.TKN_startDate))
            {
                if (source.parameters.ContainsKey(ParserTokens.PARAM_StartDate))
                {
                    ExampleValue example = new ExampleValue("OpenApiDate", ParserTokens.TKN_startDate);
                    example.GeneratedValue = openApiOperation.Description.FindSubString(ParserTokens.TKN_startDate + "(", ")");
                    source.parameters[ParserTokens.PARAM_StartDate].ExampleValue = example;
                }
            }

            if (openApiOperation.Description != null && openApiOperation.Description.Contains(ParserTokens.TKN_endDate))
            {
                if (source.parameters.ContainsKey(ParserTokens.PARAM_EndDate))
                {
                    ExampleValue example = new ExampleValue("OpenApiDate", ParserTokens.TKN_endDate);
                    example.GeneratedValue = openApiOperation.Description.FindSubString(ParserTokens.TKN_endDate + "(", ")");
                    source.parameters[ParserTokens.PARAM_EndDate].ExampleValue = example;
                }
            }
        }

        /// <summary>
        /// Sets the <see cref="IsLookupMethod"/> flag based on the
        /// presence or absence of the <see cref="ParserTokens.TKN_LookupMethod"/> custom extension
        /// </summary>
        /// <param name="openApiOperation">the <see cref="OpenApiOperation"/> that might contain user defined extensions.</param>
        public static void CheckFor_IsLookupMethod(this EndPoint source, OpenApiOperation openApiOperation)
        {
            if (openApiOperation.Tags != null)
            {
                foreach (var tag in openApiOperation.Tags)
                {
                    if (tag.Name == ParserTokens.TKN_LookupMethod)
                    {
                        source.IsLookupMethod = true;
                        break;
                    }
                }
            }
        }

        public static void AddResponseItems(this EndPoint source, OpenApiOperation openApiOperation, string ResponseItem = "200", string ContentItem = "application/json")
        {
            source.ResponseItems = new Dictionary<string, ResponseObject>();

            foreach (var response in openApiOperation.Responses)
            {
                source.ResponseItems.Add(response.Key, AddResponseItem(response.Value));
            }
        }

        /// <summary>
        /// Walks the operation's Response array to find the response object associated with 
        /// ResponseItem type of '200'.
        /// </summary>
        /// <param name="openApiOperation">the <see cref="OpenApiOperation"/> that might contain user defined extensions.</param>
        /// <param name="ResponseItem"> the response item to look for. Defaults to '200'</param>
        /// <param name="ContentItem">Describes the type of response object to look for</param>
        public static ResponseObject AddResponseItem(OpenApiResponse openApiResponse, string ContentItem = "application/json")
        {
            ResponseObject response = new ResponseObject();

            #region -- workflow -----
            /*
Content	Schema	Type	    Child	SubType		SubItem     Final Result Type
N	    N	    N				                            none
Y	    Y	    N		    N        N		                DTO
Y	    Y	    string		N		                        string
Y	    Y	    string		N		                        string
Y	    Y	    integer		N		                        integer
Y	    Y	    array	    items	N		                List<DTO>
Y	    Y	    array	    items	integer		            List<integer>
Y	    Y	    object	    addProp	integer		            integer
Y	    Y	    object	    addProp	array	    items	    List<DTO>
Y	    Y	    object	    addProp	N		                DTO
Y	    Y	    object	    addProp	string		            string

				Final Result Type
Predicates				
1	2	3	4	
Content.Count = 0				
				none
else				
	Schema.Type == null			
				DTO
	else			
		Schema.Type == string		
			format == null	
				string
			format != null && format == "binary"	
				binary string
		Schema.Type == integer		
			format != null	
				([format])integer
		Schema.Type == array		
			items.Type == null	
				List<DTO>
			format != null && format == "integer"	
				List<integer>
		Schema.Type == object		
			additionalProperties.Type == null	
				DTO
			additionalProperties.Type == integer	
				integer
			additionalProperties.Type == string	
				string
			additionalProperties.Type == array	
				
				List<DTO>

            */
            #endregion
            try
            {
                //
                if (openApiResponse.Description != null && String.IsNullOrEmpty(openApiResponse.Description) != true)
                    response.Description = openApiResponse.Description;

                // Quick check to see if a DTO is being returned.
                if (openApiResponse.Content.Count > 0)
                {
                    foreach (var contentItem in openApiResponse.Content)
                    {
                        if(contentItem.Value.Schema == null)
                        {
                            // Found an object being returned that does not have a schema.
                            if(contentItem.Value.Example != null)
                            {
                                if (contentItem.Value.Example.IsPrimitiveType() == true)
                                {
                                    response.ResponseObjectExampleText = ((OpenApiString)(contentItem.Value.Example)).Value;
                                    response.ResponseObjectExampleTextIsEncoded = false;
                                }
                                else
                                {
                                    string tempStr = JsonConvert.SerializeObject(contentItem.Value.Example);
                                    response.ResponseObjectExampleText = tempStr.Base64Encode();
                                    response.ResponseObjectExampleTextIsEncoded = true;
                                }
                            }
                        }
                        else if (contentItem.Value.Schema.Type == null)
                        {
                            response.ResponseObjectName = contentItem.Value.Schema.Reference.Id;
                            response.ResponseObjectType = ResponseTypeEnum.Object;
                        }
                        else
                        {
                            if (contentItem.Value.Schema.Type == "string")
                            {
                                if (contentItem.Value.Schema.Format != null)
                                {
                                    if (contentItem.Value.Schema.Format == "binary")
                                    {
                                        response.ResponseObjectName = "";
                                        response.ResponseObjectType = ResponseTypeEnum.BinaryString;
                                    }
                                }
                                else
                                {
                                    response.ResponseObjectName = "";
                                    response.ResponseObjectType = ResponseTypeEnum.String;
                                }
                            }
                            else if (contentItem.Value.Schema.Type == "integer")
                            {
                                if (contentItem.Value.Schema.Format != null)
                                {
                                    response.ResponseObjectName = contentItem.Value.Schema.Format;
                                    response.ResponseObjectType = ResponseTypeEnum.Integer;
                                }
                                else
                                {
                                    response.ResponseObjectName = "";
                                    response.ResponseObjectType = ResponseTypeEnum.List_Integer;
                                }
                            }
                            else if (contentItem.Value.Schema.Type == "array")
                            {
                                if (contentItem.Value.Schema.Items != null)
                                {
                                    if (contentItem.Value.Schema.Items.Type == "object")
                                    {
                                        response.ResponseObjectName = contentItem.Value.Schema.Items.Reference.Id;
                                        response.ResponseObjectType = ResponseTypeEnum.List_Object;
                                    }
                                    else if (contentItem.Value.Schema.Items.Type == "integer")
                                    {
                                        if (contentItem.Value.Schema.Items.Format != null)
                                        {
                                            response.ResponseObjectName = contentItem.Value.Schema.Items.Format;
                                            response.ResponseObjectType = ResponseTypeEnum.List_Integer;
                                        }
                                        else
                                        {
                                            response.ResponseObjectName = "";
                                            response.ResponseObjectType = ResponseTypeEnum.List_Integer;
                                        }
                                    }
                                    else
                                    {
                                        response.ResponseObjectName = $"contentItem.Value.Schema.Items.Type = {contentItem.Value.Schema.Items.Type}";
                                        response.ResponseObjectType = ResponseTypeEnum.FailedToParse;
                                    }
                                }
                                else if(contentItem.Value.Schema.Reference != null)
                                {
                                    response.ResponseObjectName = contentItem.Value.Schema.Reference.Id;
                                    response.ResponseObjectType = ResponseTypeEnum.List_Object;
                                }
                                else
                                {
                                    response.ResponseObjectName = $"contentItem.Value.Schema.Items and contentItem.Value.Schema.Reference were NULL";
                                    response.ResponseObjectType = ResponseTypeEnum.FailedToParse;
                                }
                            }
                            else if (contentItem.Value.Schema.Type == "object")
                            {
                                if (contentItem.Value.Schema.AdditionalProperties == null)
                                {
                                    response.ResponseObjectName = contentItem.Value.Schema.Reference.Id;
                                    response.ResponseObjectType = ResponseTypeEnum.Object;
                                }
                                else if (contentItem.Value.Schema.AdditionalProperties.Type == "integer")
                                {
                                    response.ResponseObjectName = "";
                                    response.ResponseObjectType = ResponseTypeEnum.Integer;
                                }
                                else if (contentItem.Value.Schema.AdditionalProperties.Type == "string")
                                {
                                    response.ResponseObjectName = "";
                                    response.ResponseObjectType = ResponseTypeEnum.String;
                                }
                                else if (contentItem.Value.Schema.AdditionalProperties.Type == "object")
                                {
                                    response.ResponseObjectName = contentItem.Value.Schema.AdditionalProperties.Reference.Id;
                                    response.ResponseObjectType = ResponseTypeEnum.Object;
                                }
                                else if (contentItem.Value.Schema.AdditionalProperties.Type == "array")
                                {
                                    if (contentItem.Value.Schema.AdditionalProperties.Items.Type == null)
                                    {
                                        response.ResponseObjectName = contentItem.Value.Schema.AdditionalProperties.Items.Reference.Id;
                                        response.ResponseObjectType = ResponseTypeEnum.List_Object;
                                    }
                                    else if (contentItem.Value.Schema.AdditionalProperties.Items.Type == "integer")
                                    {
                                        response.ResponseObjectName = $"";
                                        response.ResponseObjectType = ResponseTypeEnum.List_Integer;
                                    }
                                    else if (contentItem.Value.Schema.AdditionalProperties.Items.Type == "string")
                                    {
                                        response.ResponseObjectName = $"";
                                        response.ResponseObjectType = ResponseTypeEnum.List_String;
                                    }
                                    else
                                    {
                                        response.ResponseObjectName = $"contentItem.Value.Schema.AdditionalProperties.Items.Type = {contentItem.Value.Schema.AdditionalProperties.Items.Type}";
                                        response.ResponseObjectType = ResponseTypeEnum.FailedToParse;
                                    }
                                }
                                else
                                {
                                    response.ResponseObjectName = $"contentItem.Value.Schema.AdditionalProperties.Type = {contentItem.Value.Schema.AdditionalProperties.Type}";
                                    response.ResponseObjectType = ResponseTypeEnum.FailedToParse;
                                }
                            }
                        }
                    }
                }
                else
                {
                    response.ResponseObjectName = "no return object detected.";
                    response.ResponseObjectType = ResponseTypeEnum.none;
                }
            }
            catch (Exception ex)
            {
                response.ResponseObjectName = ex.Message;
                response.ResponseObjectType = ResponseTypeEnum.FailedToParse;
            }
            return response;
        }

        /// <summary>
        /// Adds any request body item to the endpoint.
        /// </summary>
        /// <param name="openApiOperation">the <see cref="OpenApiOperation"/> that might contain user defined extensions.</param>
        public static void AddRequestBody(this EndPoint source, OpenApiOperation openApiOperation)
        {
            source.requestBody = new RequestBody();
            if (openApiOperation.RequestBody != null && openApiOperation.RequestBody.Content.Count > 0)
            {
                if (openApiOperation.RequestBody.Content.ContainsKey(ParserTokens.OAS_JsonContentType))
                {
                    Add_ApplicationJson_RequestBody(source, openApiOperation);
                }
                else if (openApiOperation.RequestBody.Content.ContainsKey(ParserTokens.OAS_FormDataContentType))
                {
                    Add_FormData_RequestBody(source, openApiOperation);
                }
                else
                {
                    source.requestBody.RequestBodyContentType = openApiOperation.RequestBody.Content.Keys.ToString(",");
                }
            }
            else
            {
                source.requestBody.RequestBodyContentType = ParserTokens.OAS_NoContentFound;
            }
        }

        private static void Add_ApplicationJson_RequestBody(this EndPoint source, OpenApiOperation openApiOperation)
        {
            if (openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema != null)
            {
                source.requestBody.RequestBodyContentType = ParserTokens.OAS_JsonContentType;

                if (openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Items != null)
                {
                    if (openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Items.Type == "object")
                    {
                        source.requestBody.RequestBodyJsonObject = openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Items.Reference.Id;
                    }
                    else
                    {
                        source.requestBody.RequestBodyJsonObject = openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Items.Type;
                    }
                }
                else
                {
                    if (openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Type == "object")
                    {
                        if (openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Reference == null)
                        {
                            source.requestBody.RequestBodyJsonObject = openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.AdditionalProperties.Type;
                        }
                        else
                        {
                            source.requestBody.RequestBodyJsonObject = openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Reference.Id;
                        }
                    }
                    else
                    {
                        source.requestBody.RequestBodyJsonObject = openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Type;
                    }
                }
                source.requestBody.RequestBodySchemaType = openApiOperation.RequestBody.Content[ParserTokens.OAS_JsonContentType].Schema.Type;
            }
            else
            {
                source.requestBody.RequestBodyString = "The RequestBody.Content.Schema was null.";
            }
        }

        private static void Add_FormData_RequestBody(this EndPoint source, OpenApiOperation openApiOperation)
        {
            source.requestBody.RequestBodyContentType = ParserTokens.OAS_FormDataContentType;

            if (openApiOperation.RequestBody.Content[ParserTokens.OAS_FormDataContentType].Schema.Type != null)
            {
                source.requestBody.RequestBodyFormObjectOrType = openApiOperation.RequestBody.Content[ParserTokens.OAS_FormDataContentType].Schema.Type;
            }

            if (openApiOperation.RequestBody.Content[ParserTokens.OAS_FormDataContentType].Schema.Properties != null)
            {
                source.requestBody.AddProperties(openApiOperation.RequestBody.Content[ParserTokens.OAS_FormDataContentType].Schema, $"{source.Method} - {source.UriPath}");
            }
        }
        #endregion
    }
}
