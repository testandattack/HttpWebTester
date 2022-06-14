#### [ApiTestGenerator.Models](ApiTestGenerator.Models.md 'ApiTestGenerator.Models')
### [ApiTestGenerator.Models](ApiTestGenerator.Models.md#ApiTestGenerator.Models 'ApiTestGenerator.Models')

## LogSettings Class

This mclass encapsulates the settings used by the application's logger.

```csharp
public class LogSettings
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LogSettings
### Properties

<a name='ApiTestGenerator.Models.LogSettings.ClearLogFileOnStartup'></a>

## LogSettings.ClearLogFileOnStartup Property

When "true, the parser's [DefaultLogFileName](LogSettings.md#ApiTestGenerator.Models.LogSettings.DefaultLogFileName 'ApiTestGenerator.Models.LogSettings.DefaultLogFileName') file  
will be cleared each time the parser starts. When "false", the  
log file will be appended.

```csharp
public bool ClearLogFileOnStartup { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='ApiTestGenerator.Models.LogSettings.DefaultLogFileName'></a>

## LogSettings.DefaultLogFileName Property

The full path and file name that will hold the logs for the parser

```csharp
public string DefaultLogFileName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='ApiTestGenerator.Models.LogSettings.MinLogEventLevel'></a>

## LogSettings.MinLogEventLevel Property

The minimum [Serilog.Events.LogEventLevel](https://docs.microsoft.com/en-us/dotnet/api/Serilog.Events.LogEventLevel 'Serilog.Events.LogEventLevel') to  
use when creating the parser's log file.

```csharp
public Serilog.Events.LogEventLevel MinLogEventLevel { get; set; }
```

#### Property Value
[Serilog.Events.LogEventLevel](https://docs.microsoft.com/en-us/dotnet/api/Serilog.Events.LogEventLevel 'Serilog.Events.LogEventLevel')