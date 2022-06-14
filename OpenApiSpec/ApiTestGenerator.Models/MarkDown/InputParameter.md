#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiAnalyzer](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiAnalyzer 'ApiTestGenerator.Models.ApiAnalyzer')

## InputParameter Class

```csharp
public class InputParameter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; InputParameter
### Properties

<a name='ApiTestGenerator.Models.ApiAnalyzer.InputParameter.arrayFormat'></a>

## InputParameter.arrayFormat Property

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

<a name='ApiTestGenerator.Models.ApiAnalyzer.InputParameter.arrayType'></a>

## InputParameter.arrayType Property

If [IsArray](InputParameter.md#ApiTestGenerator.Models.ApiAnalyzer.InputParameter.IsArray 'ApiTestGenerator.Models.ApiAnalyzer.InputParameter.IsArray') = true, this tells the type of items in the array

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

<a name='ApiTestGenerator.Models.ApiAnalyzer.InputParameter.Description'></a>

## InputParameter.Description Property

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

<a name='ApiTestGenerator.Models.ApiAnalyzer.InputParameter.Format'></a>

## InputParameter.Format Property

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

<a name='ApiTestGenerator.Models.ApiAnalyzer.InputParameter.IsArray'></a>

## InputParameter.IsArray Property

True if the parameter is an array of items

```csharp
public bool IsArray { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiTestGenerator.Models.ApiAnalyzer.InputParameter.Name'></a>

## InputParameter.Name Property

The name of the item

```csharp
public string Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiAnalyzer.InputParameter.Reference'></a>

## InputParameter.Reference Property

A string pointing to another object to be referenced.  
[http://spec.openapis.org/oas/v3.0.3#fixed-fields-18](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#fixed-fields-18 'http://spec.openapis.org/oas/v3.0.3#fixed-fields-18')   
for more information.

```csharp
public string Reference { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiAnalyzer.InputParameter.Type'></a>

## InputParameter.Type Property

The [OpenApi defined Type](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#data-types 'http://spec.openapis.org/oas/v3.0.3#data-types')   
of the property.

```csharp
public string Type { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')