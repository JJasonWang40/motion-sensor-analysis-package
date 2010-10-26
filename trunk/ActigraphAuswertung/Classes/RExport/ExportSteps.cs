using System.Collections.Generic;
using ActigraphAuswertung.Model;
using System.IO;
using System.Linq;
using System;

namespace ActigraphAuswertung.RExport
{
    class ExportSteps : Abstract
    {
        public override void checkConditions()
        {
            base.checkConditions();

            if (this.Datasets.Count != 1)
            {
                throw new Exception("For steps graphs exactly one dataset must be selected");
            }
        }

        protected override string prepareLaunchScript()
        {
            String addition = base.prepareLaunchScript();
            CsvModel model = this.Datasets.First().Key;
            ActivityLevelsCalculator calc = model.ActivityLevelCalculator;

            addition += "anzahlTage = " + (model.Last().Date.DayOfYear - model.First().Date.DayOfYear) + "\r\n";
            addition += "source('" + this.RSettings.FilePrefix + "Auswertung_Schrittdaten.R') \r\n";

            return addition;
        }

        protected override void launchProcess()
        {
            File.Copy(this.RSettings.PathToApplication + "RScripts\\Auswertung_Schrittdaten.R",
                      this.RSettings.PathToTmp + this.RSettings.FilePrefix + "Auswertung_Schrittdaten.R"
                      );
            this.filesInvolved.Add(this.RSettings.FilePrefix + "Auswertung_Schrittdaten.R");

            base.launchProcess();
        }
    }
}
