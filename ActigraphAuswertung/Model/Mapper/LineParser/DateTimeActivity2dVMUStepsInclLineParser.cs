using System;
using System.Text.RegularExpressions;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Mapper.LineParser
{
    /// <summary>
    /// Lineparser for lines that contain <see cref="SensorData.Date"/>,
    /// <see cref="SensorData.Activity"/>, <see cref="SensorData.ActivityY"/>, 
    /// <see cref="SensorData.Inclinometer"/> 
    /// and <see cref="SensorData.Steps"/> seperated by 
    /// a comma.
    /// </summary>
    class DateTimeActivity2dVMUStepsInclLineParser : AbstractGT3XLineParser
    {
        public DateTimeActivity2dVMUStepsInclLineParser()
        {
            // set regex
            this.lineMatcher = new Regex(
                // Date & Time
                @"^([0-9][0-9]\.[0-9][0-9]\.[0-9][0-9][0-9][0-9]),"
                + "([0-9][0-9]:[0-9][0-9]:[0-9][0-9]),"
                // Activity 2d
                + "([0-9]+),([0-9]+),"
                // VMU
                + "\"([0-9]+(,[0-9]+)?)\","
                // Steps, Inclinometer
                + "([0-9]+)$"
                , RegexOptions.Compiled
            );

            // set supported values
            SensorData[] t = { 
                SensorData.Date, SensorData.Activity, SensorData.ActivityY,
                SensorData.Vmu, SensorData.Steps
            };
            this.SupportedValues = t;
        }

        /// <summary>
        /// Parses a line and returns the <see cref="RowEntry"/> with  
        /// <see cref="SensorData.Date"/>,
        /// <see cref="SensorData.Activity"/>, <see cref="SensorData.ActivityY"/>, 
        /// <see cref="SensorData.Inclinometer"/> 
        /// and <see cref="SensorData.Steps"/> set.
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
                entry.Activity = int.Parse(match.Groups[3].Value);
                entry.ActivityY = int.Parse(match.Groups[4].Value);
                entry.Vmu = (int)float.Parse(match.Groups[5].Value);
                entry.Steps = int.Parse(match.Groups[7].Value);
                this.entryTime += this.epochPeriod;
                return entry;
            }
            throw new LineparserException("Invalid line-format: " + line);
        }
    }
}
