//Author: Chris Miller
//Purpose: CLI menue to expose features after Active User is chosen

using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Managers;
using BangazonCLI.Models;

namespace BangazonCLI.Menus
{
    public class FeatureMenu
    {
        public static void Show(int ActiveUserId)
        {
            CustomerManager customerManager = new CustomerManager();
            // string ActiveCustomerName = customerManager.GetSingleCustomer(ActiveUserId).Name;

            //Clear any prior menu
            Console.Clear();
            //Feature menu that user is presented with after an Active User is selected
            // Console.WriteLine($"Active User : {ActiveCustomerName}");
            Console.WriteLine("*********************************");
            Console.WriteLine("1. Create a payment option");
            Console.WriteLine("2. Add product to sell");
            Console.WriteLine("3. Add product to shopping cart");
            Console.WriteLine("4. Complete an order");
            Console.WriteLine("5. Remove customer product");
            Console.WriteLine("6. Update product information");
            Console.WriteLine("7. Show customer revenue report");
            Console.WriteLine("8. Leave Bangazon!");
            Console.WriteLine("Press 'Q' to return to Main Menu");
            Console.Write("> ");

            //Take in the user input
            var Result = Console.ReadLine();

            //If q or Q return to main menu
            if (Result == "q" || Result == "Q")
            {
                MainMenu.Show();
            }
            //Else run switch statement for options listed above, if any other input is detected, redisplay the menu
            else
            {
                switch(Result)
                {
                    case "1":
                        AddPaymentMenu.Show(ActiveUserId);
                        break;
                    case "2":
                        AddProductMenu.Show(ActiveUserId);
                        break;
                    case "3":
                        AddOrderProductMenu.Show(ActiveUserId);
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    default:
                        FeatureMenu.Show(ActiveUserId);
                        break;
                }
            }
        }
    }
}