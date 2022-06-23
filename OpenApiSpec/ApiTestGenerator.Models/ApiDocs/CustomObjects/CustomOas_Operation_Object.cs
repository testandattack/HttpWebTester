using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.ApiDocs
{
    public class CustomOas_Operation_Object : CustomOasObject
    {
        public CustomOas_Operation_Object()
        {
            this.CustomObjectName = string.Empty;
            this.CustomObjectType = "CustomOas_Operation_Object";
        }

        public virtual void ParseObject(object sender, CustomOas_Operation_ObjectEventArgs e) { }
    }
}
