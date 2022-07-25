#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Models.ApiAnalyzer](ApiTestGenerator.Models.md#ApiSet.Models.ApiAnalyzer 'ApiSet.Models.ApiAnalyzer')

## ApiSetAnalysis Class

```csharp
public class ApiSetAnalysis
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiSetAnalysis
### Constructors

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.ApiSetAnalysis()'></a>

## ApiSetAnalysis() Constructor

The default constructor

```csharp
public ApiSetAnalysis();
```

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.ApiSetAnalysis(ApiSet.Models.ApiDocs.ApiDoc)'></a>

## ApiSetAnalysis(ApiDoc) Constructor

A constructor that lets you provide a pre-populated ApiDoc  
to this object.

```csharp
public ApiSetAnalysis(ApiSet.Models.ApiDocs.ApiDoc ApiSet);
```
#### Parameters

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.ApiSetAnalysis(ApiSet.Models.ApiDocs.ApiDoc).ApiSet'></a>

`ApiSet` [ApiDoc](ApiDoc.md 'ApiSet.Models.ApiDocs.ApiDoc')

The [ApiSet](https://docs.microsoft.com/en-us/dotnet/api/ApiSet 'ApiSet') to add to this Analysis model.
### Properties

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.AnalysisDate'></a>

## ApiSetAnalysis.AnalysisDate Property

The local Date-Time that the analysis was performed.

```csharp
public System.DateTime AnalysisDate { get; set; }
```

#### Property Value
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.AnalysisName'></a>

## ApiSetAnalysis.AnalysisName Property

The name of the ApiDoc that was analyzed

```csharp
public string AnalysisName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.analyzerErrors'></a>

## ApiSetAnalysis.analyzerErrors Property

A collection of [ApiSet.Models.ApiAnalyzer.ApiSetAnalyzerError](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiAnalyzer.ApiSetAnalyzerError 'ApiSet.Models.ApiAnalyzer.ApiSetAnalyzerError') items found while analyzing the ApiDoc.

