using OnlineExam.Framework;
using System;
using System.Data.SqlClient;

namespace OnlineExam.DatabaseHelper
{
    public class Helper
    {
        // ༼ つ ಥ_ಥ ༽つ
        // Created by Roma Bahlai
        private static string conection = $"Server = {BaseSettings.Fields.ServerName}; Database = {BaseSettings.Fields.DatabaseName}; integrated security = True";
        public static void RollbackDatabase()
        {
            Console.WriteLine("Restore operation started");
            SqlConnection con = new SqlConnection(conection);
            string database = con.Database.ToString();
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            try
            {            
                SqlCommand singleUserQuery = new SqlCommand("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", con);
                singleUserQuery.ExecuteNonQuery();

                SqlCommand restoreDatabaseQuery = new SqlCommand("USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + CurrentPath.BACKUP_PATH +"' WITH REPLACE;", con);
                restoreDatabaseQuery.ExecuteNonQuery();

                SqlCommand multiUserQuery = new SqlCommand("ALTER DATABASE [" + database + "] SET MULTI_USER", con);
                multiUserQuery.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Restore operation succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Restore operation failed");
                Console.WriteLine(ex.Message);
                SqlCommand multiUserQuery = new SqlCommand("ALTER DATABASE [" + database + "] SET MULTI_USER", con);
                multiUserQuery.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void BackupDatabase()
        {
            try
            {
                Console.WriteLine("Backup operation started");
                string backupLocation = System.IO.Path.Combine(CurrentPath.PROJECT_PATH, "Backup", "OnlineExamDB.bak");
                System.IO.File.Delete(backupLocation);
                var sqlConStrBuilder = new SqlConnectionStringBuilder(conection);
                using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
                {
                    var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'", sqlConStrBuilder.InitialCatalog, backupLocation);
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Backup operation succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Backup operation failed");
                Console.WriteLine(ex.Message);
            }
        }
    }
}