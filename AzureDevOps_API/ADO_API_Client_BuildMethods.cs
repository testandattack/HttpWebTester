using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AzureDevOps_API
{
    public partial class ADO_API_Client
    {

        // 0 = site.SiteOrg
        // 1 = site.Project
        private const string URI_GetBuilds_5_0 = "https://dev.azure.com/{0}/{1}/_apis/build/builds?api-version=5.0";
    }
}
