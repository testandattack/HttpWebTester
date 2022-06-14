#### [SwaggerParsing](SwaggerParsing.md 'SwaggerParsing')
### [GTC.SwaggerParsing](SwaggerParsing.md#GTC.SwaggerParsing 'GTC.SwaggerParsing')

## SwaggerParser Class

This class contains all of the code to read from a serialized copy of an  
Open API Specification document (from a json file or from the OAS definition URL on an API website)  
and convert it into a [
            Microsoft OpenApiDocument](https://github.com/Microsoft/OpenAPI.NET 'https://github.com/Microsoft/OpenAPI.NET'). It can also serialize and save the document to a local file system.

```csharp
public class SwaggerParser
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SwaggerParser
### Constructors

<a name='GTC.SwaggerParsing.SwaggerParser.SwaggerParser()'></a>

## SwaggerParser() Constructor

Creates a new instance of the parser using the `settings.json` file in the  
root directory of the application.

```csharp
public SwaggerParser();
```

<a name='GTC.SwaggerParsing.SwaggerParser.SwaggerParser(GTC.HttpWebTester.Settings.Settings)'></a>

## SwaggerParser(Settings) Constructor

Creates a new instance of the parser using the [GTC.HttpWebTester.Settings.Settings](https://docs.microsoft.com/en-us/dotnet/api/GTC.HttpWebTester.Settings.Settings 'GTC.HttpWebTester.Settings.Settings') object   
that is passed in.

```csharp
public SwaggerParser(GTC.HttpWebTester.Settings.Settings Settings);
```
#### Parameters

<a name='GTC.SwaggerParsing.SwaggerParser.SwaggerParser(GTC.HttpWebTester.Settings.Settings).Settings'></a>

`Settings` [GTC.HttpWebTester.Settings.Settings](https://docs.microsoft.com/en-us/dotnet/api/GTC.HttpWebTester.Settings.Settings 'GTC.HttpWebTester.Settings.Settings')

the pre-loaded settings object to use with this instance.
### Properties

<a name='GTC.SwaggerParsing.SwaggerParser.apiDocument'></a>

## SwaggerParser.apiDocument Property

The object that holds the parsed OAS document

```csharp
public Microsoft.OpenApi.Models.OpenApiDocument apiDocument { get; set; }
```

#### Property Value
[Microsoft.OpenApi.Models.OpenApiDocument](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiDocument 'Microsoft.OpenApi.Models.OpenApiDocument')

<a name='GTC.SwaggerParsing.SwaggerParser.settings'></a>

## SwaggerParser.settings Property

the local instance of the [GTC.HttpWebTester.Settings.Settings](https://docs.microsoft.com/en-us/dotnet/api/GTC.HttpWebTester.Settings.Settings 'GTC.HttpWebTester.Settings.Settings') class containing

```csharp
public GTC.HttpWebTester.Settings.Settings settings { get; set; }
```

#### Property Value
[GTC.HttpWebTester.Settings.Settings](https://docs.microsoft.com/en-us/dotnet/api/GTC.HttpWebTester.Settings.Settings 'GTC.HttpWebTester.Settings.Settings')
### Methods

<a name='GTC.SwaggerParsing.SwaggerParser.CreateAndSaveDtoCode()'></a>

## SwaggerParser.CreateAndSaveDtoCode() Method

This method uses the [NSwag](https://github.com/RicoSuter/NSwag 'https://github.com/RicoSuter/NSwag') Nuget package to generate  
C# source code for the OAS documented items. If no fileName is provided, the file is saved to the location  
specified in the settings file.

```csharp
public void CreateAndSaveDtoCode();
```

<a name='GTC.SwaggerParsing.SwaggerParser.CreateAndSaveDtoCode(string)'></a>

## SwaggerParser.CreateAndSaveDtoCode(string) Method

This method uses the [NSwag](https://github.com/RicoSuter/NSwag 'https://github.com/RicoSuter/NSwag') Nuget package to generate  
C# source code for the OAS documented items. If no fileName is provided, the file is saved to the location  
specified in the settings file.

```csharp
public void CreateAndSaveDtoCode(string fileName);
```
#### Parameters

<a name='GTC.SwaggerParsing.SwaggerParser.CreateAndSaveDtoCode(string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the fully qualified name of the code file to save.

<a name='GTC.SwaggerParsing.SwaggerParser.PopulateApiDocument()'></a>

## SwaggerParser.PopulateApiDocument() Method

call this to load the Swagger Document into memory

```csharp
public void PopulateApiDocument();
```

<a name='GTC.SwaggerParsing.SwaggerParser.PopulateApiDocument(bool)'></a>

## SwaggerParser.PopulateApiDocument(bool) Method

call this to load the Swagger Document into memory

```csharp
public void PopulateApiDocument(bool readFromFile);
```
#### Parameters

<a name='GTC.SwaggerParsing.SwaggerParser.PopulateApiDocument(bool).readFromFile'></a>

`readFromFile` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

If true, the OAS is read from a file

<a name='GTC.SwaggerParsing.SwaggerParser.PopulateApiDocument(string)'></a>

## SwaggerParser.PopulateApiDocument(string) Method

call this to load the Swagger Document into memory

```csharp
public void PopulateApiDocument(string fileName);
```
#### Parameters

<a name='GTC.SwaggerParsing.SwaggerParser.PopulateApiDocument(string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the json file to read.

<a name='GTC.SwaggerParsing.SwaggerParser.PopulateApiDocument(string,string)'></a>

## SwaggerParser.PopulateApiDocument(string, string) Method

call this to load the Swagger Document into memory

```csharp
public void PopulateApiDocument(string baseUriAddress, string swaggerStreamLocation);
```
#### Parameters

<a name='GTC.SwaggerParsing.SwaggerParser.PopulateApiDocument(string,string).baseUriAddress'></a>

`baseUriAddress` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the base URI for the connection to the server hosting the OAS Document

<a name='GTC.SwaggerParsing.SwaggerParser.PopulateApiDocument(string,string).swaggerStreamLocation'></a>

`swaggerStreamLocation` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the URI-Stem for the OAS document.

<a name='GTC.SwaggerParsing.SwaggerParser.SaveListOfURLs(string,ApiTestGenerator.Models.ApiDocs.ApiSet)'></a>

## SwaggerParser.SaveListOfURLs(string, ApiSet) Method

call this to save a base list of all operations

```csharp
public void SaveListOfURLs(string fileName, ApiTestGenerator.Models.ApiDocs.ApiSet apiSet);
```
#### Parameters

<a name='GTC.SwaggerParsing.SwaggerParser.SaveListOfURLs(string,ApiTestGenerator.Models.ApiDocs.ApiSet).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='GTC.SwaggerParsing.SwaggerParser.SaveListOfURLs(string,ApiTestGenerator.Models.ApiDocs.ApiSet).apiSet'></a>

`apiSet` [ApiTestGenerator.Models.ApiDocs.ApiSet](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiDocs.ApiSet 'ApiTestGenerator.Models.ApiDocs.ApiSet')

<a name='GTC.SwaggerParsing.SwaggerParser.SaveOriginalSwaggerDocument()'></a>

## SwaggerParser.SaveOriginalSwaggerDocument() Method

call this to save the original swagger file (if read from a stream)

```csharp
public void SaveOriginalSwaggerDocument();
```