#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.Enums](ApiTestGenerator.Models.md#ApiTestGenerator.Models.Enums 'ApiTestGenerator.Models.Enums')

## ResponseTypeEnum Enum

Describes the type of object returned from the API.

```csharp
public enum ResponseTypeEnum
```
### Fields

<a name='ApiTestGenerator.Models.Enums.ResponseTypeEnum.BinaryString'></a>

`BinaryString` 2

A binary string (usually a downloadable file, etc)

<a name='ApiTestGenerator.Models.Enums.ResponseTypeEnum.FailedToParse'></a>

`FailedToParse` 10

The ApiSet parser was not able to determine the response object type.

<a name='ApiTestGenerator.Models.Enums.ResponseTypeEnum.Integer'></a>

`Integer` 4

A plain old [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='ApiTestGenerator.Models.Enums.ResponseTypeEnum.List_BinaryString'></a>

`List_BinaryString` 6

A list of [BinaryString](ResponseTypeEnum.md#ApiTestGenerator.Models.Enums.ResponseTypeEnum.BinaryString 'ApiTestGenerator.Models.Enums.ResponseTypeEnum.BinaryString') items

<a name='ApiTestGenerator.Models.Enums.ResponseTypeEnum.List_Integer'></a>

`List_Integer` 8

A list of [Integer](ResponseTypeEnum.md#ApiTestGenerator.Models.Enums.ResponseTypeEnum.Integer 'ApiTestGenerator.Models.Enums.ResponseTypeEnum.Integer') items

<a name='ApiTestGenerator.Models.Enums.ResponseTypeEnum.List_Object'></a>

`List_Object` 5

A list of [Object](ResponseTypeEnum.md#ApiTestGenerator.Models.Enums.ResponseTypeEnum.Object 'ApiTestGenerator.Models.Enums.ResponseTypeEnum.Object') items

<a name='ApiTestGenerator.Models.Enums.ResponseTypeEnum.List_String'></a>

`List_String` 7

A list of [String](ResponseTypeEnum.md#ApiTestGenerator.Models.Enums.ResponseTypeEnum.String 'ApiTestGenerator.Models.Enums.ResponseTypeEnum.String') items

<a name='ApiTestGenerator.Models.Enums.ResponseTypeEnum.none'></a>

`none` 9

The endpoint does not return any data.

<a name='ApiTestGenerator.Models.Enums.ResponseTypeEnum.Object'></a>

`Object` 1

A class-based response object

<a name='ApiTestGenerator.Models.Enums.ResponseTypeEnum.String'></a>

`String` 3

A plain old [String](ResponseTypeEnum.md#ApiTestGenerator.Models.Enums.ResponseTypeEnum.String 'ApiTestGenerator.Models.Enums.ResponseTypeEnum.String').

### Remarks
This is used by the test generation software to 
determine what extraction and validation rule types 
can be used with the response.