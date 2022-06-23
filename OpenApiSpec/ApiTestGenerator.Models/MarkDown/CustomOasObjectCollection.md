#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiDocs](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiDocs 'ApiTestGenerator.Models.ApiDocs')

## CustomOasObjectCollection Class

A class that contains a collection of custom objects added to the OAS documentation.

```csharp
public class CustomOasObjectCollection :
System.Collections.IEnumerable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CustomOasObjectCollection

Implements [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')
### Constructors

<a name='ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection.CustomOasObjectCollection()'></a>

## CustomOasObjectCollection() Constructor

The default constructor

```csharp
public CustomOasObjectCollection();
```
### Properties

<a name='ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection.collection'></a>

## CustomOasObjectCollection.collection Property

ther dictionary that contains the collection of custom object.

```csharp
public System.Collections.Generic.Dictionary<string,ApiTestGenerator.Models.ApiDocs.CustomOasObject> collection { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[CustomOasObject](CustomOasObject.md 'ApiTestGenerator.Models.ApiDocs.CustomOasObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')
### Methods

<a name='ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection.GetEnumerator()'></a>

## CustomOasObjectCollection.GetEnumerator() Method

Gets the enumerator for the dictionary of objects making up this collection.

```csharp
public System.Collections.IEnumerator GetEnumerator();
```

Implements [GetEnumerator()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable.GetEnumerator 'System.Collections.IEnumerable.GetEnumerator')

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')