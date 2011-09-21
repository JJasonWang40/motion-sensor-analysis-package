using System;
using System.Linq;

namespace ActigraphAuswertung.Model.Calculators
{
    /// <summary>
    /// Calculator to calculate the active time of the model.
    /// </summary>
    public class DatabaseActiveTimeCalculator : CalculatorInterface
    {
        
        private DatabaseDataSet model;

        public DatabaseDayStartEndCalculator Days { get; private set; }

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
                
                foreach (SensorStartEndWearing day in this.Days.DayStartEndList)
                {
                    active += day.EndTime - day.StartTime;
                }

                return active;
            }
        }

        /// <summary>
        /// The avarage start time of activity
        /// </summary>
        public TimeSpan AvgStartTime
        {
            get
            {
                long ticks = (long) this.Days.DayStartEndList.AsQueryable().Average<SensorStartEndWearing>(s => s.StartTime.TimeOfDay.Ticks);
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
                long ticks = (long)this.Days.DayStartEndList.AsQueryable().Average<SensorStartEndWearing>(s => s.EndTime.TimeOfDay.Ticks);
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
            this.Days = new DatabaseDayStartEndCalculator(this.model);
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
