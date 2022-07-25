#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Models.ApiAnalyzer](ApiTestGenerator.Models.md#ApiSet.Models.ApiAnalyzer 'ApiSet.Models.ApiAnalyzer')

## LookupEndPoint Class

```csharp
public class LookupEndPoint
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LookupEndPoint
### Properties

<a name='ApiSet.Models.ApiAnalyzer.LookupEndPoint.ControllerName'></a>

## LookupEndPoint.ControllerName Property

The name of the controller housing this endpoint.

```csharp
public string ControllerName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
For controllers that have lookup calls which share  
the same output DTO as a call in the "Lookups" controller,  
This field will track that and will be used to provide  
input to the other endpoints in the same controller.