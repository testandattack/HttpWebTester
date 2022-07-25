#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Models.ApiDocs](ApiTestGenerator.Models.md#ApiSet.Models.ApiDocs 'ApiSet.Models.ApiDocs')

## Parameter Class

An object the contains information about input parameters for OpenApi endpoint calls  
It is based on the [https://spec.openapis.org/oas/v3.0.0#parameter-object](https://spec.openapis.org/oas/v3.0.0#parameter-object 'https://spec.openapis.org/oas/v3.0.0#parameter-object') OAS object.

```csharp
public class Parameter :
System.IComparable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Parameter

Implements [System.IComparable](https://docs.microsoft.com/en-us/dotnet/api/System.IComparable 'System.IComparable')
### Constructors

<a name='ApiSet.Models.ApiDocs.Parameter.Parameter()'></a>

## Parameter() Constructor

Creates a new instance of the [Parameter](Parameter.md 'ApiSet.Models.ApiDocs.Parameter') object

```csharp
public Parameter();
```

<a name='ApiSet.Models.ApiDocs.Parameter.Parameter(string)'></a>

## Parameter(string) Constructor

Creates a new instance of the [Parameter](Parameter.md 'ApiSet.Models.ApiDocs.Parameter') object  
and initializes the [controllerName](Parameter.md#ApiSet.Models.ApiDocs.Parameter.controllerName 'ApiSet.Models.ApiDocs.Parameter.controllerName') properties

```csharp
public Parameter(string ControllerName);
```
#### Parameters

<a name='ApiSet.Models.ApiDocs.Parameter.Parameter(string).ControllerName'></a>

`ControllerName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

[controllerName](Parameter.md#ApiSet.Models.ApiDocs.Parameter.controllerName 'ApiSet.Models.ApiDocs.Parameter.controllerName')
### Properties

<a name='ApiSet.Models.ApiDocs.Parameter.arrayFormat'></a>

## Parameter.arrayFormat Property

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

<a name='ApiSet.Models.ApiDocs.Parameter.arrayType'></a>

## Parameter.arrayType Property

If [IsArray](Parameter.md#ApiSet.Models.ApiDocs.Parameter.IsArray 'ApiSet.Models.ApiDocs.Parameter.IsArray') = true, this tells the type of items in the array

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

<a name='ApiSet.Models.ApiDocs.Parameter.controllerName'></a>

## Parameter.controllerName Property

Allows for a link back to the parent endpoint through   
[controllerName](Parameter.md#ApiSet.Models.ApiDocs.Parameter.controllerName 'ApiSet.Models.ApiDocs.Parameter.controllerName') + [uriMethod](Parameter.md#ApiSet.Models.ApiDocs.Parameter.uriMethod 'ApiSet.Models.ApiDocs.Parameter.uriMethod') + [uriPath](Parameter.md#ApiSet.Models.ApiDocs.Parameter.uriPath 'ApiSet.Models.ApiDocs.Parameter.uriPath')

```csharp
public string controllerName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiDocs.Parameter.customEndPointObjects'></a>

## Parameter.customEndPointObjects Property

A list of [CustomOasObjectCollection](CustomOasObjectCollection.md 'ApiSet.Models.ApiDocs.CustomOasObjectCollection') items that may be added to the parameter.

```csharp
public ApiSet.Models.ApiDocs.CustomOasObjectCollection customEndPointObjects { get; set; }
```

#### Property Value
[CustomOasObjectCollection](CustomOasObjectCollection.md 'ApiSet.Models.ApiDocs.CustomOasObjectCollection')

<a name='ApiSet.Models.ApiDocs.Parameter.Description'></a>

## Parameter.Description Property

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

<a name='ApiSet.Models.ApiDocs.Parameter.ExampleValue'></a>

## Parameter.ExampleValue Property

Represents an [
            OpenApi Example](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#example-object 'http://spec.openapis.org/oas/v3.0.3#example-object') entry.

```csharp
public ApiSet.Models.ApiDocs.ExampleValue ExampleValue { get; set; }
```

#### Property Value
[ExampleValue](ExampleValue.md 'ApiSet.Models.ApiDocs.ExampleValue')

### Remarks
Example of the parameter’s potential value. The example SHOULD match the   
specified schema and encoding properties if present. The example field is   
mutually exclusive of the examples field. Furthermore, if referencing a schema   
that contains an example, the example value SHALL override the example provided   
by the schema. To represent examples of media types that cannot naturally be   
represented in JSON or YAML, a string value can contain the example with escaping   
where necessary.

<a name='ApiSet.Models.ApiDocs.Parameter.ExampleValues'></a>

## Parameter.ExampleValues Property

Represents a list of [
            OpenApi Example](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#example-object 'http://spec.openapis.org/oas/v3.0.3#example-object') entries.

```csharp
public System.Collections.Generic.Dictionary<string,ApiSet.Models.ApiDocs.ExampleValue> ExampleValues { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ExampleValue](ExampleValue.md 'ApiSet.Models.ApiDocs.ExampleValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

### Remarks
Examples of the parameter’s potential value. Each example SHOULD contain a value   
in the correct format as specified in the parameter encoding. The examples field   
is mutually exclusive of the example field. Furthermore, if referencing a schema   
that contains an example, the examples value SHALL override the example provided   
by the schema.

<a name='ApiSet.Models.ApiDocs.Parameter.Format'></a>

## Parameter.Format Property

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

<a name='ApiSet.Models.ApiDocs.Parameter.inputProvider'></a>

## Parameter.inputProvider Property

Stores the value of a custom token [ParseTokens.TKN_GetsInputFrom](https://docs.microsoft.com/en-us/dotnet/api/ParseTokens.TKN_GetsInputFrom 'ParseTokens.TKN_GetsInputFrom') that  
references what response object to use when getting test values for this parameter.

```csharp
public string inputProvider { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiDocs.Parameter.IsArray'></a>

## Parameter.IsArray Property

True if the parameter is an array of items

```csharp
public bool IsArray { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiSet.Models.ApiDocs.Parameter.Name'></a>

## Parameter.Name Property

The name of the item

```csharp
public string Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiDocs.Parameter.Reference'></a>

## Parameter.Reference Property

A string pointing to another object to be referenced.  
[http://spec.openapis.org/oas/v3.0.3#fixed-fields-18](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#fixed-fields-18 'http://spec.openapis.org/oas/v3.0.3#fixed-fields-18')   
for more information.

```csharp
public string Reference { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiDocs.Parameter.Required'></a>

## Parameter.Required Property

Shows whether the parameter is mandatory

```csharp
public bool Required { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiSet.Models.ApiDocs.Parameter.ShowsUpIn'></a>

## Parameter.ShowsUpIn Property

describes the location where the parameter can appear

```csharp
public string ShowsUpIn { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
Possible values are:  
              
- query  
- header  
- path  
- cookie

<a name='ApiSet.Models.ApiDocs.Parameter.Type'></a>

## Parameter.Type Property

The [OpenApi defined Type](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#data-types 'http://spec.openapis.org/oas/v3.0.3#data-types')   
of the property.

```csharp
public string Type { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiDocs.Parameter.uriMethod'></a>

## Parameter.uriMethod Property

Allows for a link back to the parent endpoint through   
[controllerName](Parameter.md#ApiSet.Models.ApiDocs.Parameter.controllerName 'ApiSet.Models.ApiDocs.Parameter.controllerName') + [uriMethod](Parameter.md#ApiSet.Models.ApiDocs.Parameter.uriMethod 'ApiSet.Models.ApiDocs.Parameter.uriMethod') + [uriPath](Parameter.md#ApiSet.Models.ApiDocs.Parameter.uriPath 'ApiSet.Models.ApiDocs.Parameter.uriPath')

```csharp
public string uriMethod { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiDocs.Parameter.uriPath'></a>

## Parameter.uriPath Property

Allows for a link back to the parent endpoint through   
[controllerName](Parameter.md#ApiSet.Models.ApiDocs.Parameter.controllerName 'ApiSet.Models.ApiDocs.Parameter.controllerName') + [uriMethod](Parameter.md#ApiSet.Models.ApiDocs.Parameter.uriMethod 'ApiSet.Models.ApiDocs.Parameter.uriMethod') + [uriPath](Parameter.md#ApiSet.Models.ApiDocs.Parameter.uriPath 'ApiSet.Models.ApiDocs.Parameter.uriPath')

```csharp
public string uriPath { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')