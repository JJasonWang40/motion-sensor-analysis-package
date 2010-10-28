using System;
using System.Text.RegularExpressions;
using ActigraphAuswertung.Model;
using System.Globalization;

namespace ActigraphAuswertung.Mapper.LineParser
{
    /// <summary>
    /// Lineparser for lines that contain <see cref="SensorData.Date"/>, 
    /// <see cref="SensorData.CaloriesTotal"/>, <see cref="SensorData.CaloriesActivity"/> 
    /// and <see cref="SensorData.Vmu"/> and an entry-id and start and stop-flag (ignored)
    /// seperated by a comma.
    /// </summary>
    class RT3LineParser : AbstractLineParser
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RT3LineParser()
        {
            // set regex
            this.lineMatcher = new Regex(
                // Entry(1)    ,Date(2)
                    @"^([0-9]*), ([0-9]+\/[0-9]+\/[0-9][0-9][0-9][0-9]), "
                // Time(3)
                    + "([0-9]+:[0-9]+:[0-9]+), "
                // Total Calories(4(5))
                    + "([0-9]+(,[0-9]+)?), "
                // Active Calories(6(7))
                    + "([0-9]+(,[0-9]+)?), "
                // VMU(8)
                    + "([0-9]*), "
                // Start Flag (9), End Flag(10)
                    + "(false|true), (false|true)$",
                    RegexOptions.Compiled | RegexOptions.IgnoreCase
            );

            // set supported values
            SensorData[] t = { 
                SensorData.Date, SensorData.CaloriesTotal, SensorData.CaloriesActivity,
                SensorData.Vmu 
            };
            this.SupportedValues = t;
        }

        /// <summary>
        /// Parses a line and returns the <see cref="RowEntry"/> with  
        /// <see cref="SensorData.Date"/>, 
        /// <see cref="SensorData.CaloriesTotal"/>, <see cref="SensorData.CaloriesActivity"/> 
        /// and <see cref="SensorData.Vmu"/> set.
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
                // rt3 saves in us date format
                entry.Date = DateTime.Parse(match.Groups[2].Value + " " + match.Groups[3].Value, new CultureInfo("EN-us"));
                entry.CaloriesTotal = float.Parse(match.Groups[4].Value);
                entry.CaloriesActivity = float.Parse(match.Groups[6].Value);
                entry.Vmu = int.Parse(match.Groups[8].Value);
                return entry;
            }
            throw new LineparserException("Invalid line-format: " + line);
        }
    }
}
