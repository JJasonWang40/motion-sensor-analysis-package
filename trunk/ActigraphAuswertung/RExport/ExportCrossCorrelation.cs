using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ActigraphAuswertung.RExport
{
    /// <summary>
    /// Export class for cross correlation.
    /// </summary>
    class ExportCrossCorrelation : Abstract
    {
        /// <summary>
        /// Constructor. Adds the additional parameter "numberOfDatasets".
        /// </summary>
        public ExportCrossCorrelation()
        {
            this.Parameters.Add("numberOfDatasets", new KeyValuePair<string, object>("# of datasets", 1000));
        }
        /// <summary>
        /// Additionally to the basic checks it checks for exactly two datasets to be 
        /// selected with both having the same size and if the additional parameter 
        /// "numberOfDatasets" contains a valid value.
        /// </summary>
        /// <exception cref="RExportException">If one condition fails.</exception>
        public override void checkConditions()
        {
            base.checkConditions();

            if (this.Datasets.Count != 2)
            {
                throw new RExportException("Cross correlation needs exact two datasets to be selected.");
            }

            if (this.Datasets.First().Key.Count != this.Datasets.Last().Key.Count)
            {
                throw new RExportException("Cross correlation requires both datasets to have the same # of entries.");
            }

            try
            {
                int parse = int.Parse((string)this.Parameters["numberOfDatasets"].Value);
            }
            catch (Exception ex)
            {
                throw new RExportException("Scatter graph parameter '# of datasets' is invalid: " + ex.ToString());
            }
        }

        /// <summary>
        /// Adds additional R Script information and scripts to the start script.
        /// </summary>
        /// <returns>Additional start script content</returns>
        protected override string prepareLaunchScript()
        {
            String addition = base.prepareLaunchScript();
            addition += "numberOfDatasets=" + this.Parameters["numberOfDatasets"].Value + "\r\n";
            addition += "source('" + this.RSettings.FilePrefix + "Auswertung_Kreuzkorrelation.R')\r\n";

            return addition;
        }

        /// <summary>
        /// Copys additional involved files and launches the process.
        /// </summary>
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
