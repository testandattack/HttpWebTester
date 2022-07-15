#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## ApiSet Class

This class defines a Model used for translating various different web based API   
calls between the different formats. It is based on the Open API Specification.  
The idea is to allow an engine to populate this model with information from  
sources like:  
- An OAS document  
- An Http Archive (HAR) file.  
- A Postman request collection.  
and turn the results into a test harness that can be executed.

```csharp
public class ApiSet
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiSet
### Constructors

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.ApiSet()'></a>

## ApiSet() Constructor

Creates a new empty ApiSet instance.

```csharp
public ApiSet();
```

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.ApiSet(GTC.HttpWebTester.Settings.Settings)'></a>

## ApiSet(Settings) Constructor

Creates a new empty ApiSet instance using the provided [settings](ApiSet.md#ApiTestGenerator.Models.ApiDocs.ApiSet.ApiSet(GTC.HttpWebTester.Settings.Settings).settings 'ApiTestGenerator.Models.ApiDocs.ApiSet.ApiSet(GTC.HttpWebTester.Settings.Settings).settings') object.

```csharp
public ApiSet(GTC.HttpWebTester.Settings.Settings settings);
```
#### Parameters

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.ApiSet(GTC.HttpWebTester.Settings.Settings).settings'></a>

`settings` [GTC.HttpWebTester.Settings.Settings](https://docs.microsoft.com/en-us/dotnet/api/GTC.HttpWebTester.Settings.Settings 'GTC.HttpWebTester.Settings.Settings')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.ApiSet(string,GTC.HttpWebTester.Settings.Settings)'></a>

## ApiSet(string, Settings) Constructor

Creates a new ApiSet instance using the provided [ApiRoot](ApiSet.md#ApiTestGenerator.Models.ApiDocs.ApiSet.ApiSet(string,GTC.HttpWebTester.Settings.Settings).ApiRoot 'ApiTestGenerator.Models.ApiDocs.ApiSet.ApiSet(string, GTC.HttpWebTester.Settings.Settings).ApiRoot') and [settings](ApiSet.md#ApiTestGenerator.Models.ApiDocs.ApiSet.ApiSet(string,GTC.HttpWebTester.Settings.Settings).settings 'ApiTestGenerator.Models.ApiDocs.ApiSet.ApiSet(string, GTC.HttpWebTester.Settings.Settings).settings') objects.

```csharp
public ApiSet(string ApiRoot, GTC.HttpWebTester.Settings.Settings settings);
```
#### Parameters

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.ApiSet(string,GTC.HttpWebTester.Settings.Settings).ApiRoot'></a>

`ApiRoot` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.ApiSet(string,GTC.HttpWebTester.Settings.Settings).settings'></a>

`settings` [GTC.HttpWebTester.Settings.Settings](https://docs.microsoft.com/en-us/dotnet/api/GTC.HttpWebTester.Settings.Settings 'GTC.HttpWebTester.Settings.Settings')
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.apiRoot'></a>

## ApiSet.apiRoot Property

The left part of the UriStem that comes before 'controller' names.

```csharp
public string apiRoot { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
The OAS allows for [but does not require] the definition of a "basePath" node, which is part of the  
url to reach an API operation. Some OAS generators will define this value. Some will leave the root   
as part of the [Servers](ApiSet.md#ApiTestGenerator.Models.ApiDocs.ApiSet.Servers 'ApiTestGenerator.Models.ApiDocs.ApiSet.Servers') Url address. Some will leave the value as the first part of   
the 'path' node. Some may not define a root for the api. <br/>  
This variable holds one of the following values:  
1. The value defined in the `basePath` node, if present will be stored here.  
2. The value added to the `settings.json` file, if defined will be stored here.  
3. The Servers Url addresses will be searched for a common value with an   
              extension method and (if found) will be stored here.  
4. An empty string if there is not a common basePath, or if the value is  
              not provided by one of the above items.

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.apiRootSourceLocation'></a>

## ApiSet.apiRootSourceLocation Property

Lists the source for the [apiRoot](ApiSet.md#ApiTestGenerator.Models.ApiDocs.ApiSet.apiRoot 'ApiTestGenerator.Models.ApiDocs.ApiSet.apiRoot') object

```csharp
public ApiTestGenerator.Models.Enums.ApiRootSourceEnum apiRootSourceLocation { get; set; }
```

#### Property Value
[ApiRootSourceEnum](ApiRootSourceEnum.md 'ApiTestGenerator.Models.Enums.ApiRootSourceEnum')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.Components'></a>

## ApiSet.Components Property

A list of [Component](Component.md 'ApiTestGenerator.Models.ApiDocs.Component') objects

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiDocs.Component> Components { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[Component](Component.md 'ApiTestGenerator.Models.ApiDocs.Component')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.Controllers'></a>

## ApiSet.Controllers Property

A list of [Controller](Controller.md 'ApiTestGenerator.Models.ApiDocs.Controller') objects

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiDocs.Controller> Controllers { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[Controller](Controller.md 'ApiTestGenerator.Models.ApiDocs.Controller')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.Info'></a>

## ApiSet.Info Property

Contains the [Microsoft.OpenApi.Models.OpenApiInfo](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiInfo 'Microsoft.OpenApi.Models.OpenApiInfo') object from the Swagger Documentation

```csharp
public Microsoft.OpenApi.Models.OpenApiInfo Info { get; set; }
```

#### Property Value
[Microsoft.OpenApi.Models.OpenApiInfo](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiInfo 'Microsoft.OpenApi.Models.OpenApiInfo')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.OasVersion'></a>

## ApiSet.OasVersion Property

The Open API Specification version used for creating the document.

```csharp
public string OasVersion { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.Schemes'></a>

## ApiSet.Schemes Property

The transfer protocos(s) used by the API. [OAS v2.x only]

```csharp
public System.Collections.Generic.List<string> Schemes { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.SecuritySchemes'></a>

## ApiSet.SecuritySchemes Property

The list of OpenApiSecuritySchemes associated with this OAS Document

```csharp
public System.Collections.Generic.List<Microsoft.OpenApi.Models.OpenApiSecurityScheme> SecuritySchemes { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Microsoft.OpenApi.Models.OpenApiSecurityScheme](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiSecurityScheme 'Microsoft.OpenApi.Models.OpenApiSecurityScheme')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.Servers'></a>

## ApiSet.Servers Property

A list of [Microsoft.OpenApi.Models.OpenApiServer](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiServer 'Microsoft.OpenApi.Models.OpenApiServer') objects

```csharp
public System.Collections.Generic.List<Microsoft.OpenApi.Models.OpenApiServer> Servers { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Microsoft.OpenApi.Models.OpenApiServer](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiServer 'Microsoft.OpenApi.Models.OpenApiServer')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.settings'></a>

## ApiSet.settings Property

The [GTC.HttpWebTester.Settings.Settings](https://docs.microsoft.com/en-us/dotnet/api/GTC.HttpWebTester.Settings.Settings 'GTC.HttpWebTester.Settings.Settings') to use with this ApiSet.

```csharp
public GTC.HttpWebTester.Settings.Settings settings { get; set; }
```

#### Property Value
[GTC.HttpWebTester.Settings.Settings](https://docs.microsoft.com/en-us/dotnet/api/GTC.HttpWebTester.Settings.Settings 'GTC.HttpWebTester.Settings.Settings')