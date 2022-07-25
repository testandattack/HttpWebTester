using ApiSet.Models.ApiDocs;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using GTC.HttpWebTester.Settings;
using ApiDocs.CustomObjects;
using ApiSet.Engines.Interfaces;
using GTC.Extensions;
using ApiSet.Models.Enums;
using Newtonsoft.Json;
using OpenApiUtilities;
using Microsoft.OpenApi.Any;

namespace ApiSet.Engines
{
    public class OasToResponseObject : IResponseObject<OpenApiOperation>
    {
        #region -- Properties -----
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly IAbbreviatedResponseObject<KeyValuePair<string, OpenApiSchema>> _abbreviatedResponseObjectEngine;
        #endregion

        #region -- Constructors -----
        public OasToResponseObject(ILogger logger
                            , ISettings settings
                            , IAbbreviatedResponseObject<KeyValuePair<string, OpenApiSchema>> abbreviatedResponseObjectEngine)
        {
            _settings = settings;
            _logger = logger;
            _abbreviatedResponseObjectEngine = abbreviatedResponseObjectEngine;
        }
        #endregion

        #region -- Methods -----
        public Dictionary<string, ResponseObject> GetResponseObjects(OpenApiOperation apiOperation)
        {
            Dictionary<string, ResponseObject>  responseItems = new Dictionary<string, ResponseObject>();

            foreach (var response in apiOperation.Responses)
            {
                responseItems.Add(response.Key, AddResponseItem(response.Value));
            }
            return responseItems;
        }

        /// <summary>
        /// Walks the operation's Response array to find the response object associated with 
        /// ResponseItem type of '200'.
        /// </summary>
        /// <param name="openApiOperation">the <see cref="OpenApiOperation"/> that might contain user defined extensions.</param>
        /// <param name="ResponseItem"> the response item to look for. Defaults to '200'</param>
        /// <param name="ContentItem">Describes the type of response object to look for</param>
        private ResponseObject AddResponseItem(OpenApiResponse openApiResponse, string ContentItem = "application/json")
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
                        if (contentItem.Value.Schema == null)
                        {
                            // Found an object being returned that does not have a schema.
                            if (contentItem.Value.Example != null)
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
                                else if (contentItem.Value.Schema.Reference != null)
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
        #endregion
    }
}
