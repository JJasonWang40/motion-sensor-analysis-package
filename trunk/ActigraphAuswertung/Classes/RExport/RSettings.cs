using System;

namespace ActigraphAuswertung.RExport
{
    /// <summary>
    /// Container for all settings for the R export.
    /// </summary>
    public class RSettings
    {
        /// <summary>
        /// Absolute path to the r binary (including the r binary itself).
        /// </summary>
        public String PathToR;

        /// <summary>
        /// Absolute path to the temporary directory.
        /// </summary>
        public String PathToTmp;

        /// <summary>
        /// Absolute path to the output directory.
        /// </summary>
        public String PathToOutput;

        /// <summary>
        /// Absolute path to the application directoy.
        /// </summary>
        public String PathToApplication;

        /// <summary>
        /// Width of the output images.
        /// </summary>
        public int OutputWidth;

        /// <summary>
        /// Height of the output images.
        /// </summary>
        public int OutputHeight;

        /// <summary>
        /// Prefix for all files.
        /// </summary>
        public String FilePrefix;
 
        /// <summary>
        /// Copy all involved files (csv files and r scripts) to the output directory.
        /// </summary>
        public Boolean CopyInvoledFiles;

        /// <summary>
        /// Copy the output of the r process to the output directory.
        /// </summary>
        public Boolean CopyROutput;
    }
}
