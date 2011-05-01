using System;
using System.Data;
using System.IO;
using System.Data.SQLite;


namespace ActigraphAuswertung.Model.Storage
{
    class DBStorage:IStorage<DatabaseRow>
    {	
        
        private DataSet database = new DataSet();
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
            sql.CommandText="create table files( key integer PRIMARY KEY, FileHash char(100) not null)";
            sql.ExecuteNonQuery();
            sql.CommandText = "create table dataset(key integer PRIMARY KEY, files integer not null, Date DATE, Activity integer, ActivityY integer, ActivityZ integer, Incilometer integer, Steps integer, VMU integer, ColoriesActivity integer, CaloriesTotal integer, FOREIGN KEY(files) REFERENCES files(key))";
            sql.ExecuteNonQuery();
        }

        public void lockData(string id)
        {
            throw new NotImplementedException();
        }

        public bool exists(string id)
        {
            System.Data.SQLite.SQLiteCommand sql = sqllite.CreateCommand();
            sql.CommandText = "select * from files where FileHash="+id;
            SQLiteDataReader sqlreader = sql.ExecuteReader();
            if (id.Equals(sqlreader.GetString(sqlreader.GetOrdinal("FileHash")))) { return true; }
            else return false;
        }

        public bool locked(string id)
        {
            throw new NotImplementedException();
        }

        public void Add(string dataSetID, DatabaseRow dataRow)
        {
            throw new NotImplementedException();
        }
    }
}
