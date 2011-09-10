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
        private int primaryFilesKey;

        public bool locked;

        private string id;

        public string ID 
        {
            get{return this.id;}
            set { this.id = value; }
        }

        private int count;

        public int Count
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

        public TimeSpan EpochPeriod
        {
            get
            {
                return this.EndDate - this.StartDate;
            }
        }

        public DateTime StartDate
        {
            get 
            {
                SQLiteDataReader reader = getData();
                reader.Read();
                String date = reader.GetString(reader.GetOrdinal("Date"));
                return DateTime.Parse(date);
            }
        }

        public DateTime EndDate
        {
            get
            {
                SQLiteDataReader reader = getData();
                for (int i = 0; i != Count; i++)
                {
                    reader.Read();
                }
                String date = reader.GetString(reader.GetOrdinal("Date"));
                return DateTime.Parse(date);
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

        public DatabaseDataSet(){}

        #region writer
        public void lockData()
        {
            Program.storage.executeSQLCommand(("update files set Locked=1 where FileHash='" + this.ID+"'"));
        }

        public void Add(IDataRow dataRow)
        {
            if (!Program.storage.locked(this.ID))
            {
                SQLiteDataReader reader = Program.storage.readDataBase("select * from files where FileHash='" + this.ID+"'");
                reader.Read();
                String vorne, hinten;
                vorne = "insert into dataset(files";
                hinten = ") Values(" + reader.GetInt32(reader.GetOrdinal("key"));
                for (int i=0;i!=SupportedValues.Length;i++)
                {
                    switch (SupportedValues[i])
                    {
                        case SensorData.Date:
                            vorne = vorne + ", Date";
                            hinten = hinten + ", '" + dataRow.Date +"'";
                            break;
                        case SensorData.Activity:
                            vorne = vorne + ", Activity";
                            hinten = hinten + ", " + dataRow.Activity;
                            break;
                        case SensorData.ActivityY:
                            vorne = vorne + ", ActivityY";
                            hinten = hinten + ", " + dataRow.ActivityY;
                            break;
                        case SensorData.ActivityZ:
                            vorne = vorne + ", ActivityZ";
                            hinten = hinten + ", " + dataRow.ActivityZ;
                            break;
                        case SensorData.Inclinometer:
                            vorne = vorne + ", Incilometer";
                            hinten = hinten + ", " + dataRow.Inclinometer;
                            break;
                        case SensorData.Steps:
                            vorne = vorne + ", Steps";
                            hinten =hinten + ", " + dataRow.Steps;
                            break;
                        case SensorData.Vmu:
                            vorne = vorne + ", VMU";
                            hinten = hinten + ", " + dataRow.Vmu;
                            break;
                        case SensorData.CaloriesActivity:
                            vorne = vorne +", CaloriesActivity";
                            hinten = hinten + ", '"+dataRow.CaloriesActivity+"'";
                            break;
                        case SensorData.CaloriesTotal:
                            vorne = vorne + ", CaloriesTotal";
                            hinten = hinten + ", '"+dataRow.CaloriesTotal+"'";
                            break;
                    }
                }
                Program.storage.executeSQLCommand(vorne + hinten + ")");
                //Program.storage.executeSQLCommand("insert into dataset(files) Values("+ reader.GetInt32(reader.GetOrdinal("key")) + ")");
            }
            else { throw new Exception("Model already finished. Can't add new datasets"); };
        }

        public void AddNewFile()
        {
            Program.storage.executeSQLCommand("insert into files (FileHash, Locked, Steuercode) VALUES('" + this.ID + "', 0, "+generateSteuerCode()+")");
        }

        public void finishImport()
        {
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

        public void startReading()
        {
            tmpReader = getData();
        }

        public RowEntry getNextRow()
        {
            if (tmpReader == null)
            {
                startReading();
            }
            tmpReader.Read();
            RowEntry data = new RowEntry();
            for (int i = 0; i != SupportedValues.Length; i++)
            {
                switch (SupportedValues[i])
                {
                    case SensorData.Activity:
                        data.Activity = tmpReader.GetInt32(tmpReader.GetOrdinal("Activity"));
                        break;
                    case SensorData.ActivityY:
                        data.ActivityY = tmpReader.GetInt32(tmpReader.GetOrdinal("ActivityY"));
                        break;
                    case SensorData.ActivityZ:
                        data.ActivityZ = tmpReader.GetInt32(tmpReader.GetOrdinal("ActivityZ"));
                        break;
                    case SensorData.CaloriesActivity:
                        data.CaloriesActivity = tmpReader.GetFloat(tmpReader.GetOrdinal("CaloriesActivity"));
                        break;
                    case SensorData.CaloriesTotal:
                        data.CaloriesTotal = tmpReader.GetFloat(tmpReader.GetOrdinal("CaloriesTotal"));
                        break;
                    case SensorData.Date:
                        data.Date = DateTime.Parse(tmpReader.GetString(tmpReader.GetOrdinal("Date")));
                        break;
                    case SensorData.Inclinometer:
                        data.Inclinometer = tmpReader.GetInt32(tmpReader.GetOrdinal("Inclinometer"));
                        break;
                    case SensorData.Steps:
                        data.Steps = tmpReader.GetInt32(tmpReader.GetOrdinal("Steps"));
                        break;
                    case SensorData.Vmu:
                        data.Vmu = tmpReader.GetInt32(tmpReader.GetOrdinal("VMU"));
                        break;
                }
            }
            if (tmpReader.HasRows != true)
            {
                tmpReader = null;
            }
            return data;
        }

        public object readData(Boolean newline, SensorData target)
        {
            if (tmpReader == null)
            {
                tmpReader = getData();
            }
            if (newline == true)
            {
                tmpReader.Read();
            }
            if (tmpReader.HasRows != true)
            {
                tmpReader = null;
            }
            else
            {
                switch (target)
                {
                    case SensorData.Activity:
                        return tmpReader.GetInt32(tmpReader.GetOrdinal("Activity"));
                    case SensorData.ActivityY:
                        return tmpReader.GetInt32(tmpReader.GetOrdinal("ActivityY"));
                    case SensorData.ActivityZ:
                        return tmpReader.GetInt32(tmpReader.GetOrdinal("ActivityZ"));
                    case SensorData.CaloriesActivity:
                        return tmpReader.GetFloat(tmpReader.GetOrdinal("CaloriesActivity"));
                    case SensorData.CaloriesTotal:
                        return tmpReader.GetFloat(tmpReader.GetOrdinal("CaloriesTotal"));
                    case SensorData.Date:
                        return DateTime.Parse(tmpReader.GetString(tmpReader.GetOrdinal("Date")));
                    case SensorData.Inclinometer:
                        return tmpReader.GetInt32(tmpReader.GetOrdinal("Inclinometer"));
                    case SensorData.Steps:
                        return tmpReader.GetInt32(tmpReader.GetOrdinal("Steps"));
                    case SensorData.Vmu:
                        return tmpReader.GetInt32(tmpReader.GetOrdinal("Vmu"));
                }
            }
            return null;
        }

        public SQLiteDataReader getData()
        {
            SQLiteDataReader reader = Program.storage.readDataBase("select * from files where FileHash='" + this.ID + "'");
            reader.Read();
            return Program.storage.readDataBase("select * from dataset where files=" + reader.GetInt32(reader.GetOrdinal("key")));
        }

        #endregion

        #region operations
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
