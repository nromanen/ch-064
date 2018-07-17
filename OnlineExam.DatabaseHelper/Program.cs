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
            string PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //Console.WriteLine("Type 'help' for more info.");
            //Helper.BackupDatabase(@"C:\Users\FeareD\Desktop\Test.bak");

            //Helper.RestoreDatabase(@"C:\Users\FeareD\Desktop\Test.bak","Main");
            //Helper.RestoreDatabase(@"C:\Users\FeareD\Desktop\MainBackup.bak", "Main", "(LocalDb)\\MSSQLLocalDB");
            Console.ReadKey();
        }
    }
}
