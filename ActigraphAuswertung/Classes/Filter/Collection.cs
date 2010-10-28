using System.Collections.Generic;
using System.Linq;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Filter
{
    /// <summary>
    /// Possible filter methods.
    /// </summary>
    public enum FilterMethod { 
        /// <summary>
        /// All applied filters must be true.
        /// </summary>
        ALL, 

        /// <summary>
        /// At least one of the applied filters must be true.
        /// </summary>
        EITHER, 

        /// <summary>
        /// None of the applied filters must be true.
        /// </summary>
        NONE 
    };

    /// <summary>
    /// A List of filters that a model can be applied to.
    /// </summary>
    public class FilterCollection : List<FilterInterface>
    {
        /// <summary>
        /// Filters a model into a target using this filter-collection.
        /// </summary>
        /// <param name="input">The source model</param>
        /// <param name="target">The target model</param>
        /// <param name="method">The filter method</param>
        public void filter(CsvModel input, CsvModel target, FilterMethod method)
        {
            // Check for empty collection as linq throws exceptions on empty results
            if (this.Count == 0)
            {
                return;
            }

            // prepare source and result as queryables
            IQueryable<RowEntry> queryable = input.AsQueryable();
            IQueryable<RowEntry> result;

            // different concatinations for the different filter methods
            switch (method)
            {
                // All rows where any filter returns true 
                case FilterMethod.EITHER:
                    result = queryable.Where(s => this.AsQueryable().Any(f => f.Filter()(s)));
                break;

                // No rows where any filter returns true
                case FilterMethod.NONE:
                    result = queryable.Where(s => !this.AsQueryable().Any(f => f.Filter()(s)));
                break;

                // case FilterMethod.All
                // to ensure result is always set
                // All rows where all filter return true
                default:
                    result = queryable.Where(s => this.AsQueryable().All(f => f.Filter()(s)));
                break;
            }

            // add all matching rows to the target
            foreach(RowEntry t in result)
            {
                target.Add(t);
            }
        }
    }
}
