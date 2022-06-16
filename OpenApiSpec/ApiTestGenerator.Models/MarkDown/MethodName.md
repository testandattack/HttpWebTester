#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## MethodName Class

A [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') class designed to hold the  
class name of the API method in the Endpoint.

```csharp
public class MethodName : ApiTestGenerator.Models.ApiDocs.CustomEndPointObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') &#129106; MethodName

### Remarks
This allows the test generator to line up the endpoints with the   
[ProvidesValuesFor](ProvidesValuesFor.md 'ApiTestGenerator.Models.ApiDocs.ProvidesValuesFor') entries in  
other endpoints.
### Constructors

<a name='ApiTestGenerator.Models.ApiDocs.MethodName.MethodName()'></a>

## MethodName() Constructor

Creates a new instance of the [MethodName](MethodName.md 'ApiTestGenerator.Models.ApiDocs.MethodName') object.

```csharp
public MethodName();
```

<a name='ApiTestGenerator.Models.ApiDocs.MethodName.MethodName(string)'></a>

## MethodName(string) Constructor

Creates a new instance of the [MethodName](MethodName.md 'ApiTestGenerator.Models.ApiDocs.MethodName') object  
and adds the [methodName](MethodName.md#ApiTestGenerator.Models.ApiDocs.MethodName.methodName 'ApiTestGenerator.Models.ApiDocs.MethodName.methodName') value to the object.

```csharp
public MethodName(string name);
```
#### Parameters

<a name='ApiTestGenerator.Models.ApiDocs.MethodName.MethodName(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the name of the source code method as described in the   
            [TKN_MethodName](ParserTokens.md#ApiTestGenerator.Models.Consts.ParserTokens.TKN_MethodName 'ApiTestGenerator.Models.Consts.ParserTokens.TKN_MethodName') property of the Swagger Documentation.
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.MethodName.methodName'></a>

## MethodName.methodName Property

The class name of the method housing this endpoint.

```csharp
public string methodName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')