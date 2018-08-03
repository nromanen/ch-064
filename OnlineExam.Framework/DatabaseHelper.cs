using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Framework
{
    public class DatabaseHelper
    {
        private static string conection = BaseSettings.GetConnectionString();
        public static void BackupDatabase()
        {
            string backupLocation = System.IO.Path.Combine(Constants.PROJECT_PATH, "Backup", "Main.bak");
            System.IO.File.Delete(backupLocation);
            
            var sqlConStrBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder(conection);
            

            using (var connection = new System.Data.SqlClient.SqlConnection(sqlConStrBuilder.ConnectionString))
            {
                var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'", sqlConStrBuilder.InitialCatalog, backupLocation);
                Console.WriteLine(query);

                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void RollbackDatabase()
        {
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

                SqlCommand restoreDatabaseQuery = new SqlCommand("USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + Environment.CurrentDirectory + "\\Backup\\Main.bak' WITH REPLACE;", con);
                restoreDatabaseQuery.ExecuteNonQuery();

                SqlCommand multiUserQuery = new SqlCommand("ALTER DATABASE [" + database + "] SET MULTI_USER", con);
                multiUserQuery.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
