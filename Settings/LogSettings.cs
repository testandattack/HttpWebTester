using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace GTC.HttpWebTester.Settings
{
    /// <summary>
    /// This mclass encapsulates the settings used by the application's logger.
    /// </summary>
    public class LogSettings
    {
        /// <summary>
        /// The full path and file name that will hold the logs for the parser
        /// </summary>
        public string DefaultLogFileName { get; set; }

        /// <summary>
        /// The minimum <see cref="Serilog.Events.LogEventLevel"/> to
        /// use when creating the parser's log file.
        /// </summary>
        public Serilog.Events.LogEventLevel MinLogEventLevel { get; set; }

        /// <summary>
        /// When "true, the parser's <see cref="DefaultLogFileName"/> file
        /// will be cleared each time the parser starts. When "false", the
        /// log file will be appended.
        /// </summary>
        public bool ClearLogFileOnStartup { get; set; }
    }
}
