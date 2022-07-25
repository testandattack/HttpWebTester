#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')

## ApiSet.Models Assembly
### Namespaces

<a name='ApiSet.Engines.Interfaces'></a>

## ApiSet.Engines.Interfaces Namespace

| Interfaces | |
| :--- | :--- |
| [IAbbreviatedResponseObject&lt;T&gt;](IAbbreviatedResponseObject_T_.md 'ApiSet.Engines.Interfaces.IAbbreviatedResponseObject<T>') | |
| [IExampleValue&lt;T&gt;](IExampleValue_T_.md 'ApiSet.Engines.Interfaces.IExampleValue<T>') | |
| [IProperty&lt;T&gt;](IProperty_T_.md 'ApiSet.Engines.Interfaces.IProperty<T>') | |
| [IRequestBody&lt;T&gt;](IRequestBody_T_.md 'ApiSet.Engines.Interfaces.IRequestBody<T>') | |
| [IResponseObject&lt;T&gt;](IResponseObject_T_.md 'ApiSet.Engines.Interfaces.IResponseObject<T>') | |

<a name='ApiSet.Models.ApiAnalyzer'></a>

## ApiSet.Models.ApiAnalyzer Namespace

| Classes | |
| :--- | :--- |
| [ApiSetAnalysis](ApiSetAnalysis.md 'ApiSet.Models.ApiAnalyzer.ApiSetAnalysis') | |
| [EndpointSummary](EndpointSummary.md 'ApiSet.Models.ApiAnalyzer.EndpointSummary') | |
| [InputParameter](InputParameter.md 'ApiSet.Models.ApiAnalyzer.InputParameter') | |
| [LookupComponent](LookupComponent.md 'ApiSet.Models.ApiAnalyzer.LookupComponent') | |
| [LookupEndPoint](LookupEndPoint.md 'ApiSet.Models.ApiAnalyzer.LookupEndPoint') | |

<a name='ApiSet.Models.ApiDocs'></a>

## ApiSet.Models.ApiDocs Namespace

