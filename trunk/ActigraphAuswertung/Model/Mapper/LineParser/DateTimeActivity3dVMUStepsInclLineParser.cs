using System;
using System.Text.RegularExpressions;
using ActigraphAuswertung.Model;


namespace ActigraphAuswertung.Mapper.LineParser
{
    /// <summary>
    /// Lineparser for lines that contain <see cref="SensorData.Date"/>,
    /// <see cref="SensorData.Activity"/>, <see cref="SensorData.ActivityY"/>,
    /// <see cref="SensorData.ActivityZ"/>, <see cref="SensorData.Vmu"/>,
    /// <see cref="SensorData.Steps"/> and <see cref="SensorData.Inclinometer"/>
    /// seperated by comma.
    /// </summary>
    class DateTimeActivity3dVMUStepsInclLineParser : AbstractGT3XLineParser
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DateTimeActivity3dVMUStepsInclLineParser()
        {
            // set regex
            this.lineMatcher = new Regex(
                // Date & Time
                @"^([0-9][0-9]\.[0-9][0-9]\.[0-9][0-9][0-9][0-9]),"
                + "([0-9][0-9]:[0-9][0-9]:[0-9][0-9]),"
                // Activity 3d
                + "([0-9]+),([0-9]+),([0-9]+),"
                // VMU
                + "\"([0-9]+(,[0-9]+)?)\","
                // Steps, Inclinometer
                + "([0-9]+),([0-9]+)$"
                , RegexOptions.Compiled
            );
            
            // set supported data
            SensorData[] t = { 
                SensorData.Date, SensorData.Activity, SensorData.ActivityY,
                SensorData.ActivityZ, SensorData.Vmu, SensorData.Steps, SensorData.Inclinometer
            };
            this.SupportedValues = t;
        }

        /// <summary>
        /// Parses a line and returns the <see cref="RowEntry"/> with  
        /// <see cref="SensorData.Date"/>,
        /// <see cref="SensorData.Activity"/>, <see cref="SensorData.ActivityY"/>,
        /// <see cref="SensorData.ActivityZ"/>, <see cref="SensorData.Vmu"/>,
        /// <see cref="SensorData.Steps"/> and <see cref="SensorData.Inclinometer"/> set.
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
                entry.ActivityZ = int.Parse(match.Groups[5].Value);
                entry.Vmu = (int)float.Parse(match.Groups[6].Value);
                entry.Steps = int.Parse(match.Groups[8].Value);
                entry.Inclinometer = int.Parse(match.Groups[9].Value);
                this.entryTime += this.epochPeriod;
                return entry;
            }
            throw new LineparserException("Invalid line-format: " + line);
        }
    }
}
