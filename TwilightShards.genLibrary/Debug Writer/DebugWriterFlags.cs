namespace TwilightShards.genLibrary
{
    using System;
    using System.Collections.Generic;
        
    /// <summary>
    /// This enum contains the flags used to tell the writer what level of output we are using.
    /// </summary>
    [Flags]
    public enum DebugWriterFlags
    {
        /// <summary>
        /// No level of output
        /// </summary>
        E_NONE = 0,
        
        /// <summary>
        /// Allow "INFO" messages
        /// </summary>
        E_INFO = 1 << 0,

        /// <summary>
        /// Allow "WARN" messages
        /// </summary>
        E_WARN = 1 << 1,

        /// <summary>
        /// Allow "DEBUG" message
        /// </summary>
        E_DEBUG = 1 << 2,

        /// <summary>
        /// Allow "ERROR" message
        /// </summary>
        E_ERROR = 1 << 3,

        /// <summary>
        /// Output everything.
        /// </summary>
        E_ALL = ~0
    }
}