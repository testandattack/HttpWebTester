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
        /// <remarks>
        /// See this code example for how to handle creating your own custom parser
        /// <code>
        /// public override void ParseObject(object sender, CustomOasObjectEventArgs e)
        /// {
        ///    if (e.operation.Extensions != null && e.operation.Extensions.Count > 0)
        ///    {
        ///        foreach (var operationExtension in e.operation.Extensions)
        ///        {
        ///            if (operationExtension.Key == "x-Whatever-YourTokenNameMioghtBe")
        ///            {
        ///                // Create a new custom OAS object for the ApiSet
        ///                var Item = new CustomOasObject();
        ///
        ///                // Name the object
        ///                Item.CustomObjectName = "x-Whatever-YourTokenNameMioghtBe";
        ///
        ///                // Retrieve the string value
        ///                string endpointNames = ((OpenApiString)(operationExtension.Value)).Value;
        ///
        ///                //Act on the value here.
        ///                if (endpointNames.Length > 0)
        ///                {
        ///                    Item.CustomObjectValue = endpointNames.CsvStrToList();
        ///                    e.customObjects.collection.Add(Item);
        ///                }
        ///            }
        ///        }
        ///    }
        /// }
        /// </code>
        /// </remarks>
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
