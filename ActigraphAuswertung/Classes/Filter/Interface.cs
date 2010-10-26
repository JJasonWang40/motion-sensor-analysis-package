using System;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Filter
{
    /// <summary>
    /// Interface for all filter implementations.
    /// </summary>
    public interface FilterInterface
    {
        Func<RowEntry, bool> Filter();
    }
}
