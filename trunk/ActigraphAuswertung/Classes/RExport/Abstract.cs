using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.RExport
{
    /// <summary>
    /// Base class for all export classes. Export classes are implemented in a 
    /// Template-Pattern way.
    /// </summary>
    public abstract class Abstract
    {
        /// <summary>
        /// Dictionary of all involved models and their column to be exported.
        /// </summary>
        public Dictionary<CsvModel, SensorData> Datasets;

        /// <summary>
        /// Settings for the export.
        /// </summary>
        public RSettings RSettings;

        /// <summary>
        /// List of all files that need be copied.
        /// </summary>
        protected List<String> filesInvolved = new List<String>();

        /// <summary>
        /// Opional list of additional parameters an export scripts requires.
        /// </summary>
        public Dictionary<String, KeyValuePair<String, Object>> Parameters = new Dictionary<string,KeyValuePair<string,object>>();

        /// <summary>
        /// R Process output.
        /// </summary>
        private String outputMessage = "";

        /// <summary>
        /// R process error output.
        /// </summary>
        private String errorMessage = "";
        
        /// <summary>
        /// Checks all conditions for the export to be successfull.
        /// This. includes the r-executable, the output folder and the temporary folder.
        /// </summary>
        /// <exception cref="RExportException">If one condition is failed.</exception>
        public virtual void checkConditions()
        {
            // check R
            if (!File.Exists(this.RSettings.PathToR))
            {
                throw new RExportException("R not found");
            }

            // check output folder
            if (!Directory.Exists(this.RSettings.PathToOutput))
            {
                throw new RExportException("Output folder not found");
            }

            // check tmp folder
            if (!Directory.Exists(this.RSettings.PathToTmp))
            {
                throw new RExportException("Temporary folder not found");
            }
        }

        /// <summary>
        /// Only entry-point for the export. Checks all condiditions, writes the 
        /// launch script and the filtered csv-data, starts the r-process, moves
        /// all involved files and finally cleans up.
        /// </summary>
        /// <remarks>May be overwritten for further execution-steps.</remarks>
        /// <exception cref="RExportException">Thrown by any of the internal functions</exception>
        public virtual void execute()
        {
            try
            {
                this.checkConditions();

                this.prepareLaunchScriptInternal();
                this.prepareLaunchScript();
                this.prepareCsvData();

                this.launchProcess();
            }
            finally
            {
                this.cleanUp();
            }
        }

        private void prepareLaunchScriptInternal()
        {
            String script = "# Script created by ActiGraph Auswertung 3 \r\n\r\n";

            // prepare launch script
            script += "# General settings \r\n";
            // escape \ in scripts, escape escape-char too!
            script += "setwd('" + this.RSettings.PathToTmp.Replace("\\", "\\\\") + "') \r\n";
            script += "outputWidth = " + this.RSettings.OutputWidth + "\r\n";
            script += "outputHeight = " + this.RSettings.OutputHeight + "\r\n";
            script += "outputPrefix = \"" + this.RSettings.FilePrefix + "\"\r\n";
            script += "outputFolder = \"" + this.RSettings.PathToOutput.Replace("\\", "\\\\") + "\"\r\n";

            // Add datasets
            script += "\r\n# Import files \r\n";
            int entryIndex = 0;
            foreach (KeyValuePair<CsvModel, SensorData> entry in this.Datasets)
            {
                script += "datensatz" + entryIndex 
                       + " <- read.table('"
                       + this.RSettings.FilePrefix + entry.Key.FileName
                       + "', sep=';', header=FALSE, skip=4) \r\n";
                script += "datensatz" + entryIndex + "Datum"
                       + " <- as.vector(datensatz" + entryIndex + "$V1) \r\n";
                script += "datensatz" + entryIndex + "Uhrzeit"
                       + " <- as.vector(datensatz" + entryIndex + "$V2) \r\n";
                script += "datensatz" + entryIndex + "Daten"
                       + " <- as.vector(datensatz" + entryIndex + "$V3) \r\n";
                script += "datensatz" + entryIndex + "Name = \""
                       + this.RSettings.FilePrefix + entry.Key.FileName + "\"\r\n";

                entryIndex++;
            }

            // give super class chance to add something
            script += "\r\n# Script specific settings\r\n";
            script += this.prepareLaunchScript();

            // write to file
            String file = this.RSettings.FilePrefix 
                        + "RLaunchScript.R";

            File.WriteAllText(this.RSettings.PathToTmp + "\\" + file, script);
            this.filesInvolved.Add(file);
        }

        /// <summary>
        /// Template method to add additional content to the R launchscript.
        /// No need to call the base class when overwriting.
        /// </summary>
        /// <returns>Additional content to be added</returns>
        protected virtual String prepareLaunchScript()
        {
            return "";
        }

        /// <summary>
        /// Prepares all csv files in a general format for the export.
        /// Call base class when overwriting this method!
        /// </summary>
        protected virtual void prepareCsvData()
        { 
            // write csv data to temp folder
            foreach (KeyValuePair<CsvModel, SensorData> csvFile in this.Datasets)
            {
                String file = this.RSettings.FilePrefix
                            + csvFile.Key.FileName;

                using (StreamWriter output = new StreamWriter(this.RSettings.PathToTmp + "\\" + file))
                {
                    output.WriteLine("Filtered file using ActigraphAuswertung V3.0");
                    output.WriteLine("Original file: " + csvFile.Key.FileName);
                    output.WriteLine("");
                    output.WriteLine("Date;Time;" + csvFile.Value.ToString());
                    foreach (RowEntry rowEntry in csvFile.Key)
                    {
                        output.WriteLine(
                              rowEntry.Date.ToString("d", CultureInfo.CreateSpecificCulture("de-DE")) + ";"
                            + rowEntry.Date.ToString("T", CultureInfo.CreateSpecificCulture("de-DE")) + ";"
                            + rowEntry.getValue(csvFile.Value).ToString()
                        );
                    }
                }
                this.filesInvolved.Add(file);
            }
        }

        /// <summary>
        /// Prepares and launches the r process.
        /// Call base class when overwriting!
        /// </summary>
        /// <exception cref="RExportException">If the process reports an error.</exception>
        protected virtual void launchProcess()
        { 
            // create & launch r-process
            string appname = this.RSettings.PathToR;
            string appargs = "-f \"" + this.RSettings.PathToTmp
                           + "\\" + this.RSettings.FilePrefix 
                           + "RLaunchScript.R" + "\"";

            Process R = new Process();
            R.StartInfo.FileName = appname;
            R.StartInfo.Arguments = appargs;
            R.StartInfo.CreateNoWindow = true;
            R.StartInfo.UseShellExecute = false;
            R.StartInfo.ErrorDialog = false;
            R.StartInfo.RedirectStandardOutput = true;
            R.StartInfo.RedirectStandardError = true;
            R.Start();

            // Set async. listeners
            R.BeginErrorReadLine();
            R.BeginOutputReadLine();
            R.OutputDataReceived += this.onOutputData;
            R.ErrorDataReceived += this.onErrorData;

            R.WaitForExit();
            R.Close();


            if (this.RSettings.CopyROutput)
            {
                File.WriteAllText(this.RSettings.PathToTmp + "\\" + this.RSettings.FilePrefix + "ROutput.txt",
                                  this.outputMessage + this.errorMessage);
                this.filesInvolved.Add(this.RSettings.FilePrefix + "ROutput.txt");
            }

            if (this.errorMessage.Length > 0)
            {
                throw new RExportException(this.errorMessage);
            }
        }

        /// <summary>
        /// Cleans the temp directory and moves all involved files to the output directory.
        /// Call base class when overwriting!
        /// </summary>
        protected virtual void cleanUp()
        { 
            foreach (String file in this.filesInvolved)
            {
                // move file to output folder
                if (this.RSettings.CopyInvoledFiles)
                {
                    File.Copy(this.RSettings.PathToTmp + "\\" + file,
                              this.RSettings.PathToOutput + "\\" + file);
                }

                // clean tmp folder
                File.Delete(this.RSettings.PathToTmp + "\\" + file);
            }
        }

        // async. event listener on regular process output data
        private void onOutputData(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
            {
                this.outputMessage += args.Data.ToString() + "\r\n";
            }
        }

        // async. event listener on process error output data
        private void onErrorData(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
            {
                this.errorMessage += args.Data.ToString() + "\r\n";
            }
        }
    }
}
