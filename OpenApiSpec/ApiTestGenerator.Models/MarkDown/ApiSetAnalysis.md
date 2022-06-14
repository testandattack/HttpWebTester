#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiAnalyzer](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiAnalyzer 'ApiTestGenerator.Models.ApiAnalyzer')

## ApiSetAnalysis Class

```csharp
public class ApiSetAnalysis
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiSetAnalysis
### Properties

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.analyzerErrors'></a>

## ApiSetAnalysis.analyzerErrors Property

A collection of [ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalyzerError](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalyzerError 'ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalyzerError') items found while analyzing the ApiSet.

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalyzerError> analyzerErrors { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalyzerError](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalyzerError 'ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalyzerError')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.apiSet'></a>

## ApiSetAnalysis.apiSet Property

The [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs') object to analyze

```csharp
public ApiTestGenerator.Models.ApiDocs.ApiSet apiSet { get; set; }
```

#### Property Value
[ApiSet](ApiSet.md 'ApiTestGenerator.Models.ApiDocs.ApiSet')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.depricatedEndpoints'></a>

## ApiSetAnalysis.depricatedEndpoints Property

A list of all endpoints that have the 'Depricated' attribute.

```csharp
public System.Collections.Generic.List<string> depricatedEndpoints { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.endPointRestrictions'></a>

## ApiSetAnalysis.endPointRestrictions Property

A list of every endpoint showing what filter restrictions it allows.

```csharp
public System.Collections.Generic.Dictionary<string,string> endPointRestrictions { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.endpointRestrictionSummary'></a>

## ApiSetAnalysis.endpointRestrictionSummary Property

A list of the different RestrictTo filters in the API along with  
all of the endpoints that use the filter.

```csharp
public ApiTestGenerator.Models.ApiAnalyzer.EndpointRestrictionSummary endpointRestrictionSummary { get; set; }
```

#### Property Value
[ApiTestGenerator.Models.ApiAnalyzer.EndpointRestrictionSummary](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiAnalyzer.EndpointRestrictionSummary 'ApiTestGenerator.Models.ApiAnalyzer.EndpointRestrictionSummary')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.endpointSummaries'></a>

## ApiSetAnalysis.endpointSummaries Property

A list of every endpoint with an [EndpointSummary](EndpointSummary.md 'ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary') for each one.

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary> endpointSummaries { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[EndpointSummary](EndpointSummary.md 'ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.inputParameters'></a>

## ApiSetAnalysis.inputParameters Property

A list of all the [ApiDocs.Engines.Parameter](https://docs.microsoft.com/en-us/dotnet/api/ApiDocs.Engines.Parameter 'ApiDocs.Engines.Parameter') items.  
these are all of the items that will be used at some point as  
inpouts to the API calls.

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiAnalyzer.InputParameter> inputParameters { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[InputParameter](InputParameter.md 'ApiTestGenerator.Models.ApiAnalyzer.InputParameter')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.inputParametersNotInLookupProperties'></a>

## ApiSetAnalysis.inputParametersNotInLookupProperties Property

A list of the [InputParameter](InputParameter.md 'ApiTestGenerator.Models.ApiAnalyzer.InputParameter')s that do not have matching entries in  
the [lookupProperties](ApiSetAnalysis.md#ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.lookupProperties 'ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.lookupProperties') collection.

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiTestGenerator.Models.ApiAnalyzer.InputParameter> inputParametersNotInLookupProperties { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[InputParameter](InputParameter.md 'ApiTestGenerator.Models.ApiAnalyzer.InputParameter')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.inputParametersNotInProperties'></a>

## ApiSetAnalysis.inputParametersNotInProperties Property

A list of the [InputParameter](InputParameter.md 'ApiTestGenerator.Models.ApiAnalyzer.InputParameter')s that do not have matching entries in  
the [properties](ApiSetAnalysis.md#ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.properties 'ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.properties') collection.

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiTestGenerator.Models.ApiAnalyzer.InputParameter> inputParametersNotInProperties { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[InputParameter](InputParameter.md 'ApiTestGenerator.Models.ApiAnalyzer.InputParameter')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.lookupComponents'></a>

## ApiSetAnalysis.lookupComponents Property

A collection of [LookupComponent](LookupComponent.md 'ApiTestGenerator.Models.ApiAnalyzer.LookupComponent') items

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiTestGenerator.Models.ApiAnalyzer.LookupComponent> lookupComponents { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[LookupComponent](LookupComponent.md 'ApiTestGenerator.Models.ApiAnalyzer.LookupComponent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.lookupEndpoints'></a>

## ApiSetAnalysis.lookupEndpoints Property

A collection of [LookupEndPoint](LookupEndPoint.md 'ApiTestGenerator.Models.ApiAnalyzer.LookupEndPoint') items

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiTestGenerator.Models.ApiAnalyzer.LookupEndPoint> lookupEndpoints { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[LookupEndPoint](LookupEndPoint.md 'ApiTestGenerator.Models.ApiAnalyzer.LookupEndPoint')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.lookupProperties'></a>

## ApiSetAnalysis.lookupProperties Property

A collection of [Property](Property.md 'ApiTestGenerator.Models.ApiDocs.Property') objects that are in components that act   
as responses to Lookup Endpoints.

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiTestGenerator.Models.ApiDocs.AbbreviatedResponseObject> lookupProperties { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[AbbreviatedResponseObject](AbbreviatedResponseObject.md 'ApiTestGenerator.Models.ApiDocs.AbbreviatedResponseObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.properties'></a>

## ApiSetAnalysis.properties Property

A list of all the [ApiDocs.Engines.Property](https://docs.microsoft.com/en-us/dotnet/api/ApiDocs.Engines.Property 'ApiDocs.Engines.Property') items.   
This lists all of the primitive values that get returned as part  
of the response objects.

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiTestGenerator.Models.ApiAnalyzer.PropertySummary> properties { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[ApiTestGenerator.Models.ApiAnalyzer.PropertySummary](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiAnalyzer.PropertySummary 'ApiTestGenerator.Models.ApiAnalyzer.PropertySummary')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.requestBodySummary'></a>

## ApiSetAnalysis.requestBodySummary Property

A list showing the quantities and types of request bodies in the API

```csharp
public ApiTestGenerator.Models.ApiAnalyzer.RequestBodySummary requestBodySummary { get; set; }
```

#### Property Value
[ApiTestGenerator.Models.ApiAnalyzer.RequestBodySummary](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiAnalyzer.RequestBodySummary 'ApiTestGenerator.Models.ApiAnalyzer.RequestBodySummary')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.sortedEndpointSummaries'></a>

## ApiSetAnalysis.sortedEndpointSummaries Property

A collection of [EndpointSummary](EndpointSummary.md 'ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary') items found while analyzing the ApiSet.

```csharp
public System.Collections.Generic.SortedDictionary<string,ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary> sortedEndpointSummaries { get; set; }
```

#### Property Value
[System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[EndpointSummary](EndpointSummary.md 'ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')

<a name='ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis.summaryInfo'></a>

## ApiSetAnalysis.summaryInfo Property

[ApiSetSummaryModel](ApiSetSummaryModel.md 'ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel')

```csharp
public ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel summaryInfo { get; set; }
```

#### Property Value
[ApiSetSummaryModel](ApiSetSummaryModel.md 'ApiTestGenerator.Models.ApiDocs.ApiSetSummaryModel')