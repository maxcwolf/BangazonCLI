//Author: Chase Steely
using System;
using BangazonCLI.Models;
using BangazonCLI.Managers;
using BangazonCLI.Menus;
using System.Collections.Generic;

namespace BangazonCLI
{
    public class CompleteOrderMenu
    {
        //This method will prompt the user to create a new product for the active user and takes the following argument
        // CustomerID - The id number for the active customer
        public static void Show(int ActiveCustomerId)
        {
            Console.Clear();
            Console.WriteLine("COMPLETE BANGAZON ORDER");
            Console.WriteLine("********************************");
            Console.WriteLine("Your order total is insertTotal. Ready to purchase");
            Console.Write("> ");
            string result = Console.ReadLine();
            //If yes display payment types.
            if (result.ToLower() == "y")
            {
                PaymentManager pm = new PaymentManager();
                List<Payment> payment = pm.GetCustomerPayments(ActiveCustomerId);
                int count = 1;
                Console.Clear();
                Console.WriteLine("Choose a payment type");
                // Display List of Customers payment types
                foreach (Payment item in payment)
                {
                    Console.WriteLine($"{count++}. {item.PaymentType}");
                }
            }
            else
            {
                //display the Feature menu if anything other than y is chosen
                FeatureMenu.Show(ActiveCustomerId);
            }
        }
    }
}