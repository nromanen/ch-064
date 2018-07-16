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
            Console.WriteLine("Type 'help' for more info.");
            Console.Write(">");
            Helper.BackupDatabase(@"C:\Users\FeareD\Desktop\Test.bak");
            Helper.RestoreDatabase(@"C:\Users\FeareD\Desktop\Test.bak","Main");

            Console.ReadKey();
        }
    }
}
