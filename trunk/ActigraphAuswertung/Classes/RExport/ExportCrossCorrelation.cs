using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActigraphAuswertung.Model;
using System.IO;

namespace ActigraphAuswertung.RExport
{
    class ExportCrossCorrelation : Abstract
    {
        public override void checkConditions()
        {
            base.checkConditions();

            if (this.Datasets.Count != 2)
            {
                throw new Exception("Cross correlation needs exact two datasets to be selected.");
            }

            if (this.Datasets.First().Key.Count != this.Datasets.Last().Key.Count)
            {
                throw new Exception("Cross correlation requires both datasets to have the same # of entries.");
            }
        }

        protected override string prepareLaunchScript()
        {
            
            String addition = base.prepareLaunchScript();
            addition += "numberOfDatasets=\r\n";
            addition += "source('" + this.RSettings.FilePrefix + "Auswertung_Kreuzkorrelation.R')\r\n";

            return addition;
        }

        protected override void launchProcess()
        {
            File.Copy(this.RSettings.PathToApplication + "RScripts\\Auswertung_Kreuzkorrelation.R",
                      this.RSettings.PathToTmp + this.RSettings.FilePrefix + "Auswertung_Kreuzkorrelation.R"
                      );
            this.filesInvolved.Add(this.RSettings.FilePrefix + "Auswertung_Kreuzkorrelation.R");
            base.launchProcess();
        }
    }
}
