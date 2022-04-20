using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.Enums
{
    public enum HttpStatusGroupsEnum
    {
        HttpStatusAuthFailures = 1,  // 401, 403, 407, 511
        HttpStatusClientErrors = 2,  // 400, 404, 405, 411
        HttpStatusServerErrors = 3,  // 500, 501, 502, 503
        HttpStatusRedirect = 4,      // 301, 302, 307
        HttpStatusGood = 5,          // 100, 200, 204, 206, 304
        HttpStatusZero = 6,          // 0
        HttpStatusUnknown
    }
}
