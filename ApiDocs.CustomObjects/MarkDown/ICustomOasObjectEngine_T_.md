#### [ApiDocs.CustomObjects](ApiDocs.CustomObjects.md 'ApiDocs.CustomObjects')
### [ApiDocs.CustomObjects](ApiDocs.CustomObjects.md#ApiDocs.CustomObjects 'ApiDocs.CustomObjects')

## ICustomOasObjectEngine<T> Interface

Interface for describing custom objects that can be added  
to Swagger Documentation.

```csharp
public interface ICustomOasObjectEngine<T>
```
#### Type parameters

<a name='ApiDocs.CustomObjects.ICustomOasObjectEngine_T_.T'></a>

`T`

Derived  
&#8627; [CustomOasObjectEngine](CustomOasObjectEngine.md 'ApiDocs.CustomObjects.CustomOasObjectEngine')
### Properties

<a name='ApiDocs.CustomObjects.ICustomOasObjectEngine_T_.CustomOasObjectEngineType'></a>

## ICustomOasObjectEngine<T>.CustomOasObjectEngineType Property

the type of custom object

```csharp
System.Type CustomOasObjectEngineType { get; }
```

#### Property Value
[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')
### Methods

<a name='ApiDocs.CustomObjects.ICustomOasObjectEngine_T_.CheckForObject(T)'></a>

## ICustomOasObjectEngine<T>.CheckForObject(T) Method

This method is the entry point for parsing a custom object added to the OpenApiDocument.  
The default immplementation returns null. This allows the custom object event handler to  
get wired up to any OAS type and not fail if that type doesn't have any custome events.

```csharp
object CheckForObject(T item);
```
#### Parameters

<a name='ApiDocs.CustomObjects.ICustomOasObjectEngine_T_.CheckForObject(T).item'></a>

`item` [T](ICustomOasObjectEngine_T_.md#ApiDocs.CustomObjects.ICustomOasObjectEngine_T_.T 'ApiDocs.CustomObjects.ICustomOasObjectEngine<T>.T')

the item which might contain the custom object.

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')