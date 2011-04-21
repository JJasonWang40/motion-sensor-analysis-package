using System;

namespace ActigraphAuswertung.Model
{
    /// <summary>
    /// Helper class to represent the activity start and end times of a day.
    /// </summary>
    public class SensorStartEndWearing
    {
        private DateTime startDate = new DateTime();
        private DateTime endDate = new DateTime();

        private DateTime date;

        /// <summary>
        /// Activity starttime of the day.
        /// </summary>
        public DateTime StartTime
        {
            get { return this.startDate; }
            set
            {
                this.startDate = value;

                if (this.date == null)
                {
                    this.date = value.Date;
                }
            }
        }

        /// <summary>
        /// Activity endtime of the day.
        /// </summary>
        public DateTime EndTime
        {
            get { return this.endDate; }
            set
            {
                this.endDate = value; ;

                if (this.date == null)
                {
                    this.date = value.Date;
                }
            }
        }

        /// <summary>
        /// Date of the day.
        /// </summary>
        public DateTime Date
        {
            get { return this.startDate.Date; }
        }

        /// <summary>
        /// Activity time of the day.
        /// </summary>
        public TimeSpan ActiveTime
        {
            get { return this.endDate - this.startDate; }
        }
    }
}
