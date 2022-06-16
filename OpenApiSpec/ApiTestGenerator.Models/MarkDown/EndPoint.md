#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## EndPoint Class

```csharp
public class EndPoint
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EndPoint
### Constructors

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.EndPoint()'></a>

## EndPoint() Constructor

Creates a new instance of the [EndPoint](EndPoint.md 'ApiTestGenerator.Models.ApiDocs.EndPoint') object.

```csharp
public EndPoint();
```

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.EndPoint(string)'></a>

## EndPoint(string) Constructor

Creates a new instance of the [EndPoint](EndPoint.md 'ApiTestGenerator.Models.ApiDocs.EndPoint') object  
and assigns the passed in value to the [controllerName](EndPoint.md#ApiTestGenerator.Models.ApiDocs.EndPoint.controllerName 'ApiTestGenerator.Models.ApiDocs.EndPoint.controllerName') property.

```csharp
public EndPoint(string ControllerName);
```
#### Parameters

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.EndPoint(string).ControllerName'></a>

`ControllerName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the name of the API controller that houses this endpoint.
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.controllerName'></a>

## EndPoint.controllerName Property

[Extension] The name of the [Controller](Controller.md 'ApiTestGenerator.Models.ApiDocs.Controller') object  
that contains this endpoint.

```csharp
public string controllerName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.customEndPointObjects'></a>

## EndPoint.customEndPointObjects Property

A list of [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') items discovered in  
the Api Document json.

```csharp
public System.Collections.Generic.List<ApiTestGenerator.Models.ApiDocs.CustomEndPointObject> customEndPointObjects { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

### Remarks
The types of objects can be seen in this enum:  
[CustomEndPointObjectTypeEnum](CustomEndPointObjectTypeEnum.md 'ApiTestGenerator.Models.Enums.CustomEndPointObjectTypeEnum')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.Depricated'></a>

## EndPoint.Depricated Property

From the [http://spec.openapis.org/oas/v3.0.3#operation-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#operation-object 'http://spec.openapis.org/oas/v3.0.3#operation-object')  
field by the same name.

```csharp
public bool Depricated { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### Remarks
Declares this operation to be deprecated. Consumers SHOULD refrain from usage   
of the declared operation. Default value is false.

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.Description'></a>

## EndPoint.Description Property

From the [http://spec.openapis.org/oas/v3.0.3#operation-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#operation-object 'http://spec.openapis.org/oas/v3.0.3#operation-object')  
field by the same name.

```csharp
public string Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
A verbose explanation of the operation behavior. CommonMark syntax MAY be used   
for rich text representation.

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.EndpointId'></a>

## EndPoint.EndpointId Property

```csharp
public int EndpointId { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.IsForTestingPurposes'></a>

## EndPoint.IsForTestingPurposes Property

A boolean that indicates if this method is exposed solely for  
the Tester Role and woill not be used by the application.  
All Test methods contain [ApiTestGenerator.Models.Consts.ParserTokens.DESC_ForTestingPurposes](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.Consts.ParserTokens.DESC_ForTestingPurposes 'ApiTestGenerator.Models.Consts.ParserTokens.DESC_ForTestingPurposes')  
in the Description field.

```csharp
public bool IsForTestingPurposes { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.IsLookupMethod'></a>

## EndPoint.IsLookupMethod Property

A boolean that describes if the method contains the  
[TKN_LookupMethod](ParserTokens.md#ApiTestGenerator.Models.Consts.ParserTokens.TKN_LookupMethod 'ApiTestGenerator.Models.Consts.ParserTokens.TKN_LookupMethod') tag indicating  
that the method is used to grab lookup values for other  
methods in the API.

```csharp
public bool IsLookupMethod { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.Method'></a>

## EndPoint.Method Property

This is the 'Name' of the   
[http://spec.openapis.org/oas/v3.0.3#operation-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#operation-object 'http://spec.openapis.org/oas/v3.0.3#operation-object') object   
which is essentially the URI. When combined with the [UriPath](EndPoint.md#ApiTestGenerator.Models.ApiDocs.EndPoint.UriPath 'ApiTestGenerator.Models.ApiDocs.EndPoint.UriPath')  
property, it describes a unique operation on an API.

```csharp
public string Method { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.parameters'></a>

## EndPoint.parameters Property

A list of [Parameter](Parameter.md 'ApiTestGenerator.Models.ApiDocs.Parameter') objects.

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiDocs.Parameter> parameters { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[Parameter](Parameter.md 'ApiTestGenerator.Models.ApiDocs.Parameter')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.recordedResponseBody'></a>

## EndPoint.recordedResponseBody Property

This string holds the response body text that was present  
for the given Http Endpoint. Note: This only applies when   
building an ApiSet from sources like HTTP Archive files.

```csharp
public string recordedResponseBody { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.recordedResponseMessage'></a>

## EndPoint.recordedResponseMessage Property

This object holds the response object that was present  
for the given Http Endpoint. Note: This only applies when   
building an ApiSet from sources like HTTP Archive files.

```csharp
public System.Net.Http.HttpResponseMessage recordedResponseMessage { get; set; }
```

#### Property Value
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.ReportingName'></a>

## EndPoint.ReportingName Property

[Extension] This is a name to add to the request in the test harness that will  
be used for grouping results of the tests.

```csharp
public string ReportingName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.requestBody'></a>

## EndPoint.requestBody Property

[RequestBody](RequestBody.md 'ApiTestGenerator.Models.ApiDocs.RequestBody')

```csharp
public ApiTestGenerator.Models.ApiDocs.RequestBody requestBody { get; set; }
```

#### Property Value
[RequestBody](RequestBody.md 'ApiTestGenerator.Models.ApiDocs.RequestBody')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.ResponseItems'></a>

## EndPoint.ResponseItems Property

A list of [ResponseObject](ResponseObject.md 'ApiTestGenerator.Models.ApiDocs.ResponseObject') items that the endpoint can supply.

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiDocs.ResponseObject> ResponseItems { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ResponseObject](ResponseObject.md 'ApiTestGenerator.Models.ApiDocs.ResponseObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.Summary'></a>

## EndPoint.Summary Property

From the [http://spec.openapis.org/oas/v3.0.3#operation-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#operation-object 'http://spec.openapis.org/oas/v3.0.3#operation-object')  
field by the same name.

```csharp
public string Summary { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
A short summary of what the operation does.

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.UriPath'></a>

## EndPoint.UriPath Property

This is the path of the endpoint and is derived from the 'Name' of the  
[http://spec.openapis.org/oas/v3.0.3#path-item-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#path-item-object 'http://spec.openapis.org/oas/v3.0.3#path-item-object') object   
which describes the type of request that the endpoint expects.   
When combined with the [Method](EndPoint.md#ApiTestGenerator.Models.ApiDocs.EndPoint.Method 'ApiTestGenerator.Models.ApiDocs.EndPoint.Method')  
property, it describes a unique operation on an API.

```csharp
public string UriPath { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.EndPoint.Version'></a>

## EndPoint.Version Property

The version of the API that contains this operation.

```csharp
public string Version { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')