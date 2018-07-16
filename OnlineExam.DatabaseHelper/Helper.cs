using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DatabaseHelper
{
    public class Helper
    {
        public static void BackupDatabase(string backupDestinationFilePath)
        {
            try
            {
                Console.WriteLine("Backup operation started");
                Backup backup = new Backup();
                backup.Action = BackupActionType.Database;
                backup.BackupSetName = "Backup";
                backup.Database = "Main";
                BackupDeviceItem deviceItem = new BackupDeviceItem(backupDestinationFilePath, DeviceType.File);
                backup.Devices.Add(deviceItem);
                ServerConnection connection = new ServerConnection(@"(LocalDb)\MSSQLLocalDB");
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

        public static void RestoreDatabase(string backUpFilePath, string databaseName)
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
                ServerConnection connection = new ServerConnection(@"(LocalDb)\MSSQLLocalDB");
                connection.LoginSecure = true;
                Server sqlServer = new Server(connection);        
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
