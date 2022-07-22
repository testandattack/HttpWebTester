using ApiTestGenerator.Models.ApiAnalyzer;
using ApiTestGenerator.Models.ApiDocs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engines.ApiDocs
{
    public class InputParameterAnalyzer
    {
        private ApiDoc _apiSet;

        public Dictionary<string, InputParameter> InputParameters { get; set; }

        public InputParameterAnalyzer()
        {
            InputParameters = new Dictionary<string, InputParameter>();
        }

        public bool Contains(InputParameter inputParameter)
        {
            if (this.InputParameters.Values.Contains(inputParameter))
            {
                return true;
            }
            return false;
        }

        public void LoadInputParameters(ApiDoc apiSet)
        {
            _apiSet = apiSet;
            foreach (var controller in apiSet.Controllers.Values)
            {
                foreach (var endpoint in controller.EndPoints)
                {
                    AddOrUpdate(endpoint.Value, endpoint.Key);
                }
            }
        }

        private void AddOrUpdate(EndPoint endPoint, string endpointName)
        {
            foreach (var parameter in endPoint.parameters.Values)
            {
                if(InputParameters.ContainsKey(parameter.Name))
                {
                    var item = InputParameters[parameter.Name];
                    item.UsedByTheseEndpoints.Add($"{endPoint.Method} | {endPoint.UriPath}");
                    Log.ForContext<InputParameterAnalyzer>().Verbose(
                        "[{method}]: Updateing input parameter {param} with additional endpoint {endpoint} "
                        , "AddOrUpdate"
                        , parameter.Name
                        , endpointName);
                }
                else
                {
                    InputParameter inputParameter = new InputParameter(
                        parameter.Name
                        , parameter.Description
                        , parameter.Type
                        , parameter.IsArray
                        , parameter.arrayType
                        , parameter.Format
                        , parameter.Required
                        , parameter.inputProvider
                        , parameter.ShowsUpIn);

                    inputParameter.UsedByTheseEndpoints.Add(endpointName);
                    inputParameter.MatchesTheseComponents = GetMatchingComponents(inputParameter);
                    InputParameters.Add(parameter.Name, inputParameter);
                    Log.ForContext<InputParameterAnalyzer>().Verbose(
                        "[{method}]: Adding new input parameter {param} for endpoint {endpoint}"
                        , "AddOrUpdate"
                        , parameter.Name
                        , endpointName);
                }
            }
        }

        private List<string> GetMatchingComponents(InputParameter parameter)
        {
            // First, make the name singular if the item is part of an array
            string paramName;
            if(parameter.Type == "array" && parameter.Name.ToLower().EndsWith("s"))
            {
                paramName = parameter.Name.Remove(parameter.Name.Length - 1);
            }
            else
            {
                paramName = parameter.Name;
            }

            List<string> componentList = new List<string>();
            foreach (var component in _apiSet.Components)
            {
                
                if(component.Value.properties.ContainsKey(paramName))
                {
                    componentList.Add(component.Key);
                }
            }
            return componentList;
        }
    }
}
