using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LeaveData
    {
        public static void firstWriteVationLeave(string text)
        {

            List<string> lines = File.ReadAllLines(Data.data_path_l).ToList();
            lines.Add(text);
            File.WriteAllLines(Data.data_path_l, lines);


        }

        public static void secondWriteVationLeave(string text)
        {

            List<string> lines = File.ReadAllLines(Data.data_path_l).ToList();

            lines.Add(text);

            File.WriteAllLines(Data.data_path_l, lines);

        }

        public static void firstWriteSickLeave(string text)
        {

            List<string> lines = File.ReadAllLines(Data.data_path_s).ToList();
            lines.Add(text);
            File.WriteAllLines(Data.data_path_s, lines);


        }

        public static void secondWriteSickLeave(string text)
        {

            List<string> lines = File.ReadAllLines(Data.data_path_s).ToList();

            lines.Add(text);

            File.WriteAllLines(Data.data_path_s, lines);

        }
    }
}
