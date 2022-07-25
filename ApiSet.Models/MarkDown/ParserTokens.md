#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Models.Consts](ApiTestGenerator.Models.md#ApiSet.Models.Consts 'ApiSet.Models.Consts')

## ParserTokens Class

This class contains constant string values that are used for parsing OAS documents.

```csharp
public class ParserTokens
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ParserTokens

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

<a name='ApiSet.Models.Consts.ParserTokens.OAS_FormDataContentType'></a>

## ParserTokens.OAS_FormDataContentType Field

the string to search for in the content-type that indicates the response is a binary or form data object

```csharp
public const string OAS_FormDataContentType = multipart/form-data;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.OAS_JsonContentType'></a>

## ParserTokens.OAS_JsonContentType Field

the string to search for in the content-type that indicates the response is a JSON object

```csharp
public const string OAS_JsonContentType = application/json;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.OAS_NoContentFound'></a>

## ParserTokens.OAS_NoContentFound Field

the string to search for in the content-type that indicates there was no response object.

```csharp
public const string OAS_NoContentFound = No content object found;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.PARAM_EndDate'></a>

## ParserTokens.PARAM_EndDate Field

this string represents the name of an API operation's input parameter that contains a [DateTime](https://docs.microsoft.com/en-us/dotnet/api/DateTime 'DateTime')   
value for the ending date of a query.

```csharp
public const string PARAM_EndDate = endDate;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.PARAM_List_Precursor'></a>

## ParserTokens.PARAM_List_Precursor Field

this string represents the precursor for an API operation's input parameter name that contains a List of values.

```csharp
public const string PARAM_List_Precursor = List_;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.PARAM_MissingInfo'></a>

## ParserTokens.PARAM_MissingInfo Field

this string represents an item in the OAS schema that has missing info.

```csharp
public const string PARAM_MissingInfo = MissingInfo;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.PARAM_MissingTypeField'></a>

## ParserTokens.PARAM_MissingTypeField Field

this string represents an item in the OAS schema that has a missing field type.

```csharp
public const string PARAM_MissingTypeField = Type Not Found;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.PARAM_StartDate'></a>

## ParserTokens.PARAM_StartDate Field

this string represents the name of an API operation's input parameter that contains a [DateTime](https://docs.microsoft.com/en-us/dotnet/api/DateTime 'DateTime')   
value for the starting date of a query.

```csharp
public const string PARAM_StartDate = startDate;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.TKN_CalculatedDateStringFormat'></a>

## ParserTokens.TKN_CalculatedDateStringFormat Field

Contains the arguments used when providing a   
[TKN_startDate](ParserTokens.md#ApiSet.Models.Consts.ParserTokens.TKN_startDate 'ApiSet.Models.Consts.ParserTokens.TKN_startDate') or [TKN_endDate](ParserTokens.md#ApiSet.Models.Consts.ParserTokens.TKN_endDate 'ApiSet.Models.Consts.ParserTokens.TKN_endDate') Token in XML Documentation

```csharp
public const string TKN_CalculatedDateStringFormat = [BaseDate], [DateFormat], [DateOffset];
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.TKN_ClassName'></a>

## ParserTokens.TKN_ClassName Field

Gets the fully qualified class name of this DTO

```csharp
public const string TKN_ClassName = {{ClassName}}(;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.TKN_endDate'></a>

## ParserTokens.TKN_endDate Field

Sets a dynamic value for the end date based on current day offset.

```csharp
public const string TKN_endDate = {{endDate}};
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.TKN_GetsInputFrom'></a>

## ParserTokens.TKN_GetsInputFrom Field

Gets the fully qualified name of the property that will provide input into this parameter

```csharp
public const string TKN_GetsInputFrom = {{GetsInputFrom}}(;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.TKN_LookupMethod'></a>

## ParserTokens.TKN_LookupMethod Field

This tag value, when present, indicates that this method is a lookup method.

```csharp
public const string TKN_LookupMethod = Lookups;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.TKN_MethodName'></a>

## ParserTokens.TKN_MethodName Field

A Swagger custom property that contains the name of the method

```csharp
public const string TKN_MethodName = x-method-name;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.TKN_ProvidesValuesFor'></a>

## ParserTokens.TKN_ProvidesValuesFor Field

A Swagger custom property that contains a list of methods that this endpoint can potentially provide values for.

```csharp
public const string TKN_ProvidesValuesFor = x-provides-values-for;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.TKN_RestrictTo'></a>

## ParserTokens.TKN_RestrictTo Field

A Swagger custom property that contains a list of roles that this method allows access to

```csharp
public const string TKN_RestrictTo = x-restrict-to;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.TKN_startDate'></a>

## ParserTokens.TKN_startDate Field

Sets a dynamic value for the start date based on current day offset.

```csharp
public const string TKN_startDate = {{startDate}};
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.TKN_TestDataFilter'></a>

## ParserTokens.TKN_TestDataFilter Field

Provides filtering/alignment information for retrieving input data from multiple response objects

```csharp
public const string TKN_TestDataFilter = {{TestDataFilter}}(;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.Consts.ParserTokens.TKN_TestDataFilterStringFormat'></a>

## ParserTokens.TKN_TestDataFilterStringFormat Field

Contains the arguments used when providing a   
[TKN_TestDataFilter](ParserTokens.md#ApiSet.Models.Consts.ParserTokens.TKN_TestDataFilter 'ApiSet.Models.Consts.ParserTokens.TKN_TestDataFilter') Token in XML Documentation

```csharp
public const string TKN_TestDataFilterStringFormat = [SharedPropertyName], [PrimaryDto], [DependentDto];
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')