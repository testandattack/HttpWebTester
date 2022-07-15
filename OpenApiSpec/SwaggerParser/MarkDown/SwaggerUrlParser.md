#### [SwaggerParsing](SwaggerParsing.md 'SwaggerParsing')
### [GTC.SwaggerParsing](SwaggerParsing.md#GTC.SwaggerParsing 'GTC.SwaggerParsing')

## SwaggerUrlParser Class

This class contains all of the code to read from a serialized copy of an
Open API Specification document (from a json file or from the OAS definition URL on an API website)
and convert it into a [
            Microsoft OpenApiDocument](https://github.com/Microsoft/OpenAPI.NET 'https://github.com/Microsoft/OpenAPI.NET'). It can also serialize and save the document to a local file system.

```csharp
public class SwaggerUrlParser :
SharedResources.ISwaggerParser
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SwaggerUrlParser

Implements [SharedResources.ISwaggerParser](https://docs.microsoft.com/en-us/dotnet/api/SharedResources.ISwaggerParser 'SharedResources.ISwaggerParser')
### Constructors

<a name='GTC.SwaggerParsing.SwaggerUrlParser.SwaggerUrlParser()'></a>

## SwaggerUrlParser() Constructor

Creates a new instance of the parser using the `settings.json` file in the
root directory of the application.

```csharp
public SwaggerUrlParser();
```

<a name='GTC.SwaggerParsing.SwaggerUrlParser.SwaggerUrlParser(GTC.HttpWebTester.Settings.Settings)'></a>

## SwaggerUrlParser(Settings) Constructor

Creates a new instance of the parser using the [GTC.HttpWebTester.Settings.Settings](https://docs.microsoft.com/en-us/dotnet/api/GTC.HttpWebTester.Settings.Settings 'GTC.HttpWebTester.Settings.Settings') object 
that is passed in.

```csharp
public SwaggerUrlParser(GTC.HttpWebTester.Settings.Settings Settings);
```
#### Parameters

<a name='GTC.SwaggerParsing.SwaggerUrlParser.SwaggerUrlParser(GTC.HttpWebTester.Settings.Settings).Settings'></a>

`Settings` [GTC.HttpWebTester.Settings.Settings](https://docs.microsoft.com/en-us/dotnet/api/GTC.HttpWebTester.Settings.Settings 'GTC.HttpWebTester.Settings.Settings')

the pre-loaded settings object to use with this instance.
### Properties

<a name='GTC.SwaggerParsing.SwaggerUrlParser.apiDocument'></a>

## SwaggerUrlParser.apiDocument Property

The object that holds the parsed OAS document

```csharp
public Microsoft.OpenApi.Models.OpenApiDocument apiDocument { get; set; }
```

Implements [apiDocument](https://docs.microsoft.com/en-us/dotnet/api/SharedResources.ISwaggerParser.apiDocument 'SharedResources.ISwaggerParser.apiDocument')

#### Property Value
[Microsoft.OpenApi.Models.OpenApiDocument](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiDocument 'Microsoft.OpenApi.Models.OpenApiDocument')

<a name='GTC.SwaggerParsing.SwaggerUrlParser.extraInfo'></a>

## SwaggerUrlParser.extraInfo Property

This dictionary stores info from the serialized string that is not
picked up by the `OpenApiDocument` object.

```csharp
public System.Collections.Generic.Dictionary<string,string> extraInfo { get; set; }
```

Implements [extraInfo](https://docs.microsoft.com/en-us/dotnet/api/SharedResources.ISwaggerParser.extraInfo 'SharedResources.ISwaggerParser.extraInfo')

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='GTC.SwaggerParsing.SwaggerUrlParser.settings'></a>

## SwaggerUrlParser.settings Property

the local instance of the [GTC.HttpWebTester.Settings.Settings](https://docs.microsoft.com/en-us/dotnet/api/GTC.HttpWebTester.Settings.Settings 'GTC.HttpWebTester.Settings.Settings') class containing

```csharp
public GTC.HttpWebTester.Settings.Settings settings { get; set; }
```

Implements [settings](https://docs.microsoft.com/en-us/dotnet/api/SharedResources.ISwaggerParser.settings 'SharedResources.ISwaggerParser.settings')

#### Property Value
[GTC.HttpWebTester.Settings.Settings](https://docs.microsoft.com/en-us/dotnet/api/GTC.HttpWebTester.Settings.Settings 'GTC.HttpWebTester.Settings.Settings')
### Methods

<a name='GTC.SwaggerParsing.SwaggerUrlParser.CreateAndSaveDtoCode()'></a>

## SwaggerUrlParser.CreateAndSaveDtoCode() Method

This method uses the [NSwag](https://github.com/RicoSuter/NSwag 'https://github.com/RicoSuter/NSwag') Nuget package to generate
C# source code for the OAS documented items. If no fileName is provided, the file is saved to the location
specified in the settings file.

```csharp
public void CreateAndSaveDtoCode();
```

Implements [CreateAndSaveDtoCode()](https://docs.microsoft.com/en-us/dotnet/api/SharedResources.ISwaggerParser.CreateAndSaveDtoCode 'SharedResources.ISwaggerParser.CreateAndSaveDtoCode')

<a name='GTC.SwaggerParsing.SwaggerUrlParser.CreateAndSaveDtoCode(string)'></a>

## SwaggerUrlParser.CreateAndSaveDtoCode(string) Method

This method uses the [NSwag](https://github.com/RicoSuter/NSwag 'https://github.com/RicoSuter/NSwag') Nuget package to generate
C# source code for the OAS documented items. If no fileName is provided, the file is saved to the location
specified in the settings file.

```csharp
public void CreateAndSaveDtoCode(string fileName);
```
#### Parameters

<a name='GTC.SwaggerParsing.SwaggerUrlParser.CreateAndSaveDtoCode(string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the fully qualified name of the code file to save.

Implements [CreateAndSaveDtoCode(string)](https://docs.microsoft.com/en-us/dotnet/api/SharedResources.ISwaggerParser.CreateAndSaveDtoCode#SharedResources_ISwaggerParser_CreateAndSaveDtoCode_System_String_ 'SharedResources.ISwaggerParser.CreateAndSaveDtoCode(System.String)')

<a name='GTC.SwaggerParsing.SwaggerUrlParser.PopulateApiDocument()'></a>

## SwaggerUrlParser.PopulateApiDocument() Method

```csharp
public void PopulateApiDocument();
```

Implements [PopulateApiDocument()](https://docs.microsoft.com/en-us/dotnet/api/SharedResources.ISwaggerParser.PopulateApiDocument 'SharedResources.ISwaggerParser.PopulateApiDocument')

<a name='GTC.SwaggerParsing.SwaggerUrlParser.PopulateApiDocument(string)'></a>

## SwaggerUrlParser.PopulateApiDocument(string) Method

```csharp
public void PopulateApiDocument(string uriAddress);
```
#### Parameters

<a name='GTC.SwaggerParsing.SwaggerUrlParser.PopulateApiDocument(string).uriAddress'></a>

`uriAddress` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Implements [PopulateApiDocument(string)](https://docs.microsoft.com/en-us/dotnet/api/SharedResources.ISwaggerParser.PopulateApiDocument#SharedResources_ISwaggerParser_PopulateApiDocument_System_String_ 'SharedResources.ISwaggerParser.PopulateApiDocument(System.String)')

<a name='GTC.SwaggerParsing.SwaggerUrlParser.SaveOriginalSwaggerDocument()'></a>

## SwaggerUrlParser.SaveOriginalSwaggerDocument() Method

call this to save the original swagger file (if read from a stream)

```csharp
public void SaveOriginalSwaggerDocument();
```

Implements [SaveOriginalSwaggerDocument()](https://docs.microsoft.com/en-us/dotnet/api/SharedResources.ISwaggerParser.SaveOriginalSwaggerDocument 'SharedResources.ISwaggerParser.SaveOriginalSwaggerDocument')