using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveSystemFinal
{
    public class Menu
    {

        public static void ShowUI()
        {

            var returnInput = 0;

            try
            {


                do
                {
                    Console.WriteLine("*** Welcome to Employee Leave Management System ***");

                    var selectionUi = new List<string> { "", "Enter 1 - Leave Request", "Enter 2 - Login as Admin", "Enter 3 - Exit" };

                    foreach (var item in selectionUi)
                    {
                        Console.WriteLine(item);
                    }

                    Console.Write("\nUser Input: ");

                    int userInput = Convert.ToInt32(Console.ReadLine());

                    if (userInput == 1)
                    {
                        Console.WriteLine("You have chosen Leave Request. Press Enter key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        SubMenu.LeaveReqUI();


                    }
                    else if (userInput == 2)
                    {
                        Console.WriteLine($"You have chosen Login as Admin. Press Enter key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        SubMenu.AdminLogin();
                    }
                    else if (userInput == 3)
                    {
                        Console.WriteLine($"You have chosen Exit. Press Enter key to continue");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else
                    {

                        Console.WriteLine("Invalid Input. Press Enter key to return");
                        Console.ReadKey();
                        Console.Clear();
                        var change = returnInput = 1;


                    }

                } while (returnInput == 1);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine("Press Enter key to go back");
                Console.ReadKey();
                Console.Clear();
                Menu.ShowUI();
            }

        }
    }
}
