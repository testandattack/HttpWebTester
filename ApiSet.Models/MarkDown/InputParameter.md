#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Models.ApiAnalyzer](ApiTestGenerator.Models.md#ApiSet.Models.ApiAnalyzer 'ApiSet.Models.ApiAnalyzer')

## InputParameter Class

```csharp
public class InputParameter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; InputParameter
### Constructors

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.InputParameter()'></a>

## InputParameter() Constructor

```csharp
public InputParameter();
```

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.InputParameter(string,string,string,bool,string,string,bool,string,string)'></a>

## InputParameter(string, string, string, bool, string, string, bool, string, string) Constructor

```csharp
public InputParameter(string name, string description, string type, bool isArray, string ArrayType, string format, bool required, string inputProvider, string showsUpIn);
```
#### Parameters

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.InputParameter(string,string,string,bool,string,string,bool,string,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.InputParameter(string,string,string,bool,string,string,bool,string,string).description'></a>

`description` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.InputParameter(string,string,string,bool,string,string,bool,string,string).type'></a>

`type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.InputParameter(string,string,string,bool,string,string,bool,string,string).isArray'></a>

`isArray` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.InputParameter(string,string,string,bool,string,string,bool,string,string).ArrayType'></a>

`ArrayType` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.InputParameter(string,string,string,bool,string,string,bool,string,string).format'></a>

`format` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.InputParameter(string,string,string,bool,string,string,bool,string,string).required'></a>

`required` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.InputParameter(string,string,string,bool,string,string,bool,string,string).inputProvider'></a>

`inputProvider` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.InputParameter(string,string,string,bool,string,string,bool,string,string).showsUpIn'></a>

`showsUpIn` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Properties

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.arrayFormat'></a>

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

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.arrayType'></a>

## InputParameter.arrayType Property

If [IsArray](InputParameter.md#ApiSet.Models.ApiAnalyzer.InputParameter.IsArray 'ApiSet.Models.ApiAnalyzer.InputParameter.IsArray') = true, this tells the type of items in the array

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

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.Description'></a>

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

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.Format'></a>

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

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.InputProvider'></a>

## InputParameter.InputProvider Property

```csharp
public string InputProvider { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.IsArray'></a>

## InputParameter.IsArray Property

True if the parameter is an array of items

```csharp
public bool IsArray { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.MatchesTheseComponents'></a>

## InputParameter.MatchesTheseComponents Property

```csharp
public System.Collections.Generic.List<string> MatchesTheseComponents { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.Name'></a>

## InputParameter.Name Property

The name of the item

```csharp
public string Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.NameVariations'></a>

## InputParameter.NameVariations Property

```csharp
public System.Collections.Generic.List<string> NameVariations { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.Reference'></a>

## InputParameter.Reference Property

A string pointing to another object to be referenced.  
[http://spec.openapis.org/oas/v3.0.3#fixed-fields-18](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#fixed-fields-18 'http://spec.openapis.org/oas/v3.0.3#fixed-fields-18')   
for more information.

```csharp
public string Reference { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.Required'></a>

## InputParameter.Required Property

```csharp
public bool Required { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.ShowsUpIn'></a>

## InputParameter.ShowsUpIn Property

```csharp
public string ShowsUpIn { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.Type'></a>

## InputParameter.Type Property

The [OpenApi defined Type](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#data-types 'http://spec.openapis.org/oas/v3.0.3#data-types')   
of the property.

```csharp
public string Type { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.UsedByTheseEndpoints'></a>

## InputParameter.UsedByTheseEndpoints Property

```csharp
public System.Collections.Generic.List<string> UsedByTheseEndpoints { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')
### Methods

<a name='ApiSet.Models.ApiAnalyzer.InputParameter.GetHashCode()'></a>

## InputParameter.GetHashCode() Method

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')