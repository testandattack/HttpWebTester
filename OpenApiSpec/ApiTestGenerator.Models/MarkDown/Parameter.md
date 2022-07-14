#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

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

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.Parameter()'></a>

## Parameter() Constructor

Creates a new instance of the [Parameter](Parameter.md 'ApiTestGenerator.Models.ApiDocs.Parameter') object

```csharp
public Parameter();
```

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.Parameter(int,string)'></a>

## Parameter(int, string) Constructor

Creates a new instance of the [Parameter](Parameter.md 'ApiTestGenerator.Models.ApiDocs.Parameter') object  
and initializes the [operationId](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.operationId 'ApiTestGenerator.Models.ApiDocs.Parameter.operationId') and [controllerName](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.controllerName 'ApiTestGenerator.Models.ApiDocs.Parameter.controllerName') properties

```csharp
public Parameter(int operationNumber, string ControllerName);
```
#### Parameters

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.Parameter(int,string).operationNumber'></a>

`operationNumber` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

[operationId](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.operationId 'ApiTestGenerator.Models.ApiDocs.Parameter.operationId')

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.Parameter(int,string).ControllerName'></a>

`ControllerName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

[controllerName](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.controllerName 'ApiTestGenerator.Models.ApiDocs.Parameter.controllerName')
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.arrayFormat'></a>

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

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.arrayType'></a>

## Parameter.arrayType Property

If [IsArray](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.IsArray 'ApiTestGenerator.Models.ApiDocs.Parameter.IsArray') = true, this tells the type of items in the array

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

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.controllerName'></a>

## Parameter.controllerName Property

Allows for a link back to the parent endpoint through   
[controllerName](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.controllerName 'ApiTestGenerator.Models.ApiDocs.Parameter.controllerName') + [uriMethod](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.uriMethod 'ApiTestGenerator.Models.ApiDocs.Parameter.uriMethod') + [uriPath](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.uriPath 'ApiTestGenerator.Models.ApiDocs.Parameter.uriPath')

```csharp
public string controllerName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.customEndPointObjects'></a>

## Parameter.customEndPointObjects Property

A list of [CustomOasObjectCollection](CustomOasObjectCollection.md 'ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection') items that may be added to the parameter.

```csharp
public ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection customEndPointObjects { get; set; }
```

#### Property Value
[CustomOasObjectCollection](CustomOasObjectCollection.md 'ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection')

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.Description'></a>

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

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.ExampleValue'></a>

## Parameter.ExampleValue Property

Represents an [
            OpenApi Example](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#example-object 'http://spec.openapis.org/oas/v3.0.3#example-object') entry.

```csharp
public ApiTestGenerator.Models.ApiDocs.ExampleValue ExampleValue { get; set; }
```

#### Property Value
[ExampleValue](ExampleValue.md 'ApiTestGenerator.Models.ApiDocs.ExampleValue')

### Remarks
Example of the parameter’s potential value. The example SHOULD match the   
specified schema and encoding properties if present. The example field is   
mutually exclusive of the examples field. Furthermore, if referencing a schema   
that contains an example, the example value SHALL override the example provided   
by the schema. To represent examples of media types that cannot naturally be   
represented in JSON or YAML, a string value can contain the example with escaping   
where necessary.

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.ExampleValues'></a>

## Parameter.ExampleValues Property

Represents a list of [
            OpenApi Example](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#example-object 'http://spec.openapis.org/oas/v3.0.3#example-object') entries.

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiDocs.ExampleValue> ExampleValues { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ExampleValue](ExampleValue.md 'ApiTestGenerator.Models.ApiDocs.ExampleValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

### Remarks
Examples of the parameter’s potential value. Each example SHOULD contain a value   
in the correct format as specified in the parameter encoding. The examples field   
is mutually exclusive of the example field. Furthermore, if referencing a schema   
that contains an example, the examples value SHALL override the example provided   
by the schema.

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.Format'></a>

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

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.inputProvider'></a>

## Parameter.inputProvider Property

Stores the value of a custom token [ParseTokens.TKN_GetsInputFrom](https://docs.microsoft.com/en-us/dotnet/api/ParseTokens.TKN_GetsInputFrom 'ParseTokens.TKN_GetsInputFrom') that  
references what response object to use when getting test values for this parameter.

```csharp
public string inputProvider { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.IsArray'></a>

## Parameter.IsArray Property

True if the parameter is an array of items

```csharp
public bool IsArray { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.Name'></a>

## Parameter.Name Property

The name of the item

```csharp
public string Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.operationId'></a>

## Parameter.operationId Property

This is a sequentially assigned Id that shows the order in which the endpoint  
shows up within the controller.

```csharp
public int operationId { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.Reference'></a>

## Parameter.Reference Property

A string pointing to another object to be referenced.  
[http://spec.openapis.org/oas/v3.0.3#fixed-fields-18](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#fixed-fields-18 'http://spec.openapis.org/oas/v3.0.3#fixed-fields-18')   
for more information.

```csharp
public string Reference { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.Required'></a>

## Parameter.Required Property

Shows whether the parameter is mandatory

```csharp
public bool Required { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.ShowsUpIn'></a>

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

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.Type'></a>

## Parameter.Type Property

The [OpenApi defined Type](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#data-types 'http://spec.openapis.org/oas/v3.0.3#data-types')   
of the property.

```csharp
public string Type { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.uriMethod'></a>

## Parameter.uriMethod Property

Allows for a link back to the parent endpoint through   
[controllerName](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.controllerName 'ApiTestGenerator.Models.ApiDocs.Parameter.controllerName') + [uriMethod](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.uriMethod 'ApiTestGenerator.Models.ApiDocs.Parameter.uriMethod') + [uriPath](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.uriPath 'ApiTestGenerator.Models.ApiDocs.Parameter.uriPath')

```csharp
public string uriMethod { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.Parameter.uriPath'></a>

## Parameter.uriPath Property

Allows for a link back to the parent endpoint through   
[controllerName](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.controllerName 'ApiTestGenerator.Models.ApiDocs.Parameter.controllerName') + [uriMethod](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.uriMethod 'ApiTestGenerator.Models.ApiDocs.Parameter.uriMethod') + [uriPath](Parameter.md#ApiTestGenerator.Models.ApiDocs.Parameter.uriPath 'ApiTestGenerator.Models.ApiDocs.Parameter.uriPath')

```csharp
public string uriPath { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')