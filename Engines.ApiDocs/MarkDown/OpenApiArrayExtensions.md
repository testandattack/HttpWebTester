#### [Engines.ApiDocs](Engines.ApiDocs.md 'Engines.ApiDocs')
### [OpenApiUtilities](Engines.ApiDocs.md#OpenApiUtilities 'OpenApiUtilities')

## OpenApiArrayExtensions Class

A set of extension methods to work on the Microsoft.OpenApi.Models.OpenApiArray class

```csharp
public static class OpenApiArrayExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OpenApiArrayExtensions
### Methods

<a name='OpenApiUtilities.OpenApiArrayExtensions.ToString(thisMicrosoft.OpenApi.Any.OpenApiArray)'></a>

## OpenApiArrayExtensions.ToString(this OpenApiArray) Method

walks an array of items, retrieving the value from the [GetPrimitiveValue(this IOpenApiAny)](OpenApiAnyExtensions.md#OpenApiUtilities.OpenApiAnyExtensions.GetPrimitiveValue(thisMicrosoft.OpenApi.Any.IOpenApiAny) 'OpenApiUtilities.OpenApiAnyExtensions.GetPrimitiveValue(this Microsoft.OpenApi.Any.IOpenApiAny)') method

```csharp
public static string ToString(this Microsoft.OpenApi.Any.OpenApiArray source);
```
#### Parameters

<a name='OpenApiUtilities.OpenApiArrayExtensions.ToString(thisMicrosoft.OpenApi.Any.OpenApiArray).source'></a>

`source` [Microsoft.OpenApi.Any.OpenApiArray](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Any.OpenApiArray 'Microsoft.OpenApi.Any.OpenApiArray')

The `IOpenApiArray` to which this method is exposed.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')