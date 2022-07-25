#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Models.ApiDocs](ApiTestGenerator.Models.md#ApiSet.Models.ApiDocs 'ApiSet.Models.ApiDocs')

## ResponseObject Class

```csharp
public class ResponseObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ResponseObject
### Properties

<a name='ApiSet.Models.ApiDocs.ResponseObject.abbreviatedResponseObjects'></a>

## ResponseObject.abbreviatedResponseObjects Property

[Extension] - This is a collection of objects in the response

```csharp
public System.Collections.Generic.Dictionary<string,ApiSet.Models.ApiDocs.AbbreviatedResponseObject> abbreviatedResponseObjects { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[AbbreviatedResponseObject](AbbreviatedResponseObject.md 'ApiSet.Models.ApiDocs.AbbreviatedResponseObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='ApiSet.Models.ApiDocs.ResponseObject.Description'></a>

## ResponseObject.Description Property

The description for the stsus code that this response

```csharp
public string Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiDocs.ResponseObject.ResponseObjectExampleText'></a>

## ResponseObject.ResponseObjectExampleText Property

```csharp
public string ResponseObjectExampleText { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiDocs.ResponseObject.ResponseObjectExampleTextIsEncoded'></a>

## ResponseObject.ResponseObjectExampleTextIsEncoded Property

```csharp
public bool ResponseObjectExampleTextIsEncoded { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiSet.Models.ApiDocs.ResponseObject.ResponseObjectName'></a>

## ResponseObject.ResponseObjectName Property

[Extension] - The class 'name' of response object for  
responses that use a $ref tag to reference a [Component](Component.md 'ApiSet.Models.ApiDocs.Component')

```csharp
public string ResponseObjectName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiSet.Models.ApiDocs.ResponseObject.ResponseObjectType'></a>

## ResponseObject.ResponseObjectType Property

A [ResponseTypeEnum](ResponseTypeEnum.md 'ApiSet.Models.Enums.ResponseTypeEnum') value that describes the  
type of response object returned.

```csharp
public ApiSet.Models.Enums.ResponseTypeEnum ResponseObjectType { get; set; }
```

#### Property Value
[ResponseTypeEnum](ResponseTypeEnum.md 'ApiSet.Models.Enums.ResponseTypeEnum')