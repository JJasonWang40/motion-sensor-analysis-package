using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ActigraphAuswertung.Model.Calculators
{
    /// <summary>
    /// Calculator for calculating the daily start and end times of activity.
    /// </summary>
    public class DayStartEndCalculator : CalculatorInterface
    {
        // the model for calculations
        private CsvModel model;

        // queue buffer for saving the last elements we take into consideration
        // when calculating the start- and enddate
        private Queue<RowEntry> avarageBuffer = new Queue<RowEntry>();

        // list saving the start and endtime of activity for each day in this dataset
        private BindingList<SensorStartEndWearing> dayStartEndList = new BindingList<SensorStartEndWearing>();

        // helper variable to save the currents day start and end times
        private SensorStartEndWearing currentDay = new SensorStartEndWearing();

        // helper variable to see if a date already has been changed
        private DateTime nullDate = new DateTime();

        /// <summary>
        /// List of all days and their start and end times of activity.
        /// </summary>
        public BindingList<SensorStartEndWearing> DayStartEndList
        {
            get { return this.dayStartEndList; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model">The model for calculations</param>
        public DayStartEndCalculator(CsvModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Called by the model on a new entry.
        /// </summary>
        /// <param name="entry">The entry to be added</param>
        public void Add(RowEntry entry)
        {
            this.avarageBuffer.Enqueue(entry);

            // Keep lookback to max. 5. This is the place to change if you want 
            // less or stronger randoms correction.
            if (this.avarageBuffer.Count >= 6)
            {
                this.avarageBuffer.Dequeue();
            }

            // Get lowest value of last 5 entries
            double minVeloc;
            if (this.model.SupportedValues.Contains(SensorData.Activity))
            {
                minVeloc = this.avarageBuffer.AsQueryable().Min<RowEntry>(s => s.Activity);
            }
            else if (this.model.SupportedValues.Contains(SensorData.Vmu))
            {
                minVeloc = this.avarageBuffer.AsQueryable().Min<RowEntry>(s => s.Vmu);
            }
            else
            {
                return;
            }

            // If all values are bigger then 5.0 and start-date hasn't been set yet,
            // set new start-date
            if (minVeloc >= 5.0 && this.currentDay.StartTime.Equals(this.nullDate))
            {
                this.currentDay.StartTime = this.avarageBuffer.First().Date;
            }

            // If all values are bigger then 5.0 and start-date has already been set,
            // assume new end-date, but maybe we'll find a later date later on
            if (minVeloc >= 5.0 && !this.currentDay.StartTime.Equals(this.nullDate))
            {
                this.currentDay.EndTime = entry.Date;
            }
        }

        /// <summary>
        /// Called by the model on a new day.
        /// </summary>
        public void NewDay()
        {
            // reset buffer
            this.avarageBuffer.Clear();

            // add current day to the resultlist
            if (this.currentDay.StartTime.Equals(this.nullDate))
            {
                this.currentDay.StartTime = model.CurrentDay;
                this.currentDay.EndTime = model.CurrentDay;
            }

            // start new day
            this.dayStartEndList.Add(this.currentDay);
            this.currentDay = new SensorStartEndWearing();
        }
    }
}
