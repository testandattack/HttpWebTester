#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## GetsInputFrom Class

A [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') class designed to hold the  
class name of the API method in the Endpoint.

```csharp
public class GetsInputFrom : ApiTestGenerator.Models.ApiDocs.CustomEndPointObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') &#129106; GetsInputFrom

### Remarks
This allows the test generator to line up the endpoints with the   
[ProvidesValuesFor](ProvidesValuesFor.md 'ApiTestGenerator.Models.ApiDocs.ProvidesValuesFor') entries in  
other endpoints.
### Constructors

<a name='ApiTestGenerator.Models.ApiDocs.GetsInputFrom.GetsInputFrom()'></a>

## GetsInputFrom() Constructor

Creates a new instance of the [GetsInputFrom](GetsInputFrom.md 'ApiTestGenerator.Models.ApiDocs.GetsInputFrom') object.

```csharp
public GetsInputFrom();
```

<a name='ApiTestGenerator.Models.ApiDocs.GetsInputFrom.GetsInputFrom(string)'></a>

## GetsInputFrom(string) Constructor

Creates a new instance of the [GetsInputFrom](GetsInputFrom.md 'ApiTestGenerator.Models.ApiDocs.GetsInputFrom') object  
and adds the [PropertyName](GetsInputFrom.md#ApiTestGenerator.Models.ApiDocs.GetsInputFrom.PropertyName 'ApiTestGenerator.Models.ApiDocs.GetsInputFrom.PropertyName') value to the object.

```csharp
public GetsInputFrom(string name);
```
#### Parameters

<a name='ApiTestGenerator.Models.ApiDocs.GetsInputFrom.GetsInputFrom(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the name of the object that contains the input values
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.GetsInputFrom.PropertyName'></a>

## GetsInputFrom.PropertyName Property

The class name of the method housing this endpoint.

```csharp
public string PropertyName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')