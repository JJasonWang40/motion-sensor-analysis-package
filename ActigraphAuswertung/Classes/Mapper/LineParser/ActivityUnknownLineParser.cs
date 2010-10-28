using System;
using System.Text.RegularExpressions;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Mapper.LineParser
{
    /// <summary>
    /// Lineparser for lines that contain <see cref="SensorData.Activity"/>
    /// and an unknown value seperated by a comma.
    /// </summary>
    class ActivityUnknownLineParser : AbstractGT3XLineParser
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ActivityUnknownLineParser()
        {
            this.lineMatcher = new Regex("^([0-9]+),([0-9]+)$", RegexOptions.Compiled);

            SensorData[] t = { SensorData.Date, SensorData.Activity };
            this.SupportedValues = t;
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
                entry.Date = this.entryTime;
                entry.ActivityX = int.Parse(match.Groups[1].Value);
                this.entryTime += this.epochPeriod;
                return entry;
            }
            throw new LineparserException("Invalid line-format: " + line);
        }
    }
}
