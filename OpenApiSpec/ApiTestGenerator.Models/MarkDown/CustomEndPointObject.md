#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## CustomEndPointObject Class

Base Abstract class for describing custom objects that can be added  
to Swagger Documentation.

```csharp
public abstract class CustomEndPointObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CustomEndPointObject

Derived  
&#8627; [CalculatedDateValue](CalculatedDateValue.md 'ApiTestGenerator.Models.ApiDocs.CalculatedDateValue')  
&#8627; [GetsInputFrom](GetsInputFrom.md 'ApiTestGenerator.Models.ApiDocs.GetsInputFrom')  
&#8627; [MethodName](MethodName.md 'ApiTestGenerator.Models.ApiDocs.MethodName')  
&#8627; [ProvidesValuesFor](ProvidesValuesFor.md 'ApiTestGenerator.Models.ApiDocs.ProvidesValuesFor')  
&#8627; [RestrictTo](RestrictTo.md 'ApiTestGenerator.Models.ApiDocs.RestrictTo')  
&#8627; [TestDataFilter](TestDataFilter.md 'ApiTestGenerator.Models.ApiDocs.TestDataFilter')
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.CustomEndPointObject.customEndPointObjectType'></a>

## CustomEndPointObject.customEndPointObjectType Property

Enum describing the type of custom object

```csharp
public ApiTestGenerator.Models.Enums.CustomEndPointObjectTypeEnum customEndPointObjectType { get; set; }
```

#### Property Value
[CustomEndPointObjectTypeEnum](CustomEndPointObjectTypeEnum.md 'ApiTestGenerator.Models.Enums.CustomEndPointObjectTypeEnum')