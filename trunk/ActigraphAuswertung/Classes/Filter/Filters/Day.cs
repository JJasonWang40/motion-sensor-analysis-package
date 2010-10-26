using System;
using System.Collections.Generic;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Filter.Filters
{
    /// <summary>
    /// Filter where every row must be within a list of days
    /// </summary>
    class Day : FilterInterface
    {
        // The list of days the rows must be within
        private List<DateTime> days;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="days">The list of days the rows must be within</param>
        public Day(List<DateTime> days)
        {
            this.days = days;
        }

        /// <summary>
        /// Returns the filter function
        /// </summary>
        /// <returns>The filter function</returns>
        public Func<RowEntry, bool> Filter()
        {
            // Func: return true if the row's date is within (this.)days
            return new Func<RowEntry, bool>(s => this.days.Contains(s.Date.Date));
        }
    }
}
