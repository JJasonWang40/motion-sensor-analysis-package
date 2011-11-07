using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.ComponentModel;

namespace ActigraphAuswertung.Model
{
    public class FilteredDatabaseDataSet :DatabaseDataSet
    {
        #region values
        public override int Count
        {
            get
            {
                return data.Count;
            }
        }

        public override DateTime EndDate
        {
            get
            {
                return data.Last().Date;
            }
        }

        public override DateTime StartDate
        {
            get
            {
                return data.First().Date;
            }
        }

        public override TimeSpan EpochPeriod
        {
            get
            {
                return EndDate-StartDate;
            }
        }

        public override Boolean isFiltered
        {
            get
            {
                return true;
            }
        }

        private int currentRow = -1;

        private BindingList<IDataRow> data = new BindingList<IDataRow>();
        #endregion

        public FilteredDatabaseDataSet(SensorData[] SupportedValues)
        {
            this.SupportedValues = SupportedValues;
        }

        #region writer
        public override void finishImport()
        {
            lockData();
        }

        public override void lockData()
        {
            this.locked = true;
        }

        public override void Add(IDataRow dataRow)
        {
            data.Add(dataRow);
        }
        #endregion

        #region reader
        public BindingList<IDataRow> getData()
        {
            return data;
        }

        public override void startReading()
        {
            this.currentRow=0;
        }

        public override void read()
        {
            this.currentRow+=1;
        }

        public override object getNextValue(SensorData target)
        {
            read();
            return getValue(target);
        }

        public override object getValue(SensorData target)
        {
            switch (target)
            {
                case SensorData.Activity:
                    return this.data.ToArray()[currentRow].Activity;
                case SensorData.ActivityY:
                    return this.data.ToArray()[currentRow].ActivityY;
                case SensorData.ActivityZ:
                    return this.data.ToArray()[currentRow].ActivityZ;
                case SensorData.CaloriesActivity:
                    return this.data.ToArray()[currentRow].CaloriesActivity;
                case SensorData.CaloriesTotal:
                    return this.data.ToArray()[currentRow].CaloriesTotal;
                case SensorData.Date:
                    return this.data.ToArray()[currentRow].Date;
                case SensorData.Inclinometer:
                    return this.data.ToArray()[currentRow].Inclinometer;
                case SensorData.Steps:
                    return this.data.ToArray()[currentRow].Steps;
                case SensorData.Vmu:
                    return this.data.ToArray()[currentRow].Vmu;
                default:
                    return null;
            }
        }

        public override void endReading()
        {
            this.currentRow=0;
        }

        public override RowEntry getNextRow()
        {
            currentRow += 1;
            return (RowEntry)(data.ToArray())[currentRow];
        }
        #endregion
    }
}
