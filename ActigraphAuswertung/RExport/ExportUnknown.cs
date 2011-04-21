using System;

namespace ActigraphAuswertung.RExport
{
    /// <summary>
    /// Error export class.
    /// </summary>
    class ExportUnknown : Abstract
    {
        /// <summary>
        /// Will always throw an exception.
        /// </summary>
        /// <exception cref="RExportException">No script was selected.</exception>
        public override void checkConditions()
        {
            throw new RExportException("Please select an export script");
        }
    }
}
