using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace ApplicationLayer
{
    public class LeaveApp
    {


        public static void firstSelectionVacation(string employeeIDname, string name, string days)
        {



            string text = string.Format("|{0,-30}|{1,-30}|{2,-15}|{3,-30}", "Employee ID", "Name", "Days of Leave", "Type of Leave");

            string text2 = string.Format("|{0,-30}|{1,-30}|{2,-15}|{3,-30}", employeeIDname, name, days, "Vacation Leave");

            LeaveData.firstWriteVationLeave(text);

            LeaveData.secondWriteVationLeave(text2);


        }

        public static void secondSelectionVacation(string employeeIDname, string name, string days)
        {



            string text2 = string.Format("|{0,-30}|{1,-30}|{2,-15}|{3,-30}", employeeIDname, name, days, "Vacation Leave");

            LeaveData.secondWriteVationLeave(text2);
        }


        public static void firstSelectionSick(string employeeIDname, string name, string days)
        {



            string text = string.Format("|{0,-30}|{1,-30}|{2,-15}|{3,-30}", "Employee ID", "Name", "Days of Leave", "Type of Leave");

            string text2 = string.Format("|{0,-30}|{1,-30}|{2,-15}|{3,-30}", employeeIDname, name, days, "Vacation Leave");

            LeaveData.firstWriteSickLeave(text);

            LeaveData.secondWriteSickLeave(text2);



        }

        public static void secondSelectionSick(string employeeIDname, string name, string days)
        {

            List<string> lines = File.ReadAllLines(Data.data_path_s).ToList();

            string text2 = string.Format("|{0,-30}|{1,-30}|{2,-15}|{3,-30}", employeeIDname, name, days, "Vacation Leave");

            LeaveData.secondWriteSickLeave(text2);

        }
    }
}
