using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApiTestGenerator.Models.CommonItems;
using Newtonsoft.Json;

namespace ApiTestGenerator.Models.WebLogs
{

    /*
    "TimeGenerated [UTC]"
    ,CIp
    ,CsMethod
    ,CsHost
    ,CsUriStem
    ,ScStatus
    ,ScBytes
    ,TimeTaken
    
    "3/2/2021
    , 3:39:20.198 PM"
    ,"52.247.126.35"
    ,GET
    ,"iao-ascentia-api-eastus2.azurewebsites.net"
    ,"/"
    ,200
    ,375
    ,12
    
    "3/2/2021, 3:39:20.198 PM","52.247.126.35",GET,"iao-ascentia-api-eastus2.azurewebsites.net","/",200,378,34
    "2/24/2021, 7:30:12.684 PM","52.247.126.35",GET,"iao-ascentia-api-eastus2.azurewebsites.net","/",200,375,1015

    */
    public class WebLogEntry : RequestEntry, IComparable
    {
        public int ScStatus { get; set; }

        public int ScBytes { get; set; }
        
        public int CsBytes { get; set; }

        public int TimeTaken { get; set; }

        public WebLogEntry() { }

        public WebLogEntry(string[] args)
        {

          //  AppServiceHTTPLogs
          //  | where TimeGenerated > ago(10days)
          //  | where UserAgent!contains "Edge+Health+Probe"
          //  | where CsHost!contains ".scm.azurewebsites.net"
          //  | where CsMethod <> "OPTIONS"
          //  | project TimeGenerated, CIp, CsMethod, CsHost, CsUriStem, ScStatus, ScBytes, CsBytes, TimeTaken
          //  | order by TimeGenerated

            string sTime = args[0].Replace("\"", "") + args[1].Replace("\"", "");
            RequestTime = Convert.ToDateTime(sTime);
            IpAddress = args[2].Replace("\"", "");
            Method = args[3];
            Host = args[4].Replace("\"", "");
            UriStem = args[5].Replace("\"", "");
            ScStatus = Convert.ToInt32(args[6]);
            ScBytes = Convert.ToInt32(args[7]);
            CsBytes = Convert.ToInt32(args[7]);
            TimeTaken = Convert.ToInt32(args[8]);
        }

        #region -- IComparable overrides ----------------------------------
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != typeof(WebLogEntry))
            {
                return false;
            }
            WebLogEntry webLogEntry = obj as WebLogEntry;

            if (RequestTime == webLogEntry.RequestTime
                && IpAddress == webLogEntry.IpAddress
                && Method == webLogEntry.Method
                && UriStem == webLogEntry.UriStem
                && CsBytes == webLogEntry.CsBytes
                && ScBytes == webLogEntry.ScBytes
                && TimeTaken == webLogEntry.TimeTaken)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int hash = 19;
            hash = hash * 31 + RequestTime.GetHashCode();
            hash = hash * 31 + IpAddress.GetHashCode();
            hash = hash * 31 + Method.GetHashCode();
            hash = hash * 31 + UriStem.GetHashCode();
            hash = hash * 31 + CsBytes.GetHashCode();
            hash = hash * 31 + ScBytes.GetHashCode();
            hash = hash * 31 + TimeTaken.GetHashCode();
            return hash;
        }

        int IComparable.CompareTo(object obj)
        {
            WebLogEntry p1 = (WebLogEntry)this;
            WebLogEntry p2 = (WebLogEntry)obj;
            if (p1.RequestTime < p2.RequestTime)
                return -1;
            if (p1.RequestTime > p2.RequestTime)
                return 1;
            else
            {
                return string.Compare(
                    $"{p1.IpAddress}{p1.Method}{p1.UriStem}{p1.CsBytes}{p1.ScBytes}{p1.TimeTaken}",
                    $"{p2.IpAddress}{p2.Method}{p2.UriStem}{p2.CsBytes}{p2.ScBytes}{p2.TimeTaken}");
            }
        }
        #endregion

        public WebLogEntry Copy()
        {
            return (WebLogEntry)this.MemberwiseClone();
        }
    }
}
