﻿using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using OnlineExam.Framework;
using System;

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
                restore.SqlRestore(sqlServer);
                Console.WriteLine("Restore operation succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Restore operation failed");
                Console.WriteLine(ex.Message);
            }
        }

        public static void RestoreDatabase()
        {
            try
            {
                Console.WriteLine("Restore operation started");
                Restore restore = new Restore();
                restore.Database = "OnlineExamDB";
                restore.Action = RestoreActionType.Database;
                restore.Devices.AddDevice(Constants.BACKUP_PATH, DeviceType.File);
                restore.ReplaceDatabase = true;
                restore.NoRecovery = false;
                ServerConnection connection = new ServerConnection(@"DESKTOP-424095L\SQLEXPRESS");
                connection.LoginSecure = true;
                Server sqlServer = new Server(connection);
                sqlServer.KillAllProcesses("OnlineExamDB");
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