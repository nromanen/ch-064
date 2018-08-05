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
            if (args.Count() == 0)
            {
                Menu menu = new Menu();
            }
            else if (args.Contains("restore"))
            {
                Helper.RollbackDatabase();
            }
            else if (args.Contains("backup"))
            {
                Helper.BackupDatabase();
            }
        }
    }
}