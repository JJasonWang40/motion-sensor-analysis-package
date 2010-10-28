using System.Collections.Generic;
using ActigraphAuswertung.Model;
using System.IO;
using System.Linq;
using System;
using ActigraphAuswertung.Model.Calculators;

namespace ActigraphAuswertung.RExport
{
    /// <summary>
    /// Export to worn graph.
    /// </summary>
    class ExportWorn : Abstract
    {
        /// <summary>
        /// Additionally to the basic checks exactly one dataset must be selected.
        /// </summary>
        /// <exception cref="RExportException">If not exactly one dataset is selected.</exception>
        public override void checkConditions()
        {
            base.checkConditions();

            if (this.Datasets.Count != 1)
            {
                throw new RExportException("For worn graphs exactly one dataset must be selected");
            }
        }

        /// <summary>
        /// Adds additional R Script information and scripts to the start script.
        /// </summary>
        /// <returns>Additional start script content</returns>
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

        /// <summary>
        /// Copys additional involved files and launches the process.
        /// </summary>
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
