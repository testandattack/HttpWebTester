using Automatonic.HttpArchive;
using GTC.Extensions;
using System;
//using Utilities;

namespace ApiTestGenerator.Models.HttpArchive
{
    public class ResponseEx
    {
        #region -- Public Properties ---------------------------------------
        public Response baseResponse { get; set; }
        public int entryId { get; set; }

        public string responseText { get; internal set; }
        #endregion

        #region -- Constructors --------------------------------------------
        public ResponseEx()
        {
            baseResponse = new Response();
            entryId = -1;
        }

        public ResponseEx(Response response)
        {
            baseResponse = response;
            entryId = -1;
            GetResponseText();
        }

        public ResponseEx(Response response, int id)
        {
            baseResponse = response;
            entryId = id;
            GetResponseText();
        }
        #endregion

        #region -- Public Methods ------------------------------------------
        public bool HasHeader(string HeaderName)
        {
            foreach(NamedValue kvp in baseResponse.Headers)
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

            foreach (NamedValue kvp in baseResponse.Headers)
            {
                if (kvp.Name.ToLower() == HeaderName.ToLower())
                    return true;
            }
            return false;
        }

        public bool HasCookie(string CookieName)
        {
            foreach (Cookie kvp in baseResponse.Cookies)
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

            foreach (Cookie kvp in baseResponse.Cookies)
            {
                if (kvp.Name.ToLower() == CookieName.ToLower())
                    return true;
            }
            return false;
        }

        public string GetHeader(string HeaderName)
        {
            foreach (NamedValue kvp in baseResponse.Headers)
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

            foreach (NamedValue kvp in baseResponse.Headers)
            {
                if (kvp.Name.ToLower() == HeaderName.ToLower())
                    return kvp.Value;
            }
            return string.Empty;
        }

        public string GetCookie(string CookieName)
        {
            foreach (Cookie kvp in baseResponse.Cookies)
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

            foreach (Cookie kvp in baseResponse.Cookies)
            {
                if (kvp.Name.ToLower() == CookieName.ToLower())
                    return kvp.Value;
            }
            return string.Empty;
        }

        public string GetRedirectUrl()
        {
            if (baseResponse.RedirectUrl != null)
                return baseResponse.RedirectUrl;
            else
                return string.Empty;
        }

        public string GetResponseBodyStatisticsForTroubleshooting(int textLength)
        {
            
            string sText = (baseResponse.Content.Text == null) ? "NULL" : baseResponse.Content.Text;
            if (sText == string.Empty)
                sText = "N/A";
            string sMimeType = (baseResponse.Content.MimeType == null) ? "NULL" : baseResponse.Content.MimeType;
            string sEncoding = (baseResponse.Content.Encoding == null) ? "NULL" : baseResponse.Content.Encoding;
            return String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}"
                , entryId
                , baseResponse.Content.Size
                , baseResponse.Content.Compression
                , baseResponse.HeadersSize
                , baseResponse.BodySize
                , sMimeType
                , sEncoding
                , baseResponse.Status
                //, sText.Flattened(textLength));
                , responseText.Flattened(textLength));
        }

        public void ClearResponseText()
        {
            baseResponse.Content.Text = null;
        }
        #endregion

        #region -- Private Methods -----------------------------------------
        private void GetExtendedInfo()
        {

            GetResponseText();
        }

        private void GetResponseText()
        {

            if (baseResponse.Content == null
                || baseResponse.Content.Text == null)
            {
                responseText = String.Empty;
                return;
            }

            if (baseResponse.Content.Encoding != null
                && baseResponse.Content.Encoding.ToLower() == "base64")
            {
                if (baseResponse.Content.MimeType.ToLower().Contains("image"))
                {
                    responseText = "[image file]";
                }
                else
                {
                    byte[] encodedDataAsBytes = System.Convert.FromBase64String(baseResponse.Content.Text);
                    responseText = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
                }
            }
            else
                responseText = baseResponse.Content.Text;
        }
        #endregion

    }
}
