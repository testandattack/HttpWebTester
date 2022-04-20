using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApiTestGenerator.Models.AuditRecords
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// The following SQL queries, when run together in SSMS will
    /// pull the data necessary to populate this object.
    /// <code>
    ///     DECLARE @StartTime Date = GETDATE() - 7
    /// 
    /// SELECT AccessTime, UserId, UserIPAddress, APICall FROM AuditRecord
    /// WHERE ClassificationId != 2 AND UserId != '11111111-1111-1111-11111111' 
    /// AND AccessTime > @StartTime
    /// ORDER BY AccessTime DESC
    /// 
    /// 
    /// SELECT u.IdentityId, r.Name FROM[User] AS u
    /// INNER JOIN UserRole AS ur ON u.Id = ur.UserId
    /// INNER JOIN Role AS r ON ur.RoleId = r.Id
    /// WHERE u.IdentityId IN (
    ///     SELECT DISTINCT UserId FROM AuditRecord
    /// 
    ///     WHERE ClassificationId != 2 AND UserId != '11111111-1111-1111-11111111' 
    /// 
    ///     AND AccessTime > @StartTime
    /// )
    /// 
    /// SELECT u.IdentityId, a.ICAOCode FROM [User] AS u
    /// INNER JOIN UserAirline AS ua ON u.Id = ua.UserId
    /// INNER JOIN Airline AS a ON ua.AirlineId = a.Id
    /// WHERE u.IdentityId IN (
    ///     SELECT DISTINCT UserId FROM AuditRecord
    /// 
    ///     WHERE ClassificationId != 2 AND UserId != '11111111-1111-1111-11111111' 
    /// 
    ///     AND AccessTime > @StartTime
    /// </code>
    /// </remarks>
    public class AuditLog
    {
        #region -- Properties -----
        [JsonIgnore]
        public Dictionary<int, AuditRecordEntry> auditRecordEntries { get; set; }

        [JsonIgnore]
        public Dictionary<string, List<string>> UserAirlines { get; set; }

        [JsonIgnore]
        public Dictionary<string, List<string>> UserRoles { get; set; }

        public Dictionary<string, AuditRecordsByUser> entriesByUser { get; set; }
        #endregion

        #region -- Constructors -----
        public AuditLog()
        {
            auditRecordEntries = new Dictionary<int, AuditRecordEntry>();
            UserAirlines = new Dictionary<string, List<string>>();
            UserRoles = new Dictionary<string, List<string>>();
            entriesByUser = new Dictionary<string, AuditRecordsByUser>();
        }
        #endregion

        #region -- Read and Write methods -----
        public AuditLog LoadAuditLogFromFile(string fileName)
        {
            AuditLog auditLog = null;
            using (StreamReader sr = new StreamReader(fileName))
            {
                auditLog = JsonConvert.DeserializeObject<AuditLog>(sr.ReadToEnd());
            }
            if (auditLog == null)
            {
                Log.ForContext<AuditLog>().Error("LoadAuditLogFromFile failed to load the set from {fileName}", fileName);
                throw new NullReferenceException($"LoadAuditLogFromFile failed to load the set from {fileName}");
            }
            return auditLog;
        }

        public void SerializeAndSaveAuditLog(string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
                }
                Log.ForContext<AuditLog>().Information("SerializeAndSaveAuditLog completed successfully");
            }
            catch (Exception ex)
            {
                Log.ForContext<AuditLog>().Error(ex, "[EXCEPTION] {callingMethod} failed.", "SerializeAndSaveAuditLog");
            }
        }
        #endregion
    }
}
