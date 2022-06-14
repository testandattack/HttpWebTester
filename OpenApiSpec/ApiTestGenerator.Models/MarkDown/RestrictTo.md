#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## RestrictTo Class

Looks for [RestrictToRoles] entries in the endppoint and stores a  
list of those entries.

```csharp
public class RestrictTo : ApiTestGenerator.Models.ApiDocs.CustomEndPointObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') &#129106; RestrictTo

### Remarks
This allows the test generator to line up the roles with roles  
assigned to test users and then formulate whether the user should  
be denied access to the endpoint.
### Constructors

<a name='ApiTestGenerator.Models.ApiDocs.RestrictTo.RestrictTo()'></a>

## RestrictTo() Constructor

Creates a new instance of the [RestrictTo](RestrictTo.md 'ApiTestGenerator.Models.ApiDocs.RestrictTo') object.

```csharp
public RestrictTo();
```

<a name='ApiTestGenerator.Models.ApiDocs.RestrictTo.RestrictTo(System.Collections.Generic.List_string_)'></a>

## RestrictTo(List<string>) Constructor

Creates a new instance of the [RestrictTo](RestrictTo.md 'ApiTestGenerator.Models.ApiDocs.RestrictTo') object  
and adds the [RestrictToRoles](RestrictTo.md#ApiTestGenerator.Models.ApiDocs.RestrictTo.RestrictToRoles 'ApiTestGenerator.Models.ApiDocs.RestrictTo.RestrictToRoles') values to the object.

```csharp
public RestrictTo(System.Collections.Generic.List<string> roles);
```
#### Parameters

<a name='ApiTestGenerator.Models.ApiDocs.RestrictTo.RestrictTo(System.Collections.Generic.List_string_).roles'></a>

`roles` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

the name of the source code method as described in the   
            [TKN_RestrictTo](ParseTokens.md#ApiTestGenerator.Models.Consts.ParseTokens.TKN_RestrictTo 'ApiTestGenerator.Models.Consts.ParseTokens.TKN_RestrictTo') property of the Swagger Documentation.
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.RestrictTo.RestrictToRoles'></a>

## RestrictTo.RestrictToRoles Property

A list of the roles that are ALLOWED to access this endpoint.

```csharp
public System.Collections.Generic.List<string> RestrictToRoles { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')