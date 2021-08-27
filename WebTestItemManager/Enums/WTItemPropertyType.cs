using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestItemManager
{
    /// <summary>
    /// This enum classifies the highlighted object in the webtest treeview so that it can
    /// be properly added to the propertyGrid
    /// </summary>
    public enum WTItemPropertyType
    {
        None = 0,
        Header = 1,
        QueryString = 2,
        FormPost = 3,
        ExtractionRule = 4,
        RequestValidationRule = 5,
        RequestPlugin = 6,
        StringBody = 7,
        BinaryBody = 8,
        DataSource = 9,
        DataSourceTable = 10,
        ContextParameter = 11,
        WebtestValidationRule = 12,
        WebtestPlugin = 13,
        MainItemIsSelected = 14,
        Cookie = 15
    };
}
