#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## Error Class

A base class for storing errors when working with ApiSets and ApiSetAnalyzers

```csharp
public abstract class Error
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Error

Derived  
&#8627; [ApiSetError](ApiSetError.md 'ApiTestGenerator.Models.ApiDocs.ApiSetError')
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.Error.ErrorMessage'></a>

## Error.ErrorMessage Property

The text of the error message

```csharp
public string ErrorMessage { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiDocs.Error.ObjectWithError'></a>

## Error.ObjectWithError Property

A copy of the ovject that had the error.

```csharp
public object ObjectWithError { get; set; }
```

#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')
### Methods

<a name='ApiTestGenerator.Models.ApiDocs.Error.GetErrorCategory(int,ApiTestGenerator.Models.Enums.AnalyzerErrorCategoryEnum)'></a>

## Error.GetErrorCategory(int, AnalyzerErrorCategoryEnum) Method

Returns a string built from an error number and the error category

```csharp
public string GetErrorCategory(int iNum, ApiTestGenerator.Models.Enums.AnalyzerErrorCategoryEnum category);
```
#### Parameters

<a name='ApiTestGenerator.Models.ApiDocs.Error.GetErrorCategory(int,ApiTestGenerator.Models.Enums.AnalyzerErrorCategoryEnum).iNum'></a>

`iNum` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.ApiDocs.Error.GetErrorCategory(int,ApiTestGenerator.Models.Enums.AnalyzerErrorCategoryEnum).category'></a>

`category` [AnalyzerErrorCategoryEnum](AnalyzerErrorCategoryEnum.md 'ApiTestGenerator.Models.Enums.AnalyzerErrorCategoryEnum')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')