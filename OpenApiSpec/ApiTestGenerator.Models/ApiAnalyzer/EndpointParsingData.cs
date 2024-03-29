﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiTestGenerator.Models.ApiAnalyzer
{
    public class EndpointParsingData
    {
        #region -- Properties -----
        public int EndpointId { get; set; }

        /// <summary>
        /// The string that contains the regex pattern used to locate matching URLs in the HAR 
        /// NOTE: If patternString == string.Empty, then there are no params in the URL and
        /// the Regex search can be skipped and an exact string search can be performed.
        /// </summary>
        public string patternString { get; set; }

        /// <summary>
        /// int: The index of the url's subdirectory that contains the parameter
        /// string: the parameter's name
        /// </summary>
        /// <remarks>
        /// The following sample shows the "slots:"
        ///        /api/Acmf/TailNumber/{tailNumber}/Report/{reportId}
        ///        0   1    2          3            4      5
        /// In the above call, TailNumber is in slot 3 and reportId is in slot 5       
        /// </remarks>
        public Dictionary<int, string> slotLocations { get; set; }

        /// <summary>
        /// <see cref="Automatonic.HttpArchive.Request.Method"/>
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Method { get; set; }

        public List<string> Methods { get; set; }

        public string UriPath { get; set; }
        #endregion

        #region -- Constructors -----
        public EndpointParsingData()
        {
            slotLocations = new Dictionary<int, string>();
        }
        #endregion
    }
}
