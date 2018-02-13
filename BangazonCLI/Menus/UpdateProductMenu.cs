//Author: Ray Medrano //Purpose: This method will display customer products and allow a product to be removed
//as long as the product has never been placed on any orders
using System;
using BangazonCLI.Models;
using BangazonCLI.Managers;
using BangazonCLI.Menus;
using System.Collections.Generic;

namespace BangazonCLI
{
  public class UpdateProductMenu
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
      Console.WriteLine ("CHOOSE A PRODUCT TO UPDATE");
      Console.WriteLine ("**************************");
      Console.WriteLine();
      //Add a line for each product the customer has
      CustomerProductList.ForEach(p =>
        {
            Console.WriteLine($"{CustomerProductList.IndexOf(p)+1}. {p.Title}");
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
            decimal convertedPrice = (Convert.ToDecimal(SelectedProduct.Price) / 100);

            //Grab Selected Product and display all details
            Console.Clear();
            Console.WriteLine("Please select which property you wish to update:");
            Console.WriteLine();
            Console.WriteLine($"1. To Edit Title '{SelectedProduct.Title}'");
            Console.WriteLine($"2. To Edit Description '{SelectedProduct.Description}'");
            Console.WriteLine($"3. To Edit Price ${convertedPrice}");
            Console.WriteLine($"4. To Edit Quantity '{SelectedProduct.Quantity}'");
            Console.WriteLine("5. Return To Feature Menu");
            Console.Write("> ");

            int Choice = Int32.Parse(Console.ReadLine());

            //check to see if result is valid
            if (Choice != 0 && Choice <= 5 )
            {
                switch(Choice)
                {

                    case 1:
                        //prompt user for update
                        Console.WriteLine();
                        Console.WriteLine("Please Enter New Title");
                        Console.Write("> ");
                        var titleupdate = Console.ReadLine();

                        //send update to database
                        pm.UpdateExistingProduct(SelectedProduct.Id, "Title", titleupdate);

                    break;

                    case 2:
                        //prompt user for update
                        Console.WriteLine();
                        Console.WriteLine("Please Enter New Description");
                        Console.Write("> ");
                        string DescUpdate = Console.ReadLine();

                        //send update to database
                        pm.UpdateExistingProduct(SelectedProduct.Id, "Description", DescUpdate);
                    break;

                    case 3:
                        //prompt user for update
                        Console.WriteLine();
                        Console.WriteLine("Please Enter New Price");
                        Console.Write("> ");
                        string inputPrice = Console.ReadLine();

                        //remove the decimal from the string entered
                        string PriceUpdate = inputPrice.Replace(".","");

                        //send update to the database
                        pm.UpdateExistingProduct(SelectedProduct.Id, "Price", PriceUpdate);
                    break;

                    case 4:
                        //prompt user for update
                        Console.WriteLine();
                        Console.WriteLine("Please Enter New Quantity");
                        Console.Write("> ");
                        string QtyUpdate = Console.ReadLine();

                        //send update to the database
                        pm.UpdateExistingProduct(SelectedProduct.Id, "Quantity", QtyUpdate);
                    break;

                    case 5:
                    //return to feature menu
                    FeatureMenu.Show(ActiveCustomerId);
                    break;

                }
                UpdateProductMenu.Show(ActiveCustomerId);
            }
            else
            {
                FeatureMenu.Show(ActiveCustomerId);
            }
        }

    }
  }
}