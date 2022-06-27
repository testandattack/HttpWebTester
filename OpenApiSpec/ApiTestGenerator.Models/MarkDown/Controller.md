#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## Controller Class

An object that stores a list of certain
[http://spec.openapis.org/oas/v3.0.3#operation-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#operation-object 'http://spec.openapis.org/oas/v3.0.3#operation-object') items
grouped by the 'name' of the controller they are associated with in code.

```csharp
public class Controller
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Controller
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.Controller.EndPoints'></a>

## Controller.EndPoints Property

A collection of [EndPoint](EndPoint.md 'ApiTestGenerator.Models.ApiDocs.EndPoint') objects and their names

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiDocs.EndPoint> EndPoints { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[EndPoint](EndPoint.md 'ApiTestGenerator.Models.ApiDocs.EndPoint')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiTestGenerator.Models.ApiDocs.Controller.Name'></a>

## Controller.Name Property

The name of the controller

```csharp
public string Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')