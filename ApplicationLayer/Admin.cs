using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace ApplicationLayer
{
    public class Admin
    {

        public static bool ValidateEmployeeID(string EmployeeID, string Name)
        {

            return EmployeeID.Length != 0 && EmployeeID.EndsWith("PH") && Name.Length != 0;

        }

        public static bool ValidateID(string EmployeeID)
        {
            bool returnValid = false;

            List<string> lines = File.ReadAllLines(Data.data_path_e).ToList();
            foreach (string line in lines)
            {
                if (line.Contains(EmployeeID))
                {

                    returnValid = true;

                }
                else { returnValid = false; }
            }
            return returnValid;
        }


        public static string ViewSickLeaveEmployee()
        {
            if (!File.Exists(Data.data_path_s))
            {
                return "Empty";
            }
            string text = File.ReadAllText(Data.data_path_s);
            return text;
        }




        public static string ViewVacationLeaveEmployee()
        {


            if (!File.Exists(Data.data_path_l))
            {
                return "Empty";
            }
            string text = File.ReadAllText(Data.data_path_l);
            return text;
        }


        public static string AddList(string idEmployee, string name)
        {

            try
            {
                var data = new StringBuilder();
                Data.CreateEmployeeList();

                List<string> lines = File.ReadAllLines(Data.data_path_e).ToList();

                if (lines.Count == 0)
                {
                    Data.FirstWriteAddListEmployee();
                    Data.SecondWriteAddListEmployee(idEmployee, name);

                    return "success";
                }
                if (Admin.ValidateEmployeeID(idEmployee, name))
                {

                    Data.SecondWriteAddListEmployee(idEmployee, name);
                    return "success";

                }
                return "success";

            }
            catch (Exception e)
            {
                string temp = e.Message;
                return temp;
            }
        }

        public static string ReadDataEmployee()
        {

            if (!File.Exists(Data.data_path_e))
            {
                return "Empty";

            }
            string text = File.ReadAllText(Data.data_path_e);
            return text;
        }


        public static void UpdateList(string input, string newValue)
        {

            string text = File.ReadAllText(Data.data_path_e);
            text = text.Replace(input, newValue);
            File.WriteAllText(Data.data_path_e, text);

        }

        public static int DeleteList(string input)
        {


            if (input == "1")
            {
                return Data.DeleteSickLeaveList();

            }
            if (input == "2")
            {
                return Data.DeleteVacationLeaveList();
            }
            if (input == "3")
            {

                return Data.DeleteEmployeeList();


            }
            if (input == "4")
            {
                return 2;
            }

            return 5;


        }

    }

}
