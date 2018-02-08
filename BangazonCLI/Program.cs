//Author: Max Wolf
//Purpose: Entry point to the command line interface menus
using System;
using BangazonCLI.Data;
using BangazonCLI.Menus;

namespace BangazonCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseInterface db = new DatabaseInterface();
            //Show the main menu on load
            
            MainMenu.Show();


        }
    }
}
