using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace AzureDevOps_API
{
    public class AdoSettings
    {
        public Dictionary<string, DevOpsSite> DevOpsSites { get; set; }

        public AdoSettings()
        {
            DevOpsSites = new Dictionary<string, DevOpsSite>();
        }
    }

    public class DevOpsSite
    {
        public string SiteOrg { get; set; }
        public string SitePAT { get; set; }
        public List<string> Projects { get; set; }

        public string Project
        {
            get
            {
                return Projects[ActiveProject];
            }
        }

        public int ActiveProject { get; set; }

        public DevOpsSite()
        {
            Projects = new List<string>();
            ActiveProject = 0;
        }
    }
}
