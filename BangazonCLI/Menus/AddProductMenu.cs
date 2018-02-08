//Author: Ray Medrano //Purpose: This method will display the options to create a new product
using System;
using BangazonCLI.Models;
using BangazonCLI.Managers;
using BangazonCLI.Menus;

namespace BangazonCLI
{
  public class AddProductMenu
  {
    //This method will prompt the user to create a new product for the active user and takes the following argument
    // CustomerID - The id number for the active customer
    public static void Show(int ActiveCustomerId)
    {
      Console.Clear();
      Console.WriteLine ("BANGAZON PRODUCT CREATION SYSTEM");
      Console.WriteLine ("********************************");

      //user prompted to add product title
      Console.WriteLine ("Enter Product Title");
			Console.Write ("> ");
      string Title = Console.ReadLine();

      //user prompted to enter product description
      Console.WriteLine ("Enter Product Description");
			Console.Write ("> ");
      string Description = Console.ReadLine();

      //User Prompted to enter product price
      Console.WriteLine ("Enter Product Price");
			Console.Write ("> $");
      string inputPrice = Console.ReadLine();

      //remove the decimal from the string entered
      string noDecimalPrice = inputPrice.Replace(".","");

      //convert noDecimalPrice to an integer
      int Price = System.Convert.ToInt32(noDecimalPrice);

      //User Prompted to enter Quantity
      Console.WriteLine ("Enter Quantity");
			Console.Write ("> ");
      string inputQuantity = Console.ReadLine();

      //convert inputQuantity to an integer
      int Quantity = System.Convert.ToInt32(inputQuantity);

    //Create a new instance of the product manager
    ProductManager pm = new ProductManager();

    //Create New Product using values collected above
      Product NewProduct = new Product(
        1,
        ActiveCustomerId,
        Title,
        Description,
        Price,
        Quantity
        );

      //add new product to product list
      pm.AddProduct(NewProduct);

      //prompt user if they need to enter another product, or return to the feature menu
      Console.Clear();
      Console.WriteLine ("********************************");
      Console.WriteLine ("*   Customer Product Created   *");
      Console.WriteLine ("********************************");
      Console.WriteLine();
      Console.WriteLine ("Would you like to enter another Product Y/N?");
      Console.Write ("> ");
      string result = Console.ReadLine();

      if (result.ToLower() == "y" )
      {
        //Re display the Add Product Menu if "y" is chosen
        AddProductMenu.Show(ActiveCustomerId);
      } else
      {
        //display the Feature menu if anything other than y is chosen
        FeatureMenu.Show(ActiveCustomerId);
      }





    }
  }
}