using System.Collections.Generic;
using ActigraphAuswertung.Model;
using System.IO;
using System.Linq;
using System;

namespace ActigraphAuswertung.RExport
{
    class ExportWorn : Abstract
    {
        public override void checkConditions()
        {
            base.checkConditions();

            if (this.Datasets.Count != 1)
            {
                throw new Exception("For worn graphs exactly one dataset must be selected");
            }
        }

        protected override string prepareLaunchScript()
        {
            String addition = "";
            CsvModel model = this.Datasets.First().Key;
            ActivityLevelsCalculator calc = model.ActivityLevelCalculator;

            addition += "anzahlTage = " + (model.Last().Date.DayOfYear - model.First().Date.DayOfYear) + "\r\n";
            addition += "source('" + this.RSettings.FilePrefix + "Filter_NotWorn.R') \r\n";
            addition += "source('" + this.RSettings.FilePrefix + "Auswertung_Getragen.R') \r\n";

            return addition;
        }

        protected override void launchProcess()
        {
            File.Copy(this.RSettings.PathToApplication + "RScripts\\Filter_NotWorn.R",
                      this.RSettings.PathToTmp + this.RSettings.FilePrefix + "Filter_NotWorn.R"
                      );
            this.filesInvolved.Add(this.RSettings.FilePrefix + "Filter_NotWorn.R");

            File.Copy(this.RSettings.PathToApplication + "RScripts\\Auswertung_Getragen.R",
                      this.RSettings.PathToTmp + this.RSettings.FilePrefix + "Auswertung_Getragen.R"
                      );
            this.filesInvolved.Add(this.RSettings.FilePrefix + "Auswertung_Getragen.R");

            base.launchProcess();
        }
    }
}
