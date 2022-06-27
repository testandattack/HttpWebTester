#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## RequestBody Class

This class defines a container to house the Request Body
info needed to build a proper request.

```csharp
public class RequestBody
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RequestBody

### Remarks
This class is based loosely off the [
            Request Body](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#request-body-object 'http://spec.openapis.org/oas/v3.0.3#request-body-object') object in the OpenApiSpec.
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.RequestBody.properties'></a>

## RequestBody.properties Property

The list of [Property](Property.md 'ApiTestGenerator.Models.ApiDocs.Property') items
that are associated with the schema.

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiDocs.Property> properties { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[Property](Property.md 'ApiTestGenerator.Models.ApiDocs.Property')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiTestGenerator.Models.ApiDocs.RequestBody.RequestBodyContentType'></a>

## RequestBody.RequestBodyContentType Property

Holds the media content type being passed in through the Request Body.

```csharp
public string RequestBodyContentType { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.RequestBody.RequestBodyFormObjectOrType'></a>

## RequestBody.RequestBodyFormObjectOrType Property

This property holds the [http://spec.openapis.org/oas/v3.0.3#media-type-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#media-type-object 'http://spec.openapis.org/oas/v3.0.3#media-type-object')
of the request object to pass in.

```csharp
public string? RequestBodyFormObjectOrType { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.RequestBody.RequestBodyJsonObject'></a>

## RequestBody.RequestBodyJsonObject Property

If the operation is a POST, PUT or PATCH based request,
this string holds the class name of the Input DTO that is used
as a template for the request body.

```csharp
public string? RequestBodyJsonObject { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.RequestBody.RequestBodySchemaType'></a>

## RequestBody.RequestBodySchemaType Property

This property holds the [http://spec.openapis.org/oas/v3.0.3#media-type-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#media-type-object 'http://spec.openapis.org/oas/v3.0.3#media-type-object')
of the request object to pass in.

```csharp
public string? RequestBodySchemaType { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.RequestBody.RequestBodyString'></a>

## RequestBody.RequestBodyString Property

If the operation is a POST, PUT or PATCH based request,
this string holds the Swagger generated Input template
text that is generated from the $ref entry in the 
[http://spec.openapis.org/oas/v3.0.3#request-body-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#request-body-object 'http://spec.openapis.org/oas/v3.0.3#request-body-object')

```csharp
public string? RequestBodyString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')