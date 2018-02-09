//Paul Ellis
//Payment Manager

using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Models;
using BangazonCLI.Data;
using Microsoft.Data.Sqlite;

namespace BangazonCLI.Managers
{
    public class PaymentManager
    {
        private DatabaseInterface db;

        //Adds a Payment to the list
        public int Add(int user, string name, string num)
        {
        return db.Insert($"INSERT INTO Payment VALUES(null, {user}, '{name}', '{num}')");
        }
        //Gets customer payments from database. Accepts id of active customer to specify payments to be returned.
        public List<Payment> GetCustomerPayments(int CustomerId)
        {
            List<Payment> results = new List<Payment>();
            db.Query(
                "SELECT * FROM Payment WHERE Payment.CustomerId == 1;",
                (SqliteDataReader reader) => {
                        //Callback function to iterate through the returned object
                        while (reader.Read ())
                        {
                            results.Add(new Payment( reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3)));
                        }
                    }
            );
            return results;
        }

        public PaymentManager(string connection_string = "BANGAZON_CLI")
        {
            //instantiate the databaseInterface with the connection_string
            db = new DatabaseInterface(connection_string);
        }

    }
}