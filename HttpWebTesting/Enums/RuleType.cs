namespace HttpWebTesting.Enums
{
    /// <summary>
    /// Lists the rule's scope and the location where a given rule should be executed
    /// </summary>
    /// <include file='Documentation/xml_include_tag.xml' path='MyDocs/MyMembers[@name="RuleExecutionOrder"]'/>
    public enum RuleType
    {

        /// <summary>
        /// Executes before the first request of the test is executed.
        /// </summary>
        PreTest = 1,

        /// <summary>
        /// Executes before the request is executed.
        /// </summary>
        RequestRule_PreRequest = 2,

        /// <summary>
        /// Executes before EACH request is executed.
        /// </summary>
        TestRule_PreRequest = 3,

        /// <summary>
        /// Executes after the request is executed, but before any 
        /// <see cref="RequestRule_Extraction"/> Rules or any
        /// <see cref="RequestRule_PostRequest"/> Rules.
        /// </summary>
        RequestRule_Validation = 4,

        /// <summary>
        /// Executes after EACH request in the test is executed. 
        /// </summary>
        TestRule_Validation = 5,

        /// <summary>
        /// Executes after the request is executed and after any 
        /// <see cref="RequestRule_Validation"/> Rules but BEFORE any
        /// <see cref="RequestRule_PostRequest"/> Rules.
        /// </summary>
        RequestRule_Extraction = 6,

        /// <summary>
        /// Executes after the request is executed.
        /// </summary>
        RequestRule_PostRequest = 8,

        /// <summary>
        /// Executes after EACH request is executed.
        /// </summary>
        TestRule_PostRequest = 9,

        /// <summary>
        /// Executes after the last request of the test is executed.
        /// </summary>
        PostTest = 10
    };
}
