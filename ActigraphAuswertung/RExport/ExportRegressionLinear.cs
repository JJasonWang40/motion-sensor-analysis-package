using System;
using System.IO;
using System.Linq;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.RExport
{
    /// <summary>
    /// Exports to linear regression.
    /// </summary>
    class ExportRegressionLinear : Abstract
    {
        /// <summary>
        /// Additionally to the basic checks it checks for exactly two datasets with the 
        /// same ammount of entrys.
        /// </summary>
        /// <exception cref="RExportException">If one condition fails.</exception>
        public override void checkConditions()
        {
            base.checkConditions();

            if (this.Datasets.Count != 2)
            {
                throw new RExportException("Linear regression needs exact two datasets to be selected.");
            }

            if (this.Datasets.First().Key.Count != this.Datasets.Last().Key.Count)
            {
                throw new RExportException("Linear regression requires both datasets to have the same # of entries.");
            }
        }

        /// <summary>
        /// Adds additional R Script information and scripts to the start script.
        /// </summary>
        /// <returns>Additional start script content</returns>
        protected override string prepareLaunchScript()
        {
            CsvModel model = this.Datasets.First().Key;

            String addition = "anzahlTage = " + (model.Last().Date.DayOfYear - model.First().Date.DayOfYear) + "\r\n";
            addition += "source('" + this.RSettings.FilePrefix + "Auswertung_Regression_Linear.R')\r\n";

            return addition;
        }

        /// <summary>
        /// Copys additional involved files and launches the process.
        /// </summary>
        protected override void launchProcess()
        {
            File.Copy(this.RSettings.PathToApplication + "RScripts\\Auswertung_Regression_Linear.R",
                      this.RSettings.PathToTmp + this.RSettings.FilePrefix + "Auswertung_Regression_Linear.R"
                      );
            this.filesInvolved.Add(this.RSettings.FilePrefix + "Auswertung_Regression_Linear.R");
            base.launchProcess();
        }
    }
}
