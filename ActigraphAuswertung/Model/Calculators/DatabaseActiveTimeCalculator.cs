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
                DateTime tmpdatetime, actualDayEnd, actualDayStart;

                actualDayStart = (DateTime)model.readData(true, SensorData.Date);
                actualDayEnd = (DateTime)model.readData(true, SensorData.Date);

                while (model.readData(true, SensorData.Date) != null)
                {
                    tmpdatetime = (DateTime)model.readData(false, SensorData.Date);
                    if (tmpdatetime.Date != actualDayStart.Date)
                    {
                        active += actualDayEnd - actualDayStart;
                        actualDayStart = tmpdatetime;
                        actualDayEnd = tmpdatetime;
                    }
                    else actualDayEnd = tmpdatetime;
                }

                active += actualDayEnd - actualDayStart;
                //foreach (SensorStartEndWearing day in this.model.DayStartEndCalculator.DayStartEndList)
                //{
                //    active += day.EndTime - day.StartTime;
                //}

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
                //long ticks = (long)model.DayStartEndCalculator.DayStartEndList.AsQueryable().Average<SensorStartEndWearing>(s => s.StartTime.TimeOfDay.Ticks);
                //return new TimeSpan(ticks);
                return new TimeSpan(0);
            }
        }

        /// <summary>
        /// The avarage end time of activity
        /// </summary>
        public TimeSpan AvgEndTime
        {
            get
            {
                //long ticks = (long)model.DayStartEndCalculator.DayStartEndList.AsQueryable().Average<SensorStartEndWearing>(s => s.EndTime.TimeOfDay.Ticks);
                //return new TimeSpan(ticks);
                return new TimeSpan(0);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model">The model</param>
        public DatabaseActiveTimeCalculator(DatabaseDataSet model)
        {
            this.model = model;
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
