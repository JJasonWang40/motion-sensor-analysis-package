using System;
using System.Text.RegularExpressions;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Mapper.LineParser
{
    /// <summary>
    /// Abstract base class for all line parsers.
    /// </summary>
    abstract class AbstractLineParser
    {
        // Simple regex for later use. European time and date.
        protected Regex timeRegex = new Regex(@"([0-9][0-9]:[0-9][0-9]:[0-9][0-9])", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        protected Regex dateRegex = new Regex(@"([0-9][0-9]\.[0-9][0-9]\.[0-9][0-9][0-9][0-9])", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        // Must be set by inheriting class to match one complete line
        protected Regex lineMatcher = null;

        // Must be set by inheriting class.
        private SensorData[] supportedValues;

        /// <summary>
        /// Array of all datatypes each row contains if it has this line-format.
        /// </summary>
        public SensorData[] SupportedValues
        {
            get { return this.supportedValues; }
            set { this.supportedValues = value; }
        }

        /// <summary>
        /// Abstract parseLine method. 
        /// </summary>
        /// <param name="line">The line of data</param>
        /// <returns>Fully interpretated data</returns>
        public abstract RowEntry parseLine(String line);

        /// <summary>
        /// Tests if the line  matches the format for the current lineparser.
        /// </summary>
        /// <param name="line">The line to test</param>
        /// <returns>True if test was successful</returns>
        /// <exception cref="LineparserException">If no linematcher is set</exception>
        public virtual Boolean test(String line)
        {
            if (this.lineMatcher == null)
            {
                throw new LineparserException("Line Matcher: No Regex for line-matcher set");
            }
            Match test = this.lineMatcher.Match(line);
            return test.Success;
        }
    }
}
