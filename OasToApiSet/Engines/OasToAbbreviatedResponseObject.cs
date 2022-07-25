using ApiSet.Models.ApiDocs;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using GTC.HttpWebTester.Settings;
using ApiDocs.CustomObjects;
using ApiSet.Engines.Interfaces;
using ApiSet.Models.Consts;

namespace ApiSet.Engines
{
    public class OasToAbbreviatedResponseObject : IAbbreviatedResponseObject<KeyValuePair<string, OpenApiSchema>>
    {
        #region -- Properties -----
        private readonly ISettings _settings;
        private readonly ILogger _logger;

        #endregion

        #region -- Constructors -----
        public OasToAbbreviatedResponseObject(ILogger logger, ISettings settings)
        {
            _settings = settings;
            _logger = logger;
        }
        #endregion

        #region -- Methods -----
        public AbbreviatedResponseObject GetAbbreviatedResponseObject(KeyValuePair<string, OpenApiSchema> property, string endPointName)
        {
            _logger.Debug("[{method}]: Adding AbbreviatedResponseObject to {EndPoint}."
                , "BuildAndAddAbbreviatedResponseObject", endPointName);
            AbbreviatedResponseObject item = new AbbreviatedResponseObject();

            try
            {
                #region -- handle Type -----
                // Even though Type is a required field, SwaggerGen does not handle
                // the C# type "Dynamic" properly, so we have to account for it here.
                if (property.Value.Type == null)
                {
                    item.type = ParserTokens.PARAM_MissingTypeField;
                    _logger.Warning("[{method}]: Found ResponseObject in {EndPoint} without a Type. Assuming it is of type Dynamic"
                        , "BuildAndAddAbbreviatedResponseObject", endPointName);
                }
                else
                    item.type = property.Value.Type;
                #endregion

                #region -- handle Nullable -----
                if (property.Value.Nullable == true)
                    item.nullable = "true";
                else
                    item.nullable = "false";
                #endregion

                if (item.type == "array")
                {
                    #region -- handle Reference -----
                    if (property.Value.Items.Reference != null)
                        item.reference = property.Value.Items.Reference.Id;
                    else if (property.Value.Items.Type != null)
                        item.reference = property.Value.Items.Type;
                    else
                        item.reference = ParserTokens.PARAM_MissingInfo;
                    #endregion

                    #region -- handle Format -----
                    if (property.Value.Items.Format != null)
                        item.format = property.Value.Items.Format;
                    else
                        item.format = string.Empty;
                    #endregion
                }
                else if (item.type == "string")
                {
                    item.reference = "";
                    item.format = "";
                }
                else
                {
                    #region -- handle Reference -----
                    if (property.Value.Reference != null)
                        item.reference = property.Value.Reference.ReferenceV3;
                    else
                        item.reference = string.Empty;
                    #endregion

                    #region -- handle Format -----
                    if (property.Value.Format != null)
                        item.format = property.Value.Format;
                    else
                        item.format = string.Empty;
                    #endregion
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to build AbbreviatedResponseObject for {propertyName} in {endpointName}", property.Key, endPointName);
                item.reference = "Failed to parse the item";
            }
            return item;
        }
        #endregion
    }
}
