using System.Collections.Generic;
using ActigraphAuswertung.Model;
using System.IO;
using System.Linq;
using System;

namespace ActigraphAuswertung.RExport
{
    class ExportScatter : Abstract
    {
        public ExportScatter()
        {
            this.Parameters.Add("numberOfDatasets", new KeyValuePair<string, object>("# of datasets", 1000));
        }

        public override void checkConditions()
        {
            base.checkConditions();

            if (this.Datasets.Count != 2)
            {
                throw new Exception("Scatter graphs needs exact two datasets to be selected.");
            }

            if (this.Datasets.First().Key.Count != this.Datasets.Last().Key.Count)
            {
                throw new Exception("Scatter graphs requires both datasets to have the same # of entries.");
            }

            try
            {
                int parse = int.Parse((string) this.Parameters["numberOfDatasets"].Value);
            }
            catch(Exception ex)
            {
                throw new Exception("Scatter graph parameter '# of datasets' is invalid: " + ex.ToString());
            }
        }

        protected override string prepareLaunchScript()
        {
            String addition = base.prepareLaunchScript();
            CsvModel model = this.Datasets.First().Key;
            ActivityLevelsCalculator calc = model.ActivityLevelCalculator;

            addition += "numberOfDatasets = " + this.Parameters["numberOfDatasets"].Value + "\r\n";
            addition += "source('" + this.RSettings.FilePrefix + "Auswertung_Scatter.R') \r\n";

            return addition;
        }

        protected override void launchProcess()
        {
            File.Copy(this.RSettings.PathToApplication + "RScripts\\Auswertung_Scatter.R",
                      this.RSettings.PathToTmp + this.RSettings.FilePrefix + "Auswertung_Scatter.R"
                      );
            this.filesInvolved.Add(this.RSettings.FilePrefix + "Auswertung_Scatter.R");

            base.launchProcess();
        }
    }
}
