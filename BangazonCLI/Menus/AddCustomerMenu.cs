// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace BangazonCLI.Menus
// {
//     public class Program
//     {
//         public static void Main(string[] args)
//         {
//             var db = new DatabaseInterface();
//             db.Check();

//             Console.WriteLine ("Please create a new account");
//             Console.WriteLine ("*********************************");
//             Console.WriteLine ("1. Enter customer name");
// 			Console.Write ("> ");

// 			// Read in the user's choice
// 			string name = Console.ReadLine();

//             if (name)
//             {
//                 Console.WriteLine ("Enter child name");
//                 Console.Write ("> ");
//                 string childName = Console.ReadLine();
//                 ChildRegister registry = new ChildRegister();
//                 bool childId = registry.AddChild(childName);
//                 Console.WriteLine(childId);
//             }
//         }
//     }
// }