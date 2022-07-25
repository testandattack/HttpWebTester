#### [Engines.ApiDocs](Engines.ApiDocs.md 'Engines.ApiDocs')
### [Engines.ApiDocs](Engines.ApiDocs.md#Engines.ApiDocs 'Engines.ApiDocs')

## ParameterExtensions Class

```csharp
public static class ParameterExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ParameterExtensions
### Methods

<a name='Engines.ApiDocs.ParameterExtensions.GetDescriptionAndCustomObjects(thisApiSet.Models.ApiDocs.Parameter,Microsoft.OpenApi.Models.OpenApiParameter)'></a>

## ParameterExtensions.GetDescriptionAndCustomObjects(this Parameter, OpenApiParameter) Method

Parses the [Microsoft.OpenApi.Models.OpenApiParameter.Description](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiParameter.Description 'Microsoft.OpenApi.Models.OpenApiParameter.Description') string (if present)
and finds any custom objects added to it.

```csharp
public static void GetDescriptionAndCustomObjects(this ApiSet.Models.ApiDocs.Parameter source, Microsoft.OpenApi.Models.OpenApiParameter parameter);
```
#### Parameters

<a name='Engines.ApiDocs.ParameterExtensions.GetDescriptionAndCustomObjects(thisApiSet.Models.ApiDocs.Parameter,Microsoft.OpenApi.Models.OpenApiParameter).source'></a>

`source` [ApiSet.Models.ApiDocs.Parameter](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiDocs.Parameter 'ApiSet.Models.ApiDocs.Parameter')

the [ApiSet.Models.ApiDocs.Parameter](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.Models.ApiDocs.Parameter 'ApiSet.Models.ApiDocs.Parameter') object to add items to.

<a name='Engines.ApiDocs.ParameterExtensions.GetDescriptionAndCustomObjects(thisApiSet.Models.ApiDocs.Parameter,Microsoft.OpenApi.Models.OpenApiParameter).parameter'></a>

`parameter` [Microsoft.OpenApi.Models.OpenApiParameter](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiParameter 'Microsoft.OpenApi.Models.OpenApiParameter')

the [Microsoft.OpenApi.Models.OpenApiParameter](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiParameter 'Microsoft.OpenApi.Models.OpenApiParameter') object that contains the Description to parse.