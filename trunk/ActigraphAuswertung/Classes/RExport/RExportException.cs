using System;

namespace ActigraphAuswertung.RExport
{
    /// <summary>
    /// Exception class for R export exceptions.
    /// </summary>
    class RExportException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public RExportException(String message)
            : base(message)
        { }
    }
}
