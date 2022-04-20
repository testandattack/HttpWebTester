using ApiTestGenerator.Models.Enums;
using Automatonic.HttpArchive;

namespace ApiTestGenerator.Models.HttpArchive
{
    public class EntryEx
    {
        #region -- Public Properties ---------------------------------------
        public Entry baseEntry { get; set; }

        public int entryId { get; set; }

        public string parentPageId { get; set; }

        public HttpStatusGroupsEnum ResponseStatusGroup { get; set; }

        public bool DetectedCollisionOnStartedDateTime = false;
        #endregion

        #region -- Constructors --------------------------------------------
        public EntryEx()
        {
            entryId = -1;
        }

        public EntryEx(Entry Entry)
        {
            baseEntry = Entry;
            entryId = -1;
            parentPageId = string.Empty;
            
        }

        public EntryEx(Entry Entry, int id)
        {
            baseEntry = Entry;
            entryId = id;
            parentPageId = string.Empty;
        }

        public EntryEx(Entry Entry, int id, int Status)
        {
            baseEntry = Entry;
            entryId = id;
            parentPageId = string.Empty;
        }
        #endregion

        #region -- Public Methods ------------------------------------------
        public HttpStatusGroupsEnum GetResponseStatusGroup(int Status)
        {
            switch (Status)
            {
                case 100:
                case 200:
                case 204:
                case 206:
                case 304:
                    return HttpStatusGroupsEnum.HttpStatusGood;

                case 301:
                case 302:
                case 307:
                    return HttpStatusGroupsEnum.HttpStatusRedirect;

                case 401:
                case 403:
                case 407:
                case 511:
                    return HttpStatusGroupsEnum.HttpStatusAuthFailures;

                case 400:
                case 404:
                case 405:
                case 411:
                case 500:
                case 501:
                case 502:
                case 503:
                    return HttpStatusGroupsEnum.HttpStatusServerErrors;

                case 0:
                    return HttpStatusGroupsEnum.HttpStatusZero;

                default:
                    return HttpStatusGroupsEnum.HttpStatusUnknown;
            }
        }
        #endregion
    }
}
