using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;

using ActigraphAuswertung.Model;
using ActigraphAuswertung.Model.Storage;

namespace ActigraphAuswertung.Model
{
    /// <summary>
    /// Temporary List of CsvModels to make the model working with the generic interfaces 
    /// </summary>
    public class CsvModelList : BindingList<CsvModel>,IStorage<RowEntry>
    {

        public void Add(string dataSetID, RowEntry dataRow)
        {
            foreach (CsvModel model in this)
            {
                if (model.ID == dataSetID)
                {
                    model.Add(dataRow);
                }
            }
            CsvModel newModel = new CsvModel();
            newModel.ID = dataSetID;
            this.Add(newModel);
            newModel.Add(dataRow);
        }

        /// <summary>
        /// Returns the CsvModel with the given ID. If it does not already exists,
        /// it is created, added to the CsvModelList and then returned.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CsvModel getDataCollection(string dataSetID)
        {
            foreach (CsvModel model in this)
            {
                if (model.ID == dataSetID)
                {
                    return model;
                }
            }
            CsvModel newModel = new CsvModel();
            newModel.ID = dataSetID;
            this.Add(newModel);
            return newModel;
        }



        // Lock CsvModel with given ID.
        public void lockData(string id)
        {
            foreach (CsvModel model in this)
            {
                if (model.ID == id)
                {
                    model.Locked = true;
                    return;
                }
            }
        }

        // Test if CsvModel with given ID exists in CsvModelList
        public bool exists(string id)
        {
            foreach (CsvModel model in this)
            {
                if (model.ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns, whether requested CsvModel is locked.
        /// </summary>
        /// <param name="id">Requested CsvModel-ID.</param>
        /// <returns>true if locked. false if not locked.</returns>
        /// <exception cref="Exception">If given ID is not found in current CsvModelCollection.</exception>
        public bool locked(string id)
        {
            foreach (CsvModel model in this)
            {
                if (model.ID == id)
                {
                    return model.Locked;
                }

            }

            throw new Exception("Requested CsvModel does not exist!");
        }
    }
}
