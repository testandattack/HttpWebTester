#### [ApiDocs.CustomObjects](ApiDocs.CustomObjects.md 'ApiDocs.CustomObjects')
### [ApiDocs.CustomObjects](ApiDocs.CustomObjects.md#ApiDocs.CustomObjects 'ApiDocs.CustomObjects')

## CustomOasObjectEngine Class

Base Abstract class for describing custom objects that can be added  
to Swagger Documentation.

```csharp
public class CustomOasObjectEngine :
ApiDocs.CustomObjects.ICustomOasObjectEngine<ApiDocs.CustomObjects.CustomOasObjectEngine>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CustomOasObjectEngine

Derived  
&#8627; [ProvidesValuesFor_CustomOasObjectEngine](ProvidesValuesFor_CustomOasObjectEngine.md 'ApiDocs.CustomObjects.ProvidesValuesFor_CustomOasObjectEngine')

Implements [ApiDocs.CustomObjects.ICustomOasObjectEngine&lt;](ICustomOasObjectEngine_T_.md 'ApiDocs.CustomObjects.ICustomOasObjectEngine<T>')[CustomOasObjectEngine](CustomOasObjectEngine.md 'ApiDocs.CustomObjects.CustomOasObjectEngine')[&gt;](ICustomOasObjectEngine_T_.md 'ApiDocs.CustomObjects.ICustomOasObjectEngine<T>')
### Methods

<a name='ApiDocs.CustomObjects.CustomOasObjectEngine.LookForCustomObjects(Microsoft.OpenApi.Models.OpenApiOperation,ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection)'></a>

## CustomOasObjectEngine.LookForCustomObjects(OpenApiOperation, CustomOasObjectCollection) Method

This method triggers the building of event handlers and the triggering of the  
events themselves. It is called by the `Endpoint Engine`.

```csharp
public void LookForCustomObjects(Microsoft.OpenApi.Models.OpenApiOperation openApiOperation, ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection items);
```
#### Parameters

<a name='ApiDocs.CustomObjects.CustomOasObjectEngine.LookForCustomObjects(Microsoft.OpenApi.Models.OpenApiOperation,ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection).openApiOperation'></a>

`openApiOperation` [Microsoft.OpenApi.Models.OpenApiOperation](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiOperation 'Microsoft.OpenApi.Models.OpenApiOperation')

<a name='ApiDocs.CustomObjects.CustomOasObjectEngine.LookForCustomObjects(Microsoft.OpenApi.Models.OpenApiOperation,ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection).items'></a>

`items` [ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection 'ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection')