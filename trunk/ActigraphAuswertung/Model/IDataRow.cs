using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActigraphAuswertung.Model
{
    interface IDataRow
    {
        DateTime Date { get; set; }
        int Activity { get; set; }
        int ActivityY { get; set; }
        int ActivityZ { get; set; }
        int Vmu { get; set; }
        int Steps { get; set; }
        int Inclinometer { get; set; }
        float CaloriesTotal { get; set; }
        float CaloriesActivity { get; set; }
    }
}
