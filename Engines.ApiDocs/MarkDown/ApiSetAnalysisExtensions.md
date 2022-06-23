#### [Engines.ApiDocs](Engines.ApiDocs.md 'Engines.ApiDocs')
### [Engines.ApiDocs.Extensions](Engines.ApiDocs.md#Engines.ApiDocs.Extensions 'Engines.ApiDocs.Extensions')

## ApiSetAnalysisExtensions Class

A set of extension methods for operating on an [ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis 'ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis') model

```csharp
public static class ApiSetAnalysisExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiSetAnalysisExtensions
### Methods

<a name='Engines.ApiDocs.Extensions.ApiSetAnalysisExtensions.CopyEndpointSummary(thisApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis)'></a>

## ApiSetAnalysisExtensions.CopyEndpointSummary(this ApiSetAnalysis) Method

```csharp
public static System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary> CopyEndpointSummary(this ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis source);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.ApiSetAnalysisExtensions.CopyEndpointSummary(thisApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis).source'></a>

`source` [ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis 'ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis')

The `ApiSetAnalysis` to which this method is exposed.

#### Returns
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary 'ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='Engines.ApiDocs.Extensions.ApiSetAnalysisExtensions.SetEndpointSummaryValues(thisApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis,System.Collections.Generic.Dictionary_string,ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary_)'></a>

## ApiSetAnalysisExtensions.SetEndpointSummaryValues(this ApiSetAnalysis, Dictionary<string,EndpointSummary>) Method

```csharp
public static void SetEndpointSummaryValues(this ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis source, System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary> summaries);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.ApiSetAnalysisExtensions.SetEndpointSummaryValues(thisApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis,System.Collections.Generic.Dictionary_string,ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary_).source'></a>

`source` [ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis 'ApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis')

The `ApiSetAnalysis` to which this method is exposed.

<a name='Engines.ApiDocs.Extensions.ApiSetAnalysisExtensions.SetEndpointSummaryValues(thisApiTestGenerator.Models.ApiAnalyzer.ApiSetAnalysis,System.Collections.Generic.Dictionary_string,ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary_).summaries'></a>

`summaries` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary 'ApiTestGenerator.Models.ApiAnalyzer.EndpointSummary')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')