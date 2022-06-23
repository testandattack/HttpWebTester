#### [Engines.ApiDocs](Engines.ApiDocs.md 'Engines.ApiDocs')
### [Engines.ApiDocs.Extensions](Engines.ApiDocs.md#Engines.ApiDocs.Extensions 'Engines.ApiDocs.Extensions')

## ApiSetEngineExtensions Class

```csharp
public static class ApiSetEngineExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiSetEngineExtensions
### Methods

<a name='Engines.ApiDocs.Extensions.ApiSetEngineExtensions.GetListOfURLs(thisEngines.ApiDocs.ApiSetEngine)'></a>

## ApiSetEngineExtensions.GetListOfURLs(this ApiSetEngine) Method

call this to retrieve a list of all operations in string format

```csharp
public static string GetListOfURLs(this Engines.ApiDocs.ApiSetEngine source);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.ApiSetEngineExtensions.GetListOfURLs(thisEngines.ApiDocs.ApiSetEngine).source'></a>

`source` [ApiSetEngine](ApiSetEngine.md 'Engines.ApiDocs.ApiSetEngine')

The `ApiSetEngine` to which this method is exposed.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Engines.ApiDocs.Extensions.ApiSetEngineExtensions.SaveListOfURLs(thisEngines.ApiDocs.ApiSetEngine,string)'></a>

## ApiSetEngineExtensions.SaveListOfURLs(this ApiSetEngine, string) Method

call this to save a base list of all operations

```csharp
public static void SaveListOfURLs(this Engines.ApiDocs.ApiSetEngine source, string fileName);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.ApiSetEngineExtensions.SaveListOfURLs(thisEngines.ApiDocs.ApiSetEngine,string).source'></a>

`source` [ApiSetEngine](ApiSetEngine.md 'Engines.ApiDocs.ApiSetEngine')

The `ApiSetEngine` to which this method is exposed.

<a name='Engines.ApiDocs.Extensions.ApiSetEngineExtensions.SaveListOfURLs(thisEngines.ApiDocs.ApiSetEngine,string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Engines.ApiDocs.Extensions.ApiSetEngineExtensions.SetOasVersion(thisEngines.ApiDocs.ApiSetEngine,System.Collections.Generic.Dictionary_string,string_)'></a>

## ApiSetEngineExtensions.SetOasVersion(this ApiSetEngine, Dictionary<string,string>) Method

Sets the Open API Scec version used for the document

```csharp
public static void SetOasVersion(this Engines.ApiDocs.ApiSetEngine source, System.Collections.Generic.Dictionary<string,string> extraInfo);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.ApiSetEngineExtensions.SetOasVersion(thisEngines.ApiDocs.ApiSetEngine,System.Collections.Generic.Dictionary_string,string_).source'></a>

`source` [ApiSetEngine](ApiSetEngine.md 'Engines.ApiDocs.ApiSetEngine')

The `ApiSetEngine` to which this method is exposed.

<a name='Engines.ApiDocs.Extensions.ApiSetEngineExtensions.SetOasVersion(thisEngines.ApiDocs.ApiSetEngine,System.Collections.Generic.Dictionary_string,string_).extraInfo'></a>

`extraInfo` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='Engines.ApiDocs.Extensions.ApiSetEngineExtensions.SetSchemes(thisEngines.ApiDocs.ApiSetEngine,System.Collections.Generic.Dictionary_string,string_)'></a>

## ApiSetEngineExtensions.SetSchemes(this ApiSetEngine, Dictionary<string,string>) Method

Gets any schemes that were defined in the OAS document [OAS v2.x only]

```csharp
public static void SetSchemes(this Engines.ApiDocs.ApiSetEngine source, System.Collections.Generic.Dictionary<string,string> extraInfo);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.ApiSetEngineExtensions.SetSchemes(thisEngines.ApiDocs.ApiSetEngine,System.Collections.Generic.Dictionary_string,string_).source'></a>

`source` [ApiSetEngine](ApiSetEngine.md 'Engines.ApiDocs.ApiSetEngine')

The `ApiSetEngine` to which this method is exposed.

<a name='Engines.ApiDocs.Extensions.ApiSetEngineExtensions.SetSchemes(thisEngines.ApiDocs.ApiSetEngine,System.Collections.Generic.Dictionary_string,string_).extraInfo'></a>

`extraInfo` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

A dictionary of extra data retrieved during the initial reading of the serialized OAS document.