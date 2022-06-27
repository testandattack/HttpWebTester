#### [Engines.ApiDocs](Engines.ApiDocs.md 'Engines.ApiDocs')
### [Engines.ApiDocs](Engines.ApiDocs.md#Engines.ApiDocs 'Engines.ApiDocs')

## ApiSetEngine Class

A collection of objects and information that cn be used to 
generate webtests for the API.

```csharp
public class ApiSetEngine
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiSetEngine

### Remarks
This set of information is language agnostic and built from OpenApi 
Documentation so that it can be consumed by test creation software
directly. The reason for this extra step is because the ApiSet object
incorporates custom code and OpenApiSchema extensions that enhance
the swagger documentation way beyond the normal information available.