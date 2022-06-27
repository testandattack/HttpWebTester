#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## Component Class

This class defines a container to house the custom class objects
that are used for responses from the API.

```csharp
public class Component
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Component

### Remarks
This class bears the same name as the [
            Components](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#components-object 'http://spec.openapis.org/oas/v3.0.3#components-object') object in the OpenApiSpec, but it only implements a part of the functionality, specifically
the Schema objects stored under the Components object.
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.Component.ClassName'></a>

## Component.ClassName Property

The name of the class inside source code for the object being stored.

```csharp
public string ClassName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.Component.Name'></a>

## Component.Name Property

The name of the schema object.

```csharp
public string Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.Component.properties'></a>

## Component.properties Property

The list of [Property](Property.md 'ApiTestGenerator.Models.ApiDocs.Property') items
that are associated with the schema.

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiDocs.Property> properties { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[Property](Property.md 'ApiTestGenerator.Models.ApiDocs.Property')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')