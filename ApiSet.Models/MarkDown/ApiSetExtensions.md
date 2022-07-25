#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Models.Extensions](ApiTestGenerator.Models.md#ApiSet.Models.Extensions 'ApiSet.Models.Extensions')

## ApiSetExtensions Class

```csharp
public static class ApiSetExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiSetExtensions
### Methods

<a name='ApiSet.Models.Extensions.ApiSetExtensions.AddCoreInfo(thisApiSet.Models.ApiDocs.ApiDoc,System.Collections.Generic.Dictionary_string,string_)'></a>

## ApiSetExtensions.AddCoreInfo(this ApiDoc, Dictionary<string,string>) Method

Calls all the individual extraInfo extension methods

```csharp
public static void AddCoreInfo(this ApiSet.Models.ApiDocs.ApiDoc source, System.Collections.Generic.Dictionary<string,string> extraInfo);
```
#### Parameters

<a name='ApiSet.Models.Extensions.ApiSetExtensions.AddCoreInfo(thisApiSet.Models.ApiDocs.ApiDoc,System.Collections.Generic.Dictionary_string,string_).source'></a>

`source` [ApiDoc](ApiDoc.md 'ApiSet.Models.ApiDocs.ApiDoc')

The `ApiSetEngine` to which this method is exposed.

<a name='ApiSet.Models.Extensions.ApiSetExtensions.AddCoreInfo(thisApiSet.Models.ApiDocs.ApiDoc,System.Collections.Generic.Dictionary_string,string_).extraInfo'></a>

`extraInfo` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiSet.Models.Extensions.ApiSetExtensions.GetListOfURLs(thisApiSet.Models.ApiDocs.ApiDoc)'></a>

## ApiSetExtensions.GetListOfURLs(this ApiDoc) Method

call this to retrieve a list of all operations in string format

```csharp
public static string GetListOfURLs(this ApiSet.Models.ApiDocs.ApiDoc source);
```
#### Parameters

<a name='ApiSet.Models.Extensions.ApiSetExtensions.GetListOfURLs(thisApiSet.Models.ApiDocs.ApiDoc).source'></a>

`source` [ApiDoc](ApiDoc.md 'ApiSet.Models.ApiDocs.ApiDoc')

The `ApiSetEngine` to which this method is exposed.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Extensions.ApiSetExtensions.SaveListOfURLs(thisApiSet.Models.ApiDocs.ApiDoc,string)'></a>

## ApiSetExtensions.SaveListOfURLs(this ApiDoc, string) Method

call this to save a base list of all operations

```csharp
public static void SaveListOfURLs(this ApiSet.Models.ApiDocs.ApiDoc source, string fileName);
```
#### Parameters

<a name='ApiSet.Models.Extensions.ApiSetExtensions.SaveListOfURLs(thisApiSet.Models.ApiDocs.ApiDoc,string).source'></a>

`source` [ApiDoc](ApiDoc.md 'ApiSet.Models.ApiDocs.ApiDoc')

The `ApiSetEngine` to which this method is exposed.

<a name='ApiSet.Models.Extensions.ApiSetExtensions.SaveListOfURLs(thisApiSet.Models.ApiDocs.ApiDoc,string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Extensions.ApiSetExtensions.SetOasVersion(thisApiSet.Models.ApiDocs.ApiDoc,System.Collections.Generic.Dictionary_string,string_)'></a>

## ApiSetExtensions.SetOasVersion(this ApiDoc, Dictionary<string,string>) Method

Sets the Open API Scec version used for the document

```csharp
public static void SetOasVersion(this ApiSet.Models.ApiDocs.ApiDoc source, System.Collections.Generic.Dictionary<string,string> extraInfo);
```
#### Parameters

<a name='ApiSet.Models.Extensions.ApiSetExtensions.SetOasVersion(thisApiSet.Models.ApiDocs.ApiDoc,System.Collections.Generic.Dictionary_string,string_).source'></a>

`source` [ApiDoc](ApiDoc.md 'ApiSet.Models.ApiDocs.ApiDoc')

The `ApiSetEngine` to which this method is exposed.

<a name='ApiSet.Models.Extensions.ApiSetExtensions.SetOasVersion(thisApiSet.Models.ApiDocs.ApiDoc,System.Collections.Generic.Dictionary_string,string_).extraInfo'></a>

`extraInfo` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiSet.Models.Extensions.ApiSetExtensions.SetSchemes(thisApiSet.Models.ApiDocs.ApiDoc,System.Collections.Generic.Dictionary_string,string_)'></a>

## ApiSetExtensions.SetSchemes(this ApiDoc, Dictionary<string,string>) Method

Gets any schemes that were defined in the OAS document [OAS v2.x only]

```csharp
public static void SetSchemes(this ApiSet.Models.ApiDocs.ApiDoc source, System.Collections.Generic.Dictionary<string,string> extraInfo);
```
#### Parameters

<a name='ApiSet.Models.Extensions.ApiSetExtensions.SetSchemes(thisApiSet.Models.ApiDocs.ApiDoc,System.Collections.Generic.Dictionary_string,string_).source'></a>

`source` [ApiDoc](ApiDoc.md 'ApiSet.Models.ApiDocs.ApiDoc')

The `ApiSetEngine` to which this method is exposed.

<a name='ApiSet.Models.Extensions.ApiSetExtensions.SetSchemes(thisApiSet.Models.ApiDocs.ApiDoc,System.Collections.Generic.Dictionary_string,string_).extraInfo'></a>

`extraInfo` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

A dictionary of extra data retrieved during the initial reading of the serialized OAS document.