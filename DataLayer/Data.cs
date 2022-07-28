using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Data
    {
        private string adminUserName = "admin";
        private string adminPass = "admin";
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Days { get; set; }

        public string UserName { get; }
        public string PassWord { get; }

        public static string data_path_s = @"C:\Users\DT\source\repos\EmployeeLeaveSystem\EmployeeLeaveSystem\SickLeave.txt";
        public static string data_path_l = @"C:\Users\DT\source\repos\EmployeeLeaveSystem\EmployeeLeaveSystem\VacationLeave.txt";
        public static string data_path_e = @"C:\Users\DT\source\repos\EmployeeLeaveSystem\EmployeeLeaveSystem\EmployeeList.txt";
        public Data(string id, string name, string days)
        {
            EmployeeID = id;
            Name = name;
            Days = days;
            this.UserName = adminUserName;
            this.PassWord = adminPass;
        }


        public static void CreateSickList()
        {

            if (!File.Exists(Data.data_path_s))
            {
                using StreamWriter sw = File.CreateText(Data.data_path_s);
            }
        }


        public static void CreateVacationList()
        {

            if (!File.Exists(Data.data_path_l))
            {
                using StreamWriter sw = File.CreateText(Data.data_path_l);
            }
        }

        public static void CreateEmployeeList()
        {

            if (!File.Exists(Data.data_path_e))
            {
                using StreamWriter sw = File.CreateText(Data.data_path_e); 
            }

        }


        public static int DeleteSickLeaveList()
        {
            if (File.Exists(Data.data_path_s))
            {
                File.Delete(Data.data_path_s);
                return 1;
            }
            else
            {
                return 0;

            }

        }

        public static int DeleteVacationLeaveList()
        {
            if (File.Exists(Data.data_path_l))
            {

                File.Delete(Data.data_path_l);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static int DeleteEmployeeList()
        {
            if (File.Exists(Data.data_path_e))
            {
                File.Delete(Data.data_path_e);
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public static void FirstWriteAddListEmployee()
        {

            List<string> lines = File.ReadAllLines(Data.data_path_e).ToList();
            string text = string.Format("|{0,-30}|{1,-30}", "Employee ID", "Name");
            lines.Add(text);
            File.WriteAllLines(Data.data_path_e, lines);

        }

        public static void SecondWriteAddListEmployee(string idEmployee, string name)
        {

            List<string> lines = File.ReadAllLines(Data.data_path_e).ToList();
            string text2 = string.Format("|{0,-30}|{1,-30}", idEmployee, name);
            lines.Add(text2);
            File.WriteAllLines(Data.data_path_e, lines);

        }
    }
}
