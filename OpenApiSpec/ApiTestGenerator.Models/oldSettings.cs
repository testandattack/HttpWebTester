using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ApiTestGenerator.Models
{
    public class OldSettings
    {
        /// <summary>
        /// The file path to the folder that contains all of the input files
        /// and data/code files that will be added to the test harness.
        /// </summary>
        public string DefaultInputLocation { get; set; }

        /// <summary>
        /// The file path to the folder that the parser will use to store
        /// all of the generated output files.
        /// </summary>
        public string DefaultOutputLocation { get; set; }

        #region -- Settings Categories -----
        public LogSettings logSettings { get; set; }

        public SwaggerSettings swaggerSettings { get; set; }

        public ApiDocsSettings apiDocsSettings { get; set;}

        public ApiAnalysisSettings apiAnalysisSettings { get; set; }

        public CodeGenerationSettings codeGenerationSettings { get; set; }

        public HarFileProcessingSettings harFileProcessingSettings { get; set; }

        public WebLogAnalysisSettings webLogAnalysisSettings { get; set; }
        #endregion

        public static OldSettings LoadSettings(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                return JsonConvert.DeserializeObject<OldSettings>(sr.ReadToEnd());
            }
        }

    }

    /// <summary>
    /// This mclass encapsulates the settings used by the application's logger.
    /// </summary>
    public class LogSettings
    {
        /// <summary>
        /// The full path and file name that will hold the logs for the parser
        /// </summary>
        public string DefaultLogFileName { get; set; }

        /// <summary>
        /// The minimum <see cref="Serilog.Events.LogEventLevel"/> to
        /// use when creating the parser's log file.
        /// </summary>
        public Serilog.Events.LogEventLevel MinLogEventLevel { get; set; }

        /// <summary>
        /// When "true, the parser's <see cref="DefaultLogFileName"/> file
        /// will be cleared each time the parser starts. When "false", the
        /// log file will be appended.
        /// </summary>
        public bool ClearLogFileOnStartup { get; set; }
    }

    /// <summary>
    /// This class encapsulates the settings that define where and how to read 
    /// Open API Spec documentation (swagger) files.
    /// </summary>
    public class SwaggerSettings
    {
        /// <summary>
        /// The root portion of the API's UriStem.
        /// </summary>
        public string apiRoot { get; set; }

        /// <summary>
        /// The "server" portion of the URL that holds the Swagger generated
        /// document for the API. This is combined with the 
        /// <see cref="SwaggerStreamLocation"/> to read the document to parse.
        /// <strong>NOTE:</strong> This is only used if
        /// <see cref="ReadSwaggerFromFile"/> is set to "false"
        /// </summary>
        public string BaseUriAddress { get; set; }

        /// <summary>
        /// The UriStem portion of the URL that holds the Swagger generated
        /// document for the API. This is combined with the 
        /// <see cref="BaseUriAddress"/> to read the document to parse.
        /// <strong>NOTE:</strong> This is only used if
        /// <see cref="ReadSwaggerFromFile"/> is set to "false"
        /// </summary>
        public string SwaggerStreamLocation { get; set; }

        /// <summary>
        /// The file name of a pre-generated Swagger document to read
        /// and parse.
        /// <strong>NOTE:</strong> This is used if
        /// <see cref="ReadSwaggerFromFile"/> is set to "true". It is 
        /// also used as the location to save the Swagger Document if
        /// you are parsing from the swagger stream.
        /// </summary>
        public string SwaggerFileLocation { get; set; }

        /// <summary>
        /// When "true" the parser will get the Swagger Document
        /// from the <see cref="SwaggerFileLocation"/>. If "false"
        /// the parser will get the Swagger Document from the 
        /// <see cref="BaseUriAddress"/> and <see cref="SwaggerStreamLocation"/>
        /// </summary>
        public bool ReadSwaggerFromFile { get; set; }
    }

    /// <summary>
    /// This class encapsulates all settings used in the storing and reading of 
    /// <see cref="ApiDocs.ApiSet"/> data.
    /// </summary>
    public class ApiDocsSettings
    {

    }

    public class ApiAnalysisSettings
    {
        public bool AnalyzeApiEndpoints { get; set; }

        public bool AnalyzeRequestBodies { get; set; }

        public bool AnalyzeApiComponents { get; set; }

        public bool AnalyzeInputParameters { get; set; }

        public bool AnalyzeEndPointRestrictions { get; set; }

        public bool AnalyzeEndpointRestrictionSummary { get; set; }

        public bool AnalyzeProperties { get; set; }

        public bool AnalyzeLookupProperties { get; set; }

        public bool AnalyzeInputParametersNotInProperties { get; set; }

        public bool AnalyzeInputParametersNotInLookupProperties { get; set; }

        public bool AddEndpointParsingData { get; set; }

        public bool IncludeOnlyEndpointSummariesWithMatchingRequests { get; set; }
    }

    public class CodeGenerationSettings
    {
        public string DtoCodeFileName { get; set; }

        public string CodeNamespace { get; set; }

        public string CoreClassName { get; set; }

        public bool GenerateExceptionClasses { get; set; }

        public bool GenerateClientClasses { get; set; }
    }

    public class HarFileProcessingSettings
    {
        public bool AddEndpointParsingDataFromHar { get; set; }

        public string HarFileName { get; set; }

        public bool processMultipleHarFiles { get; set; }

        public string HarFileFolderLocation { get; set; }

        public bool IncludeFullHarInRequestsList { get; set; }

        public bool IncludeResponseContentInSummaryJson { get; set; }

        public bool IncludeResponseTextInSummaryJson { get; set; }

        public bool IncludeTimingsInSummaryJson { get; set; }
        
        public bool IncludeEntriesInSummaryJson { get; set; }

        public bool SaveParsedHttpArchiveInsteadOfSummary { get; set; }

        public int minimumMillisecondsForSlowPage { get; set; }

        public bool EncodeResponseText { get; set; }

        public List<string> DomainsToInclude { get; set; }

        public List<string> UnwantedItems { get; set; }

        public List<string> UnwantedPages { get; set; }

        public List<string> UnwantedReferers { get; set; }

    }

    public class WebLogAnalysisSettings
    {
        public int minimumNumRequestsForSlowEndpointProcessing { get; set; }

        public int minimumNumRequestsForPercentileProcessing { get; set; }

        public bool useNormal_StdDev { get; set; }

        public List<string> includeTheseStatusCodesForTimingAnalysis { get; set; }
    }
}
