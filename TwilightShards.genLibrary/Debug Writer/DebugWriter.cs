namespace TwilightShards.genLibrary
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// This class provides debug writing logic.
    /// </summary>
    public class DebugWriter
    {
        /// <summary>
        /// This is the file path of the debug log file
        /// </summary>
        protected string filePath { get; set; }

        /// <summary>
        /// The level of debug notices the program is using
        /// </summary>
        protected DebugWriterFlags verbosity { get; set; }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="filePath">The file we are writing to</param>
        /// <param name="verb">The level of output</param>
        public DebugWriter(string filePath, DebugWriterFlags verb)
        {
            this.filePath = filePath;
            this.verbosity = verb;
        }

        /// <summary>
        /// This updates the debug flags.
        /// </summary>
        /// <param name="d">Our new flags.</param>
        public void updateDebugFlags(DebugWriterFlags d)
        {
            this.verbosity = d;
        }

        /// <summary>
        /// This function checks if we can write "INFO" level messages to the log
        /// </summary>
        /// <param name="message">The message to be written</param>
        public bool writeLogInfo(string message)
        {
            using (StreamWriter logWrite = File.AppendText(@filePath))
            {
                if ((DebugWriterFlags.E_INFO & this.verbosity) == DebugWriterFlags.E_INFO)
                {
                    logWrite.WriteLine("INFO: " + message);
                    return true;
                }

                else return false;
            }
        }

        /// <summary>
        /// This function checks if we can write "WARN" level messages to the log
        /// </summary>
        /// <param name="message">The message to be written</param>
        public bool writeLogWarn(string message)
        {
            using (StreamWriter logWrite = File.AppendText(@filePath))
            {
                if ((DebugWriterFlags.E_WARN & this.verbosity) == DebugWriterFlags.E_WARN)
                {
                    logWrite.WriteLine("WARN: " + message);
                    return true;
                }

                else return false;
            }
        }

        /// <summary>
        /// This function checks if we can write "ERROR" level messages to the log
        /// </summary>
        /// <param name="message">The message to be written</param>
        public bool writeLogError(string message)
        {
            using (StreamWriter logWrite = File.AppendText(@filePath))
            {
                if ((DebugWriterFlags.E_ERROR & this.verbosity) == DebugWriterFlags.E_ERROR)
                {
                    logWrite.WriteLine("ERROR: " + message);
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// This function checks if we can write "DEBUG" level messages to the log
        /// </summary>
        /// <param name="message">The message to be written</param>
        public bool writeLogDebug(string message)
        {
            using (StreamWriter logWrite = File.AppendText(@filePath))
            {

               if ((DebugWriterFlags.E_DEBUG & this.verbosity) == DebugWriterFlags.E_DEBUG)
                {
                    logWrite.WriteLine("DEBUG: " + message);
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Simple check to see if we are debugging.
        /// </summary>
        /// <returns>the state of the debug flag</returns>
        public bool checkDebug()
        {
            if ((DebugWriterFlags.E_DEBUG & this.verbosity) == DebugWriterFlags.E_DEBUG)
                return true;

            else return false;
        }
    }
}
