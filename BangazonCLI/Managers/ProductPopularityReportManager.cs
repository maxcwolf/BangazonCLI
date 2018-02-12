//Paul Ellis
//Payment Manager

using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Models;
using BangazonCLI.Data;
using Microsoft.Data.Sqlite;

namespace BangazonCLI.Managers
{
    public class ProductPopularityReportManager
    {
        private DatabaseInterface db;

        public List<ProductPopularityReportViewModel> GenerateReport()
        {
            List<ProductPopularityReportViewModel> results = new List<ProductPopularityReportViewModel>();
            db.Query(
                @"
                
                with Popular as
                (
                select p.Title Product, count(op.Id) as Orders, CustomerCount.Purchasers as Purchasers, sum(p.Price) as Revenue
                from Product p
                join OrderProduct op on p.Id = op.ProductId
                join (select p.Id ProductId, count(distinct o.CustomerId) Purchasers
                from Product p
                join OrderProduct on p.Id = OrderProduct.ProductId
                join Orders o on OrderProduct.OrdersId = o.Id
                group by p.Title) CustomerCount on p.Id = CustomerCount.ProductId
                group by p.Title 
                order by Revenue desc
                limit 3
                )
				select * from Popular
                union all
                select ""Totals"" Totals, sum(""Orders"") Orders, sum(""Purchasers"") Purchasers, sum(""Revenue"") Revenue
                from Popular
                ",
                (SqliteDataReader reader) => {
                        //Callback function to iterate through the returned object
                        while (reader.Read ())
                        {
                            //for each row returned from the database, Add a new ProductPopularityViewModel to the results list
                            results.Add(new ProductPopularityReportViewModel( reader.GetString(0), reader.GetInt32(1).ToString("#,##0"),
                            reader.GetInt32(2).ToString("#,##0"), reader.GetInt32(3).ToString("#,##0")));
                            //ToString method above injects commas in the thousands place
                        }
                    }

            );
            //return the array of results
            return results;
        }

        public ProductPopularityReportManager(string connection_string)
        {
            //instantiate the databaseInterface with the connection_string
            db = new DatabaseInterface(connection_string);
        }
    }
}