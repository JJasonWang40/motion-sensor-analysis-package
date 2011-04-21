using System;
using System.Text.RegularExpressions;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Mapper.LineParser
{
    /// <summary>
    /// Line parser for GT3X sensors that only have <see cref="SensorData.Activity"/>.
    /// </summary>
    class SingleEntryLineParser : AbstractGT3XLineParser
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SingleEntryLineParser()
        {
            // set regex
            this.lineMatcher = new Regex(@"^([0-9]+)$", RegexOptions.Compiled);

            // set supported information
            SensorData[] t = { SensorData.Date, SensorData.Activity };
            this.SupportedValues = t;
        }

        /// <summary>
        /// Parses a line and returns the <see cref="RowEntry"/> with only 
        /// <see cref="SensorData.Date"/> and <see cref="SensorData.Activity"/> set.
        /// </summary>
        /// <param name="line">The line to parse</param>
        /// <returns>The parsed data</returns>
        /// <exception cref="LineparserException">If the line has an invalid format for this parser.</exception>
        public override RowEntry parseLine(String line)
        {
            Match match = this.lineMatcher.Match(line);
            if (match.Success)
            {
                RowEntry entry = new RowEntry();
                entry.Date = this.entryTime;
                entry.Activity = int.Parse(match.Groups[1].Value);
                this.entryTime += this.epochPeriod;
                return entry;
            }
            throw new LineparserException("Invalid line-format: " + line);
        }
    }
}
