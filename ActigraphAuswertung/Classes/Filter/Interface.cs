using System;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Filter
{
    /// <summary>
    /// Interface for all filter implementations.
    /// </summary>
    public interface FilterInterface
    {
        /// <summary>
        /// Get the created filter function.
        /// </summary>
        /// <returns></returns>
        Func<RowEntry, bool> Filter();
    }
}
