using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActigraphAuswertung.RExport
{
    class RExportException : Exception
    {
        public RExportException(String message)
            : base(message)
        { }
    }
}
