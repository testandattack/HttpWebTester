using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace GTC.HttpWebTester.Settings
{
    public class CodeGenerationSettings
    {
        public string DtoCodeFileName { get; set; }

        public string CodeNamespace { get; set; }

        public string CoreClassName { get; set; }

        public bool GenerateExceptionClasses { get; set; }

        public bool GenerateClientClasses { get; set; }
    }
}
