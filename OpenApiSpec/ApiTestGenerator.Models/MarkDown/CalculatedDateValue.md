#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## CalculatedDateValue Class

A [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') class designed to hold the  
class name of the API method in the Endpoint.

```csharp
public class CalculatedDateValue : ApiTestGenerator.Models.ApiDocs.CustomEndPointObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') &#129106; CalculatedDateValue

### Remarks
### Constructors

<a name='ApiTestGenerator.Models.ApiDocs.CalculatedDateValue.CalculatedDateValue()'></a>

## CalculatedDateValue() Constructor

Creates a new instance of the [CalculatedDateValue](CalculatedDateValue.md 'ApiTestGenerator.Models.ApiDocs.CalculatedDateValue') object.

```csharp
public CalculatedDateValue();
```

<a name='ApiTestGenerator.Models.ApiDocs.CalculatedDateValue.CalculatedDateValue(string)'></a>

## CalculatedDateValue(string) Constructor

Creates a new instance of the [CalculatedDateValue](CalculatedDateValue.md 'ApiTestGenerator.Models.ApiDocs.CalculatedDateValue') object  
and populates the values from the provided input string

```csharp
public CalculatedDateValue(string description);
```
#### Parameters

<a name='ApiTestGenerator.Models.ApiDocs.CalculatedDateValue.CalculatedDateValue(string).description'></a>

`description` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A string that contains a [PARAM_StartDate](ParserTokens.md#ApiTestGenerator.Models.Consts.ParserTokens.PARAM_StartDate 'ApiTestGenerator.Models.Consts.ParserTokens.PARAM_StartDate') token  
            and a set of [TKN_CalculatedDateStringFormat](ParserTokens.md#ApiTestGenerator.Models.Consts.ParserTokens.TKN_CalculatedDateStringFormat 'ApiTestGenerator.Models.Consts.ParserTokens.TKN_CalculatedDateStringFormat') values.
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.CalculatedDateValue.BaseDate'></a>

## CalculatedDateValue.BaseDate Property

The Date used as a starting point for the calculated date.

```csharp
public string BaseDate { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.CalculatedDateValue.DateFormatter'></a>

## CalculatedDateValue.DateFormatter Property

The standard C# Date Format string for representing the date

```csharp
public string DateFormatter { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.CalculatedDateValue.DaysOffset'></a>

## CalculatedDateValue.DaysOffset Property

The number of days to add to the BaseDate for the final value.  
Using a negative number will represent days in the past.

```csharp
public int DaysOffset { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')