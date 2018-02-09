//Paul Ellis
//CLI Menu to add a payment for the active customer

using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Managers;
using BangazonCLI.Models;

namespace BangazonCLI.Menus
{
    public class AddPaymentMenu
    {
        public static void Show(int ActiveCustomerId)
        {
            /*Create new instance of the Payment Manager with production database path passed in
            to create connection string*/
            PaymentManager paymentManager = new PaymentManager("BANGAZON_CLI");

            //Build the prompt
            Console.Clear();
            Console.WriteLine("Follow Prompts To Add A Payment");
            Console.WriteLine("Enter 'Q' to Return To Main Menu");
            Console.WriteLine("*********************************");
            Console.WriteLine("Enter Your Payment Type (ex: VISA, Mastercard, etc.)");
            var Result = Console.ReadLine();

            //if user enters q return to main menu - else process adding payment to database
            if (Result.ToLower() == "q")
            {
                FeatureMenu.Show(ActiveCustomerId);
            }
            else
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Enter the Account Number for this Payment Type:");
                Console.Write("> ");
                string AccountNumber = Console.ReadLine();
                paymentManager.Add(ActiveCustomerId, Result, AccountNumber);
                FeatureMenu.Show(ActiveCustomerId);
            }
        }
    }
}