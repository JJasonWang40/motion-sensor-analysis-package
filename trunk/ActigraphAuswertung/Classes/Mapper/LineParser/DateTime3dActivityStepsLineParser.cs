using System;
using System.Text.RegularExpressions;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Mapper.LineParser
{    /// <summary>
    /// Lineparser for lines that contain <see cref="SensorData.Date"/>,
    /// <see cref="SensorData.Activity"/>, <see cref="SensorData.ActivityY"/>, 
    /// <see cref="SensorData.ActivityZ"/> and <see cref="SensorData.Steps"/> seperated by 
    /// a semicolom.
    /// </summary>
    class DateTime3dActivityStepsLineParser : AbstractLineParser
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DateTime3dActivityStepsLineParser()
        {
            // set regex
            this.lineMatcher = new Regex(
                @"^([0-9]+\.[0-9]+\.[0-9]+);"
                + "([0-9]+:[0-9]+:[0-9]+);"
                + "([0-9]+);([0-9]+);([0-9]+);([0-9]+)$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled
            );

            // set supported values
            SensorData[] t = {
                SensorData.Date, SensorData.Activity, SensorData.ActivityY,
                SensorData.ActivityZ, SensorData.Steps
            };
            this.SupportedValues = t;
        }
        /// <summary>
        /// Parses a line and returns the <see cref="RowEntry"/> with  
        /// <see cref="SensorData.Date"/>,
        /// <see cref="SensorData.Activity"/>, <see cref="SensorData.ActivityY"/>, 
        /// <see cref="SensorData.ActivityZ"/> and <see cref="SensorData.Steps"/> set.
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
                entry.Date = DateTime.Parse(match.Groups[1].Value + " " + match.Groups[2].Value);
                entry.Activity = int.Parse(match.Groups[3].Value);
                entry.ActivityY = int.Parse(match.Groups[4].Value);
                entry.ActivityZ = int.Parse(match.Groups[5].Value);
                entry.Steps = int.Parse(match.Groups[6].Value);
                return entry;
            }
            throw new LineparserException("Invalid line-format: " + line);
        }
    }
}
