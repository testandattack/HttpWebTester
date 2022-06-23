using ApiTestGenerator.Models.ApiDocs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDocs.CustomObjects.Extensions
{
    public static class TestDataFilterExtensions
    {
        public static void ParseDescription(this TestDataFilter source, string description)
        {
            /*
             * This is the full entry as added to the API Code
            {{TestDataFilter}}("PRIMARY","App.Models.Model.NameOfDto1.propertyName","DEPENDENT","App.Models.Model.NameOfDto2.propertyName")

            This is the string that get's passed in to this method:
            "PRIMARY","App.Models.Model.NameOfDto1.propertyName","DEPENDENT","App.Models.Model.NameOfDto2.propertyName"

            This is the array of strings after massaging it.

            [0] PRIMARY
            [1] App.Models.Model.NameOfDto1.propertyName
            [2] DEPENDENT
            [3] App.Models.Model.NameOfDto2.propertyName
            */

            source.PrimaryDto = string.Empty;
            source.DependentDto = string.Empty;

            string[] items = description
                .Replace("\"", "")
                .Split(',');

            if (items != null && items.Length == 4)
            {
                if (items[0].ToUpper() == "PRIMARY")
                {
                    source.PrimaryDto = items[1].Substring(0, items[1].LastIndexOf("."));
                }
                if (items[2].ToUpper() == "DEPENDENT")
                {
                    source.DependentDto = items[3].Substring(0, items[3].LastIndexOf("."));
                }
                source.SharedPropertyName = items[1].Substring(items[1].LastIndexOf(".") + 1);
            }
        }
    }
}
