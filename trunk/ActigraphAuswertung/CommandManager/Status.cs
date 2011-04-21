using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActigraphAuswertung.CommandManager
{
    /// <summary>
    /// Possible status states of a command. 
    /// </summary>
    enum Status
    { 
        Waiting,
        Running,
        Finished,
        Error,
        Cancelled
    }
}
