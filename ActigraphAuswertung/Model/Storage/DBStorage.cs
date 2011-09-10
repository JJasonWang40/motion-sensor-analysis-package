using System;
using System.Data;
using System.IO;
using System.Data.SQLite;


namespace ActigraphAuswertung.Model.Storage
{
    class DBStorage:IStorage<DatabaseRow>
    {	
        
        private String databasename;
        private SQLiteConnection sqlite = new SQLiteConnection();

        public DBStorage(){
            this.databasename = "Actigraph.sqlite";
            if (File.Exists(databasename)){
                etablishconnection();
                
            }
            else {
                etablishconnection();
                generatenewdatabase(); };
        }

        private void etablishconnection()
        {
            sqlite.ConnectionString = "Data Source="+databasename;
            sqlite.Open();
        }

        private void generatenewdatabase(){
            SQLiteCommand sqlCommand = sqlite.CreateCommand();
            sqlCommand.CommandText = "create table files(key integer PRIMARY KEY AUTOINCREMENT, FileHash String not null, Locked BOOLEAN, Steuercode integer)";
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = "create table dataset(key integer PRIMARY KEY AUTOINCREMENT, files integer not null, Date String, Activity integer, ActivityY integer, ActivityZ integer, Incilometer integer, Steps integer, VMU integer, CaloriesActivity float, CaloriesTotal float, FOREIGN KEY(files) REFERENCES files(key))";
            sqlCommand.ExecuteNonQuery();
        }

        public DatabaseDataSet getDataSet(String datasetID)
        {
            DatabaseDataSet dataset = new DatabaseDataSet();
            dataset.ID = datasetID;
            if (exists(datasetID))
            {
                dataset.locked = true;
            }
            else
            {
                dataset.locked = false;
            }
            return dataset;
        }

        public bool exists(string dataSetID)
        {
            SQLiteCommand sqlCommand = sqlite.CreateCommand();           
            sqlCommand.CommandText = "select * from files where FileHash='" + dataSetID+"'";
            SQLiteDataReader sqlreader = sqlCommand.ExecuteReader();
            return sqlreader.HasRows;
           
        }

        public bool locked(string dataSetID)
        {
            SQLiteCommand sqlCommand = sqlite.CreateCommand();
            sqlCommand.CommandText = "select * from files where FileHash='" + dataSetID + "' AND Locked=1";
            SQLiteDataReader sqlreader = sqlCommand.ExecuteReader();
            return sqlreader.HasRows;
        }

        #region executeQuerry
        public bool executeStatementHashRows(String command)
        {
            SQLiteCommand sqlCommand = sqlite.CreateCommand();
            sqlCommand.CommandText = command;
            return (sqlCommand.ExecuteReader()).HasRows;
        }

        public SQLiteDataReader readDataBase(String command)
        {
            SQLiteCommand sqlCommand = sqlite.CreateCommand();
            sqlCommand.CommandText = command;
            return sqlCommand.ExecuteReader();
        }

        public void executeSQLCommand (String command)
        {
                SQLiteCommand sqlCommand = sqlite.CreateCommand();
                sqlCommand.CommandText = command;
                sqlCommand.ExecuteNonQuery();
        }
        #endregion

        public void lockData(string dataSetID)
        {
            //SQLiteCommand sqlCommand = sqlite.CreateCommand();
            //sqlCommand.CommandText = "update files set Locked=1 where FileHash=" + dataSetID;
            //sqlCommand.ExecuteNonQuery();
        }

        public void Add(string dataSetID, DatabaseRow dataRow)
        {
            //SQLiteCommand sqlCommand = sqlite.CreateCommand();
            //if (!locked(dataSetID))
            //{
            //    sqlCommand.CommandText = "select * from files where FileHash=" + dataSetID;
              //  SQLiteDataReader sqlreader = sqlCommand.ExecuteReader();
                //sqlCommand.CommandText = "insert into dataset(files, Date, Activity, ActivityY, ActivityZ, Incilometer, Steps, VMU, CaloriesActivity, CaloriesTotal) Values(" + sqlreader.GetInt32(sqlreader.GetOrdinal("key"))+ ", '" + dataRow.Date + "', " + dataRow.Activity + ", " + dataRow.ActivityY + ", " + dataRow.ActivityZ + ", " + dataRow.Inclinometer + ", " + dataRow.Steps + ", " + dataRow.Vmu + ", " + dataRow.CaloriesActivity + ", " + dataRow.CaloriesTotal + ")";
                //sqlCommand.ExecuteNonQuery();
            //}
            //else { throw new Exception("Model already finished. Can't add new datasets"); };
        }

        public void AddNewFile(string dataSetID)
        {
            //SQLiteCommand sqlCommand = sqlite.CreateCommand();
            //System.Data.SQLite.SQLiteCommand sql = sqlite.CreateCommand();
            //sql.CommandText = "insert into files (FileHash, Locked) VALUES('" + dataSetID + "', 0)";
            //sql.ExecuteNonQuery();
        }

    }
}
