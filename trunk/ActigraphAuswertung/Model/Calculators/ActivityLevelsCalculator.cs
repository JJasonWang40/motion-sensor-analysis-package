using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActigraphAuswertung.Model.Calculators
{
    /// <summary>
    /// Calculator to calculate the activity levels of a model.
    /// </summary>
    public class ActivityLevelsCalculator : CalculatorInterface
    {
        /// <summary>
        /// Structure to save the absolute count and percent values of each activity level.
        /// </summary>
        /// <remarks>Must be class to change values reference based</remarks>
        public class ActivityLevel
        {
            /// <summary>
            /// The Activity level
            /// </summary>
            public ActivityLevels Level;

            /// <summary>
            /// The absolute count of intervals for this activity level.
            /// </summary>
            public int Count;

            /// <summary>
            /// The percent value for this activity level.
            /// </summary>
            public double Percent;
        }

        // the model
        private CsvModel model;

        // List of all activity levels and their counts
        private ActivityLevel[] activityLevels;

        /// <summary>
        /// The number of accumulated rows for each calculation step.
        /// </summary>
        public int Steps = 5;

        /// <summary>
        /// The lower limit for sendantary activity level.
        /// </summary>
        public int MinSedantary = 0;

        /// <summary>
        /// The lower limit for light activity level.
        /// </summary>
        public int MinLight = 200;

        /// <summary>
        /// The lower limit for moderate activity level.
        /// </summary>
        public int MinModerate = 2000;

        /// <summary>
        /// The lower limit for heavy activity level.
        /// </summary>
        public int MinHeavy = 5750;

        /// <summary>
        /// The lower limit for very heavy activity level.
        /// </summary>
        public int MinVeryheavy = 7500;

        // queue buffer for saving the last elements we take into consideration
        // when calculating the activity levels
        private Queue<RowEntry> averageBuffer = new Queue<RowEntry>();

        //counter, which indicates the number of values added to the average calculation
        private int averageCount = 0;

        //average variable
        double avgVeloc = 0;

        // supported values
        bool activityValueSupported;
        bool vmuValueSupported;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model">The model used for calculations</param>
        public ActivityLevelsCalculator(CsvModel model)
        {
            this.model = model;
            this.activityValueSupported = this.model.SupportedValues.Contains(SensorData.Activity);
            this.vmuValueSupported = this.model.SupportedValues.Contains(SensorData.Vmu);
            
            // set array of activity levels depending of the enum
            this.activityLevels = new ActivityLevel[Enum.GetNames(typeof(ActivityLevels)).Length];

            // set structures and set them to zero.
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

        /// <summary>
        /// Called by the model on a new entry.
        /// </summary>
        /// <param name="entry">The entry to be added</param>
        public void Add(RowEntry entry)
        {

            // Add activity value to average variable
            if (activityValueSupported)
            {
                this.avgVeloc += entry.Activity;
            }
            else if (vmuValueSupported)
            {
                this.avgVeloc += entry.Vmu;
            }
            else
            {
                return;
            }
            this.averageCount++;

            if (averageCount < this.Steps)
            {
                return;
            }
            else
            {
                avgVeloc /= this.Steps;
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
            else if (this.MinVeryheavy <= avgVeloc)
            {
                this.addCount(ActivityLevels.VERYVIGOROUS);
            }

            this.avgVeloc = 0;
            this.averageCount = 0;
        }



        /// <summary>
        /// Called by the model on a new day. Unused.
        /// </summary>
        public void NewDay()
        {
            return;
        }

        /// <summary>
        /// Gets the activity level information for the given activity level.
        /// </summary>
        /// <param name="level">The activity level to get the information for.</param>
        /// <returns>The activity level information</returns>
        /// <exception cref="Exception">If the given activity level is not supported.</exception>
        public ActivityLevel getActivityLevel(ActivityLevels level)
        {
            foreach (ActivityLevel alevel in this.activityLevels)
            {
                if (alevel.Level == level)
                {
                    if (this.model.Count != 0)
                    {
                        alevel.Percent = (alevel.Count / (this.model.Count / (double)this.Steps)) * 100.0;
                    }
                    return alevel;
                }
            }

            throw new Exception("Unsupported activitylevel" + level.ToString());
        }

        // Helper function to add one count to a given activity level.
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
