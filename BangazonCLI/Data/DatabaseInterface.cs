//Chris Miller
//Copy of database interface

using System;
using Microsoft.Data.Sqlite;

namespace BangazonCLI.Data
{
    public class DatabaseInterface
    {
        private string _connectionString;
        private SqliteConnection _connection;

        //Take in the passed in Connection_String that relates to the environmental variable 
        public DatabaseInterface(string Connection_String)
        {
            //Pull the environmental variable
            string _EV = $"{Environment.GetEnvironmentVariable(Connection_String)}";
            //Set the Environmetal Variable as with the data source
            _connectionString = $"Data Source={_EV}";
            //create a connection with the data source
            _connection = new SqliteConnection(_connectionString);
        }

        //Method to inject SQL query into the database - requires a string of the query and a callback function to read the data
        public void Query(string command, Action<SqliteDataReader> handler)
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();
                dbcmd.CommandText = command;

                using (SqliteDataReader dataReader = dbcmd.ExecuteReader())
                {
                    handler(dataReader);
                }

                dbcmd.Dispose();
            }
        }

        //Delete from the database - this takes a SQL command and executes it as a non query
        public void Delete(string command)
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();
                dbcmd.CommandText = command;
                dbcmd.ExecuteNonQuery();
                dbcmd.Dispose();
            }
        }

        //Insert - takes a sql query and returns the id of the entry added
        public int Insert(string command)
        {
            int insertedItemId = 0;

            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();
                dbcmd.CommandText = command;

                dbcmd.ExecuteNonQuery();

                this.Query("select last_insert_rowid()",
                    (SqliteDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            insertedItemId = reader.GetInt32(0);
                        }
                    }
                );

                dbcmd.Dispose();
            }

            return insertedItemId;
        }
    }
}