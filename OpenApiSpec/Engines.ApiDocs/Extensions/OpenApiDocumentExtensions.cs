using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenApiUtilities
{
    /// <summary>
    /// A set of extension methods to work on the Microsoft.OpenApi.Models.OpenApiDocument class
    /// </summary>
    public static class OpenApiDocumentExtensions
    {
        //public static string GetApiRootFromServers(this OpenApiDocument source)
        //{
        //    List<string> root = new List<string>();

        //    // Routine based on comments from: https://github.com/microsoft/OpenAPI.NET/issues/450
        //    foreach (var server in source.Servers)
        //    {
        //        // find the end of 
        //        int x = server.Url.IndexOf("//");
        //        if (x == -1)
        //            throw new InvalidOperationException("Server URL did not contain valid http precursor");

        //        // Find the start of the string after the host
        //        int start = server.Url.IndexOf("/", x + 2);
        //        if (start == -1)
        //            root.Add("/");
        //        else
        //            root.Add($"{server.Url.Substring(start)}");
        //    }

        //    var qty = root.Distinct().ToList().Count;
        //    if (qty == 1)
        //        return root[0];
        //    else
        //        return string.Empty;
        //}

    }
}
