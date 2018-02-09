//Author: Chase Steely
//Purpose: Menu for user to complete order.
using System;
using BangazonCLI.Models;
using BangazonCLI.Managers;
using BangazonCLI.Menus;
using System.Collections.Generic;

namespace BangazonCLI
{
    public class CompleteOrderMenu
    {
        //This method will prompt the user tif they wat to complete their order, show the total of order, and give them payment options.
        // ActiveCustomerId - The id number for the active customer
        public static void Show(int ActiveCustomerId)
        {
            Console.Clear();
            Console.WriteLine("COMPLETE BANGAZON ORDER");
            Console.WriteLine("********************************");
            OrdersManager om = new OrdersManager();
            om.GetActiveOrder(ActiveCustomerId);
            if (om.CheckCart(ActiveCustomerId) == 0)
            {

            }
            Console.WriteLine("Your order total is insertTotal. Ready to purchase");
            Console.Write("> ");
            string result = Console.ReadLine();
            //If yes display payment types.
            if (result.ToLower() == "y")
            {
                PaymentManager pm = new PaymentManager();
                List<Payment> payment = pm.GetCustomerPayments(ActiveCustomerId);
                Console.Clear();
                Console.WriteLine("Choose a payment type");
                // Display List of Customers payment types
                foreach (Payment item in payment)
                {
                    Console.WriteLine($"{item.PaymentId}. {item.PaymentType}");
                }
                Console.Write("> ");
                int paymentType = int.Parse(Console.ReadLine());
                om.AddPayment(paymentType);
            }
            else
            {
                //display the Feature menu if anything other than y is chosen
                FeatureMenu.Show(ActiveCustomerId);
            }
        }
    }
}