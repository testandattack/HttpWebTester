#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Models.ApiDocs](ApiTestGenerator.Models.md#ApiSet.Models.ApiDocs 'ApiSet.Models.ApiDocs')

## CustomOasObjectCollection Class

A class that contains a collection of custom objects added to the OAS documentation.

```csharp
public class CustomOasObjectCollection :
System.Collections.IEnumerable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CustomOasObjectCollection

Implements [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')
### Constructors

<a name='ApiSet.Models.ApiDocs.CustomOasObjectCollection.CustomOasObjectCollection()'></a>

## CustomOasObjectCollection() Constructor

The default constructor

```csharp
public CustomOasObjectCollection();
```
### Properties

<a name='ApiSet.Models.ApiDocs.CustomOasObjectCollection.collection'></a>

## CustomOasObjectCollection.collection Property

ther dictionary that contains the collection of custom object.

```csharp
public System.Collections.Generic.List<ApiSet.Models.ApiDocs.CustomOasObject> collection { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[CustomOasObject](CustomOasObject.md 'ApiSet.Models.ApiDocs.CustomOasObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')
### Methods

<a name='ApiSet.Models.ApiDocs.CustomOasObjectCollection.GetEnumerator()'></a>

## CustomOasObjectCollection.GetEnumerator() Method

Gets the enumerator for the dictionary of objects making up this collection.

```csharp
public System.Collections.IEnumerator GetEnumerator();
```

Implements [GetEnumerator()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable.GetEnumerator 'System.Collections.IEnumerable.GetEnumerator')

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')