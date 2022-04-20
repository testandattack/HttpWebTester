using ApiTestGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.ApiDocs
{
    public abstract class Error
    {
        public string ErrorMessage { get; set; }

        public object ObjectWithError { get; set; }

        public string GetErrorCategory(int iNum, AnalyzerErrorCategoryEnum category)
        {
            return $"{iNum}-{category.ToString()}";
        }
    }
}
