#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiAnalyzer](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiAnalyzer 'ApiTestGenerator.Models.ApiAnalyzer')

## LookupComponent Class

```csharp
public class LookupComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LookupComponent
### Properties

<a name='ApiTestGenerator.Models.ApiAnalyzer.LookupComponent.EndpointNames'></a>

## LookupComponent.EndpointNames Property

The names of the Endpoints returning this DTO.

```csharp
public System.Collections.Generic.List<string> EndpointNames { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiTestGenerator.Models.ApiAnalyzer.LookupComponent.ResponseObject'></a>

## LookupComponent.ResponseObject Property

[Extension] - This is a collection of objects in the response

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiDocs.AbbreviatedResponseObject> ResponseObject { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[AbbreviatedResponseObject](AbbreviatedResponseObject.md 'ApiTestGenerator.Models.ApiDocs.AbbreviatedResponseObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiTestGenerator.Models.ApiAnalyzer.LookupComponent.ResponseObjectName'></a>

## LookupComponent.ResponseObjectName Property

[Extension] - The class 'name' of response object for  
responses that use a $ref tag to reference a [ComponentEngine](https://docs.microsoft.com/en-us/dotnet/api/ComponentEngine 'ComponentEngine')

```csharp
public string ResponseObjectName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiAnalyzer.LookupComponent.ResponseObjectType'></a>

## LookupComponent.ResponseObjectType Property

A [ResponseTypeEnum](ResponseTypeEnum.md 'ApiTestGenerator.Models.Enums.ResponseTypeEnum') value that describes the  
type of response object returned.

```csharp
public ApiTestGenerator.Models.Enums.ResponseTypeEnum ResponseObjectType { get; set; }
```

#### Property Value
[ResponseTypeEnum](ResponseTypeEnum.md 'ApiTestGenerator.Models.Enums.ResponseTypeEnum')