using System;
using System.Globalization;
using System.Text.RegularExpressions;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Mapper.LineParser
{
    /// <summary>
    /// Lineparser that parsed lines with <see cref="SensorData.Date"/> and one unknown 
    /// value which is determined from the header information. 
    /// Parses lines previously exported for R-Export.
    /// </summary>
    class RExportedLineParser : AbstractLineParser
    {
        // the third value
        private SensorData extraValue;

        /// <summary>
        /// Constructor
        /// </summary>
        public RExportedLineParser()
            : base()
        {
            // set regex
            this.lineMatcher = new Regex(
                @"^([0-9]+\.[0-9]+\.[0-9][0-9][0-9][0-9]);"
                + "([0-9]+:[0-9]+:[0-9]+);"
                + "([0-9]+(,[0-9]+)?)$"
            );
        }

        /// <summary>
        /// Tests for the lineparser format. Additionally it looks for the header row and 
        /// trys to determine the third value seperated by semicolom.
        /// </summary>
        /// <param name="line">The line to parse</param>
        /// <returns>True is successful</returns>
        /// <exception cref="LineparserException">If no linematcher is set</exception>
        public override bool test(string line)
        {
            // Is header line?
            if (line.IndexOf("Date;Time;") != -1)
            {
                // Split header line by semicolom. 
                String[] splits = line.Split(';');
                if (splits.Length != 3)
                {
                    return false;
                }

                // set additional value
                SensorData tValue = (SensorData)Enum.Parse(typeof(SensorData), splits[splits.Length - 1]);
                this.extraValue = tValue;

                // set supported values
                SensorData[] t = { SensorData.Date, tValue };
                this.SupportedValues = t;
            }

            // run the actual test
            return base.test(line);
        }

        /// <summary>
        /// Parses a line and returns the <see cref="RowEntry"/> with  
        /// <see cref="SensorData.Date"/> and one variable value determined by the header.
        /// </summary>
        /// <param name="line">The line to parse</param>
        /// <returns>The parsed data</returns>
        /// <exception cref="LineparserException">If the line has an invalid format for this parser.</exception>
        public override RowEntry parseLine(string line)
        {
            Match match = this.lineMatcher.Match(line);
            if (match.Success)
            {
                RowEntry entry = new RowEntry();
                entry.Date = DateTime.Parse(match.Groups[1].Value + " " + match.Groups[2].Value, new CultureInfo("DE-de"));
                entry.setValue(this.extraValue, match.Groups[3].Value);
                return entry;
            }
            throw new LineparserException("Invalid line-format: " + line);
        }
    }
}
