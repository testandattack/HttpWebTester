namespace ApiTestGenerator.Models.Consts
{
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

        public const string PARAM_StartDate = "startDate";
        public const string PARAM_EndDate = "endDate";

        public const string PARAM_List_Precursor = "List_";
        public const string PARAM_MissingInfo = "MissingInfo";
        public const string PARAM_MissingTypeField = "Type Not Found";


        public const string OAS_JsonContentType = "application/json";
        public const string OAS_FormDataContentType = "multipart/form-data";
        public const string OAS_NoContentFound = "No content object found";

        public const string DESC_ForTestingPurposes = "FOR TESTING PURPOSES";

        public const string PARAM_ShowsUpInQuery = "query";
    }
}
