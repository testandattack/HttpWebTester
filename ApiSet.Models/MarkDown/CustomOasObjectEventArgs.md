#### [ApiSet.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiSet.Models.ApiDocs](ApiTestGenerator.Models.md#ApiSet.Models.ApiDocs 'ApiSet.Models.ApiDocs')

## CustomOasObjectEventArgs Class

The class to hold the properties that get passed into any event handler for  
custom objects.

```csharp
public class CustomOasObjectEventArgs : System.EventArgs
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.EventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.EventArgs 'System.EventArgs') &#129106; CustomOasObjectEventArgs
### Properties

<a name='ApiSet.Models.ApiDocs.CustomOasObjectEventArgs.customObjects'></a>

## CustomOasObjectEventArgs.customObjects Property

The [CustomOasObjectCollection](CustomOasObjectCollection.md 'ApiSet.Models.ApiDocs.CustomOasObjectCollection') for the endpoint being processed.  
This is passed to the event handler so that the method can add the new object  
to the collection.

```csharp
public ApiSet.Models.ApiDocs.CustomOasObjectCollection customObjects { get; set; }
```

#### Property Value
[CustomOasObjectCollection](CustomOasObjectCollection.md 'ApiSet.Models.ApiDocs.CustomOasObjectCollection')

<a name='ApiSet.Models.ApiDocs.CustomOasObjectEventArgs.operation'></a>

## CustomOasObjectEventArgs.operation Property

The [Microsoft.OpenApi.Models.OpenApiOperation](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiOperation 'Microsoft.OpenApi.Models.OpenApiOperation') that might contain custom objects

```csharp
public Microsoft.OpenApi.Models.OpenApiOperation operation { get; set; }
```

#### Property Value
[Microsoft.OpenApi.Models.OpenApiOperation](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiOperation 'Microsoft.OpenApi.Models.OpenApiOperation')