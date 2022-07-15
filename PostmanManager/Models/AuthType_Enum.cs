using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    public enum AuthType_Enum
    {
        apikey,
        awsv4,
        basic,
        bearer,
        digest,
        edgegrid,
        hawk,
        noauth,
        oauth1,
        oauth2,
        ntlm
    }
}
