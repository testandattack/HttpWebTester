namespace ApiTestGenerator.Models.Consts
{
    /// <summary>
    /// This class contains constant string values that are used for parsing OAS documents.
    /// </summary>
    /// <remarks>
    /// These string constants represent a few different types of 'searchable' strings. The 
    /// preamble of each token represents the type of string:
    /// <list type="bullet">
    /// <item><c>TKN</c> These items represent strings that can be added to the XML Documentation in a way that they will
    /// show up in the generated OAS document.</item>
    /// <item><c>PARAM</c> These items contain strings that represent the names of common parameters that (when
    /// used by developers in the API) will allow the OAS parser to identify these parameters as properties to
    /// make dynamioc in any generated test harnesses.</item>
    /// <item><c>OAS</c> These items contain strings that are known constants defined within the Open Api Spec.</item>
    /// <item><c>DESC</c> These items are more generic and act as a 'catch-all' bucket for terms.</item>
    /// </list>
    /// </remarks>
    public class ParseTokens
    {
        /// <summary>
        /// Gets the fully qualified name of the property that will provide input into this parameter
        /// </summary>
        public const string TKN_GetsInputFrom = "{{GetsInputFrom}}(";

        /// <summary>
        /// Gets the fully qualified class name of this DTO
        /// </summary>
        public const string TKN_ClassName = "{{ClassName}}(";

        /// <summary>
        /// Provides filtering/alignment information for retrieving input data from multiple response objects
        /// </summary>
        public const string TKN_TestDataFilter = "{{TestDataFilter}}(";

        /// <summary>
        /// Contains the arguments used when providing a 
        /// <see cref="TKN_TestDataFilter"/> Token in XML Documentation
        /// </summary>
        public const string TKN_TestDataFilterStringFormat = "[SharedPropertyName], [PrimaryDto], [DependentDto]";

        /// <summary>
        /// Sets a dynamic value for the start date based on current day offset.
        /// </summary>
        public const string TKN_startDate = "{{startDate}}";

        /// <summary>
        /// Sets a dynamic value for the end date based on current day offset.
        /// </summary>
        public const string TKN_endDate = "{{endDate}}";

        /// <summary>
        /// Contains the arguments used when providing a 
        /// <see cref="TKN_startDate"/> or <see cref="TKN_endDate"/> Token in XML Documentation
        /// </summary>
        public const string TKN_CalculatedDateStringFormat = "[BaseDate], [DateFormat], [DateOffset]";

        /// <summary>
        /// A Swagger custom property that contains a list of methods that this endpoint can potentially provide values for.
        /// </summary>
        public const string TKN_ProvidesValuesFor = "x-provides-values-for";

        /// <summary>
        /// A Swagger custom property that contains the name of the method
        /// </summary>
        public const string TKN_MethodName = "x-method-name";

        /// <summary>
        /// A Swagger custom property that contains a list of roles that this method allows access to
        /// </summary>
        public const string TKN_RestrictTo = "x-restrict-to";

        /// <summary>
        /// This tag value, when present, indicates that this method is a lookup method.
        /// </summary>
        public const string TKN_LookupMethod = "Lookups";

        /// <summary>
        /// this string represents the name of an API operation's input parameter that contains a <see cref="DateTime"/> 
        /// value for the starting date of a query.
        /// </summary>
        public const string PARAM_StartDate = "startDate";

        /// <summary>
        /// this string represents the name of an API operation's input parameter that contains a <see cref="DateTime"/> 
        /// value for the ending date of a query.
        /// </summary>
        public const string PARAM_EndDate = "endDate";

        /// <summary>
        /// this string represents the precursor for an API operation's input parameter name that contains a List of values. 
        /// </summary>
        public const string PARAM_List_Precursor = "List_";

        /// <summary>
        /// this string represents an item in the OAS schema that has missing info.
        /// </summary>
        public const string PARAM_MissingInfo = "MissingInfo";

        /// <summary>
        /// this string represents an item in the OAS schema that has a missing field type.
        /// </summary>
        public const string PARAM_MissingTypeField = "Type Not Found";

        public const string PARAM_ShowsUpInQuery = "query";

        /// <summary>
        /// the string to search for in the content-type that indicates the response is a JSON object
        /// </summary>
        public const string OAS_JsonContentType = "application/json";

        /// <summary>
        /// the string to search for in the content-type that indicates the response is a binary or form data object
        /// </summary>
        public const string OAS_FormDataContentType = "multipart/form-data";

        /// <summary>
        /// the string to search for in the content-type that indicates there was no response object.
        /// </summary>
        public const string OAS_NoContentFound = "No content object found";

        public const string DESC_ForTestingPurposes = "FOR TESTING PURPOSES";
    }
}
