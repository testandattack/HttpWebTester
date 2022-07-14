using System;
using System.Collections.Generic;
using System.Text;

namespace SharedResources
{
    public static class StringExtensions
    {
        /// <summary>
        /// Builds a new string with each of the values to find
        /// replaced by the <paramref name="replaceWith"/> value.
        /// </summary>
        /// <param name="source">The <c>string</c> to which this method is exposed.</param>
        /// <param name="value1ToFind">The first string that should be replaced.</param>
        /// <param name="value2ToFind">The second string that should be replaced.</param>
        /// <param name="replaceWith">the value to use for all replacement.</param>
        /// <returns></returns>
        public static string Replace(this string source, string value1ToFind, string value2ToFind, string replaceWith)
        {
            return source.Replace(new string[] { value1ToFind, value2ToFind }, replaceWith);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">The <c>string</c> to which this method is exposed.</param>
        /// <param name="value1ToFind">The first string that should be replaced.</param>
        /// <param name="value2ToFind">The second string that should be replaced.</param>
        /// <param name="value3ToFind">The third string that should be replaced.</param>
        /// <param name="replaceWith">the value to use for all replacement.</param>
        /// <returns></returns>
        public static string Replace(this string source, string value1ToFind, string value2ToFind, string value3ToFind, string replaceWith)
        {
            return source.Replace(new string[] { value1ToFind, value2ToFind, value3ToFind }, replaceWith);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">The <c>string</c> to which this method is exposed.</param>
        /// <param name="value1ToFind">The first string that should be replaced.</param>
        /// <param name="value2ToFind">The second string that should be replaced.</param>
        /// <param name="value3ToFind">The third string that should be replaced.</param>
        /// <param name="value4ToFind">The fourth string that should be replaced.</param>
        /// <param name="replaceWith">the value to use for all replacement.</param>
        /// <returns></returns>
        public static string Replace(this string source, string value1ToFind, string value2ToFind, string value3ToFind, string value4ToFind, string replaceWith)
        {
            return source.Replace(new string[] { value1ToFind, value2ToFind, value3ToFind, value4ToFind }, replaceWith);
        }

        /// <summary>
        /// Builds a new string with each of the <paramref name="valuesToFind"/> values
        /// replaced by the <paramref name="replaceWith"/> value.
        /// </summary>
        /// <param name="source">The <c>string</c> to which this method is exposed.</param>
        /// <param name="valuesToFind">an array of strings that should all be replaced.</param>
        /// <param name="replaceWith">the value to use for all replacement.</param>
        /// <returns></returns>
        public static string Replace(this string source, string[] valuesToFind, string replaceWith)
        {
            StringBuilder sb = new StringBuilder(source);

            foreach(string str in valuesToFind)
            {
                if(str.Length > 0)
                {
                    sb.Replace(str, replaceWith);
                }
            }

            return sb.ToString();
        }
    }
}
