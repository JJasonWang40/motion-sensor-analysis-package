using System;

namespace ActigraphAuswertung.Model
{
    /// <summary>
    /// Represents one row entry of the model.
    /// </summary>
    public class RowEntry
    {
        private DateTime date;

        /// <summary>
        /// Date and time of the entry.
        /// </summary>
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        private int activity = 0;

        /// <summary>
        /// The activity(X) of the entry.
        /// </summary>
        public int Activity
        {
            get { return this.activity; }
            set { this.activity = value; }
        }

        private int activityY = 0;

        /// <summary>
        /// The Y-Activity of the entry.
        /// </summary>
        public int ActivityY
        {
            get { return this.activityY; }
            set { this.activityY = value; }
        }

        private int activityZ = 0;

        /// <summary>
        /// The Z-Activity of the entry.
        /// </summary>
        public int ActivityZ
        {
            get { return this.activityZ; }
            set { this.activityZ = value; }
        }

        private int vmu = 0;

        /// <summary>
        /// The Vmu of the entry.
        /// </summary>
        public int Vmu
        {
            get { return this.vmu; }
            set { this.vmu = value; }
        }

        private int steps = 0;

        /// <summary>
        /// The Steps of the entry.
        /// </summary>
        public int Steps
        {
            get { return this.steps; }
            set { this.steps = value; }
        }

        private int inclinometer = 0;

        /// <summary>
        /// The inclinometer of the value.
        /// </summary>
        public int Inclinometer
        {
            get { return this.inclinometer; }
            set { this.inclinometer = value; }
        }

        private float caloriesTotal = 0;

        /// <summary>
        /// The total calories of the entry.
        /// </summary>
        public float CaloriesTotal
        {
            get { return this.caloriesTotal; }
            set { this.caloriesTotal = value; }
        }

        private float caloriesActivity = 0;

        /// <summary>
        /// The activity calories of the entry.
        /// </summary>
        public float CaloriesActivity
        {
            get { return this.caloriesActivity; }
            set { this.caloriesActivity = value; }
        }

        /// <summary>
        /// Sets the <paramref name="entry"/> of the entry to <paramref name="value"/>.
        /// </summary>
        /// <param name="entry">The key to set</param>
        /// <param name="value">The value to set the key to</param>
        /// <exception cref="Exception">If the entry does not support the key.</exception>
        public void setValue(SensorData entry, String value)
        {
            switch (entry)
            {
                case SensorData.Date:
                    this.Date = DateTime.Parse(value);
                    break;

                case SensorData.Activity:
                    this.Activity = int.Parse(value);
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

        /// <summary>
        /// Gets the value of <paramref name="entry"/> or null if not found.
        /// </summary>
        /// <param name="entry">The key to search for.</param>
        /// <returns>The value of <paramref name="entry"/></returns>
        public Object getValue(SensorData entry)
        {
            switch (entry)
            {
                case SensorData.Activity:
                    return this.Activity;

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
}
