#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Engines.Interfaces](ApiTestGenerator.Models.md#ApiSet.Engines.Interfaces 'ApiSet.Engines.Interfaces')

## IExampleValue<T> Interface

```csharp
public interface IExampleValue<T>
```
#### Type parameters

<a name='ApiSet.Engines.Interfaces.IExampleValue_T_.T'></a>

`T`
### Methods

<a name='ApiSet.Engines.Interfaces.IExampleValue_T_.GetExampleValue(T)'></a>

## IExampleValue<T>.GetExampleValue(T) Method

```csharp
ApiSet.Models.ApiDocs.ExampleValue GetExampleValue(T parameter);
```
#### Parameters

<a name='ApiSet.Engines.Interfaces.IExampleValue_T_.GetExampleValue(T).parameter'></a>

`parameter` [T](IExampleValue_T_.md#ApiSet.Engines.Interfaces.IExampleValue_T_.T 'ApiSet.Engines.Interfaces.IExampleValue<T>.T')

#### Returns
[ExampleValue](ExampleValue.md 'ApiSet.Models.ApiDocs.ExampleValue')

<a name='ApiSet.Engines.Interfaces.IExampleValue_T_.GetExampleValues(T)'></a>

## IExampleValue<T>.GetExampleValues(T) Method

```csharp
System.Collections.Generic.Dictionary<string,ApiSet.Models.ApiDocs.ExampleValue> GetExampleValues(T parameter);
```
#### Parameters

<a name='ApiSet.Engines.Interfaces.IExampleValue_T_.GetExampleValues(T).parameter'></a>

`parameter` [T](IExampleValue_T_.md#ApiSet.Engines.Interfaces.IExampleValue_T_.T 'ApiSet.Engines.Interfaces.IExampleValue<T>.T')

#### Returns
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ExampleValue](ExampleValue.md 'ApiSet.Models.ApiDocs.ExampleValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')