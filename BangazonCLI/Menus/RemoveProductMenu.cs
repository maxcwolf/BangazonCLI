//Author: Ray Medrano //Purpose: This method will display customer products and allow a product to be removed
//as long as the product has never been placed on any orders
using System;
using BangazonCLI.Models;
using BangazonCLI.Managers;
using BangazonCLI.Menus;
using System.Collections.Generic;

namespace BangazonCLI
{
  public class RemoveProductMenu
  {
    //This method will display the products for the active customer and allow them to select which product they wish to delete
    public static void Show(int ActiveCustomerId)
    {
    //Create a new instance of the product manager
    ProductManager pm = new ProductManager("BANGAZON_CLI");

    //Grab list of customer products using the product manager
     List<Product> CustomerProductList = pm.GetCustomerProducts(ActiveCustomerId);

     //Build the menu Prompt
      Console.Clear();
      Console.WriteLine ("CHOOSE A PRODUCT TO REMOVE");
      Console.WriteLine ("**************************");
      Console.WriteLine();
      //Add a line for each product the customer has
      CustomerProductList.ForEach(p =>
        {
            Console.WriteLine($"{CustomerProductList.IndexOf(p)+1}. {p.Title}:   {p.Description}");
        }
      );
      Console.WriteLine("Enter 'Q' to Return To Main Menu");
      Console.Write("> ");
      var Result = Console.ReadLine();

      //if user enters Q, they are returned to the main menu, otherwise product selected
      if (Result.ToLower() == "q")
        {
            FeatureMenu.Show(ActiveCustomerId);
        }
        else
        {
            //extract product Id from the selected product
            Product SelectedProduct = CustomerProductList[int.Parse(Result)-1];

            //Delete Product If Not on Order
            Console.Clear();
            pm.DeleteCustomerProduct(SelectedProduct.Id);
            Console.WriteLine();
            Console.WriteLine("Press Any Key To Continue");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
            RemoveProductMenu.Show(ActiveCustomerId);
        }

    }
  }
}