using ApiTestGenerator.Models.Consts;


namespace ApiTestGenerator.Models.Enums
{
    /// <summary>
    /// Enumerates the types of <see cref="CustomEndPointObject"/>s that are currently supported. 
    /// </summary>
    public enum CustomEndPointObjectTypeEnum
    {
        /// <summary>
        /// <see cref="ParseTokens.TKN_RestrictTo"/>
        /// </summary>
        RestrictTo = 1,

        /// <summary>
        /// <see cref="ParseTokens.TKN_ProvidesValuesFor"/>
        /// </summary>
        ProvidesValuesFor = 2,

        /// <summary>
        /// <see cref="ParseTokens.TKN_MethodName"/>
        /// </summary>
        MethodName = 3,

        /// <summary>
        /// <see cref="ParseTokens.TKN_TestDataFilter"/>
        /// </summary>
        TestDataFilter = 4,

        /// <summary>
        /// <see cref="ParseTokens.TKN_GetsInputFrom"/>
        /// </summary>
        GetsInputFrom = 5,

        /// <summary>
        /// <see cref="ParseTokens.PARAM_StartDate"/> 
        /// or <see cref="ParseTokens.PARAM_EndDate"/>
        /// </summary>
        CalculatedDateValue = 6
    }
}
