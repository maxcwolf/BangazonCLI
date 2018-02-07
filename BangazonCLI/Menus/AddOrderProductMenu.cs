//Chris Miller
//CLI Menu to add a product to the active order for the customer

using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Managers;
using BangazonCLI.Models;

namespace BangazonCLI.Menus
{
    public class AddOrderProductMenu
    {
        public static void Show(int ActiveCustomerId)
        {
            //These value need to be refactored to take in values from the active user and the active users current order
            OrderManager orderManager = new OrderManager();
            
            int ActiveOrderId = orderManager.GetOrderById(ActiveCustomerId);

            //Class that interacts with the OrderProduct table
            OrderProductManager orderProductManager = new OrderProductManager();

            //Class that interacts with the Product table
            ProductManager productManager = new ProductManager();
            
            //Returns a list of all products that are not owned by the active user
            List<Product> productList =  productManager.GetNonActiveUserProduct(ActiveCustomeId);

            //Build the prompt
            Console.Clear();
            Console.WriteLine("Choose A Product To Add To The Order");
            Console.WriteLine("*********************************");
            Console.WriteLine();

            //Add a line for each product where the number reflects the index in the producList
            productList.ForEach(p => 
            {
                Console.WriteLine($"{productList.IndexOf(p)+1}. {p.Title}");
            });
            Console.Write ("> ");
            
            Console.WriteLine("Enter 'Q' to Return To Main Menu");
            var Result = Console.ReadLine();

            //if user enters q return to main menu - else process adding product to order
            if ( Result == "q" || Result == "Q" )
            {
                FeatureMenu.Show(ActiveCustomerId);
            } 
            else
            {
                //Pull out the selected item from the user input
                Product productSelected =  productList[int.Parse(Console.ReadLine())-1];

                //TODO : Write validation for the qunatity to purchase

                //Prompt the user to input the number of the selected item they want to add to the order
                Console.WriteLine();
                Console.WriteLine($"How Many {productSelected.Title} Would You Like To Add To The Order");
                Console.WriteLine($"There are {productSelected.Quantity} Available");
                Console.Write ("> ");
                
                int Quantity  = int.Parse(Console.ReadLine());

                //Add Quantity number of new orderProduct to the OrderProduct table by invoking 
                for (int i = 0; i < Quantity; i++)
                {
                    orderProductManager.Add(new OrderProduct(ActiveOrderId, productSelected.Id));
                }

                AddOrderProductMenu.Show(ActiveCustomerId);
            }
        }
    }
}