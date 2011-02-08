using System;
using System.Text.RegularExpressions;

namespace ActigraphAuswertung.Mapper.LineParser
{
    /// <summary>
    /// Abstract base class for all GT3X or GT1X sensors. 
    /// Does additional header analysis to extract epoch period and start time 
    /// of the sensor.
    /// </summary>
    abstract class AbstractGT3XLineParser : AbstractLineParser
    {
        // date and time of the first entry
        protected DateTime entryTime = new DateTime();

        // time of the of the first entry
        protected TimeSpan entryoffSetTime = new TimeSpan();

        // epoch time between to entrys
        protected TimeSpan epochPeriod = new TimeSpan();

        /// <summary>
        /// Tests if the line  matches the format for the current lineparser 
        /// and performs additional header analysis.
        /// </summary>
        /// <param name="line">The line to test</param>
        /// <returns>True if successful</returns>
        /// <exception cref="LineparserException">If no linematcher is set</exception>
        public override Boolean test(String line)
        {
            // perform header analysis
            this.tryParseHeaderLine(line);

            // same as in AbstractLineParser
            if (this.lineMatcher == null)
            {
                throw new LineparserException("Line Matcher: No Regex for line-matcher set");
            }
            Match test = this.lineMatcher.Match(line);
            return test.Success;
        }

        /// <summary>
        /// Performs additional header analysis to extract data start time and epoch period.
        /// </summary>
        /// <param name="line">The line to analyse</param>
        /// <exception cref="LineparserException">If an analysed line has invalid format.</exception>
        protected void tryParseHeaderLine(String line)
        {
            // epoch period has two names
            if (line.IndexOf("Epoch Period ") != -1 || line.IndexOf("Cycle Period ") != -1)
            {
                Match timeMatches = this.timeRegex.Match(line);
                if (timeMatches.Success)
                {
                    this.epochPeriod = TimeSpan.Parse(timeMatches.Groups[1].Value);
                }
                else
                {
                    throw new LineparserException("GT3X: Epoch/Cycle-Line detected but invalid format");
                }
            }

            // start time of the sensor
            if (line.IndexOf("Start Time ") != -1)
            {
                Match timeMatches = this.timeRegex.Match(line);
                if (timeMatches.Success)
                {
                    // force dd.mm.YYYY parsing
                    DateTime time = DateTime.Parse(timeMatches.Groups[1].Value, CultureInfoDE);
                    this.entryoffSetTime = new TimeSpan(time.Hour, time.Minute, time.Second);
                }
                else
                {
                    throw new LineparserException("GT3X: StartTime-Line detected but invalid format");
                }
            }

            // start date of the sensor
            if (line.IndexOf("Start Date ") != -1)
            {
                Match dateMatches = this.dateRegex.Match(line);
                if (dateMatches.Success)
                {
                    // force dd.mm.YYYY parsing
                    DateTime date = DateTime.Parse(dateMatches.Groups[1].Value, CultureInfoDE);
                    // add start time to start date
                    entryTime = date + entryoffSetTime;
                }
                else
                {
                    throw new LineparserException("GT3X: StartDate-Line detected but invalid format");
                }
            }
        }
    }
}
