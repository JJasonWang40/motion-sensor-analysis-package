using System.Collections.Generic;
using ActigraphAuswertung.Model;
using System.IO;
using System.Linq;
using System;
using ActigraphAuswertung.Model.Calculators;

namespace ActigraphAuswertung.RExport
{
    /// <summary>
    /// Exports the activity for every day.
    /// </summary>
    class ExportDaily : Abstract
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
                throw new RExportException("For daily graphs exactly one dataset must be selected");
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
            addition += "source('" + this.RSettings.FilePrefix + "Auswertung_Taeglich.R') \r\n";

            return addition;
        }

        /// <summary>
        /// Copys additional involved files and launches the process.
        /// </summary>
        protected override void launchProcess()
        {
            File.Copy(this.RSettings.PathToApplication + "RScripts\\Auswertung_Taeglich.R",
                      this.RSettings.PathToTmp + this.RSettings.FilePrefix + "Auswertung_Taeglich.R"
                      );
            this.filesInvolved.Add(this.RSettings.FilePrefix + "Auswertung_Taeglich.R");

            base.launchProcess();
        }
    }
}
