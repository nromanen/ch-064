using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DatabaseHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Contains("restore"))
            {
                Helper.RestoreDatabase("OnlineExamDB", @"DESKTOP-424095L\SQLEXPRESS");
                Console.WriteLine("roma ne molodez");
            }
            //Helper.RestoreDatabase("OnlineExamDB", @"DESKTOP-424095L\SQLEXPRESS");

            //Console.Read();

            //problem with db
        }
    }
}