//Author: Max Wolf
//Purpose: Presents a command line interface to select active customer
using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Managers;
using BangazonCLI.Models;

namespace BangazonCLI.Menus
{
    public class ActiveCustomerMenu
    {
        public static void Show()
        {

            //clear the console menu
            Console.Clear();
            //Prompt the user to select an active customer
            Console.WriteLine ("Please select active customer");
            Console.WriteLine ("*********************************");

            //create new instance of the customer manager
            CustomerManager manager = new CustomerManager();

            //ADDING DUMMY DATA
            Customer _customer = new Customer(
                1,
                "Rang Dipkin",
                "123 Derp Way",
                "Derpville",
                "TN",
                "12345",
                "1234567890"
            );

            manager.Add(_customer);


            //uses the GetAllCustomers method on the CustomerManager to store the results in a list
            List<Customer> allCustomers = manager.GetAllCustomers();

            //loop over all the customers in the list and assign their index +1 as their displayed list number along with their name
            allCustomers.ForEach(c => {
                Console.WriteLine($"{allCustomers.IndexOf(c)+1}. {c.Name}");
            });

            Console.Write (">  ");

            //Read the user choice and lead to the next menu
            int choice; //create int variable to store the user choice
			Int32.TryParse (Console.ReadLine(), out choice); //convert the string obtained thru ReadLine() to an int and store it in the choice variable

            int custId = allCustomers[choice - 1].Id;


            // FeatureMenu.Show(custId);

        }
    }
}