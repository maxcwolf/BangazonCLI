//Author: Chris Miller  
//Purpose: This is the StaleProduct View Model

using System;
namespace BangazonCLI.Models
{
    public class StaleProductViewModel
    {
        public string Title {get; set;} // Product Title
        public string Owner {get; set;} // Product Description
        public int Quantity {get; set;} // Product price stored as integer i.e. $19.95 = 1995
        public int Available {get; set;}//Product Quantity



        //This is the Default StaleProduct constructor that takes 4 arguments as defined above
        // Title, Owner, Title, Quantity, Available

        public StaleProductViewModel(string title, string owner, int quantity, int available)
        {
            this.Title = title; // product title
            this.Owner = owner; // product title
            this.Quantity = quantity;
            this.Available = available;


        }
    }
}