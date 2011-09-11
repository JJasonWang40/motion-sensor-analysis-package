using System;
using System.Linq;

namespace ActigraphAuswertung.Model.Calculators
{
    /// <summary>
    /// Calculator to calculate the active time of the model.
    /// </summary>
    public class DatabaseActiveTimeCalculator : CalculatorInterface
    {
        // the model
        private DatabaseDataSet model;

        // the days
        private DatabaseDayStartEndCalculator days;

        /// <summary>
        /// The total time of the sensor.
        /// </summary>
        public TimeSpan TotalActiveTime
        {
            get { return this.model.EndDate - this.model.StartDate; }
        }

        /// <summary>
        /// The total active time of the sensor
        /// </summary>
        public TimeSpan ActiveTime
        {
            get
            {
                TimeSpan active = new TimeSpan();
                
                foreach (SensorStartEndWearing day in this.days.DayStartEndList)
                {
                    active += day.EndTime - day.StartTime;
                }

                return active;
            }
        }

        public DatabaseDayStartEndCalculator getDayStartEndCalculator()
        {
            return days;
        }

        /// <summary>
        /// The avarage start time of activity
        /// </summary>
        public TimeSpan AvgStartTime
        {
            get
            {
                long ticks = (long)this.days.DayStartEndList.AsQueryable().Average<SensorStartEndWearing>(s => s.StartTime.TimeOfDay.Ticks);
                return new TimeSpan(ticks);
            }
        }

        /// <summary>
        /// The avarage end time of activity
        /// </summary>
        public TimeSpan AvgEndTime
        {
            get
            {
                long ticks = (long)this.days.DayStartEndList.AsQueryable().Average<SensorStartEndWearing>(s => s.EndTime.TimeOfDay.Ticks);
                return new TimeSpan(ticks);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model">The model</param>
        public DatabaseActiveTimeCalculator(DatabaseDataSet model)
        {
            this.model = model;
            this.days = new DatabaseDayStartEndCalculator(this.model);
        }

        /// <summary>
        /// Called by the model on adding a new entry. Unused.
        /// </summary>
        /// <param name="entry">The entry to be added.</param>
        public void Add(RowEntry entry)
        {
            return;
        }

        /// <summary>
        /// Called by the model on a new day. Unused.
        /// </summary>
        public void NewDay()
        {
            return;
        }
    }
}
