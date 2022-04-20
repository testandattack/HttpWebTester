using ApiTestGenerator.Models.CommonItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.AuditRecords
{
    public class AuditRecordEntry : RequestEntry
    {
        #region -- Properties -----
        public string userId { get; set; }

        public string APICall { get; set; }

        public string queryString { get; set; }
        #endregion

        #region -- Constructors -----
        public AuditRecordEntry()
        {
            userId = string.Empty;
            RequestTime = DateTime.MinValue;
            IpAddress = string.Empty;
            APICall = string.Empty;
            UriStem = string.Empty;
            queryString = string.Empty;
        }

        public AuditRecordEntry(string[] args)
        {
            //AccessTime,UserId,UserIPAddress,APICall
            RequestTime = Convert.ToDateTime(args[0]);
            userId = args[1].Substring(0, 8);
            IpAddress = args[2];
            APICall = args[3];
            GetStemAndQuery(args[3]);
        }
        #endregion

        #region -- private methods -----
        private void GetStemAndQuery(string Uri)
        {
            int iStart = Uri.IndexOf("/api/");
            if(Uri.Contains("?"))
            {
                int x = Uri.IndexOf("?");
                UriStem = Uri.Substring(iStart, x-iStart);
                queryString = Uri.Substring(x + 1);
            }
            else
            {
                UriStem = Uri.Substring(iStart);
                queryString = string.Empty;
            }
        }
        #endregion
    }
}
