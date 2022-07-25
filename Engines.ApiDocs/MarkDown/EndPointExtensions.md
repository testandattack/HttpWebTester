#### [Engines.ApiDocs](Engines.ApiDocs.md 'Engines.ApiDocs')
### [Engines.ApiDocs.Extensions](Engines.ApiDocs.md#Engines.ApiDocs.Extensions 'Engines.ApiDocs.Extensions')

## EndPointExtensions Class

An object that is based on the [http://spec.openapis.org/oas/v3.0.3#operation-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#operation-object 'http://spec.openapis.org/oas/v3.0.3#operation-object')
object, but is enhanced with extra information to help with test generation.
The 'Name' of the object is stored in the Key of the KeyValuePair and is made 
by combining the [Method](https://docs.microsoft.com/en-us/dotnet/api/Method 'Method') and [UriPath](https://docs.microsoft.com/en-us/dotnet/api/UriPath 'UriPath') objects

```csharp
public static class EndPointExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EndPointExtensions
### Methods

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.AddParameters(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation,int)'></a>

## EndPointExtensions.AddParameters(this EndPoint, OpenApiOperation, int) Method

Adds the input parameters to the object

```csharp
public static void AddParameters(this ApiSet.Models.ApiDocs.EndPoint source, Microsoft.OpenApi.Models.OpenApiOperation openApiOperation, int operationId);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.AddParameters(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation,int).source'></a>

`source` [ApiSet.Models.ApiDocs.EndPoint](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiDocs.EndPoint 'ApiSet.Models.ApiDocs.EndPoint')

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.AddParameters(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation,int).openApiOperation'></a>

`openApiOperation` [Microsoft.OpenApi.Models.OpenApiOperation](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiOperation 'Microsoft.OpenApi.Models.OpenApiOperation')

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.AddParameters(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation,int).operationId'></a>

`operationId` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.AddRequestBody(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation)'></a>

## EndPointExtensions.AddRequestBody(this EndPoint, OpenApiOperation) Method

Adds any request body item to the endpoint.

```csharp
public static void AddRequestBody(this ApiSet.Models.ApiDocs.EndPoint source, Microsoft.OpenApi.Models.OpenApiOperation openApiOperation);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.AddRequestBody(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation).source'></a>

`source` [ApiSet.Models.ApiDocs.EndPoint](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiDocs.EndPoint 'ApiSet.Models.ApiDocs.EndPoint')

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.AddRequestBody(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation).openApiOperation'></a>

`openApiOperation` [Microsoft.OpenApi.Models.OpenApiOperation](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiOperation 'Microsoft.OpenApi.Models.OpenApiOperation')

the [Microsoft.OpenApi.Models.OpenApiOperation](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiOperation 'Microsoft.OpenApi.Models.OpenApiOperation') that might contain user defined extensions.

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.AddResponseItem(Microsoft.OpenApi.Models.OpenApiResponse,string)'></a>

## EndPointExtensions.AddResponseItem(OpenApiResponse, string) Method

Walks the operation's Response array to find the response object associated with 
ResponseItem type of '200'.

```csharp
public static ApiSet.Models.ApiDocs.ResponseObject AddResponseItem(Microsoft.OpenApi.Models.OpenApiResponse openApiResponse, string ContentItem="application/json");
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.AddResponseItem(Microsoft.OpenApi.Models.OpenApiResponse,string).openApiResponse'></a>

`openApiResponse` [Microsoft.OpenApi.Models.OpenApiResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiResponse 'Microsoft.OpenApi.Models.OpenApiResponse')

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.AddResponseItem(Microsoft.OpenApi.Models.OpenApiResponse,string).ContentItem'></a>

`ContentItem` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Describes the type of response object to look for

#### Returns
[ApiSet.Models.ApiDocs.ResponseObject](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiDocs.ResponseObject 'ApiSet.Models.ApiDocs.ResponseObject')

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.CheckFor_IsLookupMethod(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation)'></a>

## EndPointExtensions.CheckFor_IsLookupMethod(this EndPoint, OpenApiOperation) Method

Sets the [IsLookupMethod](https://docs.microsoft.com/en-us/dotnet/api/IsLookupMethod 'IsLookupMethod') flag based on the
presence or absence of the [ApiSet.Models.Consts.ParserTokens.TKN_LookupMethod](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.Consts.ParserTokens.TKN_LookupMethod 'ApiSet.Models.Consts.ParserTokens.TKN_LookupMethod') custom extension

```csharp
public static void CheckFor_IsLookupMethod(this ApiSet.Models.ApiDocs.EndPoint source, Microsoft.OpenApi.Models.OpenApiOperation openApiOperation);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.CheckFor_IsLookupMethod(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation).source'></a>

`source` [ApiSet.Models.ApiDocs.EndPoint](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiDocs.EndPoint 'ApiSet.Models.ApiDocs.EndPoint')

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.CheckFor_IsLookupMethod(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation).openApiOperation'></a>

`openApiOperation` [Microsoft.OpenApi.Models.OpenApiOperation](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiOperation 'Microsoft.OpenApi.Models.OpenApiOperation')

the [Microsoft.OpenApi.Models.OpenApiOperation](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiOperation 'Microsoft.OpenApi.Models.OpenApiOperation') that might contain user defined extensions.

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.CheckForDynamicDates(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation)'></a>

## EndPointExtensions.CheckForDynamicDates(this EndPoint, OpenApiOperation) Method

Adds any [ApiSet.Models.Consts.ParserTokens.PARAM_StartDate](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.Consts.ParserTokens.PARAM_StartDate 'ApiSet.Models.Consts.ParserTokens.PARAM_StartDate') or 
[ApiSet.Models.Consts.ParserTokens.PARAM_EndDate](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.Consts.ParserTokens.PARAM_EndDate 'ApiSet.Models.Consts.ParserTokens.PARAM_EndDate') items to parameters that
have the same name.

```csharp
public static void CheckForDynamicDates(this ApiSet.Models.ApiDocs.EndPoint source, Microsoft.OpenApi.Models.OpenApiOperation openApiOperation);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.CheckForDynamicDates(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation).source'></a>

`source` [ApiSet.Models.ApiDocs.EndPoint](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiDocs.EndPoint 'ApiSet.Models.ApiDocs.EndPoint')

<a name='Engines.ApiDocs.Extensions.EndPointExtensions.CheckForDynamicDates(thisApiSet.Models.ApiDocs.EndPoint,Microsoft.OpenApi.Models.OpenApiOperation).openApiOperation'></a>

`openApiOperation` [Microsoft.OpenApi.Models.OpenApiOperation](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiOperation 'Microsoft.OpenApi.Models.OpenApiOperation')

the [Microsoft.OpenApi.Models.OpenApiOperation](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiOperation 'Microsoft.OpenApi.Models.OpenApiOperation') that might contain user defined extensions.