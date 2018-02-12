//Author: Paul Ellis; Purpose: Product Popularity Report View Model to hold each resultant row from the revenue report query


using System;

namespace BangazonCLI.Models
{
    public class ProductPopularityReportViewModel
    {
        public string Product { get; set; }
        public string Orders { get; set; }
        public string Purchasers { get; set; }
        public string Revenue {get; set;}


        //Constructor Method for Revenue Report View Model
        //Accepts arguments corresponding to the values defined above in this class
        public ProductPopularityReportViewModel(string product, string orders, string purchasers, string revenue)
        {
            Product = product;
            Orders = orders;
            Purchasers = purchasers;
            Revenue = revenue;
        }
    }
}