#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Models.ApiDocs](ApiTestGenerator.Models.md#ApiSet.Models.ApiDocs 'ApiSet.Models.ApiDocs')

## Error Class

A base class for storing errors when working with ApiSets and ApiSetAnalyzers

```csharp
public abstract class Error
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Error

Derived  
&#8627; [ApiSetError](ApiSetError.md 'ApiSet.Models.ApiDocs.ApiSetError')
### Properties

<a name='ApiSet.Models.ApiDocs.Error.ErrorMessage'></a>

## Error.ErrorMessage Property

The text of the error message

```csharp
public string ErrorMessage { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiDocs.Error.ObjectWithError'></a>

## Error.ObjectWithError Property

A copy of the ovject that had the error.

```csharp
public object ObjectWithError { get; set; }
```

#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')
### Methods

<a name='ApiSet.Models.ApiDocs.Error.GetErrorCategory(int,ApiSet.Models.Enums.AnalyzerErrorCategoryEnum)'></a>

## Error.GetErrorCategory(int, AnalyzerErrorCategoryEnum) Method

Returns a string built from an error number and the error category

```csharp
public string GetErrorCategory(int iNum, ApiSet.Models.Enums.AnalyzerErrorCategoryEnum category);
```
#### Parameters

<a name='ApiSet.Models.ApiDocs.Error.GetErrorCategory(int,ApiSet.Models.Enums.AnalyzerErrorCategoryEnum).iNum'></a>

`iNum` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiSet.Models.ApiDocs.Error.GetErrorCategory(int,ApiSet.Models.Enums.AnalyzerErrorCategoryEnum).category'></a>

`category` [AnalyzerErrorCategoryEnum](AnalyzerErrorCategoryEnum.md 'ApiSet.Models.Enums.AnalyzerErrorCategoryEnum')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')