#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models.ApiAnalyzer](ApiTestGenerator.Models.md#ApiTestGenerator.Models.ApiAnalyzer 'ApiTestGenerator.Models.ApiAnalyzer')

## EndpointParsingData Class

```csharp
public class EndpointParsingData
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EndpointParsingData
### Properties

<a name='ApiTestGenerator.Models.ApiAnalyzer.EndpointParsingData.Method'></a>

## EndpointParsingData.Method Property

[Automatonic.HttpArchive.Request.Method](https://docs.microsoft.com/en-us/dotnet/api/Automatonic.HttpArchive.Request.Method 'Automatonic.HttpArchive.Request.Method')

```csharp
public string? Method { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiAnalyzer.EndpointParsingData.patternString'></a>

## EndpointParsingData.patternString Property

The string that contains the regex pattern used to locate matching URLs in the HAR   
NOTE: If patternString == string.Empty, then there are no params in the URL and  
the Regex search can be skipped and an exact string search can be performed.

```csharp
public string patternString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.ApiAnalyzer.EndpointParsingData.slotLocations'></a>

## EndpointParsingData.slotLocations Property

int: The index of the url's subdirectory that contains the parameter  
string: the parameter's name

```csharp
public System.Collections.Generic.Dictionary<int,string> slotLocations { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

### Remarks
The following sample shows the "slots:"  
       /api/Acmf/TailNumber/{tailNumber}/Report/{reportId}  
       0   1    2          3            4      5  
In the above call, TailNumber is in slot 3 and reportId is in slot 5