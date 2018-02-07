using System;
using BangazonCLI.Models;

namespace BangazonCLI
{
  public class AddProductMenu
  {
    public static void Show()
    {
      Console.Clear();
      Console.WriteLine ("BANGAZON PRODUCT CREATION SYSTEM");
      Console.WriteLine ("********************************");
      Console.WriteLine ("Enter Product Title");
			Console.Write ("> ");
      string Title = Console.ReadLine();
      Console.WriteLine ("Enter Product Description");
			Console.Write ("> ");
      string Description = Console.ReadLine();
      Console.WriteLine ("Enter Product Price (");
			Console.Write ("> $");
      string InitialPrice = Console.ReadLine();
      //remove decimal from Price
      string ConvertedPrice = InitialPrice.Replace(".","");
      Console.WriteLine ("Enter Quantity");
			Console.Write ("> ");
      string Quantity = Console.ReadLine();

      Console.WriteLine ("You Entered The Following Information");
      Console.WriteLine ("Title: " + Title );
      Console.WriteLine ("Description: " + Title );
      Console.WriteLine ("Title: " + Title );
      Console.WriteLine ("Title: " + Title );

      Product NewProduct = new Product();
    }
  }
}