```csharp
public System.Collections.Generic.Dictionary<string,ApiSet.Models.ApiAnalyzer.ApiSetAnalyzerError> analyzerErrors { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ApiSet.Models.ApiAnalyzer.ApiSetAnalyzerError](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiAnalyzer.ApiSetAnalyzerError 'ApiSet.Models.ApiAnalyzer.ApiSetAnalyzerError')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.apiSet'></a>

## ApiSetAnalysis.apiSet Property

The [ApiSet.Models.ApiDocs](ApiTestGenerator.Models.md#ApiSet.Models.ApiDocs 'ApiSet.Models.ApiDocs') object to analyze

```csharp
public ApiSet.Models.ApiDocs.ApiDoc apiSet { get; set; }
```

#### Property Value
[ApiDoc](ApiDoc.md 'ApiSet.Models.ApiDocs.ApiDoc')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.depricatedEndpoints'></a>

## ApiSetAnalysis.depricatedEndpoints Property

A list of all endpoints that have the 'Depricated' attribute.

```csharp
public System.Collections.Generic.List<string> depricatedEndpoints { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.endpointSummaries'></a>

## ApiSetAnalysis.endpointSummaries Property

A list of every endpoint with an [EndpointSummary](EndpointSummary.md 'ApiSet.Models.ApiAnalyzer.EndpointSummary') for each one.

```csharp
public System.Collections.Generic.Dictionary<string,ApiSet.Models.ApiAnalyzer.EndpointSummary> endpointSummaries { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[EndpointSummary](EndpointSummary.md 'ApiSet.Models.ApiAnalyzer.EndpointSummary')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.endpointsWithMultipleMethods'></a>

## ApiSetAnalysis.endpointsWithMultipleMethods Property

A list of all endpoints that have the same URL, but offer different  
methods for calling.

```csharp
public System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<int,string>> endpointsWithMultipleMethods { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.endpointsWithoutUrlParams'></a>

## ApiSetAnalysis.endpointsWithoutUrlParams Property

A List containing the EndpointIds of all endpoints that do NOT contain an  
input parameter in the URL

```csharp
public System.Collections.Generic.List<int> endpointsWithoutUrlParams { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.endpointsWithUrlParams'></a>

## ApiSetAnalysis.endpointsWithUrlParams Property

A List containing the EndpointIds of all endpoints that contain an  
input parameter in the URL

```csharp
public System.Collections.Generic.List<int> endpointsWithUrlParams { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.inputParameters'></a>

## ApiSetAnalysis.inputParameters Property

A list of all the [ApiDocs.Engines.Parameter](https://docs.microsoft.com/en-us/dotnet/api/ApiDocs.Engines.Parameter 'ApiDocs.Engines.Parameter') items.  
these are all of the items that will be used at some point as  
inputs to the API calls.

```csharp
public System.Collections.Generic.Dictionary<string,ApiSet.Models.ApiAnalyzer.InputParameter> inputParameters { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[InputParameter](InputParameter.md 'ApiSet.Models.ApiAnalyzer.InputParameter')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.inputParametersNotInLookupProperties'></a>

## ApiSetAnalysis.inputParametersNotInLookupProperties Property

A list of the [InputParameter](InputParameter.md 'ApiSet.Models.ApiAnalyzer.InputParameter')s that do not have matching entries in  
the [lookupProperties](ApiSetAnalysis.md#ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.lookupProperties 'ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.lookupProperties') collection.

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiSet.Models.ApiAnalyzer.InputParameter> inputParametersNotInLookupProperties { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[InputParameter](InputParameter.md 'ApiSet.Models.ApiAnalyzer.InputParameter')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.inputParametersNotInProperties'></a>

## ApiSetAnalysis.inputParametersNotInProperties Property

A list of the [InputParameter](InputParameter.md 'ApiSet.Models.ApiAnalyzer.InputParameter')s that do not have matching entries in  
the [properties](ApiSetAnalysis.md#ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.properties 'ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.properties') collection.

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiSet.Models.ApiAnalyzer.InputParameter> inputParametersNotInProperties { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[InputParameter](InputParameter.md 'ApiSet.Models.ApiAnalyzer.InputParameter')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.lookupComponents'></a>

## ApiSetAnalysis.lookupComponents Property

A collection of [LookupComponent](LookupComponent.md 'ApiSet.Models.ApiAnalyzer.LookupComponent') items

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiSet.Models.ApiAnalyzer.LookupComponent> lookupComponents { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[LookupComponent](LookupComponent.md 'ApiSet.Models.ApiAnalyzer.LookupComponent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.lookupEndpoints'></a>

## ApiSetAnalysis.lookupEndpoints Property

A collection of [LookupEndPoint](LookupEndPoint.md 'ApiSet.Models.ApiAnalyzer.LookupEndPoint') items

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiSet.Models.ApiAnalyzer.LookupEndPoint> lookupEndpoints { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[LookupEndPoint](LookupEndPoint.md 'ApiSet.Models.ApiAnalyzer.LookupEndPoint')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.lookupProperties'></a>

## ApiSetAnalysis.lookupProperties Property

A collection of [Property](Property.md 'ApiSet.Models.ApiDocs.Property') objects that are in components that act   
as responses to Lookup Endpoints.

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiSet.Models.ApiDocs.AbbreviatedResponseObject> lookupProperties { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[AbbreviatedResponseObject](AbbreviatedResponseObject.md 'ApiSet.Models.ApiDocs.AbbreviatedResponseObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.properties'></a>

## ApiSetAnalysis.properties Property

A list of all the [ApiDocs.Engines.Property](https://docs.microsoft.com/en-us/dotnet/api/ApiDocs.Engines.Property 'ApiDocs.Engines.Property') items.   
This lists all of the primitive values that get returned as part  
of the response objects.

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiSet.Models.ApiAnalyzer.PropertySummary> properties { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[ApiSet.Models.ApiAnalyzer.PropertySummary](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiAnalyzer.PropertySummary 'ApiSet.Models.ApiAnalyzer.PropertySummary')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.requestBodySummary'></a>

## ApiSetAnalysis.requestBodySummary Property

A list showing the quantities and types of request bodies in the API

```csharp
public ApiSet.Models.ApiAnalyzer.RequestBodySummary requestBodySummary { get; set; }
```

#### Property Value
[ApiSet.Models.ApiAnalyzer.RequestBodySummary](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiAnalyzer.RequestBodySummary 'ApiSet.Models.ApiAnalyzer.RequestBodySummary')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.sortedEndpointSummaries'></a>

## ApiSetAnalysis.sortedEndpointSummaries Property

A collection of [EndpointSummary](EndpointSummary.md 'ApiSet.Models.ApiAnalyzer.EndpointSummary') items found while analyzing the ApiDoc.

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiSet.Models.ApiAnalyzer.EndpointSummary> sortedEndpointSummaries { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[EndpointSummary](EndpointSummary.md 'ApiSet.Models.ApiAnalyzer.EndpointSummary')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiSet.Models.ApiAnalyzer.ApiSetAnalysis.summaryInfo'></a>

## ApiSetAnalysis.summaryInfo Property

[ApiSetSummaryModel](ApiSetSummaryModel.md 'ApiSet.Models.ApiDocs.ApiSetSummaryModel')

```csharp
public ApiSet.Models.ApiDocs.ApiSetSummaryModel summaryInfo { get; set; }
```

#### Property Value
[ApiSetSummaryModel](ApiSetSummaryModel.md 'ApiSet.Models.ApiDocs.ApiSetSummaryModel')