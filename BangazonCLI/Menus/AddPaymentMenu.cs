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
            Console.Write("yo");
            // //Create new instance of the Payment Manager
            // PaymentManager paymentManager = new PaymentManager();

            // //Build the prompt
            // Console.Clear();
            // Console.WriteLine("Enter Your Payment Type (ex: VISA, Mastercard, etc.)");
            // Console.WriteLine("Enter 'Q' to Return To Main Menu");
            // var Result = Console.ReadLine();
            

            // //if user enters q return to main menu - else process adding product to order
            // if ( Result == "q" || Result == "Q" )
            // {
            //     FeatureMenu.Show(ActiveCustomerId);
            // } 
            // else
            // {
            // Console.WriteLine("Enter the Account Number for this Payment Type:");
            // Console.WriteLine("*********************************");
            // Console.Write ("> ");
            // string AccountNumber = Console.ReadLine();
            // Payment newPayment = new Payment(1, Result, AccountNumber, ActiveCustomerId);
            // paymentManager.Add(newPayment);
            // FeatureMenu.Show(ActiveCustomerId);
            // }
        }
    }
}