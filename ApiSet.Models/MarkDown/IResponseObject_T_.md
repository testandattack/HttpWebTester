#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Engines.Interfaces](ApiTestGenerator.Models.md#ApiSet.Engines.Interfaces 'ApiSet.Engines.Interfaces')

## IResponseObject<T> Interface

```csharp
public interface IResponseObject<T>
```
#### Type parameters

<a name='ApiSet.Engines.Interfaces.IResponseObject_T_.T'></a>

`T`
### Methods

<a name='ApiSet.Engines.Interfaces.IResponseObject_T_.GetResponseObjects(T)'></a>

## IResponseObject<T>.GetResponseObjects(T) Method

```csharp
System.Collections.Generic.Dictionary<string,ApiSet.Models.ApiDocs.ResponseObject> GetResponseObjects(T apiOperation);
```
#### Parameters

<a name='ApiSet.Engines.Interfaces.IResponseObject_T_.GetResponseObjects(T).apiOperation'></a>

`apiOperation` [T](IResponseObject_T_.md#ApiSet.Engines.Interfaces.IResponseObject_T_.T 'ApiSet.Engines.Interfaces.IResponseObject<T>.T')

#### Returns
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ResponseObject](ResponseObject.md 'ApiSet.Models.ApiDocs.ResponseObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')