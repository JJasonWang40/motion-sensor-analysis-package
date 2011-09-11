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
        public void filter(DatabaseDataSet input, FilteredDatabaseDataSet target, FilterMethod method)
        {
            // Check for empty collection as linq throws exceptions on empty results
            if (this.Count == 0)
            {
                return;
            }

            int lowerLimit=0, upperLimit=0, count=input.Count;

            input.startReading();

            // different concatinations for the different filter methods
            switch (method)
            {
                // All rows where any filter returns true 
                case FilterMethod.EITHER:
                    {
                        for (int i=1; i!= count; i++)
                        {
                            RowEntry entry = input.getNextRow();
                            foreach (FilterInterface filterType in this)
                            {
                                if (filterType.filter(entry))
                                {
                                    target.Add(entry);
                                    break;
                                }
                            }

                        }
                    }
                    break;

                // No rows where any filter returns true
                case FilterMethod.NONE:
                {
                    bool noFilterApplies;
                    for (int i = 1; i != count; i++)
                    {
                        RowEntry entry = input.getNextRow();
                        noFilterApplies = true;
                        foreach (FilterInterface filterType in this)
                        {
                            if (filterType.filter(entry))
                            {
                                noFilterApplies = false;
                                break;
                            }
                        }
                        if (noFilterApplies) 
                        {
                            target.Add(entry);
                        }
                    }
                }
                break;

                // case FilterMethod.All
                // to ensure result is always set
                // All rows where all filter return true
                default:
                {
                    bool allFilterApply;
                    for (int i = 1; i != count; i++)
                    {
                        RowEntry entry = input.getNextRow();
                        allFilterApply = true;
                        foreach (FilterInterface filterType in this)
                        {
                            if (!filterType.filter(entry))
                            {
                                allFilterApply = false;
                                break;
                            }
                        }
                        if (allFilterApply)
                        {
                            target.Add(entry);
                        }
                    }
                }
                break;
            }

            input.endReading();

            // add all matching rows to the target
            
        }
    }
}
