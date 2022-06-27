#### [Engines.ApiDocs](Engines.ApiDocs.md 'Engines.ApiDocs')
### [Engines.ApiDocs.Extensions](Engines.ApiDocs.md#Engines.ApiDocs.Extensions 'Engines.ApiDocs.Extensions')

## PropertyExtensions Class

```csharp
public static class PropertyExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PropertyExtensions
### Methods

<a name='Engines.ApiDocs.Extensions.PropertyExtensions.GetDescriptionAndCustomObjects(thisApiTestGenerator.Models.ApiDocs.Property,Microsoft.OpenApi.Models.OpenApiSchema)'></a>

## PropertyExtensions.GetDescriptionAndCustomObjects(this Property, OpenApiSchema) Method

Parses the [Microsoft.OpenApi.Models.OpenApiSchema.Description](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiSchema.Description 'Microsoft.OpenApi.Models.OpenApiSchema.Description') string (if present)
and finds any custom objects added to it.

```csharp
public static void GetDescriptionAndCustomObjects(this ApiTestGenerator.Models.ApiDocs.Property source, Microsoft.OpenApi.Models.OpenApiSchema property);
```
#### Parameters

<a name='Engines.ApiDocs.Extensions.PropertyExtensions.GetDescriptionAndCustomObjects(thisApiTestGenerator.Models.ApiDocs.Property,Microsoft.OpenApi.Models.OpenApiSchema).source'></a>

`source` [ApiTestGenerator.Models.ApiDocs.Property](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiDocs.Property 'ApiTestGenerator.Models.ApiDocs.Property')

the [ApiTestGenerator.Models.ApiDocs.Property](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiDocs.Property 'ApiTestGenerator.Models.ApiDocs.Property') object to add items to.

<a name='Engines.ApiDocs.Extensions.PropertyExtensions.GetDescriptionAndCustomObjects(thisApiTestGenerator.Models.ApiDocs.Property,Microsoft.OpenApi.Models.OpenApiSchema).property'></a>

`property` [Microsoft.OpenApi.Models.OpenApiSchema](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiSchema 'Microsoft.OpenApi.Models.OpenApiSchema')

the [Microsoft.OpenApi.Models.OpenApiSchema](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiSchema 'Microsoft.OpenApi.Models.OpenApiSchema') object that contains the Description to parse.