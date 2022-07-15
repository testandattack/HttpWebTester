#### [PostmanManager](PostmanManager.md 'PostmanManager')
### [PostmanManager](PostmanManager.md#PostmanManager 'PostmanManager').[PostmanItem_JsonConverter](PostmanManager.md#PostmanManager.PostmanItem_JsonConverter 'PostmanManager.PostmanItem_JsonConverter')

## PostmanItem_JsonConverter.WriteJson(JsonWriter, object, JsonSerializer) Method

This overridden method never gets called since the base item is 
an abstract class and the concrete instances do not need custom
serializers.

```csharp
public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer);
```
#### Parameters

<a name='PostmanManager.PostmanItem_JsonConverter.WriteJson(Newtonsoft.Json.JsonWriter,object,Newtonsoft.Json.JsonSerializer).writer'></a>

`writer` [Newtonsoft.Json.JsonWriter](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonWriter 'Newtonsoft.Json.JsonWriter')

<a name='PostmanManager.PostmanItem_JsonConverter.WriteJson(Newtonsoft.Json.JsonWriter,object,Newtonsoft.Json.JsonSerializer).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='PostmanManager.PostmanItem_JsonConverter.WriteJson(Newtonsoft.Json.JsonWriter,object,Newtonsoft.Json.JsonSerializer).serializer'></a>

`serializer` [Newtonsoft.Json.JsonSerializer](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonSerializer 'Newtonsoft.Json.JsonSerializer')