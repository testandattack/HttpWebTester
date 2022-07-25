using Engines.ApiDocs;
using Engines.ApiDocs.Extensions;
using ApiSet.Models.ApiDocs;
using ApiSet.Models.Consts;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using GTC.Extensions;
using GTC.OpenApiUtilities;

namespace Engines.ApiDocs
{
    public static class ParameterExtensions
    {
        /// <summary>
        /// Parses the <see cref="OpenApiParameter.Description"/> string (if present)
        /// and finds any custom objects added to it.
        /// </summary>
        /// <param name="source">the <see cref="Parameter"/> object to add items to.</param>
        /// <param name="parameter">the <see cref="OpenApiParameter"/> object that contains the Description to parse.</param>
        public static void GetDescriptionAndCustomObjects(this Parameter source, OpenApiParameter parameter)
        {
            if (string.IsNullOrEmpty(parameter.Description))
                return;

            source.Description = parameter.Description;
            //source.CheckForTestDataFilter(parameter.Description);
            //source.CheckForGetsInputFrom(parameter.Description);
            //source.CheckForStartDate(parameter.Description);
            //source.CheckForEndDate(parameter.Description);
        }

/*        public static void CheckForTestDataFilter(this Parameter source, string description)
        {
            string str = description.FindSubString(ParserTokens.TKN_TestDataFilter, ")");

            if (str != string.Empty)
            {
                TestDataFilter testDataFilter = new TestDataFilter(str);
                source.customEndPointObjects.Add(testDataFilter);
            }
        }

        public static void CheckForGetsInputFrom(this Parameter source, string description)
        {
            string str = description.FindSubString(ParserTokens.TKN_GetsInputFrom, ")");

            if (str != string.Empty)
            {
                GetsInputFrom getsInputFrom = new GetsInputFrom(str);
                source.customEndPointObjects.Add(getsInputFrom);
            }
        }

        public static void CheckForStartDate(this Parameter source, string description)
        {
            if (source.Name.ToLower().StartsWith("start") == false)
                return;

 
            string str = description.FindSubString(ParserTokens.PARAM_StartDate, ")");
            if (str != string.Empty)
            {
                CalculatedDateValue calcultedDate = new CalculatedDateValue(str);
                source.customEndPointObjects.Add(calcultedDate);
            }
        }

        public static void CheckForEndDate(this Parameter source, string description)
        {
            if (source.Name.ToLower().StartsWith("end") == false)
                return;


            string str = description.FindSubString(ParserTokens.PARAM_EndDate, ")");
            if (str != string.Empty)
            {
                CalculatedDateValue calcultedDate = new CalculatedDateValue(str);
                source.customEndPointObjects.Add(calcultedDate);
            }
        }
*/

        public static void GetParameterExamples(this Parameter source, OpenApiParameter parameter)
        {
            if (parameter.Examples == null)
            {
                return;
            }

            Dictionary<string, ExampleValue> examples = new Dictionary<string, ExampleValue>();
            foreach (var example in parameter.Examples)
            {
                examples.Add(example.Key, GetExampleValue(example.Value));
            }
            source.ExampleValues = examples;
        }

        private static ExampleValue GetExampleValue(OpenApiExample example)
        {
            Type exampleType = example.Value.GetType();

            // If the type is NOT primitive, then handle it. 
            if (exampleType == typeof(OpenApiArray))
            {
                return new ExampleValue("OpenApiArray", ((OpenApiArray)(example.Value)).ToString());
            }
            else if (exampleType == typeof(OpenApiObject))
            {
                return new ExampleValue("OpenApiObject", "not currently supported");
            }
            else  // If it is primitive, we'll handle it  here
            {
                return new ExampleValue(exampleType.ToString(), example.Value.GetPrimitiveValue());
            }
        }

        public static void GetParameterExample(this Parameter source, OpenApiParameter parameter)
        {

            if (parameter.Example == null)
            {
                return;
            }
            else
            {
                source.ExampleValue = GetExampleValue(parameter.Example);
            }
        }

        private static ExampleValue GetExampleValue(IOpenApiAny example)
        {
            Type exampleType = example.GetType();

            // If the type is NOT primitive, then handle it. 
            if (exampleType == typeof(OpenApiArray))
            {
                return new ExampleValue("OpenApiArray", ((OpenApiArray)(example)).ToString());
            }
            else if (exampleType == typeof(OpenApiObject))
            {
                return new ExampleValue("OpenApiObject", "not currently supported");
            }
            else  // If it is primitive, we'll handle it  here
            {
                return new ExampleValue(exampleType.ToString(), example.GetPrimitiveValue());
            }

        }
    }
}
