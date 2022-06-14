#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## TestDataFilter Class

A [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') class designed to hold   
information about filters that should be applied to result  
sets when extracting input data for the method this filter  
is associated with.

```csharp
public class TestDataFilter : ApiTestGenerator.Models.ApiDocs.CustomEndPointObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [CustomEndPointObject](CustomEndPointObject.md 'ApiTestGenerator.Models.ApiDocs.CustomEndPointObject') &#129106; TestDataFilter

### Remarks
If you are providing data that needs to properly align, but   
the constraint is provided by the front end (meaning that the   
dependency cannot be determined by looking at the DBModel code in the API),  
this filter will describe the constraints. All values from the   
DEPENDENT DTO must contain the same shared property as the values chosen   
from the PRIMARY DTO.  
<br/>Sample  
  
```csharp  
{{TestDataFilter}}("PRIMARY","App.Models.Model.NameOfDto1.propertyName","DEPENDENT","App.Models.Model.NameOfDto2.propertyName")  
```
### Constructors

<a name='ApiTestGenerator.Models.ApiDocs.TestDataFilter.TestDataFilter()'></a>

## TestDataFilter() Constructor

Creates a new instance of the [TestDataFilter](TestDataFilter.md 'ApiTestGenerator.Models.ApiDocs.TestDataFilter') object.

```csharp
public TestDataFilter();
```

<a name='ApiTestGenerator.Models.ApiDocs.TestDataFilter.TestDataFilter(string)'></a>

## TestDataFilter(string) Constructor

Creates a new instance of the [TestDataFilter](TestDataFilter.md 'ApiTestGenerator.Models.ApiDocs.TestDataFilter') object  
and populates the values from the provided input string

```csharp
public TestDataFilter(string description);
```
#### Parameters

<a name='ApiTestGenerator.Models.ApiDocs.TestDataFilter.TestDataFilter(string).description'></a>

`description` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A string that contains a [TKN_TestDataFilter](ParseTokens.md#ApiTestGenerator.Models.Consts.ParseTokens.TKN_TestDataFilter 'ApiTestGenerator.Models.Consts.ParseTokens.TKN_TestDataFilter') token  
            and a set of values in the form of [TKN_TestDataFilterStringFormat](ParseTokens.md#ApiTestGenerator.Models.Consts.ParseTokens.TKN_TestDataFilterStringFormat 'ApiTestGenerator.Models.Consts.ParseTokens.TKN_TestDataFilterStringFormat').
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.TestDataFilter.DependentDto'></a>

## TestDataFilter.DependentDto Property

The DTO to use SECOND when retrieving items to feed into   
this endpoint.

```csharp
public string DependentDto { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.TestDataFilter.PrimaryDto'></a>

## TestDataFilter.PrimaryDto Property

The DTO to use FIRST when retrieving items to feed into   
this endpoint.

```csharp
public string PrimaryDto { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.TestDataFilter.SharedPropertyName'></a>

## TestDataFilter.SharedPropertyName Property

The name of the property that will be in both of the objects  
used to get input values. Whatever items you pull from the   
[PrimaryDto](TestDataFilter.md#ApiTestGenerator.Models.ApiDocs.TestDataFilter.PrimaryDto 'ApiTestGenerator.Models.ApiDocs.TestDataFilter.PrimaryDto'),  
use the value of this property in those items to filter the  
values you retrieve from the [DependentDto](TestDataFilter.md#ApiTestGenerator.Models.ApiDocs.TestDataFilter.DependentDto 'ApiTestGenerator.Models.ApiDocs.TestDataFilter.DependentDto')

```csharp
public string SharedPropertyName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')