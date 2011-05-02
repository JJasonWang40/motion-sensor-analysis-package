using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActigraphAuswertung.Model.Storage
{
    class DatabaseRow:IDataRow
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

        private int activity;

        /// <summary>
        /// The activity(X) of the entry.
        /// </summary>
        public int Activity
        {
            get { return this.activity; }
            set { this.activity = value; }
        }

        private int activityY;

        /// <summary>
        /// The Y-Activity of the entry.
        /// </summary>
        public int ActivityY
        {
            get { return this.activityY; }
            set { this.activityY = value; }
        }

        private int activityZ;

        /// <summary>
        /// The Z-Activity of the entry.
        /// </summary>
        public int ActivityZ
        {
            get { return this.activityZ; }
            set { this.activityZ = value; }
        }

        private int vmu;

        /// <summary>
        /// The Vmu of the entry.
        /// </summary>
        public int Vmu
        {
            get { return this.vmu; }
            set { this.vmu = value; }
        }

        private int steps;

        /// <summary>
        /// The Steps of the entry.
        /// </summary>
        public int Steps
        {
            get { return this.steps; }
            set { this.steps = value; }
        }

        private int inclinometer;

        /// <summary>
        /// The inclinometer of the value.
        /// </summary>
        public int Inclinometer
        {
            get { return this.inclinometer; }
            set { this.inclinometer = value; }
        }

        private float caloriesTotal;

        /// <summary>
        /// The total calories of the entry.
        /// </summary>
        public float CaloriesTotal
        {
            get { return this.caloriesTotal; }
            set { this.caloriesTotal = value; }
        }

        private float caloriesActivity;

        /// <summary>
        /// The activity calories of the entry.
        /// </summary>
        public float CaloriesActivity
        {
            get { return this.caloriesActivity; }
            set { this.caloriesActivity = value; }
        }

        private int key;

        public int Key
        {
            get { return this.key; }
            set { this.key = value; }
        }

    }
}
