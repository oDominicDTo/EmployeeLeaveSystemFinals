using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer;
using DataLayer;

namespace EmployeeLeaveSystemFinal
{
    public class SubMenu
    {

        public static int returnInput = 0;
        public static void LeaveReqUI()
        {
            try
            {
                do
                {
                    Console.WriteLine("*** Leave Application ***");

                    Console.WriteLine("\nYou have requested for leave. Enter all the details needed below:");

                    Console.WriteLine("\nChoose your Leave Type:");

                    var selectionUi = new List<string> { "", "Enter 1 - Sick Leave", "Enter 2 - Vacation Leave", "Enter 3 - Go back" };

                    foreach (var item in selectionUi)
                    {
                        Console.WriteLine(item);
                    }

                    Console.Write("\nInput Leave Type: ");

                    int userInput = Convert.ToInt32(Console.ReadLine());

                    if (userInput == 1)
                    {
                        Console.Clear();
                        LeaveMenu.SickLeaveUI();

                    }
                    else if (userInput == 2)
                    {
                        Console.Clear();
                        LeaveMenu.VacationLeaveUI();

                    }
                    else if (userInput == 3)
                    {
                        Console.WriteLine($"You want to go back. Press Enter key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        Menu.ShowUI();
                    }
                    else
                    {

                        Console.WriteLine("Invalid Input. Press Enter key to return");
                        Console.ReadKey();
                        var change = SubMenu.returnInput = 1;


                    }

                } while (returnInput == 1);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine("Press Enter key to go back");
                Console.ReadKey();
                Console.Clear();
                SubMenu.LeaveReqUI();
            }
        }


        public static void AdminLogin()
        {
            try
            {
                do
                {
                    Console.WriteLine("\a \n *** Admin Login ***\n ");



                    Console.Write("Username: ");
                    var username = Console.ReadLine();


                    Console.Write("Password: ");
                    var password = Console.ReadLine();


                    var x = new Data(null, null, null);


                    if (username == x.UserName && password == x.PassWord)
                    {
                        Console.Clear();
                        SubMenu.AdminSelection();

                    }
                    else
                    {

                        Console.WriteLine("Your username or password is incorrect!");
                        Console.ReadKey();
                        Console.Clear();
                        var change = SubMenu.returnInput = 1;


                    }

                } while (returnInput == 1);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                Console.WriteLine("Press Enter key to go back");
                Console.ReadKey();
                Console.Clear();
                SubMenu.AdminLogin();
            }
        }


        public static void AdminSelection()
        {

            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("*** Employee Data ***");

                    Console.WriteLine("\nSelect from MENU:\n");

                    var selectionUi = new List<string> { "Enter 0 - View Employee Leave List", "Enter 1 - View List of Employees", "Enter 2 - Add New Employee/s", "Enter 3 - Update list of Employee/s", "Enter 4 - Delete List", "Enter 5 - Go Back", "Enter 6 - Exit" };

                    foreach (var item in selectionUi)
                    {
                        Console.WriteLine(item);
                    }

                    Console.Write("\nUser Input: ");

                    int userInput = Convert.ToInt32(Console.ReadLine());

                    if (userInput == 0)


                    {
                        Console.Clear();
                        Console.WriteLine("Enter 1 - Sick Leave List");
                        Console.WriteLine("Enter 2 - Vacation Leave List");

                        var input = Console.ReadLine();

                        switch (input)
                        {
                            case "1":
                                Console.Clear();
                                if (Admin.ViewSickLeaveEmployee() == "Empty")
                                {

                                    Console.WriteLine("List is Empty");
                                    Console.ReadKey();
                                    Console.Clear();

                                }
                                else
                                {
                                    Console.WriteLine(Admin.ViewSickLeaveEmployee());
                                    Console.ReadKey();
                                    Console.Clear();
                                    SubMenu.AdminSelection();
                                }

                                break;
                            case "2":
                                Console.Clear();
                                if (Admin.ViewVacationLeaveEmployee() == "Empty")
                                {

                                    Console.WriteLine("List is Empty");
                                    Console.ReadKey();
                                    Console.Clear();

                                }
                                else
                                {
                                    Console.WriteLine(Admin.ViewVacationLeaveEmployee());
                                    Console.ReadKey();
                                    Console.Clear();
                                    SubMenu.AdminSelection();
                                }
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid Input");
                                break;

                        }
                    }


                    else if (userInput == 1)
                    {
                        Console.Clear();
                        Console.WriteLine(Admin.ReadDataEmployee());
                        Console.ReadKey();
                        Console.Clear();
                        SubMenu.AdminSelection();
                    }

                    else if (userInput == 2)
                    {
                        Console.Clear();

                        string idEmployee, name;

                        Console.Write("Employee ID:");
                        idEmployee = Console.ReadLine();

                        Console.Write("Name: ");
                        name = Console.ReadLine();



                        if (Admin.ValidateEmployeeID(idEmployee, name))
                        {
                            Console.Clear();

                            var result = Admin.AddList(idEmployee, name);

                            if (result == "success")
                            {
                                Console.WriteLine(Admin.ReadDataEmployee());

                                Console.WriteLine("\n*** Employee ID recorded. ***");

                                Console.WriteLine("\nPress ANY key to return to Menu.");

                            }
                            else
                            {
                                Console.WriteLine(result);
                            }

                        }
                        else { Console.WriteLine("Invalid Input"); }

                        Console.ReadKey();

                        Console.Clear();
                        SubMenu.AdminSelection();


                    }
                    else if (userInput == 3)
                    {

                        if (Admin.ReadDataEmployee() == "Empty")
                        {

                            Console.WriteLine("List is Empty");
                            Console.ReadKey();
                            Console.Clear();


                        }
                        else
                        {

                            Console.WriteLine(Admin.ReadDataEmployee());

                            Console.Write("\nReplace: ");
                            string input = Console.ReadLine();

                            Console.Write("\nTo: ");
                            string newValue = Console.ReadLine();

                            Admin.UpdateList(input, newValue);

                            Console.WriteLine("Succesfully Updated");

                            Console.ReadKey();
                            Console.Clear();
                            SubMenu.AdminSelection();

                        }
                    }


                    else if (userInput == 4)
                    {
                        Console.Clear();
                        Console.WriteLine("*** Choose which File to Delete ***");
                        var deleteSelection = new List<string> { "", "Enter 1 - Sick Leave List", "Enter 2 - Vacation Leave List", "Enter 3 - Employee List", "Enter 4 - Go back" };

                        foreach (string item in deleteSelection)
                        {
                            Console.WriteLine(item);
                        }

                        Console.Write("\nUser Input:");
                        var input = Console.ReadLine();


                        switch (Admin.DeleteList(input))
                        {

                            case 0:
                                Console.WriteLine("\nFile does not exist");
                                Console.ReadKey();
                                Console.Clear();
                                SubMenu.AdminSelection();
                                break;

                            case 1:
                                Console.WriteLine("\nDeleting File...");
                                Thread.Sleep(1000);
                                Console.WriteLine("\nSuccesfully Deleted");
                                Console.ReadKey();
                                Console.Clear();
                                SubMenu.AdminSelection();
                                break;

                            case 2:
                                SubMenu.AdminSelection();
                                break;

                            default:
                                Console.Clear();
                                SubMenu.AdminSelection();
                                break;
                        }
                    }


                    else if (userInput == 5)
                    {

                        Console.Clear();
                        Menu.ShowUI();

                    }
                    else if (userInput == 6)
                    {
                        Environment.Exit(0);

                    }
                    else
                    {

                        Console.WriteLine("Invalid Input. Press Enter key to return");
                        Console.ReadKey();
                        var change = SubMenu.returnInput = 1;


                    }

                } while (returnInput == 1);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine("Press Enter key to go back");
                Console.ReadKey();
                Console.Clear();
                SubMenu.AdminSelection();
            }
        }

    }
}