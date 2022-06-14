#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## Property Class

A custom object that implements some of the   
[http://spec.openapis.org/oas/v3.0.3#properties](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#properties 'http://spec.openapis.org/oas/v3.0.3#properties') listed in   
the OpenApiSpec.

```csharp
public class Property
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Property
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.Property.arrayFormat'></a>

## Property.arrayFormat Property

If array is of an OpenApi primitive type, this field describes the  
format of the type contained in the array.

```csharp
public string arrayFormat { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
Primitives have an optional modifier property: format. OAS uses several known formats   
to define in fine detail the data type being used. However, to support documentation   
needs, the format property is an open string-valued property, and can have any value.   
Formats such as "email", "uuid", and so on, MAY be used even though undefined by this   
specification. Types that are not accompanied by a format property follow the type   
definition in the JSON Schema. Tools that do not recognize a specific format MAY default   
back to the type alone, as if the format is not specified.

<a name='ApiTestGenerator.Models.ApiDocs.Property.arrayType'></a>

## Property.arrayType Property

If [IsArray](Property.md#ApiTestGenerator.Models.ApiDocs.Property.IsArray 'ApiTestGenerator.Models.ApiDocs.Property.IsArray') = true, this tells the type of items in the array

```csharp
public string arrayType { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
Primitive data types in the OAS are based on the types supported by the JSON Schema   
Specification Wright Draft 00. Note that integer as a type is also supported and is   
defined as a JSON number without a fraction or exponent part. null is not supported   
as a type (see nullable for an alternative solution). Models are defined using the   
Schema Object, which is an extended subset of JSON Schema Specification Wright Draft 00.

<a name='ApiTestGenerator.Models.ApiDocs.Property.customEndPointObjects'></a>

## Property.customEndPointObjects Property

A list of [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') items that may be added to the parameter.

```csharp
public System.Collections.Generic.List<ApiTestGenerator.Models.ApiDocs.CustomEndPointObject> customEndPointObjects { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiTestGenerator.Models.ApiDocs.Property.Description'></a>

## Property.Description Property

The description of the parameter

```csharp
public string Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
The text that shows up in the Description   
            is any text added through XML Comments to the parameter   
            in the API code

<a name='ApiTestGenerator.Models.ApiDocs.Property.Format'></a>

## Property.Format Property

If array is of an OpenApi primitive type, this field describes the  
format of the type contained in the array.

```csharp
public string Format { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
Primitives have an optional modifier property: format. OAS uses several known formats   
to define in fine detail the data type being used. However, to support documentation   
needs, the format property is an open string-valued property, and can have any value.   
Formats such as "email", "uuid", and so on, MAY be used even though undefined by this   
specification. Types that are not accompanied by a format property follow the type   
definition in the JSON Schema. Tools that do not recognize a specific format MAY default   
back to the type alone, as if the format is not specified.

<a name='ApiTestGenerator.Models.ApiDocs.Property.IsArray'></a>

## Property.IsArray Property

True if the parameter is an array of items

```csharp
public bool IsArray { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiTestGenerator.Models.ApiDocs.Property.Name'></a>

## Property.Name Property

The name of the item

```csharp
public string Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.Property.propertyParsingError'></a>

## Property.propertyParsingError Property

A string that holds any error message that arose while parsing the component  
for all properties.

```csharp
public string propertyParsingError { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.Property.Reference'></a>

## Property.Reference Property

A string pointing to another object to be referenced.  
[http://spec.openapis.org/oas/v3.0.3#fixed-fields-18](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#fixed-fields-18 'http://spec.openapis.org/oas/v3.0.3#fixed-fields-18')   
for more information.

```csharp
public string Reference { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.Property.Type'></a>

## Property.Type Property

The [OpenApi defined Type](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#data-types 'http://spec.openapis.org/oas/v3.0.3#data-types')   
of the property.

```csharp
public string Type { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')