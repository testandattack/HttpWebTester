#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')

## ApiTestGenerator.Models Assembly
### Namespaces

<a name='ApiTestGenerator.Models.ApiAnalyzer'></a>

## ApiTestGenerator.Models.ApiAnalyzer Namespace

| Classes | |
| :--- | :--- |
| [ApiSetAnalysis](ApiSetAnalysis.md 'ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis') | |
| [EndpointSummary](EndpointSummary.md 'ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary') | |
| [InputParameter](InputParameter.md 'ApiTestGenerator.Models.ApiAnalyzer.InputParameter') | |
| [LookupComponent](LookupComponent.md 'ApiTestGenerator.Models.ApiAnalyzer.LookupComponent') | |
| [LookupEndPoint](LookupEndPoint.md 'ApiTestGenerator.Models.ApiAnalyzer.LookupEndPoint') | |

<a name='ApiTestGenerator.Models.ApiDocs'></a>

## ApiTestGenerator.Models.ApiDocs Namespace

| Classes | |
| :--- | :--- |
| [AbbreviatedResponseObject](AbbreviatedResponseObject.md 'ApiTestGenerator.Models.ApiDocs.AbbreviatedResponseObject') | [Extension] Holds a few key properties about the response object. |
| [ApiSet](ApiSet.md 'ApiTestGenerator.Models.ApiDocs.ApiSet') | This class defines a Model used for translating various different web based API  calls between the different formats. It is based on the Open API Specification. The idea is to allow an engine to populate this model with information from sources like:  and turn the results into a test harness that can be executed. |
| [ApiSetSummaryModel](ApiSetSummaryModel.md 'ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel') | A set of counts for various items in the ApiSet after parasing it. |
| [Component](Component.md 'ApiTestGenerator.Models.ApiDocs.Component') | This class defines a container to house the custom class objects that are used for responses from the API. |
| [Controller](Controller.md 'ApiTestGenerator.Models.ApiDocs.Controller') | An object that stores a list of certain [http://spec.openapis.org/oas/v3.0.3#operation-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#operation-object 'http://spec.openapis.org/oas/v3.0.3#operation-object') items grouped by the 'name' of the controller they are associated with in code. |
| [CustomOasObject](CustomOasObject.md 'ApiTestGenerator.Models.ApiDocs.CustomOasObject') | This is the base class for creating custom objects. |
| [CustomOasObjectCollection](CustomOasObjectCollection.md 'ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection') | A class that contains a collection of custom objects added to the OAS documentation. |
| [CustomOasObjectEventArgs](CustomOasObjectEventArgs.md 'ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs') | The class to hold the properties that get passed into any event handler for custom objects. |
| [EndPoint](EndPoint.md 'ApiTestGenerator.Models.ApiDocs.EndPoint') | This object is the equivalent to an OAS "Operation" object. |
| [ExampleValue](ExampleValue.md 'ApiTestGenerator.Models.ApiDocs.ExampleValue') | An object loosely based on the [http://spec.openapis.org/oas/v3.0.3#example-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#example-object 'http://spec.openapis.org/oas/v3.0.3#example-object') object. |
| [Parameter](Parameter.md 'ApiTestGenerator.Models.ApiDocs.Parameter') | An object the contains information about input parameters for OpenApi endpoint calls It is based on the [https://spec.openapis.org/oas/v3.0.0#parameter-object](https://spec.openapis.org/oas/v3.0.0#parameter-object 'https://spec.openapis.org/oas/v3.0.0#parameter-object') OAS object. |
| [Property](Property.md 'ApiTestGenerator.Models.ApiDocs.Property') | A custom object that implements some of the  [http://spec.openapis.org/oas/v3.0.3#properties](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#properties 'http://spec.openapis.org/oas/v3.0.3#properties') listed in  the OpenApiSpec. |
| [RequestBody](RequestBody.md 'ApiTestGenerator.Models.ApiDocs.RequestBody') | This class defines a container to house the Request Body info needed to build a proper request. |
| [ResponseObject](ResponseObject.md 'ApiTestGenerator.Models.ApiDocs.ResponseObject') | |

<a name='ApiTestGenerator.Models.Consts'></a>

## ApiTestGenerator.Models.Consts Namespace

| Classes | |
| :--- | :--- |
| [ParserTokens](ParserTokens.md 'ApiTestGenerator.Models.Consts.ParserTokens') | This class contains constant string values that are used for parsing OAS documents. |

<a name='ApiTestGenerator.Models.Enums'></a>

## ApiTestGenerator.Models.Enums Namespace

| Enums | |
| :--- | :--- |
| [AnalyzerErrorCategoryEnum](AnalyzerErrorCategoryEnum.md 'ApiTestGenerator.Models.Enums.AnalyzerErrorCategoryEnum') | Defines the category of error in the ApiSetAnalyzerError list |
| [CustomEndPointObjectTypeEnum](CustomEndPointObjectTypeEnum.md 'ApiTestGenerator.Models.Enums.CustomEndPointObjectTypeEnum') | Enumerates the types of [CustomEndPointObject](https://docs.microsoft.com/en-us/dotnet/api/CustomEndPointObject 'CustomEndPointObject')s that are currently supported. |
| [ObjectTypeEnum](ObjectTypeEnum.md 'ApiTestGenerator.Models.Enums.ObjectTypeEnum') | Enumerates the types of data objects that can be found in an [Microsoft.OpenApi.Models.OpenApiSchema](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiSchema 'Microsoft.OpenApi.Models.OpenApiSchema') object |
| [ParameterIsInEnum](ParameterIsInEnum.md 'ApiTestGenerator.Models.Enums.ParameterIsInEnum') | Lists the locations within an OpenApiOperation that a parameter can show up. |
| [ResponseTypeEnum](ResponseTypeEnum.md 'ApiTestGenerator.Models.Enums.ResponseTypeEnum') | Describes the type of object returned from the API. |
| [RestrictToRolesEnum](RestrictToRolesEnum.md 'ApiTestGenerator.Models.Enums.RestrictToRolesEnum') | Enumerates the types of roles that can be seen in a  [RestrictTo](https://docs.microsoft.com/en-us/dotnet/api/RestrictTo 'RestrictTo') object. |
