#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Models.ApiDocs](ApiTestGenerator.Models.md#ApiSet.Models.ApiDocs 'ApiSet.Models.ApiDocs')

## ExampleValue Class

An object loosely based on the [http://spec.openapis.org/oas/v3.0.3#example-object](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#example-object 'http://spec.openapis.org/oas/v3.0.3#example-object')  
object.

```csharp
public class ExampleValue
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExampleValue
### Constructors

<a name='ApiSet.Models.ApiDocs.ExampleValue.ExampleValue()'></a>

## ExampleValue() Constructor

Creates a new instance of the [ExampleValue](ExampleValue.md 'ApiSet.Models.ApiDocs.ExampleValue') object.

```csharp
public ExampleValue();
```

<a name='ApiSet.Models.ApiDocs.ExampleValue.ExampleValue(string,string)'></a>

## ExampleValue(string, string) Constructor

Creates a new instance of the [ExampleValue](ExampleValue.md 'ApiSet.Models.ApiDocs.ExampleValue') object  
and initiates the [Type](ExampleValue.md#ApiSet.Models.ApiDocs.ExampleValue.Type 'ApiSet.Models.ApiDocs.ExampleValue.Type') and [Value](ExampleValue.md#ApiSet.Models.ApiDocs.ExampleValue.Value 'ApiSet.Models.ApiDocs.ExampleValue.Value') properties.

```csharp
public ExampleValue(string type, string value);
```
#### Parameters

<a name='ApiSet.Models.ApiDocs.ExampleValue.ExampleValue(string,string).type'></a>

`type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The [OpenApi defined Type](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#data-types 'http://spec.openapis.org/oas/v3.0.3#data-types') of the example

<a name='ApiSet.Models.ApiDocs.ExampleValue.ExampleValue(string,string).value'></a>

`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The actual value to use.
### Properties

<a name='ApiSet.Models.ApiDocs.ExampleValue.GeneratedValue'></a>

## ExampleValue.GeneratedValue Property

[Extension] - Used to store a formula or other item   
describing how to generate values for the example.

```csharp
public string GeneratedValue { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiDocs.ExampleValue.Type'></a>

## ExampleValue.Type Property

The [OpenApi defined Type](https://docs.microsoft.com/en-us/dotnet/api/http://spec.openapis.org/oas/v3.0.3#data-types 'http://spec.openapis.org/oas/v3.0.3#data-types')   
of the Example value being provided.

```csharp
public string Type { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiDocs.ExampleValue.Value'></a>

## ExampleValue.Value Property

The actual value of the provided example

```csharp
public string Value { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')