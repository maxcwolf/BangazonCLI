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
            int OrderID = om.GetActiveOrder(ActiveCustomerId);
            //Check if Customer has products in their Order
            if (om.CheckCart(OrderID) == 0)
            {
                Console.WriteLine("Please add some products to your order first. Press any key to return to main menu.");
                Console.ReadKey();
                FeatureMenu.Show(ActiveCustomerId);
            }else {
                om.GetActiveOrder(ActiveCustomerId);
            }
            //If Customer has products they see this
            double total = om.getOrderTotal(OrderID);
            string tot = total.ToString("f2");
            Console.WriteLine($"Your order total is $ {tot}. Ready to purchase");
            Console.Write("> Y/N ");
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
                    Console.WriteLine($"{item.Id}. {item.PaymentType}");
                }
                Console.Write("> ");
                int paymentType = int.Parse(Console.ReadLine());
                om.AddPaymentTypeToOrder(paymentType, OrderID);
                Console.Write("Order Completed.");
                FeatureMenu.Show(ActiveCustomerId);
            }
            else
            {
                //display the Feature menu if anything other than y is chosen
                FeatureMenu.Show(ActiveCustomerId);
            }
        }
    }
}