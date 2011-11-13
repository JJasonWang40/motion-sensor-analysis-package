using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActigraphAuswertung.Model.Storage;
using System.Data.SQLite;
using System.Collections;

namespace ActigraphAuswertung.Model
{
    public class DatabaseDataSet:IDataSet
    {

        #region values
        private SQLiteDataReader tmpReader;

        StringBuilder sb, vorne, hinten;
        
        protected int primaryFilesKey;

        public bool locked;

        private string id;

        public string ID 
        {
            get{return this.id;}
            set { this.id = value; }
        }

        protected int count;

        public virtual int Count
        {
            get
            {
                if (count == 0)
                {
                    this.count = countRows();
                }
                return count;
            }
        }

        public virtual TimeSpan EpochPeriod
        {
            get
            {
                return this.EndDate - this.StartDate;
            }
        }

        public virtual Boolean isFiltered
        {
            get
            {
                return false;
            }
        }

        public virtual DateTime StartDate
        {
            get 
            {
                SQLiteDataReader reader = getData();
                reader.Read();
                return DateTime.Parse(reader.GetString(reader.GetOrdinal("Date")));
            }
        }

        public virtual DateTime EndDate
        {
            get
            {
                SQLiteDataReader reader = getData();
                for (int i = 0; i != Count; i++)
                {
                    reader.Read();
                }
                return DateTime.Parse(reader.GetString(reader.GetOrdinal("Date")));
            }
        }

        private String absoluteFileName = null;

        /// <summary>
        /// Absolute path to the file including the filename.
        /// </summary>
        public String AbsoluteFileName
        {
            get { return this.absoluteFileName; }
            set { this.absoluteFileName = value; }
        }

        private String Name = null;

        public String FileName
        {
            get
            {
                if (this.Name == null && this.AbsoluteFileName != null)
                {
                    String[] t = this.AbsoluteFileName.Split('\\');
                    this.Name = t.Last();
                }
                return this.Name;
            }
        }

        public SensorData[] SupportedValues = null;
        #endregion

        public DatabaseDataSet(){
            sb= new StringBuilder();
            vorne = new StringBuilder();
            hinten = new StringBuilder();
        }

        #region writer
        public virtual void lockData()
        {
            this.locked = true;
            Program.storage.executeSQLCommand(("update files set Locked=1 where FileHash='" + this.ID+"'"));
        }

        public virtual void Add(IDataRow dataRow)
        {
            if (!Program.storage.locked(this.ID))
            {
                SQLiteDataReader reader = Program.storage.readDataBase("select * from files where FileHash='" + this.ID+"'");
                reader.Read();
                vorne.Append("insert into dataset(files");
                hinten.Append(") Values(" + reader.GetInt32(reader.GetOrdinal("key")));
                for (int i=0;i!=SupportedValues.Length;i++)
                {
                    switch (SupportedValues[i])
                    {
                        case SensorData.Date:
                            vorne.Append(", Date");
                            hinten.Append(", '");
                            hinten.Append(dataRow.Date);
                            hinten.Append("'");
                            break;
                        case SensorData.Activity:
                            vorne.Append(", Activity");
                            hinten.Append(", ");
                            hinten.Append(dataRow.Activity);
                            break;
                        case SensorData.ActivityY:
                            vorne.Append(", ActivityY");
                            hinten.Append(", ");
                            hinten.Append(dataRow.ActivityY);
                            break;
                        case SensorData.ActivityZ:
                            vorne.Append(", ActivityZ");
                            hinten.Append(", ");
                            hinten.Append(dataRow.ActivityZ);
                            break;
                        case SensorData.Inclinometer:
                            vorne.Append(", Incilometer");
                            hinten.Append(", ");
                            hinten.Append(dataRow.Inclinometer);
                            break;
                        case SensorData.Steps:
                            vorne.Append(", Steps");
                            hinten.Append(", ");
                            hinten.Append(dataRow.Steps);
                            break;
                        case SensorData.Vmu:
                            vorne.Append(", VMU");
                            hinten.Append(", ");
                            hinten.Append(dataRow.Vmu);
                            break;
                        case SensorData.CaloriesActivity:
                            vorne.Append(", CaloriesActivity");
                            hinten.Append(", '");
                            hinten.Append(dataRow.CaloriesActivity);
                            hinten.Append("'");
                            break;
                        case SensorData.CaloriesTotal:
                            vorne.Append(", CaloriesTotal");
                            hinten.Append(", '");
                            hinten.Append(dataRow.CaloriesTotal);
                            hinten.Append("'");
                            break;
                    }
                }
                Program.storage.executeSQLCommand(vorne.ToString()+hinten.ToString()+");");
                //sb.Append(vorne.ToString() + hinten.ToString()+");");
                vorne.Remove(0,vorne.Length);
                hinten.Remove(0,hinten.Length);
            }
            else { throw new Exception("Model already finished. Can't add new datasets"); };
        }

