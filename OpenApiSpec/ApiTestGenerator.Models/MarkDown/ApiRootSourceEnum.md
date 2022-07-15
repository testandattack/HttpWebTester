#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.Enums](ApiTestGenerator.Models.md#ApiTestGenerator.Models.Enums 'ApiTestGenerator.Models.Enums')

## ApiRootSourceEnum Enum

Lists the source for the [apiRoot](ApiSet.md#ApiTestGenerator.Models.ApiDocs.ApiSet.apiRoot 'ApiTestGenerator.Models.ApiDocs.ApiSet.apiRoot') object

```csharp
public enum ApiRootSourceEnum
```
### Fields

<a name='ApiTestGenerator.Models.Enums.ApiRootSourceEnum.basePath'></a>

`basePath` 0

The value defined in the `basePath` node

<a name='ApiTestGenerator.Models.Enums.ApiRootSourceEnum.empty'></a>

`empty` 2

An empty string if there is not a common basePath, or if the value is  
not provided by one of the above items.

<a name='ApiTestGenerator.Models.Enums.ApiRootSourceEnum.settingsFile'></a>

`settingsFile` 1

The value added to the `settings.json` file