using Engines.ApiDocs;
using ApiTestGenerator.Models.ApiDocs;
using ApiTestGenerator.Models.Consts;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using GTC.OpenApiUtilities;

namespace Engines.ApiDocs.Extensions
{
    public static class PropertyExtensions
    {
        /// <summary>
        /// Parses the <see cref="OpenApiSchema.Description"/> string (if present)
        /// and finds any custom objects added to it.
        /// </summary>
        /// <param name="source">the <see cref="Property"/> object to add items to.</param>
        /// <param name="property">the <see cref="OpenApiSchema"/> object that contains the Description to parse.</param>
        public static void GetDescriptionAndCustomObjects(this Property source, OpenApiSchema property)
        {
            if (string.IsNullOrEmpty(property.Description))
                return;

            source.Description = property.Description;
        }

        public static void GetReferenceInfo(this Property property, OpenApiSchema propertySchema)
        {
            if (propertySchema.Reference != null)
            {
                Log.ForContext<Property>().Verbose("[{method}]: Found single object Reference {ReferenceId} in {propertyName}"
                    , "GetReferenceInfo", propertySchema.Reference.Id, property.Name);
                property.Reference = propertySchema.Reference.Id;

            }
            else if (propertySchema.Items != null)
            {
                if (propertySchema.Items.Reference != null)
                {
                    Log.ForContext<Property>().Verbose("[{method}]: Found array Reference {ReferenceId} in {propertyName}"
                        , "GetReferenceInfo", propertySchema.Items.Reference.Id, property.Name);
                    property.Reference = propertySchema.Items.Reference.Id;
                }
            }
            else
            {
                Log.ForContext<Property>().Verbose("[{method}]: Did not find a reference in {propertyName}"
                    , "GetReferenceInfo", property.Name);
            }
        }

        public static Property GetPropertyItem(this OpenApiSchema property, string propertyName, string parentItemName)
        {
            if (property.Type == null)
            {
                Property gtcProperty = new Property($"Property {propertyName} for {parentItemName} did not have a type.");
                gtcProperty.Name = propertyName;
                Log.ForContext<Property>().Error("[{method}]: Property {propertyKey} for {parentItemName} did not have a type."
                    , "AddProperties", propertyName, parentItemName);
                gtcProperty.GetReferenceInfo(property);
                return gtcProperty;
            }
            else
            {
                Log.ForContext<Property>().Verbose("[{method}]: Parsing {propertyKey} for {parentItemName}"
                    , "AddProperties", propertyName, parentItemName);
                Property gtcProperty = new Property();

                gtcProperty.Name = propertyName;

                gtcProperty.Type = property.GetSchemaItemType();
                
                Log.ForContext<Property>().Verbose("[{method}]: Found  {propertyType} for {propertyName}"
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

                gtcProperty.GetReferenceInfo(property);
                return gtcProperty;
            }

        }
    }
}
