#### [Engines.ApiDocs](Engines.ApiDocs.md 'Engines.ApiDocs')
### [OpenApiUtilities](Engines.ApiDocs.md#OpenApiUtilities 'OpenApiUtilities')

## OpenApiAnyExtensions Class

A set of extension methods to work on the Microsoft.OpenApi.Models.OpenApiAny class

```csharp
public static class OpenApiAnyExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OpenApiAnyExtensions
### Methods

<a name='OpenApiUtilities.OpenApiAnyExtensions.GetPrimitiveValue(thisMicrosoft.OpenApi.Any.IOpenApiAny)'></a>

## OpenApiAnyExtensions.GetPrimitiveValue(this IOpenApiAny) Method

Reads the passed in [Microsoft.OpenApi.Any.IOpenApiAny](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Any.IOpenApiAny 'Microsoft.OpenApi.Any.IOpenApiAny') object and returns the value
it contains in a predefined format

```csharp
public static string GetPrimitiveValue(this Microsoft.OpenApi.Any.IOpenApiAny source);
```
#### Parameters

<a name='OpenApiUtilities.OpenApiAnyExtensions.GetPrimitiveValue(thisMicrosoft.OpenApi.Any.IOpenApiAny).source'></a>

`source` [Microsoft.OpenApi.Any.IOpenApiAny](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Any.IOpenApiAny 'Microsoft.OpenApi.Any.IOpenApiAny')

The `IOpenApiAny` to which this method is exposed.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
a string representation of the contained primitive value.

<a name='OpenApiUtilities.OpenApiAnyExtensions.IsPrimitiveType(thisMicrosoft.OpenApi.Any.IOpenApiAny)'></a>

## OpenApiAnyExtensions.IsPrimitiveType(this IOpenApiAny) Method

```csharp
public static bool IsPrimitiveType(this Microsoft.OpenApi.Any.IOpenApiAny source);
```
#### Parameters

<a name='OpenApiUtilities.OpenApiAnyExtensions.IsPrimitiveType(thisMicrosoft.OpenApi.Any.IOpenApiAny).source'></a>

`source` [Microsoft.OpenApi.Any.IOpenApiAny](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Any.IOpenApiAny 'Microsoft.OpenApi.Any.IOpenApiAny')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')