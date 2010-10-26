using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace ActigraphAuswertung.Model
{
    public enum SensorData {
        [Description("Date & Time")]    Date, 
        [Description("Activity")]     Activity,
        [Description("Activity Y")]     ActivityY, 
        [Description("Activity Z")]     ActivityZ,
        [Description("Vmu")]            Vmu,
        [Description("Steps")]          Steps,
        [Description("Inclinometer")]   Inclinometer,
        [Description("Calories (Total)")]       CaloriesTotal,
        [Description("Calories (Activity)")]    CaloriesActivity
    };

    public class RowEntry
    {
        private DateTime date;

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        private int activityX = 0;

        public int ActivityX
        {
            get { return this.activityX; }
            set { this.activityX = value; }
        }

        private int activityY = 0;

        public int ActivityY
        {
            get { return this.activityY; }
            set { this.activityY = value; }
        }

        private int activityZ = 0;

        public int ActivityZ
        {
            get { return this.activityZ; }
            set { this.activityZ = value; }
        }

        private int vmu = 0;

        public int Vmu
        {
            get { return this.vmu; }
            set { this.vmu = value; }
        }

        private int steps = 0;

        public int Steps
        {
            get { return this.steps; }
            set { this.steps = value; }
        }

        private int inclinometer = 0;

        public int Inclinometer
        {
            get { return this.inclinometer; }
            set { this.inclinometer = value; }
        }

        private float caloriesTotal = 0;

        public float CaloriesTotal
        {
            get { return this.caloriesTotal; }
            set { this.caloriesTotal = value; }
        }

        private float caloriesActivity = 0;

        public float CaloriesActivity
        {
            get { return this.caloriesActivity; }
            set { this.caloriesActivity = value; }
        }

        public void setValue(SensorData entry, String value)
        {
            switch (entry)
            { 
                case SensorData.Date:
                    this.Date = DateTime.Parse(value);
                    break;

                case SensorData.Activity:
                    this.ActivityX = int.Parse(value);
                    break;

                case SensorData.ActivityY:
                    this.ActivityY = int.Parse(value);
                    break;

                case SensorData.ActivityZ:
                    this.ActivityZ = int.Parse(value);
                    break;

                case SensorData.CaloriesActivity:
                    this.CaloriesActivity = float.Parse(value);
                    break;

                case SensorData.CaloriesTotal:
                    this.CaloriesTotal = float.Parse(value);
                    break;

                case SensorData.Inclinometer:
                    this.Inclinometer = int.Parse(value);
                    break;

                case SensorData.Steps:
                    this.Steps = int.Parse(value);
                    break;

                case SensorData.Vmu:
                    this.Vmu = int.Parse(value);
                    break;

                default:
                    throw new Exception("Unsupported value " + entry.ToString());
            }
        }

        public Object getValue(SensorData entry)
        {
            switch (entry)
            { 
                case SensorData.Activity:
                    return this.ActivityX;

                case SensorData.ActivityY:
                    return this.ActivityY;

                case SensorData.ActivityZ:
                    return this.ActivityZ;

                case SensorData.CaloriesActivity:
                    return this.CaloriesActivity;

                case SensorData.CaloriesTotal:
                    return this.CaloriesTotal;

                case SensorData.Inclinometer:
                    return this.Inclinometer;

                case SensorData.Steps:
                    return this.Steps;

                case SensorData.Vmu:
                    return this.Vmu;

                case SensorData.Date:
                    return this.Date;

                default:
                    return null;
            }
        }
    }

    public class SensorStartEndWearing
    {
        private DateTime startDate = new DateTime();
        private DateTime endDate = new DateTime();

        private DateTime date;

        public DateTime StartTime
        {
            get { return this.startDate; }
            set 
            { 
                this.startDate = value;

                if (this.date == null) {
                    this.date = value.Date;
                }
            }
        }

        public DateTime EndTime
        {
            get { return this.endDate; }
            set
            {
                this.endDate = value; ;

                if (this.date == null)
                {
                    this.date = value.Date;
                }
            }
        }

        public DateTime Date
        {
            get { return this.startDate.Date; }
        }

        public TimeSpan ActiveTime
        {
            get { return this.endDate - this.startDate; }
        }
    }

    /**
     * WARNING: Do not add index-based. This will cause serious troubles with the 
     * avarage calculations! This class only supports appending of elements.
     */
    public class CsvModel : BindingList<RowEntry>
    {
        /**
         * Absolute file name of the csv-file, accessor for datagrid binding
         */
        private String absoluteFileName = null;

        public String AbsoluteFileName
        {
            get { return this.absoluteFileName; }
            set { this.absoluteFileName = value; }
        }


        /**
         * File-name only without path
         */
        private String fileName = null;

        public String FileName
        {
            get
            {
                if (this.fileName == null && this.AbsoluteFileName != null)
                {
                    String[] t = this.AbsoluteFileName.Split('\\');
                    this.fileName = t.Last();
                }
                return this.fileName;
            }
        }

        public TimeSpan EpochPeriod
        {
            get 
            {
                IEnumerable<RowEntry> t = this.Take<RowEntry>(2);
                return t.Last().Date - t.First().Date;
            }
        }

        private Boolean locked = false;

        /** 
         * Supported sensor values of this file
         */
        public SensorData[] SupportedValues;

        private DayStartEndCalculator dayStartEndCalculator;

        public DayStartEndCalculator DayStartEndCalculator
        {
            get { return this.dayStartEndCalculator; }
        }

        private ActiveTimeCalculator activeTimeCalculator;

        public ActiveTimeCalculator ActiveTimeCalculator
        {
            get { return this.activeTimeCalculator; }
        }

        private ActivityLevelsCalculator activityLevelCalculator;

        public ActivityLevelsCalculator ActivityLevelCalculator
        {
            get { return this.activityLevelCalculator; }
        }

        // helper variable to see if a date already has been changed
        private DateTime nullDate = new DateTime();

        // most of these accessors are trivial and must be defined for datagrid binding
        public DateTime StartDate
        {
            get { return this.First().Date; }
        }

        public DateTime EndDate
        {
            get { return this.Last().Date; }
        }

        private DateTime currentDay = new DateTime();

        public DateTime CurrentDay
        {
            get { return this.currentDay; }
        }

        public CsvModel()
        {
            this.dayStartEndCalculator = new DayStartEndCalculator(this);
            this.activeTimeCalculator = new ActiveTimeCalculator(this);
            this.activityLevelCalculator = new ActivityLevelsCalculator(this);
        }

        // Helper function to see if Start & End date are set correctly
        public Boolean isValid()
        {
            return ((this.StartDate != this.nullDate)
                && (this.EndDate != this.nullDate));
        }

        protected override void InsertItem(int index, RowEntry item)
        {
            if (this.locked) 
            {
                throw new Exception("Model already finished. Can't add new datasets");
            }

            // Init current day
            if (this.currentDay.Equals(this.nullDate))
            {
                this.currentDay = item.Date.Date;
            }

            // New day
            if (this.currentDay.Date < item.Date.Date)
            {
                this.finishDay();
                this.currentDay = item.Date.Date;
            }

            // inform calculators about new item
            this.dayStartEndCalculator.Add(item);
            this.activeTimeCalculator.Add(item);
            this.activityLevelCalculator.Add(item);

            base.InsertItem(index, item);
        }

        private void finishDay()
        {
            // inform calculators about new day
            this.dayStartEndCalculator.NewDay();
            this.activeTimeCalculator.NewDay();
            this.activityLevelCalculator.NewDay();
        }

        public void finishParsing()
        {
            // lock object to prevent further modifications
            this.locked = true;
            // finish last day
            this.finishDay();
        }
    }
}