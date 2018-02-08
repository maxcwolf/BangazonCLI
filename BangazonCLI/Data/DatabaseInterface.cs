using System;
using Microsoft.Data.Sqlite;

namespace BangazonCLI.Data
{
    public class DatabaseInterface
    {
        private string _connectionString;
        private SqliteConnection _connection;

        public DatabaseInterface(string Connection_String)
        {
            string _EV = $"{Environment.GetEnvironmentVariable(Connection_String)}";
            _connectionString = $"Data Source={_EV}";
            _connection = new SqliteConnection(_connectionString);
        }

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