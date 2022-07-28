using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer;
using DataLayer;
namespace EmployeeLeaveSystemFinal
{
    public class LeaveMenu

    {

        public static void SickLeaveUI()
        {

            var data = new StringBuilder();

            string idEmployee, nameEmployee, daysLeave;

            Console.WriteLine("*** Sick Leave ***");

            Console.Write("\nEmployee ID number: ");
            idEmployee = Console.ReadLine();

            Data.CreateEmployeeList();

            if (idEmployee.Length == 0) { Console.WriteLine("Returning to Leave Application"); Console.ReadKey(); Console.Clear(); SubMenu.LeaveReqUI(); }
            if (Admin.ValidateID(idEmployee))
            {

                Console.Write("\nName: ");
                nameEmployee = Console.ReadLine();

                Console.Write("\nDays of Leave: ");
                daysLeave = Console.ReadLine();

                Console.WriteLine();

                Data.CreateSickList();

                Data test = new Data(idEmployee, nameEmployee, daysLeave);

                data.AppendLine("Employee ID number\t\tName\t\t\tDays of Leave\t\t\t Type of Leave");
                data.AppendLine($"{test.EmployeeID}\t\t\t\t{test.Name}\t\t\t{test.Days}\t\t\t\t Sick Leave");
                Console.WriteLine(data.ToString());

                try
                {


                    List<string> lines = File.ReadAllLines(Data.data_path_s).ToList();

                    var employeeIDname = test.EmployeeID.ToString();
                    var name = test.Name.ToString();
                    var days = test.Days.ToString();



                    if (lines.Count == 0)
                    {
                        LeaveApp.firstSelectionSick(employeeIDname, name, days);

                    }
                    else
                    {
                        LeaveApp.secondSelectionSick(employeeIDname, name, days);
                    }


                    Console.WriteLine("\n*** Leave Request recorded. ***");

                    Console.WriteLine("Press ANY key to return to Menu.");
                    Console.ReadKey();

                    Console.Clear();

                    Menu.ShowUI();

                }
                catch (Exception e)
                {
                    string temp = e.Message;
                    Console.WriteLine(temp);

                }

            }
            else
            {
                Console.WriteLine("Invalid Employee ID");
                Console.ReadKey();
                Console.Clear();
                LeaveMenu.SickLeaveUI();
            }
        }


        public static void VacationLeaveUI()
        {

            var data = new StringBuilder();

            string idEmployee, nameEmployee, daysLeave;

            Console.WriteLine("*** Vacation Leave ***");

            Console.Write("\nEmployee ID number: ");
            idEmployee = Console.ReadLine();

            Data.CreateEmployeeList();

            if (idEmployee.Length == 0) { Console.WriteLine("Returning to Leave Application"); Console.ReadKey(); Console.Clear(); SubMenu.LeaveReqUI(); }
            if (Admin.ValidateID(idEmployee))
            {

                Console.Write("\nName: ");
                nameEmployee = Console.ReadLine();

                Console.Write("\nDays of Leave: ");
                daysLeave = Console.ReadLine();

                Console.WriteLine();

                Data.CreateVacationList();

                Data test = new Data(idEmployee, nameEmployee, daysLeave);

                data.AppendLine("Employee ID number\t\tName\t\t\tDays of Leave\t\t\t Type of Leave");
                data.AppendLine($"{test.EmployeeID}\t\t\t\t{test.Name}\t\t\t{test.Days}\t\t\t\t Vacation Leave");
                Console.WriteLine(data.ToString());

                try
                {


                    List<string> lines = File.ReadAllLines(Data.data_path_l).ToList();

                    var employeeIDname = test.EmployeeID.ToString();
                    var name = test.Name.ToString();
                    var days = test.Days.ToString();

                    if (lines.Count == 0)
                    {
                        LeaveApp.firstSelectionVacation(employeeIDname, name, days);

                    }
                    else
                    {
                        LeaveApp.secondSelectionVacation(employeeIDname, name, days);
                    }

                    Console.WriteLine("\n*** Leave Request recorded. ***");

                    Console.WriteLine("Press ANY key to return to Menu.");
                    Console.ReadKey();

                    Console.Clear();

                    Menu.ShowUI();


                }
                catch (Exception ee)
                {
                    string temp = ee.Message;

                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID");
                Console.ReadKey();
                Console.Clear();
                LeaveMenu.VacationLeaveUI();

            }
        }
    }
}
