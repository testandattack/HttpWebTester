#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models](ApiTestGenerator.Models.md#ApiTestGenerator.Models 'ApiTestGenerator.Models')

## SwaggerSettings Class

This class encapsulates the settings that define where and how to read   
Open API Spec documentation (swagger) files.

```csharp
public class SwaggerSettings
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SwaggerSettings
### Properties

<a name='ApiTestGenerator.Models.SwaggerSettings.apiRoot'></a>

## SwaggerSettings.apiRoot Property

The root portion of the API's UriStem.

```csharp
public string apiRoot { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.SwaggerSettings.BaseUriAddress'></a>

## SwaggerSettings.BaseUriAddress Property

The "server" portion of the URL that holds the Swagger generated  
document for the API. This is combined with the   
[SwaggerStreamLocation](SwaggerSettings.md#ApiTestGenerator.Models.SwaggerSettings.SwaggerStreamLocation 'ApiTestGenerator.Models.SwaggerSettings.SwaggerStreamLocation') to read the document to parse.  
<strong>NOTE:</strong> This is only used if  
[ReadSwaggerFromFile](SwaggerSettings.md#ApiTestGenerator.Models.SwaggerSettings.ReadSwaggerFromFile 'ApiTestGenerator.Models.SwaggerSettings.ReadSwaggerFromFile') is set to "false"

```csharp
public string BaseUriAddress { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.SwaggerSettings.ReadSwaggerFromFile'></a>

## SwaggerSettings.ReadSwaggerFromFile Property

When "true" the parser will get the Swagger Document  
from the [SwaggerFileLocation](SwaggerSettings.md#ApiTestGenerator.Models.SwaggerSettings.SwaggerFileLocation 'ApiTestGenerator.Models.SwaggerSettings.SwaggerFileLocation'). If "false"  
the parser will get the Swagger Document from the   
[BaseUriAddress](SwaggerSettings.md#ApiTestGenerator.Models.SwaggerSettings.BaseUriAddress 'ApiTestGenerator.Models.SwaggerSettings.BaseUriAddress') and [SwaggerStreamLocation](SwaggerSettings.md#ApiTestGenerator.Models.SwaggerSettings.SwaggerStreamLocation 'ApiTestGenerator.Models.SwaggerSettings.SwaggerStreamLocation')

```csharp
public bool ReadSwaggerFromFile { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiTestGenerator.Models.SwaggerSettings.SwaggerFileLocation'></a>

## SwaggerSettings.SwaggerFileLocation Property

The file name of a pre-generated Swagger document to read  
and parse.  
<strong>NOTE:</strong> This is used if  
[ReadSwaggerFromFile](SwaggerSettings.md#ApiTestGenerator.Models.SwaggerSettings.ReadSwaggerFromFile 'ApiTestGenerator.Models.SwaggerSettings.ReadSwaggerFromFile') is set to "true". It is   
also used as the location to save the Swagger Document if  
you are parsing from the swagger stream.

```csharp
public string SwaggerFileLocation { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.SwaggerSettings.SwaggerStreamLocation'></a>

## SwaggerSettings.SwaggerStreamLocation Property

The UriStem portion of the URL that holds the Swagger generated  
document for the API. This is combined with the   
[BaseUriAddress](SwaggerSettings.md#ApiTestGenerator.Models.SwaggerSettings.BaseUriAddress 'ApiTestGenerator.Models.SwaggerSettings.BaseUriAddress') to read the document to parse.  
<strong>NOTE:</strong> This is only used if  
[ReadSwaggerFromFile](SwaggerSettings.md#ApiTestGenerator.Models.SwaggerSettings.ReadSwaggerFromFile 'ApiTestGenerator.Models.SwaggerSettings.ReadSwaggerFromFile') is set to "false"

```csharp
public string SwaggerStreamLocation { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')