using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ActigraphAuswertung.Model.Calculators;

namespace ActigraphAuswertung.Model
{
    /// <summary>
    /// Sensor independent represenation of a file. 
    /// </summary>
    /// <remarks>Do not insert index-based. This will screw up all calculations!</remarks>
    public class CsvModel : BindingList<RowEntry>,IDataSet
    {
        private string id;

        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }


        private String absoluteFileName = null;

        /// <summary>
        /// Absolute path to the file including the filename.
        /// </summary>
        public String AbsoluteFileName
        {
            get { return this.absoluteFileName; }
            set { this.absoluteFileName = value; }
        }


        /**
         * File-name only without path
         */
        private String fileName = null;

        /// <summary>
        /// Filename of the file.
        /// </summary>
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

        /// <summary>
        /// Epoch period between two entrys.
        /// </summary>
        public TimeSpan EpochPeriod
        {
            get 
            {
                IEnumerable<RowEntry> t = this.Take<RowEntry>(2);
                return t.Last().Date - t.First().Date;
            }
        }

        // Model is finished. No further adding possible.
        private bool locked = false;

        public bool Locked
        {
            get { return this.locked; }
            set { this.locked = value; }
        }

        /// <summary>
        /// Supported values of the file.
        /// </summary>
        public SensorData[] SupportedValues;

        private DayStartEndCalculator dayStartEndCalculator;

        /// <summary>
        /// The <see cref="DayStartEndCalculator"/> of the model.
        /// </summary>
        public DayStartEndCalculator DayStartEndCalculator
        {
            get { return this.dayStartEndCalculator; }
        }

        private ActiveTimeCalculator activeTimeCalculator;

        /// <summary>
        /// The <see cref="ActiveTimeCalculator"/> of the model.
        /// </summary>
        public ActiveTimeCalculator ActiveTimeCalculator
        {
            get { return this.activeTimeCalculator; }
        }

        private ActivityLevelsCalculator activityLevelCalculator;

        /// <summary>
        /// The <see cref="ActivityLevelsCalculator"/> of the model.
        /// </summary>
        public ActivityLevelsCalculator ActivityLevelCalculator
        {
            get { return this.activityLevelCalculator; }
        }

        // helper variable to see if a date already has been changed
        private DateTime nullDate = new DateTime();

        /// <summary>
        /// Date of the first entry of the model.
        /// </summary>
        public DateTime StartDate
        {
            get { return this.First().Date; }
        }

        /// <summary>
        /// Date of the last entry of the model.
        /// </summary>
        public DateTime EndDate
        {
            get { return this.Last().Date; }
        }

        private DateTime currentDay = new DateTime();

        /// <summary>
        /// Date of the current day the model is working on.
        /// </summary>
        public DateTime CurrentDay
        {
            get { return this.currentDay; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public CsvModel(SensorData[] SupportedValues)
        {
            this.SupportedValues = SupportedValues;
            this.dayStartEndCalculator = new DayStartEndCalculator(this);
            this.activeTimeCalculator = new ActiveTimeCalculator(this);
            this.activityLevelCalculator = new ActivityLevelsCalculator(this);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public CsvModel()
        {
        }

        /// <summary>
        /// Helper function to see if Start and End date are set correctly.
        /// </summary>
        /// <returns>True if model is valid</returns>
        public Boolean isValid()
        {
            return ((this.StartDate != this.nullDate)
                && (this.EndDate != this.nullDate));
        }

        /// <summary>
        /// Overwritten insert method of the model.
        /// </summary>
        /// <param name="index">The position where to add the item.</param>
        /// <param name="item">The entry to add to the model</param>
        /// <exception cref="Exception">If the model is already locked.</exception>
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

        /// <summary>
        /// Finish the current day the model is aware of.
        /// </summary>
        private void finishDay()
        {
            // inform calculators about new day
            this.dayStartEndCalculator.NewDay();
            this.activeTimeCalculator.NewDay();
            this.activityLevelCalculator.NewDay();
        }

        /// <summary>
        /// Finish the parsing of the model. Locks the model for further modifications 
        /// and finishes the current day.
        /// </summary>
        public void finishParsing()
        {
            // lock object to prevent further modifications
            this.locked = true;
            // finish last day
            this.finishDay();
        }
    }
}