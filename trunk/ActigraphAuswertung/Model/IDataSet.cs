using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActigraphAuswertung.Model
{
    interface IDataSet
    {
        //void addDataSet(IDataSet dataSet);
        //IDataSet getDataSet(int index);
        string ID { get; }

        TimeSpan EpochPeriod { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }
    }
}