        public void AddNewFile()
        {
            Program.storage.executeSQLCommand("insert into files (FileHash, Locked, Steuercode) VALUES('" + this.ID + "', 0, "+generateSteuerCode()+")");
            Program.storage.executeSQLCommand("begin");
        }

        public virtual void finishImport()
        {
            sb.Append("commit;");
            Program.storage.executeSQLCommand(sb.ToString());
            lockData();
            loadData();
        }
        #endregion

        #region reader
        public void loadData()
        {
            SQLiteDataReader reader = Program.storage.readDataBase("select * from files where FileHash='"+this.ID+"'");
            reader.Read();
            if (SupportedValues == null)
            {
               SupportedValues = parseSteuerCode(reader.GetInt32(reader.GetOrdinal("Steuercode")));
            }
            primaryFilesKey = reader.GetInt32(reader.GetOrdinal("key"));
        }

        public virtual void startReading()
        {
            this.tmpReader = getData();
        }

        public virtual RowEntry getNextRow()
        {
            this.tmpReader.Read();
            RowEntry data = new RowEntry();
            for (int i = 0; i != SupportedValues.Length; i++)
            {
                switch (SupportedValues[i])
                {
                    case SensorData.Activity:
                        data.Activity = this.tmpReader.GetInt32(this.tmpReader.GetOrdinal("Activity"));
                        break;
                    case SensorData.ActivityY:
                        data.ActivityY = this.tmpReader.GetInt32(this.tmpReader.GetOrdinal("ActivityY"));
                        break;
                    case SensorData.ActivityZ:
                        data.ActivityZ = this.tmpReader.GetInt32(this.tmpReader.GetOrdinal("ActivityZ"));
                        break;
                    case SensorData.CaloriesActivity:
                        data.CaloriesActivity = this.tmpReader.GetFloat(this.tmpReader.GetOrdinal("CaloriesActivity"));
                        break;
                    case SensorData.CaloriesTotal:
                        data.CaloriesTotal = this.tmpReader.GetFloat(this.tmpReader.GetOrdinal("CaloriesTotal"));
                        break;
                    case SensorData.Date:
                        data.Date = DateTime.Parse(this.tmpReader.GetString(this.tmpReader.GetOrdinal("Date")));
                        break;
                    case SensorData.Inclinometer:
                        data.Inclinometer = this.tmpReader.GetInt32(this.tmpReader.GetOrdinal("Inclinometer"));
                        break;
                    case SensorData.Steps:
                        data.Steps = this.tmpReader.GetInt32(this.tmpReader.GetOrdinal("Steps"));
                        break;
                    case SensorData.Vmu:
                        data.Vmu = this.tmpReader.GetInt32(this.tmpReader.GetOrdinal("VMU"));
                        break;
                }
            }
            return data;
        }

        public virtual void read()
        {
            this.tmpReader.Read();
        }

        public virtual object getNextValue(SensorData target)
        {
            read();
            return getValue(target);
        }

