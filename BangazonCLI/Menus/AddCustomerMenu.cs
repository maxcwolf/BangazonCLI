//Author: Max Wolf
//Purpose: Presents a command line interface to enter new customer data
using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Managers;
using BangazonCLI.Models;

namespace BangazonCLI.Menus
{
    public class AddCustomerMenu
    {
        public static void Show()
        {
            //clear the console menu
            Console.Clear();

            //Prompt the user to enter the customer name
            Console.WriteLine ("Please create a new account");
            Console.WriteLine ("*********************************");
            Console.WriteLine ("1. Enter customer name");
			Console.Write ("> ");

			// Read user's name input and store as name variable
			string name = Console.ReadLine();

            //Prompt the user to enter the customer street
            Console.WriteLine("----");
            Console.WriteLine ("2. Enter customer street address");
			Console.Write ("> ");

			// Read user's street input and store as street variable
            string street = Console.ReadLine();

            //Prompt the user to enter the customer city
            Console.WriteLine("----");
            Console.WriteLine ("3. Enter customer city");
			Console.Write ("> ");

			// Read user's city input and store as city variable
            string city = Console.ReadLine();

            //Prompt the user to enter the customer state
            Console.WriteLine("----");
            Console.WriteLine ("4. Enter customer state abbreviation (two capital letters)");
			Console.Write ("> ");

			// Read user's state input and store as state variable
            string state = Console.ReadLine();

            //Prompt the user to enter the customer zip
            Console.WriteLine("----");
            Console.WriteLine ("5. Enter customer zip code (5-digit number)");
			Console.Write ("> ");

			// Read user's zip input and store as zip variable
            string zip = Console.ReadLine();

            //Prompt the user to enter the customer phone
            Console.WriteLine("----");
            Console.WriteLine ("6. Enter customer phone number (10 digit number without spaces or other characters)");
			Console.Write ("> ");

			// Read user's phone input and store as phone variable
            string phone = Console.ReadLine();

            //creates a new customer from the entered data
            Customer customer = new Customer(
                1,
                name,
                street,
                city,
                state,
                zip,
                phone
            );

            //create new instance of the customer manager
            CustomerManager manager = new CustomerManager();

            //Adds customer to the customer table
            manager.Add(customer);

            //After all customer information is entered, clear the menu and let them press any key to return
            //to the main menu
            Console.Clear();
            Console.WriteLine("Thank you. Press any key to return to the main menu");
            Console.ReadKey();
            MainMenu.Show();
        }
    }
}