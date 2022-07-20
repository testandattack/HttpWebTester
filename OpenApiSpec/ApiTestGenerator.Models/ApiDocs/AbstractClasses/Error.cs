using ApiTestGenerator.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// A base class for storing errors when working with ApiSets and ApiSetAnalyzers
    /// </summary>
    [JsonObject(Title = "error")]
    public abstract class Error
    {
        /// <summary>
        /// The text of the error message
        /// </summary>
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// A copy of the ovject that had the error.
        /// </summary>
        [JsonProperty("objectWithError")]
        public object ObjectWithError { get; set; }

        /// <summary>
        /// Returns a string built from an error number and the error category
        /// </summary>
        /// <param name="iNum"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public string GetErrorCategory(int iNum, AnalyzerErrorCategoryEnum category)
        {
            return $"{iNum}-{category.ToString()}";
        }
    }
}
