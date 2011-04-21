using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Model.Storage
{
    interface IStorage<T> where T : IDataRow
    {
        void lockData(string id);

        bool exists(string id);
        bool locked(string id);

        void Add(string dataSetID, T dataRow);

        //IDataSet getDataCollection(string id);
    }
}
