//Author: Ray Medrano //Purpose: This is the Product Model
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
        public String DateAdded {get; set;} // Date product was added to system this is calculated by the database and returned as a string



        //This is the Default Product constructor that takes 6 arguments as defined above
        // Id, CustomerId, Title, Description, Price, Quantity

        public Product(int id, int customerId, string title, string description, int price, int quantity, string dateAdded)
        {
            this.Id = id;
            this.CustomerId = customerId;
            this.Title = title; // product title
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
            this.DateAdded = dateAdded;


        }
 
    }
}