using ApiSet.Models.ApiDocs;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using GTC.HttpWebTester.Settings;
using ApiDocs.CustomObjects;
using ApiSet.Engines.Interfaces;
using GTC.OpenApiUtilities;
using ApiSet.Models.Consts;

namespace ApiSet.Engines
{
    public class OasToProperty : IProperty<OpenApiSchema>
    {
        #region -- Properties -----
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        #endregion

        #region -- Constructors -----
        public OasToProperty(ILogger logger, ISettings settings)
        {
            _settings = settings;
            _logger = logger;
        }
        #endregion

        #region -- Methods -----
        public Property GetPropertyItem(OpenApiSchema property, string propertyName, string parentItemName)
        {
            if (property.Type == null)
            {
                Property gtcProperty = new Property($"Property {propertyName} for {parentItemName} did not have a type.");
                gtcProperty.Name = propertyName;
                _logger.Error("[{method}]: Property {propertyKey} for {parentItemName} did not have a type."
                    , "AddProperties", propertyName, parentItemName);
                GetReferenceInfo(ref gtcProperty, property);
                return gtcProperty;
            }
            else
            {
                _logger.Verbose("[{method}]: Parsing {propertyKey} for {parentItemName}"
                    , "AddProperties", propertyName, parentItemName);
                Property gtcProperty = new Property();

                gtcProperty.Name = propertyName;

                gtcProperty.Type = property.GetSchemaItemType();

                _logger.Verbose("[{method}]: Found  {propertyType} for {propertyName}"
                    , "AddProperties", gtcProperty.Type, gtcProperty.Name);

                if (gtcProperty.Type.StartsWith(ParserTokens.PARAM_List_Precursor))
                {
                    gtcProperty.IsArray = true;
                    gtcProperty.arrayType = gtcProperty.Type.Remove(0, ParserTokens.PARAM_List_Precursor.Length);
                }

                if (property.Format != null)
                {
                    gtcProperty.Format = property.Format;
                }

                GetReferenceInfo(ref gtcProperty,property);
                return gtcProperty;
            }
        }

        private string GetDescriptionAndCustomObjects(OpenApiSchema property)
        {
            if (string.IsNullOrEmpty(property.Description))
                return string.Empty;

            return property.Description;
        }

        private void GetReferenceInfo(ref Property property, OpenApiSchema propertySchema)
        {
            if (propertySchema.Reference != null)
            {
                _logger.Verbose("[{method}]: Found single object Reference {ReferenceId} in {propertyName}"
                    , "GetReferenceInfo", propertySchema.Reference.Id, property.Name);
                property.Reference = propertySchema.Reference.Id;

            }
            else if (propertySchema.Items != null)
            {
                if (propertySchema.Items.Reference != null)
                {
                    _logger.Verbose("[{method}]: Found array Reference {ReferenceId} in {propertyName}"
                        , "GetReferenceInfo", propertySchema.Items.Reference.Id, property.Name);
                    property.Reference = propertySchema.Items.Reference.Id;
                }
            }
            else
            {
                _logger.Verbose("[{method}]: Did not find a reference in {propertyName}"
                    , "GetReferenceInfo", property.Name);
            }
        }
        #endregion
    }
}
