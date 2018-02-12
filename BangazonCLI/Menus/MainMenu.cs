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
            Console.WriteLine("WELCOME TO THE BANGAZON CLI");
            Console.WriteLine("*********************************");
            Console.WriteLine("1. Add a new customer");
            Console.WriteLine("2. Select active customer");
            Console.WriteLine("3. Show Overall Product Popularity");
            Console.WriteLine("4. Show Stale Products");


            Console.Write("> ");
            //Store the key pressed by the user
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCustomerMenu.Show();
                    break;
                case "2":
                    ActiveCustomerMenu.Show();
                    break;
                case "3":
                    ProductPopularityReportMenu.Show();
                    break;
                case "4":
                    break;
            }
        }
    }
}