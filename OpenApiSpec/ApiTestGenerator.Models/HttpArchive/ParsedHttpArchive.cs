using Automatonic.HttpArchive;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApiTestGenerator.Models.HttpArchive
{
    /// <summary>
    /// This class contains the results of parsing the base HAR file.
    /// It is used by the test generator to build the list of
    /// requests to add to a test harness.
    /// </summary>
    public class ParsedHttpArchive
    {
        #region -- Public Properties ---------------------------------------
        /// <summary>
        /// This list, sorted by time, contains all of the request entries
        /// that met the criteria for keeping for analysis and testing.
        /// </summary>
        public SortedList<DateTime, EntryEx> SortedEntries { get; set; }

        /// <summary>
        /// This list contains the response data from every request
        /// that met the criteria for keeping for analysis and testing.
        /// </summary>
        public Dictionary<int, ResponseEx> Responses { get; set; }

        /// <summary>
        /// This list contains the PAGE level entries that were parsed
        /// from the <see cref="archiveDocument"/>.
        /// </summary>
        public SortedList<DateTime, Page> mainPages { get; set; }


        public HttpArchiveSummary summary { get; set; }
        #endregion

        #region -- Constructors --------------------------------------------
        public ParsedHttpArchive()
        {
            SortedEntries = new SortedList<DateTime, EntryEx>();
            Responses = new Dictionary<int, ResponseEx>();
            mainPages = new SortedList<DateTime, Page>();
        }
        #endregion

        #region -- Read and Write methods -----
        public void SerializeAndSaveParsedHttpArchive(string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
                }
                Serilog.Log.ForContext<ParsedHttpArchive>().Information("SerializeAndSaveParsedHttpArchive completed successfully");
            }
            catch (Exception ex)
            {
                Serilog.Log.ForContext<ParsedHttpArchive>().Error(ex, "[EXCEPTION] {callingMethod} failed.", "SerializeAndSaveParsedHttpArchive");
            }
        }

        public static ParsedHttpArchive LoadParsedHttpArchiveFromFile(string fileName)
        {
            ParsedHttpArchive parsedHttpArchive = null;
            using (StreamReader sr = new StreamReader(fileName))
            {
                parsedHttpArchive = JsonConvert.DeserializeObject<ParsedHttpArchive>(sr.ReadToEnd());
            }
            if (parsedHttpArchive == null)
            {
                Serilog.Log.ForContext<HttpArchiveSummary>().Error("LoadParsedHttpArchiveFromFile failed to load the set from {fileName}", fileName);
                throw new NullReferenceException($"LoadParsedHttpArchiveFromFile failed to load the set from {fileName}");
            }
            return parsedHttpArchive;
        }
        #endregion
    }
}
