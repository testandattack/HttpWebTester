using System.Collections.Generic;

namespace ApiTestGenerator.Models.ApiAnalyzer
{
    public class EndpointRestrictionSummary
    {
        /*
                NO_RESTRICTION = 0,
                ADMIN = 1,
                AIRLINE_ADMIN = 2,
                AIRLINE_USER = 3,
                ENGINEER = 4,
                USER_MANAGER = 5,
                TESTER = 6,
                ACMF_USER = 7,
                EXPORTER = 8,
                PWC_USER = 9,
                ACMF_ANALYTICS_AUTHORIZED = 10,
                ANALYTIC_ADMIN = 11,
                ISSUE_INVESTIGATOR = 12,
                DOCUMENT_MANAGER = 13

         */
        #region -- Properties -----
        public List<string> NO_RESTRICTION_OK_Endpoints { get; set; }
        public List<string> ADMIN_OK_Endpoints { get; set; }
        public List<string> AIRLINE_ADMIN_OK_Endpoints { get; set; }
        public List<string> AIRLINE_USER_OK_Endpoints { get; set; }
        public List<string> ENGINEER_OK_Endpoints { get; set; }
        public List<string> USER_MANAGER_OK_Endpoints { get; set; }
        public List<string> TESTER_OK_Endpoints { get; set; }
        public List<string> ACMF_USER_OK_Endpoints { get; set; }
        public List<string> EXPORTER_OK_Endpoints { get; set; }
        public List<string> PWC_USER_OK_Endpoints { get; set; }
        public List<string> ACMF_ANALYTICS_AUTHORIZED_OK_Endpoints { get; set; }
        public List<string> ANALYTIC_ADMIN_OK_Endpoints { get; set; }
        public List<string> ISSUE_INVESTIGATOR_OK_Endpoints { get; set; }
        public List<string> DOCUMENT_MANAGER_OK_Endpoints { get; set; }
        
        public List<string> UnknownType { get; set; }
        public List<string> Only_AIRLINE_USER { get; set; }
        public List<string> NO_RESTRICTION_AndOthers { get; set; }
        #endregion

        #region -- Constructors -----
        public EndpointRestrictionSummary()
        {
            NO_RESTRICTION_OK_Endpoints = new List<string>();
            ADMIN_OK_Endpoints = new List<string>();
            AIRLINE_ADMIN_OK_Endpoints = new List<string>();
            AIRLINE_USER_OK_Endpoints = new List<string>();
            ENGINEER_OK_Endpoints = new List<string>();
            USER_MANAGER_OK_Endpoints = new List<string>();
            TESTER_OK_Endpoints = new List<string>();
            ACMF_USER_OK_Endpoints = new List<string>();
            EXPORTER_OK_Endpoints = new List<string>();
            PWC_USER_OK_Endpoints = new List<string>();
            ACMF_ANALYTICS_AUTHORIZED_OK_Endpoints = new List<string>();
            ANALYTIC_ADMIN_OK_Endpoints = new List<string>();
            ISSUE_INVESTIGATOR_OK_Endpoints = new List<string>();
            DOCUMENT_MANAGER_OK_Endpoints = new List<string>();
            UnknownType = new List<string>();
            Only_AIRLINE_USER = new List<string>();
            NO_RESTRICTION_AndOthers = new List<string>();
        }
        #endregion
    }
}
