using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;

namespace OnlineExam.DatabaseHelper
{
    public class Helper
    {
        // ༼ つ ಥ_ಥ ༽つ
        //default server connection: @"(LocalDb)\MSSQLLocalDB"
        //default database name: Main
        public static void BackupDatabase(string backupDestinationFilePath, string databaseName, string serverConnection)
        {
            try
            {
                Console.WriteLine("Backup operation started");
                Backup backup = new Backup();
                backup.Action = BackupActionType.Database;
                backup.BackupSetName = "Backup";
                backup.Database = databaseName;
                BackupDeviceItem deviceItem = new BackupDeviceItem(backupDestinationFilePath, DeviceType.File);
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

        public static void RestoreDatabase(string backUpFilePath, string databaseName, string serverConnection)
        {
            try
            {
                Console.WriteLine("Restore operation started");
                Restore restore = new Restore();
                restore.Database = databaseName;
                restore.Action = RestoreActionType.Database;       
                restore.Devices.AddDevice(backUpFilePath, DeviceType.File);
                restore.ReplaceDatabase = true;
                restore.NoRecovery = false;
                ServerConnection connection = new ServerConnection(serverConnection);
                connection.LoginSecure = true;
                Server sqlServer = new Server(connection);
                sqlServer.KillAllProcesses(databaseName);
                restore.SqlRestore(sqlServer);
                Console.WriteLine("Restore operation succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Restore operation failed");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
