#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## ApiSet Class

```csharp
public class ApiSet
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiSet
### Properties

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

<a name='ApiTestGenerator.Models.ApiDocs.ApiSet.Servers'></a>

## ApiSet.Servers Property

A list of [Microsoft.OpenApi.Models.OpenApiServer](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiServer 'Microsoft.OpenApi.Models.OpenApiServer') objects

```csharp
public System.Collections.Generic.List<Microsoft.OpenApi.Models.OpenApiServer> Servers { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Microsoft.OpenApi.Models.OpenApiServer](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiServer 'Microsoft.OpenApi.Models.OpenApiServer')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')