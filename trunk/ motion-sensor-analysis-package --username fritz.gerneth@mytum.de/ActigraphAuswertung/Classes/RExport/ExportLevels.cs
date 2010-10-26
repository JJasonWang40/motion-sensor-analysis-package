using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActigraphAuswertung.Model;
using System.IO;

namespace ActigraphAuswertung.RExport
{
    class ExportLevels : Abstract
    {
        public override void checkConditions()
        {
            base.checkConditions();

            if (this.Datasets.Count != 1)
            {
                throw new Exception("For level graphs exactly one dataset must be selected");
            }
        }

        protected override string prepareLaunchScript()
        {
            String addition = "";
            CsvModel model = this.Datasets.First().Key;
            ActivityLevelsCalculator calc = model.ActivityLevelCalculator;

            addition += "anzahlTage = " + (model.Last().Date.DayOfYear - model.First().Date.DayOfYear) + "\r\n";
            addition += "sed = " + calc.MinLight + "\r\n";
            addition += "lgt = " + calc.MinModerate + "\r\n";
            addition += "mod = " + calc.MinHeavy + "\r\n";
            addition += "hvy = " + calc.MinVeryheavy + "\r\n";

            addition += "source('" + this.RSettings.FilePrefix + "Auswertung_Levels.R') \r\n";

            return addition;
        }

        protected override void launchProcess()
        {
            File.Copy(this.RSettings.PathToApplication + "RScripts\\Auswertung_Levels.R",
                      this.RSettings.PathToTmp + this.RSettings.FilePrefix + "Auswertung_Levels.R"
                      );
            this.filesInvolved.Add(this.RSettings.FilePrefix + "Auswertung_Levels.R");
            base.launchProcess();
        }
    }
}
