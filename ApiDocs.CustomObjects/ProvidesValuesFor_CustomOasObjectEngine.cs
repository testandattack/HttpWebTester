using ApiTestGenerator.Models.ApiDocs;
using ApiTestGenerator.Models.Consts;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using GTC.Extensions;

namespace ApiDocs.CustomObjects
{
    /// <summary>
    /// A custom Operation Object parser
    /// </summary>
    public class ProvidesValuesFor_CustomOasObjectEngine : CustomOasObjectEngine
    {
        /// <summary>
        /// This is the method that parses the <see cref="OpenApiOperation.Extensions"/> objects from the OAS.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ParseObject(object sender, CustomOasObjectEventArgs e) 
        {
            if (e.operation.Extensions != null && e.operation.Extensions.Count > 0)
            {
                foreach (var operationExtension in e.operation.Extensions)
                {
                    if (operationExtension.Key == ParserTokens.TKN_ProvidesValuesFor)
                    {
                        var Item = new CustomOasObject();
                        Item.CustomObjectName = ParserTokens.TKN_ProvidesValuesFor;
                        string endpointNames = ((OpenApiString)(operationExtension.Value)).Value;
                        if (endpointNames.Length > 0)
                        {
                            Item.CustomObjectValue = endpointNames.CsvStrToList();
                            e.customObjects.collection.Add(Item);
                        }
                    }
                }
            }
        }
    }
}
