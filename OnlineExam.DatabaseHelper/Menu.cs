using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineExam.DatabaseHelper
{
    public class Menu
    {
        public Menu()
        {
            CallMenuList();
        }

        public void CallMenuList()
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1) Rollback database");
            Console.WriteLine("2) Backup database");
            Console.WriteLine("3) Open backup folder");
            Console.WriteLine("4) Exit");
            Console.WriteLine("\nPress 1-4 to perform action (type 'help' for more info)");
            string command = Console.ReadLine();

            switch (command)
            {
                case ("1"):
                    Console.Clear();
                    Helper.RollbackDatabase();
                    Dialog("\nBack to menu? y/n");
                    break;
                case ("2"):
                    Console.Clear();
                    Danger("ATTENTION: this command will rewrite current backup file, you know what you doing??? (Yes/No)");
                    Dialog("\nBack to menu? y/n");
                    break;
                case ("3"):
                    Console.Clear();
                    Console.WriteLine($"Backup path: {Framework.CurrentPath.BACKUP_PATH}");
                    System.Diagnostics.Process.Start(Path.GetFullPath(Path.Combine(Framework.CurrentPath.BACKUP_PATH, @"..\")));
                    Dialog("\nBack to menu? y/n");
                    break;
                case ("4"):
                    Environment.Exit(0);
                    break;
                default:
                    Dialog("Undefined command try again? y/n");
                    break;
            }
        }

        public void Dialog(string message)
        {
            Console.WriteLine(message);
            string command = Console.ReadLine();

            switch (command)
            {
                case ("y"):
                    Console.Clear();
                    CallMenuList();
                    break;
                case ("n"):
                    Environment.Exit(0);
                    break;
                default:
                    Dialog("Undefined command try again");
                    break;
            }
        }

        public void Danger(string message)
        {
            Console.WriteLine(message);

            string command = Console.ReadLine();

            switch (command)
            {
                case ("Yes"):
                    Console.Clear();
                    Helper.BackupDatabase();
                    break;
                case ("No"):
                    Console.Clear();
                    CallMenuList();
                    break;
                default:
                    Danger("Undefined command try again");
                    break;
            }
        }
    }
}