        public virtual object getValue(SensorData target)
        {
            switch (target)
            {
                case SensorData.Activity:
                    return this.tmpReader.GetInt32(this.tmpReader.GetOrdinal("Activity"));
                case SensorData.ActivityY:
                    return this.tmpReader.GetInt32(this.tmpReader.GetOrdinal("ActivityY"));
                case SensorData.ActivityZ:
                    return this.tmpReader.GetInt32(this.tmpReader.GetOrdinal("ActivityZ"));
                case SensorData.CaloriesActivity:
                    return this.tmpReader.GetFloat(this.tmpReader.GetOrdinal("CaloriesActivity"));
                case SensorData.CaloriesTotal:
                    return this.tmpReader.GetFloat(this.tmpReader.GetOrdinal("CaloriesTotal"));
                case SensorData.Date:
                    return DateTime.Parse(this.tmpReader.GetString(this.tmpReader.GetOrdinal("Date")));
                case SensorData.Inclinometer:
                    return this.tmpReader.GetInt32(this.tmpReader.GetOrdinal("Inclinometer"));
                case SensorData.Steps:
                    return this.tmpReader.GetInt32(this.tmpReader.GetOrdinal("Steps"));
                case SensorData.Vmu:
                    return this.tmpReader.GetInt32(this.tmpReader.GetOrdinal("VMU"));
                default:
                    return null;
            }
        }

        public virtual SQLiteDataReader getData()
        {
            return Program.storage.readDataBase("select * from dataset where files=" + primaryFilesKey);
        }

        public virtual void endReading()
        {
            this.tmpReader = null;
        }
        #endregion

        #region operations
        public Boolean valueSupported(SensorData target)
        {
            for (int i = 0; i != SupportedValues.Length; i++)
            {
                if (SupportedValues[i] == target) return true;
            }
            return false;
        }

        public int countRows()
        {
            tmpReader = getData();
            int back=-1;
            while (tmpReader.HasRows)
            {
                back +=1;
                tmpReader.Read();
            }
            tmpReader = null;
            return back;
        }

        public int generateSteuerCode(){
            int code = 0;
            for (int i = 0; i != SupportedValues.Length; i++)
            {
                switch (SupportedValues[i])
                {
                    case SensorData.Date:
                        code += 1;
                        break;
                    case SensorData.Activity:
                        code += 10;
                        break;
                    case SensorData.ActivityY:
                        code += 100;
                        break;
                    case SensorData.ActivityZ:
                        code += 1000;
                        break;
                    case SensorData.Vmu:
                        code += 10000;
                        break;
                    case SensorData.Steps:
                        code += 100000;
                        break;
                    case SensorData.Inclinometer:
                        code += 1000000;
                        break;
                    case SensorData.CaloriesTotal:
                        code += 10000000;
                        break;
                    case SensorData.CaloriesActivity:
                        code += 100000000;
                        break;
                }
            }
            return code;
        }

        public SensorData[] parseSteuerCode(int code)
        {
            ArrayList tmp = new ArrayList();
            SensorData[] tmpReverse;
            for (int i = 100000000; i != 0; )
            {
                int erg = code / i;
                if (erg == 1)
                {
                    switch (i)
                    {
                        case 100000000: 
                            tmp.Add(SensorData.CaloriesActivity);
                            break;
                        case 10000000: 
                            tmp.Add(SensorData.CaloriesTotal);
                            break;
                        case 1000000: 
                            tmp.Add(SensorData.Inclinometer);
                            break;
                        case 100000: 
                            tmp.Add(SensorData.Steps);
                            break;
                        case 10000: 
                            tmp.Add(SensorData.Vmu);
                            break;
                        case 1000: 
                            tmp.Add(SensorData.ActivityZ);
                            break;
                        case 100: 
                            tmp.Add(SensorData.ActivityY);
                            break;
                        case 10: 
                            tmp.Add(SensorData.Activity);
                            break;
                        case 1: 
                            tmp.Add(SensorData.Date);
                            break;
                    }
                    code = code - i;
                }
                i = i / 10;
            }
            tmpReverse = new SensorData[tmp.Count];
            tmp.Reverse();
            for (int i = 0; i != tmp.Count; i++)
            {
                tmpReverse[i] = (SensorData)tmp[i];
            }   
            return tmpReverse;
        }
        
        #endregion

    }
}
