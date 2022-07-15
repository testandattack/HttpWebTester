#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## ApiSetSummaryModel Class

A set of counts for various items in the ApiSet after  
parasing it.

```csharp
public class ApiSetSummaryModel
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiSetSummaryModel
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.apiInfo'></a>

## ApiSetSummaryModel.apiInfo Property

A copy of the [OpenApiInfo](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#info-object 'http://spec.openapis.org/oas/v3.0.3#info-object') object  
from the API Documentation

```csharp
public Microsoft.OpenApi.Models.OpenApiInfo apiInfo { get; set; }
```

#### Property Value
[Microsoft.OpenApi.Models.OpenApiInfo](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiInfo 'Microsoft.OpenApi.Models.OpenApiInfo')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.apiRoot'></a>

## ApiSetSummaryModel.apiRoot Property

The UriStem portion of the Swagger Operation that preceeds the   
"controller" name i nthe path.

```csharp
public string apiRoot { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.apiRootSourceLocation'></a>

## ApiSetSummaryModel.apiRootSourceLocation Property

Lists the source for the [apiRoot](ApiSet.md#ApiTestGenerator.Models.ApiDocs.ApiSet.apiRoot 'ApiTestGenerator.Models.ApiDocs.ApiSet.apiRoot') object

```csharp
public ApiTestGenerator.Models.Enums.ApiRootSourceEnum apiRootSourceLocation { get; set; }
```

#### Property Value
[ApiRootSourceEnum](ApiRootSourceEnum.md 'ApiTestGenerator.Models.Enums.ApiRootSourceEnum')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.numActiveEndpoints'></a>

## ApiSetSummaryModel.numActiveEndpoints Property

The number of non-depricated [EndPoint](EndPoint.md 'ApiTestGenerator.Models.ApiDocs.EndPoint') items in the set.

```csharp
public int numActiveEndpoints { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.numComponents'></a>

## ApiSetSummaryModel.numComponents Property

The number of [Component](Component.md 'ApiTestGenerator.Models.ApiDocs.Component') items in the set.

```csharp
public int numComponents { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.numControllers'></a>

## ApiSetSummaryModel.numControllers Property

the number of [Controller](Controller.md 'ApiTestGenerator.Models.ApiDocs.Controller') items in the set.

```csharp
public int numControllers { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.numDepricated'></a>

## ApiSetSummaryModel.numDepricated Property

The number of depricated [EndPoint](EndPoint.md 'ApiTestGenerator.Models.ApiDocs.EndPoint') items in the set.

```csharp
public int numDepricated { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.NumEndpointsWithExample'></a>

## ApiSetSummaryModel.NumEndpointsWithExample Property

The number of endpoints that have one or more [ExampleValue](ExampleValue.md 'ApiTestGenerator.Models.ApiDocs.ExampleValue') items   
for their input parameters.

```csharp
public int NumEndpointsWithExample { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.NumEndpointsWithExamples'></a>

## ApiSetSummaryModel.NumEndpointsWithExamples Property

The number of endpoints that have one or more [System.Collections.Generic.List&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1') items   
for their input parameters.

```csharp
public int NumEndpointsWithExamples { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.numErrors'></a>

## ApiSetSummaryModel.numErrors Property

The number of non-fatal errors that occurred during analysis

```csharp
public int numErrors { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.numInputParametersWithoutLookupProperty'></a>

## ApiSetSummaryModel.numInputParametersWithoutLookupProperty Property

The number of input parameters that do not appear to be related  
to any Lookup [Component](Component.md 'ApiTestGenerator.Models.ApiDocs.Component')s in the API.

```csharp
public int numInputParametersWithoutLookupProperty { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.numInputParametersWithoutProperty'></a>

## ApiSetSummaryModel.numInputParametersWithoutProperty Property

The number of input parameters that do not appear to be related  
to any [Component](Component.md 'ApiTestGenerator.Models.ApiDocs.Component')s in the API.

```csharp
public int numInputParametersWithoutProperty { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.numInputProperties'></a>

## ApiSetSummaryModel.numInputProperties Property

The number of [Component](Component.md 'ApiTestGenerator.Models.ApiDocs.Component') Properties that are used as  
input parameters.

```csharp
public int numInputProperties { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.numLookupComponents'></a>

## ApiSetSummaryModel.numLookupComponents Property

The number of DTOs that are responses from Lookup Endpoint items

```csharp
public int numLookupComponents { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

### Remarks
This count is tracked separately from the Lookup endpoints because there are  
sometimes multiple endpoints returning the same lookup DTO. ALSO, this count does  
not include primitive response types.

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.numLookupEndpoints'></a>

## ApiSetSummaryModel.numLookupEndpoints Property

The number of Lookup Endpoint items found in the set.

```csharp
public int numLookupEndpoints { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.numLookupProperties'></a>

## ApiSetSummaryModel.numLookupProperties Property

The number of individual objects that can be extracted from returned  
[Component](Component.md 'ApiTestGenerator.Models.ApiDocs.Component')s of Lookup Endpoints.

```csharp
public int numLookupProperties { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.numTestMethods'></a>

## ApiSetSummaryModel.numTestMethods Property

The number of non-depricated [EndPoint](EndPoint.md 'ApiTestGenerator.Models.ApiDocs.EndPoint') items  
in the set that exist solely for testing services.

```csharp
public int numTestMethods { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.oasVersion'></a>

## ApiSetSummaryModel.oasVersion Property

A string containing the Open API Specification version of the OAS document that this summary represents.

```csharp
public string oasVersion { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.propertyFormats'></a>

## ApiSetSummaryModel.propertyFormats Property

A list of all of the unique [Format](Property.md#ApiTestGenerator.Models.ApiDocs.Property.Format 'ApiTestGenerator.Models.ApiDocs.Property.Format')  
entries found in the documentation.

```csharp
public System.Collections.Generic.List<string> propertyFormats { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.propertyTypes'></a>

## ApiSetSummaryModel.propertyTypes Property

A list of all of the unique [Type](Property.md#ApiTestGenerator.Models.ApiDocs.Property.Type 'ApiTestGenerator.Models.ApiDocs.Property.Type')  
entries found in the documentation.

```csharp
public System.Collections.Generic.List<string> propertyTypes { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel.responseStatuses'></a>

## ApiSetSummaryModel.responseStatuses Property

A list of all unique [Microsoft.OpenApi.Models.OpenApiResponse](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiResponse 'Microsoft.OpenApi.Models.OpenApiResponse') status   
codes found in the documentation.

```csharp
public System.Collections.Generic.List<string> responseStatuses { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')