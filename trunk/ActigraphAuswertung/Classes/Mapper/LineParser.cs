using System;
using System.Globalization;
using System.Text.RegularExpressions;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Mapper.LineParser
{
    /** 
     * Abstract base class for all line parsers
     */
    abstract class AbstractLineParser
    {
        protected Regex timeRegex = new Regex(@"([0-9][0-9]:[0-9][0-9]:[0-9][0-9])", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        protected Regex dateRegex = new Regex(@"([0-9][0-9]\.[0-9][0-9]\.[0-9][0-9][0-9][0-9])", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        protected Regex lineMatcher = null;

        private SensorData[] supportedValues;

        public abstract RowEntry parseLine(String line);

        public virtual Boolean test(String line)
        {
            if (this.lineMatcher == null)
            {
                throw new Exception("Line Matcher: No Regex for line-matcher set");
            }
            Match test = this.lineMatcher.Match(line);
            return test.Success;         
        }

        public SensorData[] SupportedValues
        {
            get { return this.supportedValues; }
            set { this.supportedValues = value; }
        }
    }

    /**
     * Abstract base class for all GT3X/GT1X sensors
     * 
     * This class reads header information and stores them
     * for later possibly DateTime calculations.
     */
    abstract class AbstractGT3XLineParser : AbstractLineParser
    {
        protected DateTime entryTime = new DateTime();
        protected TimeSpan entryoffSetTime = new TimeSpan();
        protected TimeSpan epochPeriod = new TimeSpan();

        public override Boolean test(String line)
        {
            this.tryParseHeaderLine(line);

            if (this.lineMatcher == null)
            {
                throw new Exception("Line Matcher: No Regex for line-matcher set");
            }
            Match test = this.lineMatcher.Match(line);
            return test.Success;
        }

        protected void tryParseHeaderLine(String line)
        {
            if (line.IndexOf("Epoch Period ") != -1 || line.IndexOf("Cycle Period ") != -1)
            {
                Match timeMatches = this.timeRegex.Match(line);
                if (timeMatches.Success)
                {
                    this.epochPeriod = TimeSpan.Parse(timeMatches.Groups[1].Value);
                }
                else
                {
                    throw new Exception("GT3X: Epoch/Cycle-Line detected but invalid format");
                }
            }

            if (line.IndexOf("Start Time ") != -1)
            {
                Match timeMatches = this.timeRegex.Match(line);
                if (timeMatches.Success)
                {
                    // force dd.mm.YYYY parsing
                    DateTime time = DateTime.Parse(timeMatches.Groups[1].Value, new CultureInfo("de-DE"));
                    this.entryoffSetTime = new TimeSpan(time.Hour, time.Minute, time.Second);
                }
                else
                {
                    throw new Exception("GT3X: StartTime-Line detected but invalid format");
                }
            }

            if (line.IndexOf("Start Date ") != -1)
            {
                Match dateMatches = this.dateRegex.Match(line);
                if (dateMatches.Success)
                {
                    // force dd.mm.YYYY parsing
                    DateTime date = DateTime.Parse(dateMatches.Groups[1].Value, new CultureInfo("de-DE"));
                    entryTime = date + entryoffSetTime;
                }
                else
                {
                    throw new Exception("GT3X: StartDate-Line detected but invalid format");
                }
            }
        }
    }

    /**
     * Sensor: GT3X
     * Firmware: 420/210
     * Sample-file: 12_ArmCSV.csv
     * 
     * Parser for files that contain only one value
     */
    class SingleEntryLineParser : AbstractGT3XLineParser
    {
        public SingleEntryLineParser()
        {
            this.lineMatcher = new Regex(@"^([0-9]+)$", RegexOptions.Compiled);

            SensorData[] t = { SensorData.Date, SensorData.Activity };
            this.SupportedValues = t;
        }

        public override RowEntry parseLine(String line)
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
            throw new Exception("Invalid line-format: " + line);
        }
    }

    /**
     * Sensor GT3X
     * Firmware 430/220
     * Sample-file: ARM.csv
     * 
     * Parser for lines that match "[Date],[Time],[Activity],[Steps]
     */
    class DateTimeActivityStepsLineParser : AbstractGT3XLineParser
    {
        public DateTimeActivityStepsLineParser()
        {
            this.lineMatcher = new Regex(
                @"^([0-9][0-9]\.[0-9][0-9]\.[0-9][0-9][0-9][0-9]),"
                + "([0-9][0-9]:[0-9][0-9]:[0-9][0-9]),"
                + "([0-9]+),([0-9]+)$"
                , RegexOptions.Compiled
            );

            SensorData[] t = {SensorData.Date, SensorData.Activity, SensorData.Steps};
            this.SupportedValues = t;
        }

        public override RowEntry parseLine(string line)
        {
            Match match = this.lineMatcher.Match(line);
            if (match.Success)
            {
                RowEntry entry = new RowEntry();
                entry.Date = this.entryTime;
                entry.ActivityX = int.Parse(match.Groups[3].Value);
                entry.Steps = int.Parse(match.Groups[4].Value);
                this.entryTime += this.epochPeriod;
                return entry;
            }
            throw new Exception("Invalid line-format: " + line);
        }
    }

    class NoDate3dActivityStepsLineParser : AbstractGT3XLineParser
    {
        public NoDate3dActivityStepsLineParser()
        {
            this.lineMatcher = new Regex(
                @"([0-9]+),([0-9]+),([0-9]+),([0-9]+)$"
                , RegexOptions.Compiled
            );

            SensorData[] t = {
                SensorData.Date, SensorData.Activity, SensorData.ActivityY,
                SensorData.ActivityZ, SensorData.Steps
            };
            this.SupportedValues = t;
        }

        public override RowEntry parseLine(string line)
        {
            Match match = this.lineMatcher.Match(line);
            if (match.Success)
            {
                RowEntry entry = new RowEntry();
                entry.Date = this.entryTime;
                entry.ActivityX = int.Parse(match.Groups[1].Value);
                entry.ActivityY = int.Parse(match.Groups[2].Value);
                entry.ActivityZ = int.Parse(match.Groups[3].Value);
                entry.Steps = int.Parse(match.Groups[4].Value);
                this.entryTime += this.epochPeriod;
                return entry;
            }
            throw new Exception("Invalid line-format: " + line);
        }        
    }

    /**
     * Sensor (GT3X?)
     * Firmware ?
     * Sample-file: G_Data.csv
     * 
     * Parser for files that match "[Date],[Time],3x [Activity],[Steps]"
     */
    class DateTime3dActivityStepsLineParser : AbstractLineParser
    {
        public DateTime3dActivityStepsLineParser()
        {
            this.lineMatcher = new Regex(
                @"^([0-9][0-9]\.[0-9][0-9]\.[0-9][0-9][0-9][0-9]);"
                + "([0-9][0-9]:[0-9][0-9]:[0-9][0-9]);"
                + "([0-9]+);([0-9]+);([0-9]+);([0-9]+)$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled
            );

            SensorData[] t = {
                SensorData.Date, SensorData.Activity, SensorData.ActivityY,
                SensorData.ActivityZ, SensorData.Steps
            };
            this.SupportedValues = t;
        }

        public override RowEntry parseLine(string line)
        {
            Match match = this.lineMatcher.Match(line);
            if (match.Success)
            {
                RowEntry entry = new RowEntry();
                entry.Date = DateTime.Parse(match.Groups[1].Value + " " + match.Groups[2].Value);
                entry.ActivityX = int.Parse(match.Groups[3].Value);
                entry.ActivityY = int.Parse(match.Groups[4].Value);
                entry.ActivityZ = int.Parse(match.Groups[5].Value);
                entry.Steps = int.Parse(match.Groups[6].Value);
                return entry;
            }
            throw new Exception("Invalid line-format: " + line);
        }

        public override bool test(string line)
        {
            Match test = this.lineMatcher.Match(line);
            return test.Success;
        }
    }

    /**
     * Sensor GT3X
     * Firmware 430/220
     * Sample-file: 25 leg of MCSV.csv
     * 
     * Parser for lines that match "[Activity],[Unknown, maybe steps]"
     */
    class ActivityUnknownLineParser : AbstractGT3XLineParser
    {
        public ActivityUnknownLineParser()
        {
            this.lineMatcher = new Regex("^([0-9]+),([0-9]+)$", RegexOptions.Compiled);

            SensorData[] t = { SensorData.Date, SensorData.Activity };
            this.SupportedValues = t;
        }

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
            throw new Exception("Invalid line-format: " + line);
        }
    }

    /**
     * Sensor: GT3X
     * Firmware: 430/220
     * Sample-file: P50_bein.csv
     * 
     * Parser for lines that match "[Date],[Time],[Activity],[Activity Horz.],[3d Axis],[VMU],[Steps],[Inclinometer]"
     */
    class DateTimeActivity3dVMUStepsInclLineParser : AbstractGT3XLineParser
    {
        public DateTimeActivity3dVMUStepsInclLineParser()
        {
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

            SensorData[] t = { 
                SensorData.Date, SensorData.Activity, SensorData.ActivityY,
                SensorData.ActivityZ, SensorData.Vmu, SensorData.Steps, SensorData.Inclinometer
            };
            this.SupportedValues = t;
        }

        public override RowEntry parseLine(string line)
        {
            Match match = this.lineMatcher.Match(line);
            if (match.Success)
            {
                RowEntry entry = new RowEntry();
                entry.Date = this.entryTime;
                entry.ActivityX = int.Parse(match.Groups[3].Value);
                entry.ActivityY = int.Parse(match.Groups[4].Value);
                entry.ActivityZ = int.Parse(match.Groups[5].Value);
                entry.Vmu = (int) float.Parse(match.Groups[6].Value);
                entry.Steps = int.Parse(match.Groups[8].Value);
                entry.Inclinometer = int.Parse(match.Groups[9].Value);
                this.entryTime += this.epochPeriod;
                return entry;
            }
            throw new Exception("Invalid line-format: " + line);
        }
    }

    /**
     * Sensor: GT3X
     * Firmware: 430/220
     * Sample-file: P50_bein.csv
     * 
     * Parser for lines that match "[Date],[Time],[Activity],[Activity Horz.],[VMU],[Steps],[Inclinometer]"
     */
        class DateTimeActivity2dVMUStepsInclLineParser : AbstractGT3XLineParser
        {
        public DateTimeActivity2dVMUStepsInclLineParser()
        {
            this.lineMatcher = new Regex(
                // Date & Time
                @"^([0-9][0-9]\.[0-9][0-9]\.[0-9][0-9][0-9][0-9]),"
                + "([0-9][0-9]:[0-9][0-9]:[0-9][0-9]),"
                // Activity 3d
                + "([0-9]+),([0-9]+),"
                // VMU
                + "\"([0-9]+(,[0-9]+)?)\","
                // Steps, Inclinometer
                + "([0-9]+)$"
                , RegexOptions.Compiled
            );

            SensorData[] t = { 
                SensorData.Date, SensorData.Activity, SensorData.ActivityY,
                SensorData.Vmu, SensorData.Steps
            };
            this.SupportedValues = t;
        }

        public override RowEntry parseLine(string line)
        {
            Match match = this.lineMatcher.Match(line);
            if (match.Success)
            {
                RowEntry entry = new RowEntry();
                entry.Date = this.entryTime;
                entry.ActivityX = int.Parse(match.Groups[3].Value);
                entry.ActivityY = int.Parse(match.Groups[4].Value);
                entry.Vmu = (int)float.Parse(match.Groups[5].Value);
                entry.Steps = int.Parse(match.Groups[7].Value);
                this.entryTime += this.epochPeriod;
                return entry;
            }
            throw new Exception("Invalid line-format: " + line);
        }
    }

    /**
     * Sensor: GT3X
     * Firmware: 430/220
     * Sample-file: 19leg,26,13CSV.csv
     * 
     * Parser for lines that match "[Activity],[Activity Horz.],[3d Axis],[VMU],[Steps]"
     */
    class Activity3dVMULineParser : AbstractGT3XLineParser
    {
        public Activity3dVMULineParser()
        {
            this.lineMatcher = new Regex(
                // Activity 3d
                @"^([0-9]+),([0-9]+),([0-9]+),"
                // VMU, Steps
                + "([0-9]+),([0-9]+)$"
                , RegexOptions.Compiled
            );

            SensorData[] t = { 
                SensorData.Date, SensorData.Activity, SensorData.ActivityY,
                SensorData.ActivityZ, SensorData.Vmu, SensorData.Steps 
            };
            this.SupportedValues = t;
        }

        public override RowEntry parseLine(string line)
        {
            Match match = this.lineMatcher.Match(line);
            if (match.Success)
            {
                RowEntry entry = new RowEntry();
                entry.Date = this.entryTime;
                entry.ActivityX = int.Parse(match.Groups[1].Value);
                entry.ActivityY = int.Parse(match.Groups[2].Value);
                entry.ActivityZ = int.Parse(match.Groups[3].Value);
                entry.Vmu = int.Parse(match.Groups[4].Value);
                entry.Steps = int.Parse(match.Groups[5].Value);
                this.entryTime += this.epochPeriod;
                return entry;
            }
            throw new Exception("Invalid line-format: " + line);
        }
    }

   /**
     * Sensor: GT1X
     * Firmware: 441/620
     * Sample-file: g,f,iCSV.csv
     * 
     * Parser for lines that match "[Activity],[Activity Horz.],[VMU]"
     */
    class Activity2dVMULineParser : AbstractGT3XLineParser
    {
        public Activity2dVMULineParser()
        {
            this.lineMatcher = new Regex("^([0-9]+),([0-9]+),([0-9]+)$", RegexOptions.Compiled);

            SensorData[] t = {SensorData.Date, SensorData.Activity, SensorData.ActivityY, SensorData.Vmu };
            this.SupportedValues = t; 
        }

        public override RowEntry parseLine(string line)
        {
            Match match = this.lineMatcher.Match(line);
            if (match.Success)
            {
                RowEntry entry = new RowEntry();
                entry.Date = this.entryTime;
                entry.ActivityX = int.Parse(match.Groups[1].Value);
                entry.ActivityY = int.Parse(match.Groups[2].Value);
                entry.Vmu = int.Parse(match.Groups[3].Value);
                this.entryTime += this.epochPeriod;
                return entry;
            }
            throw new Exception("Invalid line-format: " + line);
        }
    }

    /**
     * Sensor: Unknown (GT3X?)
     * 
     * Sample file: B leg of DCSV.csv
     * 
     * Line format: "[Date];[Time];ActivityX"
     */
    class DateTimeActivityLineParser : AbstractLineParser 
    {
        public DateTimeActivityLineParser()
        {
            this.lineMatcher = new Regex(
                @"([0-9]+\.[0-9]+\.[0-9][0-9][0-9][0-9]);"
                + "([0-9]+:[0-9]+:[0-9]+);"
                + "([0-9]+)",
                RegexOptions.Compiled
            );

            SensorData[] data = { SensorData.Date, SensorData.Activity };
            this.SupportedValues = data;
        }

        public override bool test(string line)
        {
            if (this.lineMatcher == null)
            {
                throw new Exception("Line Matcher: No Regex for line-matcher set");
            }
            Match test = this.lineMatcher.Match(line);
            return test.Success;
        }

        public override RowEntry parseLine(string line)
        {
            Match match = this.lineMatcher.Match(line);
            if (match.Success)
            {
                RowEntry entry = new RowEntry();
                entry.Date = DateTime.Parse(match.Groups[1].Value + " " + match.Groups[2].Value, new CultureInfo("DE-de"));
                entry.ActivityX = int.Parse(match.Groups[3].Value);
                return entry;
            }
            throw new Exception("Invalid line-format: " + line);
        }
    }

   /**
     * Sensor: RT3
     * Firmware: -
     * Sample-file: -
     * 
     * Parser for lines that match "[Entry],[Date],[Time],[Tot. Cal.],[Act. Cal.],[VMU],[Start],[Stop]"
     */
    class RT3LineParser : AbstractLineParser
    {
        public RT3LineParser()
        {
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

            SensorData[] t = { 
                SensorData.Date, SensorData.CaloriesTotal, SensorData.CaloriesActivity,
                SensorData.Vmu 
            };
            this.SupportedValues = t;
        }

        public override Boolean test(String line)
        {
            if (this.lineMatcher == null)
            {
                throw new Exception("Line Matcher: No Regex for line-matcher set");
            }
            Match test = this.lineMatcher.Match(line);
            return test.Success;
        }

        public override RowEntry parseLine(string line)
        {
            Match match = this.lineMatcher.Match(line);
            if (match.Success)
            {
                RowEntry entry = new RowEntry();
                entry.Date = DateTime.Parse(match.Groups[2].Value + " " + match.Groups[3].Value, new CultureInfo("EN-us"));
                entry.CaloriesTotal = float.Parse(match.Groups[4].Value);
                entry.CaloriesActivity = float.Parse(match.Groups[6].Value);
                entry.Vmu = int.Parse(match.Groups[8].Value);
                return entry;
            }
            throw new Exception("Invalid line-format: " + line);
        }
    }

    class RT3KommaSepLineParser : AbstractLineParser
    {
        public RT3KommaSepLineParser() : base()
        {
            this.lineMatcher = new Regex(
                // Entry(1)    ,Date(2)
                    @"^([0-9]*);([0-9]+\.[0-9]+\.[0-9][0-9][0-9][0-9]); "
                // Time(3)
                    + "([0-9]+:[0-9]+:[0-9]+);"
                // Total Calories(4(5))
                    + "([0-9]+(;[0-9]+)?);"
                // Active Calories(6(7))
                    + "([0-9]+(;[0-9]+)?);"
                // VMU(8)
                    + "([0-9]*); "
                // Start Flag (9), End Flag(10)
                    + "(false|true);( (false|true))?$",
                    RegexOptions.Compiled | RegexOptions.IgnoreCase
            ); 
            
            SensorData[] t = { 
                SensorData.Date, SensorData.CaloriesTotal, SensorData.CaloriesActivity,
                SensorData.Vmu 
            };
            this.SupportedValues = t;
        }

        public override Boolean test(String line)
        {
            if (this.lineMatcher == null)
            {
                throw new Exception("Line Matcher: No Regex for line-matcher set");
            }
            Match test = this.lineMatcher.Match(line);
            return test.Success;
        }

        public override RowEntry parseLine(string line)
        {
            Match match = this.lineMatcher.Match(line);
            if (match.Success)
            {
                RowEntry entry = new RowEntry();
                entry.Date = DateTime.Parse(match.Groups[2].Value + " " + match.Groups[3].Value, new CultureInfo("DE-de"));
                entry.CaloriesTotal = float.Parse(match.Groups[4].Value.Replace(";", ","));
                entry.CaloriesActivity = float.Parse(match.Groups[6].Value.Replace(";", ","));
                entry.Vmu = int.Parse(match.Groups[8].Value);
                return entry;
            }
            throw new Exception("Invalid line-format: " + line);
        }
    }

    /** 
     * Lineparser for files that have been exported previously
     * 
     * Possible duplicate of DateTimeActivityLineParser
     */
    class RExportedLineParser : AbstractLineParser
    {
        private SensorData extraValue;

        public RExportedLineParser()
            : base()
        {
            this.lineMatcher = new Regex(
                @"([0-9]+\.[0-9]+\.[0-9][0-9][0-9][0-9]);"
                + "([0-9]+:[0-9]+:[0-9]+);"
                + "([0-9]+(,[0-9]+)?)"
            );
        }

        public override bool test(string line)
        {
            if (line.IndexOf("Date;Time;") != -1)
            {
                String[] splits = line.Split(';');
                if (splits.Length != 3)
                {
                    return false;
                }
                SensorData tValue = (SensorData)Enum.Parse(typeof(SensorData), splits[splits.Length - 1]);
                this.extraValue = tValue;
                Console.WriteLine(tValue.ToString() + ": " + splits[splits.Length - 1]);

                SensorData[] t = { SensorData.Date, tValue };
                this.SupportedValues = t;
            }
   
            return base.test(line);
        }

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
            throw new Exception("Invalid line-format: " + line);
        }
    }
}
