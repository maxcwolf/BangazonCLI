using System;
using BangazonCLI.Menus;

namespace BangazonCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine ("WELCOME TO THE BANGAZON CLI");
            Console.WriteLine ("*********************************");
            Console.WriteLine ("1. Add a new customer");
            Console.WriteLine ("2. Select active customer");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            if (choice == 1)
            {
                AddCustomerMenu.Show();
            }




        }
    }
}
