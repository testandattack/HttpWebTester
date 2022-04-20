using Automatonic.HttpArchive;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
//using Utilities;

namespace ApiTestGenerator.Models.HttpArchive
{
    public class HarStatistics
    {
        public int minimumMillisecondsForSlowPage_ValueUsed { get; set; }

        public int numPages { get; set; }

        public int numItemsInEntriesList { get; set; }

        public int numItemsInRequestsList { get; set; }

        public int numItemsProcessed { get; set; }

        public int numItemsIgnored { get; set; }

        public HarStatistics()
        {
            numPages = 0;
            numItemsInEntriesList = 0;
            numItemsInRequestsList = 0;
            numItemsProcessed = 0;
            numItemsIgnored = 0;
            minimumMillisecondsForSlowPage_ValueUsed = 0;
        }
    }
}
