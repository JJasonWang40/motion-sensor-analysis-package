using System;
using System.Data;
using System.IO;
using System.Data.SQLite;


namespace ActigraphAuswertung.Model.Storage
{
    class DBStorage:IStorage<DatabaseRow>
    {	
        
        private String databasename = "Actigraph.sqlite";
        private SQLiteConnection sqllite = new SQLiteConnection();

        public DBStorage(){
            if (File.Exists(databasename)){
                etablisheconection();
                
            }
            else {
                etablisheconection();
                generatenewdatabase(); };
        }

        public void etablisheconection()
        {
            sqllite.ConnectionString = "Data Source="+databasename;
            sqllite.Open();
        }

        public void generatenewdatabase(){
            System.Data.SQLite.SQLiteCommand sql = sqllite.CreateCommand();
            sql.CommandText="create table files( key integer PRIMARY KEY AUTOINCREMENT, FileHash TEXT not null, Locked BOOLEAN)";
            sql.ExecuteNonQuery();
            sql.CommandText = "create table dataset(key integer PRIMARY KEY AUTOINCREMENT, files integer not null, Date DATE, Activity integer, ActivityY integer, ActivityZ integer, Incilometer integer, Steps integer, VMU integer, CaloriesActivity integer, CaloriesTotal integer, FOREIGN KEY(files) REFERENCES files(key))";
            sql.ExecuteNonQuery();
        }

        public void lockData(string id)
        {
            System.Data.SQLite.SQLiteCommand sql = sqllite.CreateCommand();
            sql.CommandText = "update files set Locked=1 where FileHash="+id;
            sql.ExecuteNonQuery();
        }

        public bool exists(string id)
        {
            System.Data.SQLite.SQLiteCommand sql = sqllite.CreateCommand();
            sql.CommandText = "select * from files where FileHash="+id;
            SQLiteDataReader sqlreader = sql.ExecuteReader();
            if (id.Equals(sqlreader.GetString(sqlreader.GetOrdinal("FileHash")))) { return true; }
            else { return false; };
        }

        public bool locked(string id)
        {
            System.Data.SQLite.SQLiteCommand sql = sqllite.CreateCommand();
            sql.CommandText = "select * from files where FileHash=" + id+" AND Locked=true";
            SQLiteDataReader sqlreader = sql.ExecuteReader();
            if (id.Equals(sqlreader.GetString(sqlreader.GetOrdinal("FileHash")))&&(sqlreader.GetBoolean(sqlreader.GetOrdinal("Locked"))==true)) { return true; }
            else return false;
        }

        public void Add(string dataSetID, DatabaseRow dataRow)
        {
            System.Data.SQLite.SQLiteCommand sql = sqllite.CreateCommand();
            if (!locked(dataSetID))
            {
                sql.CommandText = "select * from files where FileHash=" + dataSetID;
                SQLiteDataReader sqlreader = sql.ExecuteReader();
                dataRow.Key = sqlreader.GetInt32(sqlreader.GetOrdinal("key"));
                sql.CommandText = "insert into dataset(files, Date, Activity, ActivityY, ActivityZ, Incilometer, Steps, VMU, CaloriesActivity, CaloriesTotal) Values(" + dataRow.Key + ", " + dataRow.Date + ", " + dataRow.Activity + ", " + dataRow.ActivityY + ", " + dataRow.ActivityZ + ", " + dataRow.Inclinometer + ", " + dataRow.Steps + ", " + dataRow.Vmu + ", " + dataRow.CaloriesActivity + ", " + dataRow.CaloriesTotal + ")";
                sql.ExecuteNonQuery();
            }
            else { throw new Exception("Model already finished. Can't add new datasets"); };
        }

        public void AddNewFile(string id)
        {
            System.Data.SQLite.SQLiteCommand sql = sqllite.CreateCommand();
            sql.CommandText = "insert into files (FileHash, Locked) VALUES('" + id + "', 0)";
            sql.ExecuteNonQuery();
        }
    }
}
