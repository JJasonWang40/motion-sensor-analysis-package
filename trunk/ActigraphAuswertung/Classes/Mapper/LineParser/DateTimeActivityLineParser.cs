using System;
using System.Text.RegularExpressions;
using ActigraphAuswertung.Model;
using System.Globalization;

namespace ActigraphAuswertung.Mapper.LineParser
{
    /// <summary>
    /// Lineparser for lines that contain <see cref="SensorData.Date"/> 
    /// and <see cref="SensorData.Activity"/> seperated by 
    /// a semicolom.
    /// </summary>
    class DateTimeActivityLineParser : AbstractLineParser
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DateTimeActivityLineParser()
        {
            // set regex
            this.lineMatcher = new Regex(
                // (1: Date)(2: Seperator)
                @"^([0-9]+\.[0-9]+\.[0-9][0-9][0-9][0-9])(;|,)"
                // (3: Time)(4: Seperator)
                + "([0-9]+:[0-9]+:[0-9]+)(;|,)"
                // (5: Activity)
                + "([0-9]+)$",
                RegexOptions.Compiled
            );

            // set supported values
            SensorData[] data = { SensorData.Date, SensorData.Activity };
            this.SupportedValues = data;
        }

        /// <summary>
        /// Parses a line and returns the <see cref="RowEntry"/> with  
        /// <see cref="SensorData.Date"/> and <see cref="SensorData.Activity"/> set.
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
                entry.Date = DateTime.Parse(match.Groups[1].Value + " " + match.Groups[3].Value, new CultureInfo("DE-de"));
                entry.Activity = int.Parse(match.Groups[5].Value);
                return entry;
            }
            throw new LineparserException("Invalid line-format: " + line);
        }
    }
}
