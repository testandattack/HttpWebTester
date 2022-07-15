using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GTC.Extensions;
using Newtonsoft.Json.Serialization;
using ErrorEventArgs = Newtonsoft.Json.Serialization.ErrorEventArgs;
using Serilog;

namespace PostmanManager
{
    public static class PostmanCollection_Extensions
    {
        public static void LoadCollection(this PostmanCollection source, string fileName)
        {
            List<string> errors = new List<string>();
            
            using (StreamReader sr = new StreamReader(fileName))
            {
                var settings = new JsonSerializerSettings
                {
                    Error = delegate (object sender, ErrorEventArgs args)
                    {
                        errors.Add(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    },
                    TypeNameHandling = TypeNameHandling.Objects
                };
                source = JsonConvert.DeserializeObject<PostmanCollection>(sr.ReadToEnd(), settings);
            }
            Log.Information(errors.ToString("\r\n"));
        }

        public static void SaveCollection(this PostmanCollection source, string fileName)
        {
            List<string> errors = new List<string>();
            
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                var settings = new JsonSerializerSettings
                {
                    Error = delegate (object sender, ErrorEventArgs args)
                    {
                        errors.Add(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    },
                    TypeNameHandling = TypeNameHandling.Objects,
                    NullValueHandling = NullValueHandling.Ignore
                };
                sw.Write(JsonConvert.SerializeObject(source, Formatting.Indented));
            }
            Log.Information(errors.ToString("\r\n"));
        }
    }
}
