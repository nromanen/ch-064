using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using OnlineExam.Framework;
using System;
using System.Data.SqlClient;

namespace OnlineExam.DatabaseHelper
{
    public class Helper
    {
        // ༼ つ ಥ_ಥ ༽つ
        //default server connection: @"(LocalDb)\MSSQLLocalDB"
        //default database name: Main
        public static void BackupDatabase(string databaseName, string serverConnection)
        {
            try
            {
                Console.WriteLine("Backup operation started");
                Backup backup = new Backup();
                backup.Action = BackupActionType.Database;
                backup.BackupSetName = "Backup";
                backup.Database = databaseName;
                BackupDeviceItem deviceItem = new BackupDeviceItem(Constants.BACKUP_PATH, DeviceType.File);
                backup.Devices.Add(deviceItem);
                ServerConnection connection = new ServerConnection(serverConnection);
                connection.LoginSecure = true;
                //connection.Login = "testuser";
                //connection.Password = "testuser";
                Server sqlServer = new Server(connection);
                backup.Initialize = true;
                backup.Checksum = true;
                backup.ContinueAfterError = true;
                backup.LogTruncation = BackupTruncateLogType.Truncate;
                backup.SqlBackup(sqlServer);
                Console.WriteLine("Backup operation succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Backup operation failed");
                Console.WriteLine(ex.Message);
            }
        }

        public static void BackupDatabase()
        {
            try
            {
                Console.WriteLine("Backup operation started");
                Backup backup = new Backup();
                backup.Action = BackupActionType.Database;
                backup.BackupSetName = "Backup";
                backup.Database = "OnlineExamDB";
                BackupDeviceItem deviceItem = new BackupDeviceItem(Constants.BACKUP_PATH, DeviceType.File);
                backup.Devices.Add(deviceItem);
                ServerConnection connection = new ServerConnection(@"DESKTOP-424095L\SQLEXPRESS");
                connection.LoginSecure = true;
                //connection.Login = "testuser";
                //connection.Password = "testuser";
                Server sqlServer = new Server(connection);
                backup.Initialize = true;
                backup.Checksum = true;
                backup.ContinueAfterError = true;
                backup.LogTruncation = BackupTruncateLogType.Truncate;
                backup.SqlBackup(sqlServer);
                Console.WriteLine("Backup operation succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Backup operation failed");
                Console.WriteLine(ex.Message);
            }
        }

        public static void RestoreDatabase(string databaseName, string serverConnection)
        {
            try
            {
                Console.WriteLine("Restore operation started");
                Restore restore = new Restore();
                restore.Database = databaseName;
                restore.Action = RestoreActionType.Database;
                restore.Devices.AddDevice(Constants.BACKUP_PATH, DeviceType.File);
                restore.ReplaceDatabase = true;
                restore.NoRecovery = false;
                ServerConnection connection = new ServerConnection(serverConnection);
                connection.LoginSecure = true;
                Server sqlServer = new Server(connection);
                sqlServer.KillAllProcesses(databaseName);

                string conection =
                    "data source = DESKTOP-424095L\\SQLEXPRESS; initial catalog = OnlineExamDB; integrated security = True; MultipleActiveResultSets = True;";

                using (var ctx = new DataModel(conection))
                {
                    ctx.Database.ExecuteSqlCommandAsync(
                        "ALTER DATABASE [OnlineExamDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE" +
                        "USE MASTER RESTORE DATABASE [OnlineExamDB] FROM DISK=" +
                        Constants.BACKUP_PATH + " WITH REPLACE; " +
                        "ALTER DATABASE [OnlineExamDB] SET MULTI_USER");
                    //ctx.Database.ExecuteSqlCommand(
                    //    "ALTER DATABASE [OnlineExamDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");

                    //ctx.Database.ExecuteSqlCommand("USE MASTER RESTORE DATABASE [OnlineExamDB] FROM DISK=" +
                    //                               Constants.BACKUP_PATH + " WITH REPLACE; ");
                    //ctx.Database.ExecuteSqlCommand("ALTER DATABASE [OnlineExamDB] SET MULTI_USER");
                }

                //sqlServer.ConnectionContext.ExecuteNonQuery(
                //    "ALTER DATABASE [OnlineExamDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                //sqlServer.ConnectionContext.ExecuteNonQuery("USE MASTER RESTORE DATABASE [OnlineExamDB] FROM DISK=" +
                //                                            Constants.BACKUP_PATH + " WITH REPLACE; ");
                //sqlServer.ConnectionContext.ExecuteNonQuery("ALTER DATABASE [OnlineExamDB] SET MULTI_USER");


                restore.SqlRestore(sqlServer);
                connection.Disconnect();
                Console.WriteLine("Restore operation succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Restore operation failed");
                Console.WriteLine(ex.Message);
            }
        }

        // private static string conection = "data source = DESKTOP-424095L\\SQLEXPRESS; initial catalog = OnlineExamDB; integrated security = True; MultipleActiveResultSets = True;";


        public static void RestoreDatabase()
        {
            try

            {
                Console.WriteLine("Restore operation started");
                Restore restore = new Restore();
                ServerConnection connection = new ServerConnection(@"DESKTOP-424095L\SQLEXPRESS");
                connection.LoginSecure = true;
                Server sqlServer = new Server(connection);

                //  sqlServer.KillAllProcesses("OnlineExamDB");
                sqlServer.ConnectionContext.ExecuteNonQuery(
                    "ALTER DATABASE [OnlineExamDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                sqlServer.ConnectionContext.ExecuteNonQuery("USE MASTER RESTORE DATABASE [OnlineExamDB] FROM DISK=" +
                                                            Constants.BACKUP_PATH + " WITH REPLACE; ");
                sqlServer.ConnectionContext.ExecuteNonQuery("ALTER DATABASE [OnlineExamDB] SET MULTI_USER");


                //sqlServer.KillAllProcesses("OnlineExamDB");
                restore.SqlRestore(sqlServer);
                Console.WriteLine("Restore operation succeeded");
            }
            //SqlConnection con = new SqlConnection(conection);
            //string database = con.Database.ToString();
            //if (con.State != System.Data.ConnectionState.Open)
            //{
            //    con.Open();
            //}
            //try
            //{
            //    Console.WriteLine("Restore operation started");

            //    SqlCommand singleUserQuery = new SqlCommand("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", con);
            //    singleUserQuery.ExecuteNonQuery();

            //    SqlCommand restoreDatabaseQuery = new SqlCommand("USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + Constants.BACKUP_PATH + "' WITH REPLACE;", con);
            //    restoreDatabaseQuery.ExecuteNonQuery();

            //    SqlCommand multiUserQuery = new SqlCommand("ALTER DATABASE [" + database + "] SET MULTI_USER", con);
            //    multiUserQuery.ExecuteNonQuery();
            //    con.Close();
            //    Console.WriteLine("Restore operation succeeded");
            //}

            catch (Exception ex)
            {
                Console.WriteLine("Restore operation failed");
                Console.WriteLine(ex.Message);
            }
        }
    }
}