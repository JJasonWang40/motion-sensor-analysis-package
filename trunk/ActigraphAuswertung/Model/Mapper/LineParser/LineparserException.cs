using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActigraphAuswertung.Mapper.LineParser
{
    /// <summary>
    /// Class of any exception that is thrown in the lineparsers.
    /// </summary>
    class LineparserException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The exception message</param>
        public LineparserException(String message)
            : base(message)
        { }
    }
}
