using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using GTC.Extensions;

namespace HttpWebTestingEditor
{
    public static class BitmapConversion
    {
        /// <summary>
        /// This converts a normal bitmap to a BitmapSource object that can be used by WPF controls.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static BitmapSource ToWpfBitmap(this Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);

                stream.Position = 0;
                BitmapImage result = new BitmapImage();
                result.BeginInit();
                // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                // Force the bitmap to load right now so we can dispose the stream.
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }
    }

    /// <summary>
    /// This extension is used to force an update of the status bar messages in real time so that the messages for DB actions are reported as they occur.
    /// </summary>
    public static class ExtensionMethods
    {
        private static Action EmptyDelegate = delegate () { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Send, EmptyDelegate);
        }

        //    //Example of using the delegate:
        //    tsslMessage.Content = sUpdated;
        //    tsslMessage.Refresh();
    }

    public static class DictionaryExtensionMethods
    {
        public static string GetKey(this Dictionary<string, IEnumerable<string>> source, int iIndex)
        {
            int x = 0;
            if (source.Count <= iIndex)
                return string.Empty;

            foreach(var item in source)
            {
                if (iIndex == x)
                    return item.Key;
                x++;
            }
            return string.Empty;
        }

        public static string GetValue(this Dictionary<string, IEnumerable<string>> source, int iIndex)
        {
            int x = 0;
            if (source.Count <= iIndex)
                return string.Empty;

            foreach (var item in source)
            {
                if (iIndex == x)
                    return item.Value.ToString(";");
                x++;
            }
            return string.Empty;
        }

        public static string GetKey(this Dictionary<string, string> source, int iIndex)
        {
            int x = 0;
            if (source.Count <= iIndex)
                return string.Empty;

            foreach (var item in source)
            {
                if (iIndex == x)
                    return item.Key;
                x++;
            }
            return string.Empty;
        }

        public static string GetValue(this Dictionary<string, string> source, int iIndex)
        {
            int x = 0;
            if (source.Count <= iIndex)
                return string.Empty;

            foreach (var item in source)
            {
                if (iIndex == x)
                    return item.Value;
                x++;
            }
            return string.Empty;
        }
    }

    public static class StringExtensions
    {
        public static string ExcludePath(this string source)
        {
            int iStart = source.LastIndexOf("\\");

            if (iStart == -1 || iStart + 1 >= source.Length)
                return source;
            else
                return source.Substring(iStart + 1);
        }
    }


}
