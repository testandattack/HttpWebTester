using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace GTC.HttpWebTester.Settings
{
    public class Settings
    {
        /// <summary>
        /// The file path to the folder that contains all of the input files
        /// and data/code files that will be added to the test harness.
        /// </summary>
        public string DefaultInputLocation { get; set; }

        /// <summary>
        /// The file path to the folder that the parser will use to store
        /// all of the generated output files.
        /// </summary>
        public string DefaultOutputLocation { get; set; }

        #region -- Settings Categories -----
        public LogSettings logSettings { get; set; }

        public SwaggerSettings swaggerSettings { get; set; }

        public ApiDocsSettings apiDocsSettings { get; set;}

        public ApiAnalysisSettings apiAnalysisSettings { get; set; }
        #endregion

        public Settings() { }

        public Settings(string fileName)
        {
            LoadSettings(fileName);
        }

        public void LoadSettings(string fileName)
        {
            var tempSettings = ReadSettingsFromFile(fileName);
            this.DefaultInputLocation = tempSettings.DefaultInputLocation;
            this.DefaultOutputLocation = tempSettings.DefaultOutputLocation;
            this.logSettings = tempSettings.logSettings;
            this.swaggerSettings = tempSettings.swaggerSettings;
            this.apiDocsSettings = tempSettings.apiDocsSettings;
            this.apiAnalysisSettings = tempSettings.apiAnalysisSettings;
        }

        private static Settings ReadSettingsFromFile(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                return JsonConvert.DeserializeObject<Settings>(sr.ReadToEnd());
            }
        }
    }
}
