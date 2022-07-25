using System.Text.RegularExpressions;

namespace OasToApiSet.Extensions
{
    public static class JsonStringExtensions
    {
        public static string ToJsonCompact(this string source)
        {
            // First see if we are using full CR-LF or just LF
            if (source.Contains("\r\n"))
            {
                source = source.Replace("\r\n", "");
            }
            else
            {
                source = source.Replace("\n", "");
            }
            return Regex.Replace(source, @"\s+", " ");
        }
    }
}
