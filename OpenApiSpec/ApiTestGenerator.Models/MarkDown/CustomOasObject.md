#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## CustomOasObject Class

This is the base class for creating custom objects.

```csharp
public class CustomOasObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CustomOasObject
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.CustomOasObject.CustomObjectName'></a>

## CustomOasObject.CustomObjectName Property

The name of the custom object.

```csharp
public string CustomObjectName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
The preferred convention (per the OAS standards) is to make the name of any custom entry 
use "x-" at the beginning of the custom entry. The two samples included with the ApiSet
code have names of:
- x-provides-values-for
- x-method-name

<a name='ApiTestGenerator.Models.ApiDocs.CustomOasObject.CustomObjectValue'></a>

## CustomOasObject.CustomObjectValue Property

The value of the custom item.

```csharp
public object CustomObjectValue { get; set; }
```

#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

### Remarks
The ApiSet parsing engine assumes that the value is stored in the OAS as a string.
The custom methods you can provide may convert the string into a standard object,
such as a List or Dictionary, but you will have to provide the parser to convert 
the string into that object.