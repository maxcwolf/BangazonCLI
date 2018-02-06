using System;
namespace BangazonCLI.Models
{
    public class Product
    {
        public int Id {get; set;} //product Id (Primary Key)
        public int CustomerId {get; set;} // Customer Id (Foreign Key)
        public string Title {get; set;} // Product Title
        public string Description {get; set;} // Product Description
        public int Price {get; set;} // Product price stored as integer i.e. $19.95 = 1995
        public int Quantity {get; set;}//Product Quantity
        public DateTime DateAdded {get; set;} // Date product was added to system

        public Product()
        {
            this.Id = 1;
            this.CustomerId = 1;
            this.Title = "Refrigerator";
            this.Description = "23 Cubic Foot French Door Refrigerator";
            this.Price = 300000;
            this.Quantity = 1;
            this.DateAdded = DateTime.Now;
        }

    }
}