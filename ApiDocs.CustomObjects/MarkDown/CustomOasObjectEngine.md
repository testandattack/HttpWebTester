#### [ApiDocs.CustomObjects](ApiDocs.CustomObjects.md 'ApiDocs.CustomObjects')
### [ApiDocs.CustomObjects](ApiDocs.CustomObjects.md#ApiDocs.CustomObjects 'ApiDocs.CustomObjects')

## CustomOasObjectEngine Class

Base class for describing custom objects that can be added
to Swagger Documentation.

```csharp
public class CustomOasObjectEngine :
ApiDocs.CustomObjects.ICustomOasObjectEngine<ApiDocs.CustomObjects.CustomOasObjectEngine>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CustomOasObjectEngine

Derived  
&#8627; [ProvidesValuesFor_CustomOasObjectEngine](ProvidesValuesFor_CustomOasObjectEngine.md 'ApiDocs.CustomObjects.ProvidesValuesFor_CustomOasObjectEngine')

Implements [ApiDocs.CustomObjects.ICustomOasObjectEngine&lt;](ICustomOasObjectEngine_T_.md 'ApiDocs.CustomObjects.ICustomOasObjectEngine<T>')[CustomOasObjectEngine](CustomOasObjectEngine.md 'ApiDocs.CustomObjects.CustomOasObjectEngine')[&gt;](ICustomOasObjectEngine_T_.md 'ApiDocs.CustomObjects.ICustomOasObjectEngine<T>')

### Remarks

This base class has all of the event hooks and handler methods that tie into the ApiSet\Endpoint parser.

To add custom objects, create your own class and have it inherit from this class. Then, update the 
[BuildCustomObjects()](AddAllCustomObjectEngines.md#ApiDocs.CustomObjects.AddAllCustomObjectEngines.BuildCustomObjects() 'ApiDocs.CustomObjects.AddAllCustomObjectEngines.BuildCustomObjects()') method to call your custom class.
### Methods

<a name='ApiDocs.CustomObjects.CustomOasObjectEngine.LookForCustomObjects(Microsoft.OpenApi.Models.OpenApiOperation,ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection)'></a>

## CustomOasObjectEngine.LookForCustomObjects(OpenApiOperation, CustomOasObjectCollection) Method

This method triggers the building of event handlers and the triggering of the
events themselves. It is called by the `Endpoint Engine`.

```csharp
public void LookForCustomObjects(Microsoft.OpenApi.Models.OpenApiOperation openApiOperation, ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection items);
```
#### Parameters

<a name='ApiDocs.CustomObjects.CustomOasObjectEngine.LookForCustomObjects(Microsoft.OpenApi.Models.OpenApiOperation,ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection).openApiOperation'></a>

`openApiOperation` [Microsoft.OpenApi.Models.OpenApiOperation](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Models.OpenApiOperation 'Microsoft.OpenApi.Models.OpenApiOperation')

This is the OAS operation that is being parsed to build the EndPoint object

<a name='ApiDocs.CustomObjects.CustomOasObjectEngine.LookForCustomObjects(Microsoft.OpenApi.Models.OpenApiOperation,ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection).items'></a>

`items` [ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection 'ApiTestGenerator.Models.ApiDocs.CustomOasObjectCollection')

This is the Endpoint's collection of custom objects.

### Remarks
This method is used by the EndPoint Engine and should not be called by your code.

<a name='ApiDocs.CustomObjects.CustomOasObjectEngine.OnOpenApiOperationEvent(ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs)'></a>

## CustomOasObjectEngine.OnOpenApiOperationEvent(CustomOasObjectEventArgs) Method

This method is part of the C# event handler functionality.

```csharp
protected virtual void OnOpenApiOperationEvent(ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs e);
```
#### Parameters

<a name='ApiDocs.CustomObjects.CustomOasObjectEngine.OnOpenApiOperationEvent(ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs).e'></a>

`e` [ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs 'ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs')

<a name='ApiDocs.CustomObjects.CustomOasObjectEngine.ParseObject(object,ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs)'></a>

## CustomOasObjectEngine.ParseObject(object, CustomOasObjectEventArgs) Method

This is the method that you should override in your derived class.

```csharp
public virtual void ParseObject(object sender, ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs e);
```
#### Parameters

<a name='ApiDocs.CustomObjects.CustomOasObjectEngine.ParseObject(object,ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='ApiDocs.CustomObjects.CustomOasObjectEngine.ParseObject(object,ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs).e'></a>

`e` [ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs](https://docs.microsoft.com/en-us/dotnet/api/ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs 'ApiTestGenerator.Models.ApiDocs.CustomOasObjectEventArgs')

### Remarks
This code example how to create your own custom parser

```cs
public override void ParseObject(object sender, CustomOasObjectEventArgs e)
{
   // First, verify that this operation contains at least one extension 
   if (e.operation.Extensions != null && e.operation.Extensions.Count > 0)
   {
       // Loop through the extensions
       foreach (var operationExtension in e.operation.Extensions)
       {
           // Make sure the current extensoin is the one you are looking for
           if (operationExtension.Key == "x-Whatever-YourTokenNameMioghtBe")
           {
               // Create a new CustomOasObject for the ApiSet
               var Item = new CustomOasObject();

               // Name the object
               Item.CustomObjectName = "x-Whatever-YourTokenNameMioghtBe";

               // Retrieve the value stored in the OAS (this example assumes it is a string)
               // For more information, see the section below.
               string endpointNames = ((OpenApiString)(operationExtension.Value)).Value;

               // Make sure that there is a legitimate value to use
               if (endpointNames.Length > 0)
               {
                   // Here you can convert the string to a different object type as needed. In
                   // this case, the string contains a comma separated list of strings, so we
                   // use the CsvStrToList(string, bool) extension method to create a list 
                   // and add that to the CustomOasObject.
                   Item.CustomObjectValue = endpointNames.CsvStrToList();
                   
                   // Finally, we add the CustomOasObject to the endpoint's collection
                   e.customObjects.collection.Add(Item);
               }
           }
       }
   }
}
```

The extension object as specified in the schema is of type [Microsoft.OpenApi.Any.IOpenApiAny](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.OpenApi.Any.IOpenApiAny 'Microsoft.OpenApi.Any.IOpenApiAny'). 
 The value can be null, a primitive, an array or an object. Can have any valid JSON format value.

For more information on the OAS Specification Extensions, see [
             this article](https://spec.openapis.org/oas/v3.0.0#specification-extensions 'https://spec.openapis.org/oas/v3.0.0#specification-extensions').