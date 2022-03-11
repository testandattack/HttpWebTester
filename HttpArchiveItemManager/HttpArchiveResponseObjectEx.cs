using Automatonic.HttpArchive;
using GTC.Utilities;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GTC.Utilities.WebTestProcessing;
using System.Text.RegularExpressions;
using System;
using GTC.Extensions;

namespace GTC_HttpArchiveReader
{
    public class HttpArchiveResponseObjectEx
    {
        #region -- Public Properties ---------------------------------------
        public int entryId { get; set; }
        public Response responseEx { get; set; }

        public string responseText { get; internal set; }
        #endregion

        #region -- Constructors --------------------------------------------
        public HttpArchiveResponseObjectEx()
        {
            responseEx = new Response();
            entryId = -1;
        }

        public HttpArchiveResponseObjectEx(Response response)
        {
            responseEx = response;
            entryId = -1;
            GetResponseText();
        }

        public HttpArchiveResponseObjectEx(Response response, int id)
        {
            responseEx = response;
            entryId = id;
            GetResponseText();
        }
        #endregion

        #region -- Public Methods ------------------------------------------
        public bool HasHeader(string HeaderName)
        {
            foreach(NamedValue kvp in responseEx.Headers)
            {
                if (kvp.Name == HeaderName)
                    return true;
            }
            return false;
        }

        public bool HasHeader(string HeaderName, bool IgnoreCase)
        {
            if (!IgnoreCase)
                return HasHeader(HeaderName);

            foreach (NamedValue kvp in responseEx.Headers)
            {
                if (kvp.Name.ToLower() == HeaderName.ToLower())
                    return true;
            }
            return false;
        }

        public bool HasCookie(string CookieName)
        {
            foreach (Cookie kvp in responseEx.Cookies)
            {
                if (kvp.Name == CookieName)
                    return true;
            }
            return false;
        }

        public bool HasCookie(string CookieName, bool IgnoreCase)
        {
            if (!IgnoreCase)
                return HasCookie(CookieName);

            foreach (Cookie kvp in responseEx.Cookies)
            {
                if (kvp.Name.ToLower() == CookieName.ToLower())
                    return true;
            }
            return false;
        }

        public string GetHeader(string HeaderName)
        {
            foreach (NamedValue kvp in responseEx.Headers)
            {
                if (kvp.Name == HeaderName)
                    return kvp.Value;
            }
            return string.Empty;
        }

        public string GetHeader(string HeaderName, bool IgnoreCase)
        {
            if (!IgnoreCase)
                return GetHeader(HeaderName);

            foreach (NamedValue kvp in responseEx.Headers)
            {
                if (kvp.Name.ToLower() == HeaderName.ToLower())
                    return kvp.Value;
            }
            return string.Empty;
        }

        public string GetCookie(string CookieName)
        {
            foreach (Cookie kvp in responseEx.Cookies)
            {
                if (kvp.Name == CookieName)
                    return kvp.Value;
            }
            return string.Empty;
        }

        public string GetCookie(string CookieName, bool IgnoreCase)
        {
            if (!IgnoreCase)
                return GetCookie(CookieName);

            foreach (Cookie kvp in responseEx.Cookies)
            {
                if (kvp.Name.ToLower() == CookieName.ToLower())
                    return kvp.Value;
            }
            return string.Empty;
        }

        public string GetRedirectUrl()
        {
            if (responseEx.RedirectUrl != null)
                return responseEx.RedirectUrl;
            else
                return string.Empty;
        }

        public string GetResponseBodyStatisticsForTroubleshooting(int textLength)
        {
            
            string sText = (responseEx.Content.Text == null) ? "NULL" : responseEx.Content.Text;
            if (sText == string.Empty)
                sText = "N/A";
            string sMimeType = (responseEx.Content.MimeType == null) ? "NULL" : responseEx.Content.MimeType;
            string sEncoding = (responseEx.Content.Encoding == null) ? "NULL" : responseEx.Content.Encoding;
            return String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}"
                , entryId
                , responseEx.Content.Size
                , responseEx.Content.Compression
                , responseEx.HeadersSize
                , responseEx.BodySize
                , sMimeType
                , sEncoding
                , responseEx.Status
                //, sText.Flattened(textLength));
                , responseText.Flattened(textLength));
        }
        #endregion

        #region -- Private Methods -----------------------------------------
        private void GetExtendedInfo()
        {

            GetResponseText();
        }

        private void GetResponseText()
        {

            if (responseEx.Content == null
                || responseEx.Content.Text == null)
            {
                responseText = String.Empty;
                return;
            }

            if (responseEx.Content.Encoding != null
                && responseEx.Content.Encoding.ToLower() == "base64")
            {
                if (responseEx.Content.MimeType.ToLower().Contains("image"))
                {
                    responseText = "[image file]";
                }
                else
                {
                    byte[] encodedDataAsBytes = System.Convert.FromBase64String(responseEx.Content.Text);
                    responseText = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
                }
            }
            else
                responseText = responseEx.Content.Text;
        }
        #endregion

    }
}
