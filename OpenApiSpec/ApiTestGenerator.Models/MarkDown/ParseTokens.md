#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.Consts](ApiTestGenerator.Models.md#ApiTestGenerator.Models.Consts 'ApiTestGenerator.Models.Consts')

## ParseTokens Class

This class contains constant string values that are used for parsing OAS documents.

```csharp
public class ParseTokens
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ParseTokens

### Remarks
These string constants represent a few different types of 'searchable' strings. The   
preamble of each token represents the type of string:  
- `TKN` These items represent strings that can be added to the XML Documentation in a way that they will  
              show up in the generated OAS document.  
- `PARAM` These items contain strings that represent the names of common parameters that (when  
              used by developers in the API) will allow the OAS parser to identify these parameters as properties to  
              make dynamioc in any generated test harnesses.  
- `OAS` These items contain strings that are known constants defined within the Open Api Spec.  
- `DESC` These items are more generic and act as a 'catch-all' bucket for terms.
### Fields

<a name='ApiTestGenerator.Models.Consts.ParseTokens.OAS_FormDataContentType'></a>

## ParseTokens.OAS_FormDataContentType Field

the string to search for in the content-type that indicates the response is a binary or form data object

```csharp
public const string OAS_FormDataContentType = multipart/form-data;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.OAS_JsonContentType'></a>

## ParseTokens.OAS_JsonContentType Field

the string to search for in the content-type that indicates the response is a JSON object

```csharp
public const string OAS_JsonContentType = application/json;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.OAS_NoContentFound'></a>

## ParseTokens.OAS_NoContentFound Field

the string to search for in the content-type that indicates there was no response object.

```csharp
public const string OAS_NoContentFound = No content object found;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.PARAM_EndDate'></a>

## ParseTokens.PARAM_EndDate Field

this string represents the name of an API operation's input parameter that contains a [DateTime](https://docs.microsoft.com/en-us/dotnet/api/DateTime 'DateTime')   
value for the ending date of a query.

```csharp
public const string PARAM_EndDate = endDate;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.PARAM_List_Precursor'></a>

## ParseTokens.PARAM_List_Precursor Field

this string represents the precursor for an API operation's input parameter name that contains a List of values.

```csharp
public const string PARAM_List_Precursor = List_;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.PARAM_MissingInfo'></a>

## ParseTokens.PARAM_MissingInfo Field

this string represents an item in the OAS schema that has missing info.

```csharp
public const string PARAM_MissingInfo = MissingInfo;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.PARAM_MissingTypeField'></a>

## ParseTokens.PARAM_MissingTypeField Field

this string represents an item in the OAS schema that has a missing field type.

```csharp
public const string PARAM_MissingTypeField = Type Not Found;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.PARAM_StartDate'></a>

## ParseTokens.PARAM_StartDate Field

this string represents the name of an API operation's input parameter that contains a [DateTime](https://docs.microsoft.com/en-us/dotnet/api/DateTime 'DateTime')   
value for the starting date of a query.

```csharp
public const string PARAM_StartDate = startDate;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.TKN_CalculatedDateStringFormat'></a>

## ParseTokens.TKN_CalculatedDateStringFormat Field

Contains the arguments used when providing a   
[TKN_startDate](ParseTokens.md#ApiTestGenerator.Models.Consts.ParseTokens.TKN_startDate 'ApiTestGenerator.Models.Consts.ParseTokens.TKN_startDate') or [TKN_endDate](ParseTokens.md#ApiTestGenerator.Models.Consts.ParseTokens.TKN_endDate 'ApiTestGenerator.Models.Consts.ParseTokens.TKN_endDate') Token in XML Documentation

```csharp
public const string TKN_CalculatedDateStringFormat = [BaseDate], [DateFormat], [DateOffset];
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.TKN_ClassName'></a>

## ParseTokens.TKN_ClassName Field

Gets the fully qualified class name of this DTO

```csharp
public const string TKN_ClassName = {{ClassName}}(;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.TKN_endDate'></a>

## ParseTokens.TKN_endDate Field

Sets a dynamic value for the end date based on current day offset.

```csharp
public const string TKN_endDate = {{endDate}};
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.TKN_GetsInputFrom'></a>

## ParseTokens.TKN_GetsInputFrom Field

Gets the fully qualified name of the property that will provide input into this parameter

```csharp
public const string TKN_GetsInputFrom = {{GetsInputFrom}}(;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.TKN_LookupMethod'></a>

## ParseTokens.TKN_LookupMethod Field

This tag value, when present, indicates that this method is a lookup method.

```csharp
public const string TKN_LookupMethod = Lookups;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.TKN_MethodName'></a>

## ParseTokens.TKN_MethodName Field

A Swagger custom property that contains the name of the method

```csharp
public const string TKN_MethodName = x-method-name;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.TKN_ProvidesValuesFor'></a>

## ParseTokens.TKN_ProvidesValuesFor Field

A Swagger custom property that contains a list of methods that this endpoint can potentially provide values for.

```csharp
public const string TKN_ProvidesValuesFor = x-provides-values-for;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.TKN_RestrictTo'></a>

## ParseTokens.TKN_RestrictTo Field

A Swagger custom property that contains a list of roles that this method allows access to

```csharp
public const string TKN_RestrictTo = x-restrict-to;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.TKN_startDate'></a>

## ParseTokens.TKN_startDate Field

Sets a dynamic value for the start date based on current day offset.

```csharp
public const string TKN_startDate = {{startDate}};
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.TKN_TestDataFilter'></a>

## ParseTokens.TKN_TestDataFilter Field

Provides filtering/alignment information for retrieving input data from multiple response objects

```csharp
public const string TKN_TestDataFilter = {{TestDataFilter}}(;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.Consts.ParseTokens.TKN_TestDataFilterStringFormat'></a>

## ParseTokens.TKN_TestDataFilterStringFormat Field

Contains the arguments used when providing a   
[TKN_TestDataFilter](ParseTokens.md#ApiTestGenerator.Models.Consts.ParseTokens.TKN_TestDataFilter 'ApiTestGenerator.Models.Consts.ParseTokens.TKN_TestDataFilter') Token in XML Documentation

```csharp
public const string TKN_TestDataFilterStringFormat = [SharedPropertyName], [PrimaryDto], [DependentDto];
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')