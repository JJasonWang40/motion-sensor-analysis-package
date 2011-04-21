using System;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Filter.Filters
{
    /// <summary>
    /// Time based filter
    /// </summary>
    class Time : FilterInterface
    {
        // The time the row must be bigger then
        private TimeSpan startTime;

        // The time the row must be smaller then
        private TimeSpan endTime;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startTime">The time the row must be bigger then</param>
        /// <param name="endTime">The time the row must be smaller then</param>
        public Time(TimeSpan startTime, TimeSpan endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }

        /// <summary>
        /// Returns the filter function
        /// </summary>
        /// <returns>The filter function</returns>
        public Func<RowEntry, bool> Filter()
        {
            // Func: return true if row's TimeOfDay is smaller then endTime and larger then startTime
            return new Func<RowEntry, bool>(s => (s.Date.TimeOfDay > this.startTime) && (s.Date.TimeOfDay < this.endTime));
        }

        public bool filter(RowEntry entry)
        {
            return ((entry.Date.TimeOfDay > this.startTime) && (entry.Date.TimeOfDay < this.endTime));
        }
    }
}
