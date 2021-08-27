using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

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
}
