//Author: Max Wolf, et al.
//Purpose: Main CLI menu initally shown when cli is opened

using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Managers;
using BangazonCLI.Models;

namespace BangazonCLI.Menus
{
    public class MainMenu
    {
        public static void Show()
        {
            //Clear any prior menu
            Console.Clear();
            //Main menu that user is initially presented with
            Console.WriteLine ("WELCOME TO THE BANGAZON CLI");
            Console.WriteLine ("*********************************");
            Console.WriteLine ("1. Add a new customer");
            Console.WriteLine ("2. Select active customer");
			Console.Write ("> ");

			//Read the user choice and lead to the next menu
            int choice; //create int variable to store the user choice
			Int32.TryParse (Console.ReadLine(), out choice); //convert the string obtained thru ReadLine() to an int and store it in the choice variable

            //If 1 is selected, show the add customer menu
            if (choice == 1)
            {
                AddCustomerMenu.Show();
            } else if (choice == 2)
            {
                ActiveCustomerMenu.Show();
            }
        }
    }
}