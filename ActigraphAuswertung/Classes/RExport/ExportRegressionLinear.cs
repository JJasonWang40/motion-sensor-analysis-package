using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActigraphAuswertung.Model;
using System.IO;

namespace ActigraphAuswertung.RExport
{
    class ExportRegressionLinear : Abstract
    {
        public override void checkConditions()
        {
            base.checkConditions();

            if (this.Datasets.Count != 2)
            {
                throw new Exception("Linear regression needs exact two datasets to be selected.");
            }

            if (this.Datasets.First().Key.Count != this.Datasets.Last().Key.Count)
            {
                throw new Exception("Linear regression requires both datasets to have the same # of entries.");
            }
        }

        protected override string prepareLaunchScript()
        {
            String addition = "source('" + this.RSettings.FilePrefix + "Auswertung_Regression_Linear.R')\r\n";

            return addition;
        }

        protected override void launchProcess()
        {
            File.Copy(this.RSettings.PathToApplication + "RScripts\\Auswertung_Regression_Linear.R",
                      this.RSettings.PathToTmp + this.RSettings.FilePrefix + "Auswertung_Kreuzkorrelation.R"
                      );
            this.filesInvolved.Add(this.RSettings.FilePrefix + "Auswertung_Regression_Linear.R");
            base.launchProcess();
        }
    }
}
