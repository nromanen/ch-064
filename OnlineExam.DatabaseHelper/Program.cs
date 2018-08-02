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
                Helper.RollbackDatabase();
            }

            if (args.Contains("backup"))
            {
                Helper.BackupDatabase();
            }
            //Helper.RollBack();
            //Helper.RollbackDatabase();
            Helper.BackupDatabase();
        }
    }
}