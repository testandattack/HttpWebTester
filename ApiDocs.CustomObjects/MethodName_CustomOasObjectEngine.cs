using ApiTestGenerator.Models.ApiDocs;
using ApiTestGenerator.Models.Consts;
using Microsoft.OpenApi.Any;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDocs.CustomObjects
{
    public class MethodName_CustomOasObjectEngine : CustomOasObjectEngine
    {

        public MethodName_CustomOasObjectEngine() { }


        public override void ParseObject(object sender, CustomOasObjectEventArgs e) 
        {
            if (e.operation.Extensions != null && e.operation.Extensions.Count > 0)
            {
                foreach (var operationExtension in e.operation.Extensions)
                {
                    if (operationExtension.Key == ParserTokens.TKN_MethodName)
                    {
                        var Item = new CustomOasObject();
                        Item.CustomObjectName = ParserTokens.TKN_MethodName;
                        Item.CustomObjectValue = ((OpenApiString)(operationExtension.Value)).Value;
                        e.customObjects.collection.Add(Item);
                    }
                }
            }
        }
    }
}