| Classes | |
| :--- | :--- |
| [AbbreviatedResponseObject](AbbreviatedResponseObject.md 'ApiSet.Models.ApiDocs.AbbreviatedResponseObject') | [Extension] Holds a few key properties about the response object. |
| [ApiDoc](ApiDoc.md 'ApiSet.Models.ApiDocs.ApiDoc') | This class defines a Model used for translating various different web based API <br/>calls between the different formats. It is based on the Open API Specification.<br/>The idea is to allow an engine to populate this model with information from<br/>sources like:<br/><br/>and turn the results into a test harness that can be executed. |
| [ApiSetError](ApiSetError.md 'ApiSet.Models.ApiDocs.ApiSetError') | |
| [ApiSetSummaryModel](ApiSetSummaryModel.md 'ApiSet.Models.ApiDocs.ApiSetSummaryModel') | A set of counts for various items in the ApiDoc after<br/>parasing it. |
| [Component](Component.md 'ApiSet.Models.ApiDocs.Component') | This class defines a container to house the custom class objects<br/>that are used for responses from the API. |
| [Controller](Controller.md 'ApiSet.Models.ApiDocs.Controller') | An object that stores a list of certain<br/>[http://spec.openapis.org/oas/v3.0.3#operation-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#operation-object 'http://spec.openapis.org/oas/v3.0.3#operation-object') items<br/>grouped by the 'name' of the controller they are associated with in code. |
| [CustomOasObject](CustomOasObject.md 'ApiSet.Models.ApiDocs.CustomOasObject') | This is the base class for creating custom objects. |
| [CustomOasObjectCollection](CustomOasObjectCollection.md 'ApiSet.Models.ApiDocs.CustomOasObjectCollection') | A class that contains a collection of custom objects added to the OAS documentation. |
| [CustomOasObjectEventArgs](CustomOasObjectEventArgs.md 'ApiSet.Models.ApiDocs.CustomOasObjectEventArgs') | The class to hold the properties that get passed into any event handler for<br/>custom objects. |
| [EndPoint](EndPoint.md 'ApiSet.Models.ApiDocs.EndPoint') | This object is the equivalent to an OAS "Operation" object. |
| [Error](Error.md 'ApiSet.Models.ApiDocs.Error') | A base class for storing errors when working with ApiSets and ApiSetAnalyzers |
| [ExampleValue](ExampleValue.md 'ApiSet.Models.ApiDocs.ExampleValue') | An object loosely based on the [http://spec.openapis.org/oas/v3.0.3#example-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#example-object 'http://spec.openapis.org/oas/v3.0.3#example-object')<br/>object. |
| [Parameter](Parameter.md 'ApiSet.Models.ApiDocs.Parameter') | An object the contains information about input parameters for OpenApi endpoint calls<br/>It is based on the [https://spec.openapis.org/oas/v3.0.0#parameter-object](https://spec.openapis.org/oas/v3.0.0#parameter-object 'https://spec.openapis.org/oas/v3.0.0#parameter-object') OAS object. |
| [Property](Property.md 'ApiSet.Models.ApiDocs.Property') | A custom object that implements some of the <br/>[http://spec.openapis.org/oas/v3.0.3#properties](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#properties 'http://spec.openapis.org/oas/v3.0.3#properties') listed in <br/>the OpenApiSpec. |
| [RequestBody](RequestBody.md 'ApiSet.Models.ApiDocs.RequestBody') | This class defines a container to house the Request Body<br/>info needed to build a proper request. |
| [ResponseObject](ResponseObject.md 'ApiSet.Models.ApiDocs.ResponseObject') | |

<a name='ApiSet.Models.Consts'></a>

## ApiSet.Models.Consts Namespace

| Classes | |
| :--- | :--- |
| [ParserTokens](ParserTokens.md 'ApiSet.Models.Consts.ParserTokens') | This class contains constant string values that are used for parsing OAS documents. |

<a name='ApiSet.Models.Enums'></a>

## ApiSet.Models.Enums Namespace

| Enums | |
| :--- | :--- |
| [AnalyzerErrorCategoryEnum](AnalyzerErrorCategoryEnum.md 'ApiSet.Models.Enums.AnalyzerErrorCategoryEnum') | Defines the category of error in the ApiSetAnalyzerError list |
| [ApiRootSourceEnum](ApiRootSourceEnum.md 'ApiSet.Models.Enums.ApiRootSourceEnum') | Lists the source for the [ApiSet.apiRoot](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.apiRoot 'ApiSet.apiRoot') object |
| [CustomEndPointObjectTypeEnum](CustomEndPointObjectTypeEnum.md 'ApiSet.Models.Enums.CustomEndPointObjectTypeEnum') | Enumerates the types of [CustomEndPointObject](https://docs.microsoft.com/en-us/dotnet/api/CustomEndPointObject 'CustomEndPointObject')s that are currently supported. |
| [ObjectTypeEnum](ObjectTypeEnum.md 'ApiSet.Models.Enums.ObjectTypeEnum') | Enumerates the types of data objects that can be found in<br/>an [Microsoft.OpenApi.Models.OpenApiSchema](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiSchema 'Microsoft.OpenApi.Models.OpenApiSchema') object |
| [ParameterIsInEnum](ParameterIsInEnum.md 'ApiSet.Models.Enums.ParameterIsInEnum') | Lists the locations within an OpenApiOperation that a parameter can show up. |
| [ResponseTypeEnum](ResponseTypeEnum.md 'ApiSet.Models.Enums.ResponseTypeEnum') | Describes the type of object returned from the API. |
| [RestrictToRolesEnum](RestrictToRolesEnum.md 'ApiSet.Models.Enums.RestrictToRolesEnum') | Enumerates the types of roles that can be seen in a <br/>[RestrictTo](https://docs.microsoft.com/en-us/dotnet/api/RestrictTo 'RestrictTo') object. |

<a name='ApiSet.Models.Extensions'></a>

## ApiSet.Models.Extensions Namespace

| Classes | |
| :--- | :--- |
| [ApiSetExtensions](ApiSetExtensions.md 'ApiSet.Models.Extensions.ApiSetExtensions') | |
