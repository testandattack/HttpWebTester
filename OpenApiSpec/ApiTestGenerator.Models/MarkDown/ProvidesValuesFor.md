#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## ProvidesValuesFor Class

A [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') class designed to hold a  
list of class names that this method's response object can  
provide values to.

```csharp
public class ProvidesValuesFor : ApiTestGenerator.Models.ApiDocs.CustomEndPointObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') &#129106; ProvidesValuesFor

### Remarks
This allows the test generator to line up the endpoints that  
will get input from this endpoint's response object  
using the [MethodName](MethodName.md 'ApiTestGenerator.Models.ApiDocs.MethodName') entries in  
other endpoints.
### Constructors

<a name='ApiTestGenerator.Models.ApiDocs.ProvidesValuesFor.ProvidesValuesFor()'></a>

## ProvidesValuesFor() Constructor

Creates a new instance of the [ProvidesValuesFor](ProvidesValuesFor.md 'ApiTestGenerator.Models.ApiDocs.ProvidesValuesFor') object.

```csharp
public ProvidesValuesFor();
```

<a name='ApiTestGenerator.Models.ApiDocs.ProvidesValuesFor.ProvidesValuesFor(System.Collections.Generic.List_string_)'></a>

## ProvidesValuesFor(List<string>) Constructor

Creates a new instance of the [MethodName](MethodName.md 'ApiTestGenerator.Models.ApiDocs.MethodName') object  
and adds the [ProvidesValuesForTheseMethods](ProvidesValuesFor.md#ApiTestGenerator.Models.ApiDocs.ProvidesValuesFor.ProvidesValuesForTheseMethods 'ApiTestGenerator.Models.ApiDocs.ProvidesValuesFor.ProvidesValuesForTheseMethods') values to the object.

```csharp
public ProvidesValuesFor(System.Collections.Generic.List<string> endPoints);
```
#### Parameters

<a name='ApiTestGenerator.Models.ApiDocs.ProvidesValuesFor.ProvidesValuesFor(System.Collections.Generic.List_string_).endPoints'></a>

`endPoints` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

the name of the source code method as described in the   
            [TKN_ProvidesValuesFor](ParserTokens.md#ApiTestGenerator.Models.Consts.ParserTokens.TKN_ProvidesValuesFor 'ApiTestGenerator.Models.Consts.ParserTokens.TKN_ProvidesValuesFor') property of the Swagger Documentation.
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.ProvidesValuesFor.ProvidesValuesForTheseMethods'></a>

## ProvidesValuesFor.ProvidesValuesForTheseMethods Property

A list of class names that can get input values from this endpoint's   
response object.

```csharp
public System.Collections.Generic.List<string> ProvidesValuesForTheseMethods { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')