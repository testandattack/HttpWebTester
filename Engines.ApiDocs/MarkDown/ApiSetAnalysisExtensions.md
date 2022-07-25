#### [Engines.ApiDocs](Engines.ApiDocs.md 'Engines.ApiDocs')
### [Engines.ApiDocs.Extensions](Engines.ApiDocs.md#Engines.ApiDocs.Extensions 'Engines.ApiDocs.Extensions')

## ApiSetAnalysisExtensions Class

A set of extension methods for operating on an [ApiSet.Models.ApiAnalyzer.ApiSetAnalysis](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiAnalyzer.ApiSetAnalysis 'ApiSet.Models.ApiAnalyzer.ApiSetAnalysis') model

```csharp
public static class ApiSetAnalysisExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiSetAnalysisExtensions
### Methods

<a name='Engines.ApiDocs.Extensions.ApiSetAnalysisExtensions.CopyEndpointSummary(thisApiSet.Models.ApiAnalyzer.ApiSetAnalysis)'></a>

## ApiSetAnalysisExtensions.CopyEndpointSummary(this ApiSetAnalysis) Method

```csharp
public static System.Collections.Generic.Dictionary<string,ApiSet.Models.ApiAnalyzer.EndpointSummary> CopyEndpointSummary(this ApiSet.Models.ApiAnalyzer.ApiSetAnalysis source);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.ApiSetAnalysisExtensions.CopyEndpointSummary(thisApiSet.Models.ApiAnalyzer.ApiSetAnalysis).source'></a>

`source` [ApiSet.Models.ApiAnalyzer.ApiSetAnalysis](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiAnalyzer.ApiSetAnalysis 'ApiSet.Models.ApiAnalyzer.ApiSetAnalysis')

The `ApiSetAnalysis` to which this method is exposed.

#### Returns
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ApiSet.Models.ApiAnalyzer.EndpointSummary](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiAnalyzer.EndpointSummary 'ApiSet.Models.ApiAnalyzer.EndpointSummary')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='Engines.ApiDocs.Extensions.ApiSetAnalysisExtensions.SetEndpointSummaryValues(thisApiSet.Models.ApiAnalyzer.ApiSetAnalysis,System.Collections.Generic.Dictionary_string,ApiSet.Models.ApiAnalyzer.EndpointSummary_)'></a>

## ApiSetAnalysisExtensions.SetEndpointSummaryValues(this ApiSetAnalysis, Dictionary<string,EndpointSummary>) Method

```csharp
public static void SetEndpointSummaryValues(this ApiSet.Models.ApiAnalyzer.ApiSetAnalysis source, System.Collections.Generic.Dictionary<string,ApiSet.Models.ApiAnalyzer.EndpointSummary> summaries);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.ApiSetAnalysisExtensions.SetEndpointSummaryValues(thisApiSet.Models.ApiAnalyzer.ApiSetAnalysis,System.Collections.Generic.Dictionary_string,ApiSet.Models.ApiAnalyzer.EndpointSummary_).source'></a>

`source` [ApiSet.Models.ApiAnalyzer.ApiSetAnalysis](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiAnalyzer.ApiSetAnalysis 'ApiSet.Models.ApiAnalyzer.ApiSetAnalysis')

The `ApiSetAnalysis` to which this method is exposed.

<a name='Engines.ApiDocs.Extensions.ApiSetAnalysisExtensions.SetEndpointSummaryValues(thisApiSet.Models.ApiAnalyzer.ApiSetAnalysis,System.Collections.Generic.Dictionary_string,ApiSet.Models.ApiAnalyzer.EndpointSummary_).summaries'></a>

`summaries` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ApiSet.Models.ApiAnalyzer.EndpointSummary](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiAnalyzer.EndpointSummary 'ApiSet.Models.ApiAnalyzer.EndpointSummary')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')