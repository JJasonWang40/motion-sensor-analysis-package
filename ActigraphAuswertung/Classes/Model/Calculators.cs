using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ActigraphAuswertung.Model
{
    interface Calculators
    {
        void Add(RowEntry entry);
        void NewDay();
    }

    public class ActiveTimeCalculator : Calculators
    {
        private CsvModel model;

        public TimeSpan TotalActiveTime
        {
            get { return this.model.EndDate - this.model.StartDate; }
        }

        public TimeSpan ActiveTime
        {
            get 
            {
                TimeSpan active = new TimeSpan();

                foreach (SensorStartEndWearing day in this.model.DayStartEndCalculator.DayStartEndList)
                {
                    active += day.EndTime - day.StartTime;
                }

                return active;
            }
        }

        public TimeSpan AvgStartTime
        {
            get
            {
                long ticks = (long)model.DayStartEndCalculator.DayStartEndList.AsQueryable().Average<SensorStartEndWearing>(s => s.StartTime.TimeOfDay.Ticks);
                return new TimeSpan(ticks);
            }
        }

        public TimeSpan AvgEndTime
        {
            get
            {
                long ticks = (long)model.DayStartEndCalculator.DayStartEndList.AsQueryable().Average<SensorStartEndWearing>(s => s.EndTime.TimeOfDay.Ticks);
                return new TimeSpan(ticks);
            }
        }

        public ActiveTimeCalculator(CsvModel model)
        {
            this.model = model;
        }

        public void Add(RowEntry entry)
        {
            return;
        }

        public void NewDay()
        {
            return;
        }
    }

    public class DayStartEndCalculator : Calculators
    {
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

        public BindingList<SensorStartEndWearing> DayStartEndList
        {
            get { return this.dayStartEndList; }
        }

        public DayStartEndCalculator(CsvModel model)
        {
            this.model = model;
        }

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
                minVeloc = this.avarageBuffer.AsQueryable().Min<RowEntry>(s => s.ActivityX);
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

        public void NewDay()
        {
            this.avarageBuffer.Clear();

            if (this.currentDay.StartTime.Equals(this.nullDate))
            {
                this.currentDay.StartTime = model.CurrentDay;
                this.currentDay.EndTime = model.CurrentDay;
            }

            this.dayStartEndList.Add(this.currentDay);
            this.currentDay = new SensorStartEndWearing();
        }
    }

    public class ActivityLevelsCalculator : Calculators
    {
        // must be class to change values reference based
        public class ActivityLevel
        {
            public ActivityLevels Level;

            public int Count;

            public double Percent;
        }

        private CsvModel model;

        private ActivityLevel[] activityLevels;

        public int Steps = 5;

        public int MinSedantary = 0;

        public int MinLight = 200;

        public int MinModerate = 2000;

        public int MinHeavy = 5750;

        public int MinVeryheavy = 7500;

        // queue buffer for saving the last elements we take into consideration
        // when calculating the activity levels
        private Queue<RowEntry> avarageBuffer = new Queue<RowEntry>();

        public ActivityLevelsCalculator(CsvModel model)
        {
            this.model = model;

            this.activityLevels = new ActivityLevel[Enum.GetNames(typeof(ActivityLevels)).Length];

            int position = 0;
            foreach (ActivityLevels level in Enum.GetValues(typeof(ActivityLevels)))
            {
                ActivityLevel l = new ActivityLevel();
                l.Level = level;
                l.Count = 0;
                l.Percent = 0.0;
                
                this.activityLevels[position] = l;
                position++;
            }
        }

        public void Add(RowEntry entry)
        {
            this.avarageBuffer.Enqueue(entry);

            // Calculate every 5th. entry
            if (this.avarageBuffer.Count < this.Steps)
            {
                return;
            }

            // Get Avg of these values
            double avgVeloc;
            if (this.model.SupportedValues.Contains(SensorData.Activity))
            {
                avgVeloc = this.avarageBuffer.AsQueryable().Average<RowEntry>(s => s.ActivityX);
            }
            else if (this.model.SupportedValues.Contains(SensorData.Vmu))
            {
                avgVeloc = this.avarageBuffer.AsQueryable().Average<RowEntry>(s => s.Vmu);
            }
            else 
            {
                return;
            }

            if (this.MinSedantary <= avgVeloc && avgVeloc < this.MinLight)
            {
                this.addCount(ActivityLevels.SEDENTARY);
            }
            else if (this.MinLight <= avgVeloc && avgVeloc < this.MinModerate)
            {
                this.addCount(ActivityLevels.LIGHT);
            }
            else if (this.MinModerate <= avgVeloc && avgVeloc < this.MinHeavy)
            {
                this.addCount(ActivityLevels.MODERATE);
            }
            else if (this.MinHeavy <= avgVeloc && avgVeloc < this.MinVeryheavy)
            {
                this.addCount(ActivityLevels.VIGOROUS);
            }
            else if(this.MinVeryheavy <= avgVeloc)
            {
                this.addCount(ActivityLevels.VERYVIGOROUS);
            }

            this.avarageBuffer.Clear();
        }

        public void NewDay()
        {
            return;
        }

        public ActivityLevel getActivityLevel(ActivityLevels level)
        {
            foreach (ActivityLevel alevel in this.activityLevels)
            {
                if (alevel.Level == level)
                {
                    if (this.model.Count != 0)
                    {
                        alevel.Percent = (alevel.Count / (this.model.Count / (double) this.Steps)) * 100.0;
                    }
                    return alevel;
                }
            }

            throw new Exception("Unsupported activitylevel" + level.ToString());
        }

        private void addCount(ActivityLevels level)
        {
            foreach (ActivityLevel alevel in this.activityLevels)
            {
                if (alevel.Level == level) 
                {
                    alevel.Count++;
                    return;
                }
            }
        }
    }
}
