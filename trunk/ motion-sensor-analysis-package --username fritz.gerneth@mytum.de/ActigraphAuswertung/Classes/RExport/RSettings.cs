using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.RExport
{
    public class RSettings
    {
        public String PathToR;

        public String PathToTmp;

        public String PathToOutput;

        public String PathToApplication;

        public int OutputWidth;

        public int OutputHeight;

        public String FilePrefix;
 
        public Boolean CopyInvoledFiles;

        public Boolean CopyROutput;
    }
}
