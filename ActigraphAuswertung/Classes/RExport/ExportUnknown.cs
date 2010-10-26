using System;
using System.Collections.Generic;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.RExport
{
    class ExportUnknown : Abstract
    {
        public override void checkConditions()
        {
            throw new Exception("Please select an export script");
        }
    }
}
