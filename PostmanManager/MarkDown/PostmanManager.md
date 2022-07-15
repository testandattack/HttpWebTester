#### [PostmanManager](PostmanManager.md 'PostmanManager')

## PostmanManager Assembly
### Namespaces

<a name='PostmanManager'></a>

## PostmanManager Namespace
### Classes

<a name='PostmanManager.PostmanAuth_JsonConverter'></a>

## PostmanAuth_JsonConverter Class

Custom Json Converter to handle [Auth](PostmanManager.md#PostmanManager.Models.Auth 'PostmanManager.Models.Auth') objects from Postman

```csharp
public class PostmanAuth_JsonConverter : Newtonsoft.Json.JsonConverter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Newtonsoft.Json.JsonConverter](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonConverter 'Newtonsoft.Json.JsonConverter') &#129106; PostmanAuth_JsonConverter

<a name='PostmanManager.PostmanCollection'></a>

## PostmanCollection Class

The root item for postman collections
<remarks>
FROM [geoffgr]. The summary documentation is directly from the postman 
schema listed below:
<code>
"$schema": "http://json-schema.org/draft-04/schema#",
"id": "https://schema.getpostman.com/json/collection/v2.1.0/",
</code><para>The C# objects created in this package are not guaranteed to be 
identical to the objects in postman, but they should always serialize to 
a json object that can be imported into Postman.</para></remarks>

```csharp
public class PostmanCollection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PostmanCollection

| Properties | |
| :--- | :--- |
| [Auth](PostmanCollection.Auth.md 'PostmanManager.PostmanCollection.Auth') | Represents authentication helpers provided by Postman |
| [Events](PostmanCollection.Events.md 'PostmanManager.PostmanCollection.Events') | Postman allows you to configure scripts to run when specific events  occur. These scripts are stored here, and can be referenced in the  collection by their ID. |
| [Info](PostmanCollection.Info.md 'PostmanManager.PostmanCollection.Info') | Detailed description of the info block |
| [Items](PostmanCollection.Items.md 'PostmanManager.PostmanCollection.Items') | Items are the basic unit for a Postman collection.  You can think of them as corresponding to a single  API endpoint. Each Item has one request and may have  multiple API responses associated with it. |
| [ProtocolProfileBehavior](PostmanCollection.ProtocolProfileBehavior.md 'PostmanManager.PostmanCollection.ProtocolProfileBehavior') | Set of configurations used to alter the usual behavior of sending the request. |
| [Variables](PostmanCollection.Variables.md 'PostmanManager.PostmanCollection.Variables') | Collection variables allow you to define a set of variables,  that are a *part of the collection*, as opposed to environments,  which are separate entities.\n*Note: Collection variables must  not contain any sensitive information.* |

<a name='PostmanManager.PostmanDescription_JsonConverter'></a>

## PostmanDescription_JsonConverter Class

Custom Json Converter to handle [Description](PostmanManager.md#PostmanManager.Models.Description 'PostmanManager.Models.Description') objects from Postman

```csharp
public class PostmanDescription_JsonConverter : Newtonsoft.Json.JsonConverter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Newtonsoft.Json.JsonConverter](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonConverter 'Newtonsoft.Json.JsonConverter') &#129106; PostmanDescription_JsonConverter

<a name='PostmanManager.PostmanHeader_JsonConverter'></a>

## PostmanHeader_JsonConverter Class

Custom Json Converter to handle [Header](PostmanManager.md#PostmanManager.Models.Header 'PostmanManager.Models.Header') objects from Postman

```csharp
public class PostmanHeader_JsonConverter : Newtonsoft.Json.JsonConverter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Newtonsoft.Json.JsonConverter](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonConverter 'Newtonsoft.Json.JsonConverter') &#129106; PostmanHeader_JsonConverter

<a name='PostmanManager.PostmanItem_JsonConverter'></a>

## PostmanItem_JsonConverter Class

Custom Json Converter to handle [PostmanManager.Models.ItemCollection](https://docs.microsoft.com/en-us/dotnet/api/PostmanManager.Models.ItemCollection 'PostmanManager.Models.ItemCollection') objects from Postman

```csharp
public class PostmanItem_JsonConverter : Newtonsoft.Json.JsonConverter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Newtonsoft.Json.JsonConverter](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonConverter 'Newtonsoft.Json.JsonConverter') &#129106; PostmanItem_JsonConverter

| Methods | |
| :--- | :--- |
| [WriteJson(JsonWriter, object, JsonSerializer)](PostmanItem_JsonConverter.WriteJson(JsonWriter,object,JsonSerializer).md 'PostmanManager.PostmanItem_JsonConverter.WriteJson(Newtonsoft.Json.JsonWriter, object, Newtonsoft.Json.JsonSerializer)') | This overridden method never gets called since the base item is  an abstract class and the concrete instances do not need custom serializers. |

<a name='PostmanManager.PostmanPath_JsonConverter'></a>

## PostmanPath_JsonConverter Class

Custom Json Converter to handle [Path](PostmanManager.md#PostmanManager.Models.Path 'PostmanManager.Models.Path') objects from Postman

```csharp
public class PostmanPath_JsonConverter : Newtonsoft.Json.JsonConverter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Newtonsoft.Json.JsonConverter](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonConverter 'Newtonsoft.Json.JsonConverter') &#129106; PostmanPath_JsonConverter

<a name='PostmanManager.PostmanRequest_JsonConverter'></a>

## PostmanRequest_JsonConverter Class

Custom Json Converter to handle [Request](PostmanManager.md#PostmanManager.Models.Request 'PostmanManager.Models.Request') objects from Postman

```csharp
public class PostmanRequest_JsonConverter : Newtonsoft.Json.JsonConverter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Newtonsoft.Json.JsonConverter](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonConverter 'Newtonsoft.Json.JsonConverter') &#129106; PostmanRequest_JsonConverter

<a name='PostmanManager.PostmanUrl_JsonConverter'></a>

## PostmanUrl_JsonConverter Class

Custom Json Converter to handle [Url](PostmanManager.md#PostmanManager.Models.Url 'PostmanManager.Models.Url') objects from Postman

```csharp
public class PostmanUrl_JsonConverter : Newtonsoft.Json.JsonConverter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Newtonsoft.Json.JsonConverter](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonConverter 'Newtonsoft.Json.JsonConverter') &#129106; PostmanUrl_JsonConverter

<a name='PostmanManager.PostmanVersion_JsonConverter'></a>

## PostmanVersion_JsonConverter Class

Custom Json Converter to handle [Version](PostmanManager.md#PostmanManager.Models.Version 'PostmanManager.Models.Version') objects from Postman

```csharp
public class PostmanVersion_JsonConverter : Newtonsoft.Json.JsonConverter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Newtonsoft.Json.JsonConverter](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonConverter 'Newtonsoft.Json.JsonConverter') &#129106; PostmanVersion_JsonConverter

<a name='PostmanManager.Models'></a>

## PostmanManager.Models Namespace
### Classes

<a name='PostmanManager.Models.Auth'></a>

## Auth Class

Represents authentication helpers provided by Postman

```csharp
public class Auth
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Auth

| Properties | |
| :--- | :--- |
| [ApiKey](Auth.ApiKey.md 'PostmanManager.Models.Auth.ApiKey') | The attributes for API Key Authentication. |
| [AwsV4](Auth.AwsV4.md 'PostmanManager.Models.Auth.AwsV4') | The attributes for [AWS Auth](http://docs.aws.amazon.com/AmazonS3/latest/dev/RESTAuthentication.html). |
| [Basic](Auth.Basic.md 'PostmanManager.Models.Auth.Basic') | The attributes for [Basic Authentication](https://en.wikipedia.org/wiki/Basic_access_authentication). |
| [Bearer](Auth.Bearer.md 'PostmanManager.Models.Auth.Bearer') | The helper attributes for [Bearer Token Authentication](https://tools.ietf.org/html/rfc6750) |
| [Digest](Auth.Digest.md 'PostmanManager.Models.Auth.Digest') | The attributes for [Digest Authentication](https://en.wikipedia.org/wiki/Digest_access_authentication). |
| [EdgeGrid](Auth.EdgeGrid.md 'PostmanManager.Models.Auth.EdgeGrid') | The attributes for [Akamai EdgeGrid Authentication](https://developer.akamai.com/legacy/introduction/Client_Auth.html). |
| [Hawk](Auth.Hawk.md 'PostmanManager.Models.Auth.Hawk') | The attributes for [Hawk Authentication](https://github.com/hueniverse/hawk) |
| [Ntlm](Auth.Ntlm.md 'PostmanManager.Models.Auth.Ntlm') | The attributes for [NTLM Authentication](https://msdn.microsoft.com/en-us/library/cc237488.aspx) |
| [OAuth1](Auth.OAuth1.md 'PostmanManager.Models.Auth.OAuth1') | "The attributes for [OAuth2](https://oauth.net/1/) |
| [OAuth2](Auth.OAuth2.md 'PostmanManager.Models.Auth.OAuth2') | Helper attributes for [OAuth2](https://oauth.net/2/) |

<a name='PostmanManager.Models.AuthAttribute'></a>

## AuthAttribute Class

Represents an attribute for any authorization method 
provided by Postman. For example `username` and `password` 
are set as auth attributes for Basic Authentication method.

```csharp
public class AuthAttribute
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AuthAttribute

| Properties | |
| :--- | :--- |
| [Key](AuthAttribute.Key.md 'PostmanManager.Models.AuthAttribute.Key') | No Description Given |
| [Type](AuthAttribute.Type.md 'PostmanManager.Models.AuthAttribute.Type') | No Description Given |
| [Value](AuthAttribute.Value.md 'PostmanManager.Models.AuthAttribute.Value') | No Description Given |

<a name='PostmanManager.Models.Body'></a>

## Body Class

This field contains the data usually contained in the request body.

```csharp
public class Body
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Body

| Properties | |
| :--- | :--- |
| [Disabled](Body.Disabled.md 'PostmanManager.Models.Body.Disabled') | When set to true, prevents this form data entity from being sent. |
| [File](Body.File.md 'PostmanManager.Models.Body.File') | No description given |
| [FormData](Body.FormData.md 'PostmanManager.Models.Body.FormData') | No description given |
| [Graphql](Body.Graphql.md 'PostmanManager.Models.Body.Graphql') | No description given |
| [Mode](Body.Mode.md 'PostmanManager.Models.Body.Mode') | Postman stores the type of data associated with this request in this field. |
| [Options](Body.Options.md 'PostmanManager.Models.Body.Options') | Additional configurations and options set for various body modes. |
| [Raw](Body.Raw.md 'PostmanManager.Models.Body.Raw') | No description given |
| [UrlEncoded](Body.UrlEncoded.md 'PostmanManager.Models.Body.UrlEncoded') | No description given |

<a name='PostmanManager.Models.Certificate'></a>

## Certificate Class

A representation of a list of ssl certificates

```csharp
public class Certificate
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Certificate

| Properties | |
| :--- | :--- |
| [Cert](Certificate.Cert.md 'PostmanManager.Models.Certificate.Cert') | An object containing path to file certificate, on the file system |
| [Key](Certificate.Key.md 'PostmanManager.Models.Certificate.Key') | An object containing path to file containing private key, on the file system |
| [Matches](Certificate.Matches.md 'PostmanManager.Models.Certificate.Matches') | A list of Url match pattern strings, to identify Urls this certificate can be used for. |
| [Name](Certificate.Name.md 'PostmanManager.Models.Certificate.Name') | A name for the certificate for user reference |
| [PassPhrase](Certificate.PassPhrase.md 'PostmanManager.Models.Certificate.PassPhrase') | The passphrase for the certificate |

<a name='PostmanManager.Models.Cookie'></a>

## Cookie Class

A representation of a list of cookies

```csharp
public class Cookie
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Cookie

| Properties | |
| :--- | :--- |
| [Domain](Cookie.Domain.md 'PostmanManager.Models.Cookie.Domain') | The domain for which this cookie is valid. |
| [Expires](Cookie.Expires.md 'PostmanManager.Models.Cookie.Expires') | When the cookie expires. NOTE: Type = oneOf: string, number |
| [Extensions](Cookie.Extensions.md 'PostmanManager.Models.Cookie.Extensions') | Custom attributes for a cookie go here, such as the [Priority Field](https://code.google.com/p/chromium/issues/detail?id=232693) |
| [HostOnly](Cookie.HostOnly.md 'PostmanManager.Models.Cookie.HostOnly') | True if the cookie is a host-only cookie. (i.e. a request's URL domain must exactly match the domain of the cookie). |
| [HttpOnly](Cookie.HttpOnly.md 'PostmanManager.Models.Cookie.HttpOnly') | Indicates if this cookie is HTTP Only. (if True, the cookie is inaccessible to client-side scripts) |
| [MaxAge](Cookie.MaxAge.md 'PostmanManager.Models.Cookie.MaxAge') | No Description Given |
| [Name](Cookie.Name.md 'PostmanManager.Models.Cookie.Name') | This is the name of the Cookie. |
| [Path](Cookie.Path.md 'PostmanManager.Models.Cookie.Path') | The path associated with the Cookie. |
| [Secure](Cookie.Secure.md 'PostmanManager.Models.Cookie.Secure') | Indicates if the 'secure' flag is set on the Cookie, meaning that it is transmitted over secure connections only. (typically HTTPS) |
| [Session](Cookie.Session.md 'PostmanManager.Models.Cookie.Session') | True if the cookie is a session cookie. |
| [Value](Cookie.Value.md 'PostmanManager.Models.Cookie.Value') | The value of the Cookie. |

<a name='PostmanManager.Models.Description'></a>

## Description Class

```csharp
public class Description
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Description

| Properties | |
| :--- | :--- |
| [Content](Description.Content.md 'PostmanManager.Models.Description.Content') | The content of the description goes here, as a raw string. |
| [Type](Description.Type.md 'PostmanManager.Models.Description.Type') | Holds the mime type of the raw description content.  E.g: 'text/markdown' or 'text/html'.\nThe type is  used to correctly render the description when generating  documentation, or in the Postman app. |
| [Version](Description.Version.md 'PostmanManager.Models.Description.Version') | Description can have versions associated with it, which should be put in this property. |

<a name='PostmanManager.Models.Event'></a>

## Event Class

```csharp
public class Event
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Event

| Properties | |
| :--- | :--- |
| [Disabled](Event.Disabled.md 'PostmanManager.Models.Event.Disabled') | Indicates whether the event is disabled. If absent, the event is assumed to be enabled. |
| [Id](Event.Id.md 'PostmanManager.Models.Event.Id') | A unique identifier for the enclosing event. |
| [Listen](Event.Listen.md 'PostmanManager.Models.Event.Listen') | Can be set to `test` or `prerequest` for test scripts or pre-request scripts respectively. |
| [Script](Event.Script.md 'PostmanManager.Models.Event.Script') | "A script is a snippet of Javascript code that can be used to to perform setup or teardown operations on a particular response. |

<a name='PostmanManager.Models.FileUploadObject'></a>

## FileUploadObject Class

```csharp
public class FileUploadObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FileUploadObject

| Properties | |
| :--- | :--- |
| [Content](FileUploadObject.Content.md 'PostmanManager.Models.FileUploadObject.Content') | No description given |
| [Source](FileUploadObject.Source.md 'PostmanManager.Models.FileUploadObject.Source') | Contains the name of the file to upload. _Not the path_. A null src indicates that no file has been selected as a part of the request body. |

<a name='PostmanManager.Models.FormParameter'></a>

## FormParameter Class

```csharp
public class FormParameter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FormParameter

| Properties | |
| :--- | :--- |
| [ContentType](FormParameter.ContentType.md 'PostmanManager.Models.FormParameter.ContentType') | Override Content-Type header of this form data entity. |
| [Description](FormParameter.Description.md 'PostmanManager.Models.FormParameter.Description') | A description of the header |
| [Disabled](FormParameter.Disabled.md 'PostmanManager.Models.FormParameter.Disabled') | When set to true, prevents this form data entity from being sent. |
| [Key](FormParameter.Key.md 'PostmanManager.Models.FormParameter.Key') | No description given |
| [Src](FormParameter.Src.md 'PostmanManager.Models.FormParameter.Src') | No description given |
| [Value](FormParameter.Value.md 'PostmanManager.Models.FormParameter.Value') | No description given |

<a name='PostmanManager.Models.Header'></a>

## Header Class

```csharp
public class Header
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Header

| Properties | |
| :--- | :--- |
| [Description](Header.Description.md 'PostmanManager.Models.Header.Description') | A description of the header |
| [Disabled](Header.Disabled.md 'PostmanManager.Models.Header.Disabled') | If set to true, the current header will not be sent with requests. |
| [Key](Header.Key.md 'PostmanManager.Models.Header.Key') | This holds the LHS of the HTTP Header, e.g ``Content-Type`` or ``X-Custom-Header`` |
| [Value](Header.Value.md 'PostmanManager.Models.Header.Value') | The value (or the RHS) of the Header is stored in this field. |

<a name='PostmanManager.Models.Info'></a>

## Info Class

Detailed description of the info block

```csharp
public class Info
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Info

| Properties | |
| :--- | :--- |
| [Description](Info.Description.md 'PostmanManager.Models.Info.Description') | No description given |
| [Name](Info.Name.md 'PostmanManager.Models.Info.Name') | A collection's friendly name is defined by this field.  You would want to set this field to a value that would  allow you to easily identify this collection among a  bunch of other collections, as such outlining its usage or content. |
| [PostmanId](Info.PostmanId.md 'PostmanManager.Models.Info.PostmanId') | Every collection is identified by the unique value of  this field. The value of this field is usually easiest  to generate using a UID generator function. If you already  have a collection, it is recommended that you maintain the  same id since changing the id usually implies that is a  different collection than it was originally.\n *Note: This  field exists for compatibility reasons with Collection Format V1.* |
| [Schema](Info.Schema.md 'PostmanManager.Models.Info.Schema') | This should ideally hold a link to the Postman schema  that is used to validate this collection.  E.g: https://schema.getpostman.com/collection/v1 |
| [Version](Info.Version.md 'PostmanManager.Models.Info.Version') | see the [Version](Info.Version.md 'PostmanManager.Models.Info.Version') class for info. |

<a name='PostmanManager.Models.Item'></a>

## Item Class

One of the primary goals of Postman is to organize the development of APIs. 
To this end, it is necessary to be able to group requests together. This 
can be achived using 'Folders'. A folder just is an ordered set of requests.

```csharp
public class Item : PostmanManager.Models.ItemCollection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [PostmanManager.Models.ItemCollection](https://docs.microsoft.com/en-us/dotnet/api/PostmanManager.Models.ItemCollection 'PostmanManager.Models.ItemCollection') &#129106; Item

| Properties | |
| :--- | :--- |
| [Description](Item.Description.md 'PostmanManager.Models.Item.Description') | |
| [Event](Item.Event.md 'PostmanManager.Models.Item.Event') | Defines a script associated with an associated event name |
| [Name](Item.Name.md 'PostmanManager.Models.Item.Name') | A human readable identifier for the current item. |
| [ProtocolProfileBehavior](Item.ProtocolProfileBehavior.md 'PostmanManager.Models.Item.ProtocolProfileBehavior') | Set of configurations used to alter the usual behavior of sending the request. |
| [Variables](Item.Variables.md 'PostmanManager.Models.Item.Variables') | Using variables in your Postman requests eliminates  the need to duplicate requests, which can save a  lot of time. Variables can be defined, and referenced  to from any part of a request. |

<a name='PostmanManager.Models.ItemGroup'></a>

## ItemGroup Class

Items are entities which contain an actual HTTP request, and sample responses attached to it.

```csharp
public class ItemGroup : PostmanManager.Models.ItemCollection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [PostmanManager.Models.ItemCollection](https://docs.microsoft.com/en-us/dotnet/api/PostmanManager.Models.ItemCollection 'PostmanManager.Models.ItemCollection') &#129106; ItemGroup

| Properties | |
| :--- | :--- |
| [Auth](ItemGroup.Auth.md 'PostmanManager.Models.ItemGroup.Auth') | Represents authentication helpers provided by Postman. |
| [Description](ItemGroup.Description.md 'PostmanManager.Models.ItemGroup.Description') | |
| [Event](ItemGroup.Event.md 'PostmanManager.Models.ItemGroup.Event') | Defines a script associated with an associated event name |
| [Items](ItemGroup.Items.md 'PostmanManager.Models.ItemGroup.Items') | Items are entities which contain an actual HTTP request,  and sample responses attached to it. |
| [Name](ItemGroup.Name.md 'PostmanManager.Models.ItemGroup.Name') | A human readable identifier for the current item. |
| [ProtocolProfileBehavior](ItemGroup.ProtocolProfileBehavior.md 'PostmanManager.Models.ItemGroup.ProtocolProfileBehavior') | Set of configurations used to alter the usual behavior of sending the request. |
| [Variables](ItemGroup.Variables.md 'PostmanManager.Models.ItemGroup.Variables') | Using variables in your Postman requests eliminates  the need to duplicate requests, which can save a  lot of time. Variables can be defined, and referenced  to from any part of a request. |

<a name='PostmanManager.Models.Path'></a>

## Path Class

The complete path of the current url, broken down into segments. A segment could be a string, or a path variable.

```csharp
public class Path
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Path

| Properties | |
| :--- | :--- |
| [objectPath](Path.objectPath.md 'PostmanManager.Models.Path.objectPath') | No Description Given |
| [stringArrayPath](Path.stringArrayPath.md 'PostmanManager.Models.Path.stringArrayPath') | The complete path of the current url, broken down into segments. A segment could be a string, or a path variable. |
| [stringPath](Path.stringPath.md 'PostmanManager.Models.Path.stringPath') | No Description Given |

<a name='PostmanManager.Models.Proxy'></a>

## Proxy Class

Using the Proxy, you can configure your custom proxy into 
the postman for particular url match

```csharp
public class Proxy
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Proxy

| Properties | |
| :--- | :--- |
| [Disabled](Proxy.Disabled.md 'PostmanManager.Models.Proxy.Disabled') | When set to true, ignores this proxy configuration entity |
| [Host](Proxy.Host.md 'PostmanManager.Models.Proxy.Host') | The proxy server host |
| [Match](Proxy.Match.md 'PostmanManager.Models.Proxy.Match') | The Url match for which the proxy config is defined. |
| [Port](Proxy.Port.md 'PostmanManager.Models.Proxy.Port') | The proxy server port |
| [Tunnel](Proxy.Tunnel.md 'PostmanManager.Models.Proxy.Tunnel') | The tunneling details for the proxy config |

<a name='PostmanManager.Models.Request'></a>

## Request Class

A request represents an HTTP request. If a string, the string is assumed to be the 
request URL and the method is assumed to be 'GET'.

```csharp
public class Request
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Request

| Properties | |
| :--- | :--- |
| [Auth](Request.Auth.md 'PostmanManager.Models.Request.Auth') | Represents authentication helpers provided by Postman |
| [Body](Request.Body.md 'PostmanManager.Models.Request.Body') | This field contains the data usually contained in the request body. |
| [Certificate](Request.Certificate.md 'PostmanManager.Models.Request.Certificate') | A representation of an ssl certificate |
| [Description](Request.Description.md 'PostmanManager.Models.Request.Description') | The description of this request. |
| [Headers](Request.Headers.md 'PostmanManager.Models.Request.Headers') | A representation for a list of headers. |
| [Method](Request.Method.md 'PostmanManager.Models.Request.Method') | The Standard HTTP method associated with this request. |
| [Proxy](Request.Proxy.md 'PostmanManager.Models.Request.Proxy') | Using the Proxy, you can configure your custom proxy into the postman for  particular url match |
| [RawRequest](Request.RawRequest.md 'PostmanManager.Models.Request.RawRequest') | This string holds the value of a Postman Request object that was stored as a string value. If the Request is an object, then this string will be empty. |
| [Url](Request.Url.md 'PostmanManager.Models.Request.Url') | If object, contains the complete broken-down URL for this request. If  string, contains the literal request URL. |

<a name='PostmanManager.Models.Response'></a>

## Response Class

A response represents an HTTP response.

```csharp
public class Response
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Response

| Properties | |
| :--- | :--- |
| [Body](Response.Body.md 'PostmanManager.Models.Response.Body') | The raw text of the response |
| [Code](Response.Code.md 'PostmanManager.Models.Response.Code') | The numerical response code, example: 200, 201, 404, etc. |
| [Cookies](Response.Cookies.md 'PostmanManager.Models.Response.Cookies') | |
| [Headers](Response.Headers.md 'PostmanManager.Models.Response.Headers') | No HTTP request is complete without its headers, and the  same is true for a Postman request. This field is an array  containing all the headers. |
| [Id](Response.Id.md 'PostmanManager.Models.Response.Id') | A unique, user defined identifier that can  be used to  refer to this response from requests. |
| [OriginalRequest](Response.OriginalRequest.md 'PostmanManager.Models.Response.OriginalRequest') | [Request](PostmanManager.md#PostmanManager.Models.Request 'PostmanManager.Models.Request') |
| [ResponseTime](Response.ResponseTime.md 'PostmanManager.Models.Response.ResponseTime') | The time taken by the request to complete. If a number, the ' unit is milliseconds. If the response is manually created,  this can be set to `null`. |
| [Status](Response.Status.md 'PostmanManager.Models.Response.Status') | The response status, e.g: '200 OK' |
| [Timings](Response.Timings.md 'PostmanManager.Models.Response.Timings') | Set of timing information related to request and response in milliseconds |

<a name='PostmanManager.Models.Script'></a>

## Script Class

A script is a snippet of Javascript code that can be 
used to to perform setup or teardown operations on a particular response.

```csharp
public class Script
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Script

| Properties | |
| :--- | :--- |
| [Exec](Script.Exec.md 'PostmanManager.Models.Script.Exec') | This is an array of strings, where each line  represents a single line of code. Having lines  separate makes it possible to easily track  changes made to scripts. |
| [Id](Script.Id.md 'PostmanManager.Models.Script.Id') | A unique, user defined identifier that can   be used to refer to this script from requests. |
| [Name](Script.Name.md 'PostmanManager.Models.Script.Name') | script name |
| [Type](Script.Type.md 'PostmanManager.Models.Script.Type') | Type of the script. E.g: 'text/javascript' |
| [Url](Script.Url.md 'PostmanManager.Models.Script.Url') | No Description Given |

<a name='PostmanManager.Models.StringOrNumber'></a>

## StringOrNumber Class

Generic class to handle Json objects that are of type "oneOf" where
the choices are "String", "Integer", or null.

```csharp
public class StringOrNumber
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; StringOrNumber

<a name='PostmanManager.Models.Url'></a>

## Url Class

If object, contains the complete broken-down URL for this request. If string, contains the literal request URL.

```csharp
public class Url
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Url

| Properties | |
| :--- | :--- |
| [Hash](Url.Hash.md 'PostmanManager.Models.Url.Hash') | Contains the URL fragment (if any). Usually this is not transmitted over the network, but it could be useful to store this in some cases. |
| [Host](Url.Host.md 'PostmanManager.Models.Url.Host') | The host for the URL, E.g: api.yourdomain.com. |
| [Path](Url.Path.md 'PostmanManager.Models.Url.Path') | The complete path of the current url, broken down into segments. A segment could be a string, or a path variable. |
| [Port](Url.Port.md 'PostmanManager.Models.Url.Port') | The port number present in this URL. An empty value implies 80/443 depending on whether the protocol field contains http/https. |
| [Protocol](Url.Protocol.md 'PostmanManager.Models.Url.Protocol') | The protocol associated with the request, E.g: 'http' |
| [QueryParams](Url.QueryParams.md 'PostmanManager.Models.Url.QueryParams') | An array of QueryParams, which is basically the query string part of the URL, parsed into separate variables |
| [Raw](Url.Raw.md 'PostmanManager.Models.Url.Raw') | The string representation of the request URL, including the protocol, host, path, hash, query parameter(s) and path variable(s). |

<a name='PostmanManager.Models.UrlEncodedParameter'></a>

## UrlEncodedParameter Class

```csharp
public class UrlEncodedParameter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; UrlEncodedParameter

| Properties | |
| :--- | :--- |
| [Description](UrlEncodedParameter.Description.md 'PostmanManager.Models.UrlEncodedParameter.Description') | A description of the header |
| [Disabled](UrlEncodedParameter.Disabled.md 'PostmanManager.Models.UrlEncodedParameter.Disabled') | No description given |
| [Key](UrlEncodedParameter.Key.md 'PostmanManager.Models.UrlEncodedParameter.Key') | No description given |
| [Value](UrlEncodedParameter.Value.md 'PostmanManager.Models.UrlEncodedParameter.Value') | No description given |

<a name='PostmanManager.Models.Variable'></a>

## Variable Class

```csharp
public class Variable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Variable

| Properties | |
| :--- | :--- |
| [Description](Variable.Description.md 'PostmanManager.Models.Variable.Description') | The raw text description of the variable. NOTE: currently this class does not saupport the use of objects to hold the description. |
| [Disabled](Variable.Disabled.md 'PostmanManager.Models.Variable.Disabled') | No Description Given |
| [Id](Variable.Id.md 'PostmanManager.Models.Variable.Id') | A variable ID is a unique user-defined value that identifies the variable within a collection. In traditional terms, this would be a variable name. |
| [Key](Variable.Key.md 'PostmanManager.Models.Variable.Key') | A variable key is a human friendly value that identifies the variable within a collection. In traditional terms, this would be a variable name. |
| [Name](Variable.Name.md 'PostmanManager.Models.Variable.Name') | Variable name |
| [System](Variable.System.md 'PostmanManager.Models.Variable.System') | When set to true, indicates that this variable has been set by Postman |
| [Type](Variable.Type.md 'PostmanManager.Models.Variable.Type') | A variable may have multiple types. This field specifies the type of the variable. |
| [Value](Variable.Value.md 'PostmanManager.Models.Variable.Value') | The value that a variable holds in this collection. Ultimately, the variables will be replaced by this value, when say running a set of requests from a collection |

<a name='PostmanManager.Models.Version'></a>

## Version Class

Postman allows you to version your collections as they grow, 
and this field holds the version number. While optional, 
it is recommended that you use this field to its fullest extent!

```csharp
public class Version
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Version

| Properties | |
| :--- | :--- |
| [Identifier](Version.Identifier.md 'PostmanManager.Models.Version.Identifier') | A human friendly identifier to make sense of the version numbers. E.g: 'beta-3' |
| [Major](Version.Major.md 'PostmanManager.Models.Version.Major') | Increment this number if you make changes to the collection that changes its behaviour.  E.g: Removing or adding new test scripts. (partly or completely). |
| [Minor](Version.Minor.md 'PostmanManager.Models.Version.Minor') | You should increment this number if you make changes that will not break  anything that uses the collection. E.g: removing a folder. |
| [Patch](Version.Patch.md 'PostmanManager.Models.Version.Patch') | Ideally, minor changes to a collection should result in the increment of this number. |
| [VersionAsString](Version.VersionAsString.md 'PostmanManager.Models.Version.VersionAsString') | Holds the string representation of a Postman Version if the JSON has the Version stored as a string instead of an object |
