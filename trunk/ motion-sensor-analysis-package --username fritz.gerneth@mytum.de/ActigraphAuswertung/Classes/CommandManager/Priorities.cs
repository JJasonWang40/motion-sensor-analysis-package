using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActigraphAuswertung.CommandManager
{
    /// <summary>
    /// Possible prioritys for commands. Sortable (highest priority has value 10, lowest value 0).
    /// </summary>
    enum Priority  
    {
        VeryHigh = 10,
        High = 8,
        Medium = 5,
        Low = 2,
        VeryLow = 0
    };
}
