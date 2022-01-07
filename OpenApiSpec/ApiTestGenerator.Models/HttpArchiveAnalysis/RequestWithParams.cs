using System;
using System.Collections.Generic;

namespace ApiTestGenerator.Models.HttpArchiveAnalysis
{
    public class RequestWithParams
    {
        public string requestEntryName { get; set; }

        /// <summary>
        /// the name and value for each param located.
        /// </summary>
        public Dictionary<string, string> paramValues { get; set; }

        public RequestWithParams()
        {
            paramValues = new Dictionary<string, string>();
        }

        public void AddParamValues(string urlWithValues, Dictionary<int, string> slotLocations)
        {
            /*
                /api/Acmf/TailNumber/{tailNumber}/Report/{reportId}
                0   1    2          3            4      5

                /api/Acmf/TailNumber/XX101/Report/9851047
                0   1    2          3     4      5
            */
            // ASSUMPTIONS:
            // 1. The slotLocations have already been found.
            // 2. The string passed in starts at the exact same path location as the slotLocations string
            string[] subdirs = urlWithValues.Split('/', StringSplitOptions.RemoveEmptyEntries);
            foreach(var item in slotLocations)
            {
                paramValues.Add(item.Value, subdirs[item.Key]);
            }
        }
    }
}
