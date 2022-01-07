using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.AuditRecords
{
    public class AuditRecordsByUser
    {
        public string userId { get; set; }

        public List<string> airlines { get; set; }

        public List<string> roles { get; set; }

        public List<string> IpAddresses { get; set; }

        public Dictionary<int, AuditRecordEntry> auditRecordEntries { get; set; }

        public AuditRecordsByUser()
        {
            userId = string.Empty;
            airlines = new List<string>();
            roles = new List<string>();
            IpAddresses = new List<string>();
            auditRecordEntries = new Dictionary<int, AuditRecordEntry>();
        }

        public AuditRecordsByUser(string user)
        {
            userId = user;
            airlines = new List<string>();
            roles = new List<string>();
            IpAddresses = new List<string>();
            auditRecordEntries = new Dictionary<int, AuditRecordEntry>();
        }
    }
}
