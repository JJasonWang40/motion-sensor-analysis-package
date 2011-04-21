using System;
using System.IO;
using System.Linq;
using ActigraphAuswertung.Model;
using ActigraphAuswertung.Model.Calculators;

namespace ActigraphAuswertung.RExport
{
    /// <summary>
    /// Export to step graph.
    /// </summary>
    class ExportSteps : Abstract
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
                throw new RExportException("For steps graphs exactly one dataset must be selected");
            }
        }

        /// <summary>
        /// Adds additional R Script information and scripts to the start script.
        /// </summary>
        /// <returns>Additional start script content</returns>
        protected override string prepareLaunchScript()
        {
            String addition = base.prepareLaunchScript();
            CsvModel model = this.Datasets.First().Key;
            ActivityLevelsCalculator calc = model.ActivityLevelCalculator;

            addition += "anzahlTage = " + (model.Last().Date.DayOfYear - model.First().Date.DayOfYear) + "\r\n";
            addition += "source('" + this.RSettings.FilePrefix + "Auswertung_Schrittdaten.R') \r\n";

            return addition;
        }

        /// <summary>
        /// Copys additional involved files and launches the process.
        /// </summary>
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
