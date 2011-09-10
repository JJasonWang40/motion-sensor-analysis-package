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
    public class DatabaseDayStartEndCalculator : CalculatorInterface
    {
        // the model for calculations
        private DatabaseDataSet model;

        // queue buffer for saving the last elements we take into consideration
        // when calculating the start- and enddate
        private Queue<RowEntry> averageBuffer = new Queue<RowEntry>();

        // list saving the start and endtime of activity for each day in this dataset
        private BindingList<SensorStartEndWearing> dayStartEndList = new BindingList<SensorStartEndWearing>();

        // helper variable to save the currents day start and end times
        private SensorStartEndWearing currentDay = new SensorStartEndWearing();

        // helper variable to see if a date already has been changed
        private DateTime nullDate = new DateTime();

        //variables for Add()
        double minVeloc = 0;
        int[] averageBufferArray = new int[5];
        int arrayCount = 0;
        int entryCount = 0;
        int Step = 5;
        bool activityValueSupported;
        bool vmuValueSupported;

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
        public DatabaseDayStartEndCalculator(DatabaseDataSet model)
        {
            this.model = model;
            this.activityValueSupported = this.model.SupportedValues.Contains(SensorData.Activity);
            this.vmuValueSupported = this.model.SupportedValues.Contains(SensorData.Vmu);
            generateData();
        }

        private void generateData()
        {
            currentDay = new SensorStartEndWearing();
            DateTime tmpdatetime, actualDayEnd, actualDayStart;

            actualDayStart = (DateTime)model.readData(true, SensorData.Date);
            actualDayEnd = (DateTime)model.readData(true, SensorData.Date);

            while (model.readData(true, SensorData.Date) != null)
            {
                tmpdatetime = (DateTime)model.readData(false, SensorData.Date);
                if (tmpdatetime.Date != actualDayStart.Date)
                {
                    currentDay.StartTime = actualDayStart;
                    currentDay.EndTime = actualDayEnd;
                    dayStartEndList.Add(currentDay);
                    actualDayStart = tmpdatetime;
                    actualDayEnd = tmpdatetime;
                    currentDay = new SensorStartEndWearing();
                }
                else actualDayEnd = tmpdatetime;
            }
            currentDay.StartTime = actualDayStart;
            currentDay.EndTime = actualDayEnd;
            dayStartEndList.Add(currentDay);
            currentDay = new SensorStartEndWearing();
        }

        /// <summary>
        /// Called by the model on a new entry.
        /// </summary>
        /// not longer used
        /// <param name="entry">The entry to be added</param>
        public void Add(RowEntry entry)
        {


            this.averageBuffer.Enqueue(entry);

            //arrayCount reset after the maximum number of steps. Preventing array overflow.
            this.arrayCount = this.entryCount % this.Step;


            // Add values to averageBufferArray
            if (activityValueSupported)
            {
                this.averageBufferArray[this.arrayCount] = entry.Activity;
            }
            else if (vmuValueSupported)
            {
                this.averageBufferArray[this.arrayCount] = entry.Vmu;
            }
            else
            {
                return;
            }

            this.entryCount++;

            if (entryCount < (this.Step))
            {
                return;
            }

            // Keep lookback to max. of the variable Step. This is the place to change if you want 
            // less or stronger randoms correction.
            if (this.averageBuffer.Count > this.Step)
            {
                this.averageBuffer.Dequeue();
            }

            // Get minimum of the Buffer
            this.minVeloc = this.averageBufferArray.Min();

            // If all values are bigger then 5.0 and start-date hasn't been set yet,
            // set new start-date
            if (minVeloc >= 5.0 && this.currentDay.StartTime.Equals(this.nullDate))
            {
                this.currentDay.StartTime = this.averageBuffer.First().Date;
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
        /// not longer used
        public void NewDay()
        {
            // reset buffer and entryCount
            this.averageBuffer.Clear();
            this.entryCount = 0;

            // add current day to the resultlist
            if (this.currentDay.StartTime.Equals(this.nullDate))
            {
                //this.currentDay.StartTime = model.CurrentDay;
                //this.currentDay.EndTime = model.CurrentDay;
            }

            // start new day
            this.dayStartEndList.Add(this.currentDay);
            this.currentDay = new SensorStartEndWearing();
        }
    }
}