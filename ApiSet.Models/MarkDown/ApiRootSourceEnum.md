#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Models.Enums](ApiTestGenerator.Models.md#ApiSet.Models.Enums 'ApiSet.Models.Enums')

## ApiRootSourceEnum Enum

Lists the source for the [ApiSet.apiRoot](https://docs.microsoft.com/en-us/dotnet/api/ApiSet.apiRoot 'ApiSet.apiRoot') object

```csharp
public enum ApiRootSourceEnum
```
### Fields

<a name='ApiSet.Models.Enums.ApiRootSourceEnum.basePath'></a>

`basePath` 0

The value defined in the `basePath` node

<a name='ApiSet.Models.Enums.ApiRootSourceEnum.empty'></a>

`empty` 2

An empty string if there is not a common basePath, or if the value is  
not provided by one of the above items.

<a name='ApiSet.Models.Enums.ApiRootSourceEnum.settingsFile'></a>

`settingsFile` 1

The value added to the `settings.json` file