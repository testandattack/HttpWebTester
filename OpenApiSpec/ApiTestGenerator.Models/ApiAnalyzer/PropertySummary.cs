using System;
using System.Collections.Generic;

namespace ApiTestGenerator.Models.ApiAnalyzer
{
    public class PropertySummary : IComparable
    {
        #region -- Properties -----
        public string Name { get; set; }
        public string Type { get; set; }
        public string Format { get; set; }
        public string Reference { get; set; }
        public List<string> IsInTheseComponents { get; set; }
        #endregion

        #region -- Constructors -----
        public PropertySummary()
        {
            Name = string.Empty;
            Type = string.Empty;
            Format = string.Empty;
            Reference = string.Empty;

            IsInTheseComponents = new List<string>();
        }

        public PropertySummary(string name, string type, 
            string format, string reference)
        {
            Name = name;
            Type = type;
            Format = format;
            Reference = reference;

            IsInTheseComponents = new List<string>();
        }
        #endregion

        #region -- IComparable overrides ----------------------------------
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != typeof(PropertySummary))
            {
                return false;
            }
            PropertySummary propertySummary = obj as PropertySummary;

            //return base.Equals(obj);
            if (Name.ToUpper() == propertySummary.Name.ToUpper()
                && Type == propertySummary.Type
                && Format == propertySummary.Format
                && Reference == propertySummary.Reference
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int hash = 19;
            hash = hash * 31 + Name.ToUpper().GetHashCode();
            hash = hash * 31 + Type.GetHashCode();
            hash = hash * 31 + Format.GetHashCode();
            hash = hash * 31 + Reference.GetHashCode();
            return hash;
        }

        int IComparable.CompareTo(object obj)
        {
            PropertySummary p1 = (PropertySummary)this;
            PropertySummary p2 = (PropertySummary)obj;
            return string.Compare(p1.Name, p2.Name, true);
        }
        #endregion
    }

    public static class PropertySummaryExtensions
    {
        public static PropertySummary GetMatchingPropertySummary(this SortedDictionary<string, PropertySummary> source, PropertySummary obj)
        {
            foreach(var summary in source.Values)
            {
                if(summary.Equals(obj))
                {
                    return summary;
                }
            }
            return null;
        }
    }
}
