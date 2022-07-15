#### [PostmanManager](PostmanManager.md 'PostmanManager')
### [PostmanManager.Models](PostmanManager.md#PostmanManager.Models 'PostmanManager.Models').[Info](PostmanManager.md#PostmanManager.Models.Info 'PostmanManager.Models.Info')

## Info.PostmanId Property

Every collection is identified by the unique value of 
this field. The value of this field is usually easiest 
to generate using a UID generator function. If you already 
have a collection, it is recommended that you maintain the 
same id since changing the id usually implies that is a 
different collection than it was originally.\n *Note: This 
field exists for compatibility reasons with Collection Format V1.*

```csharp
public string PostmanId { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')