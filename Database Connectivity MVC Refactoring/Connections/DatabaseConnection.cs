using System.Data.SqlClient;

namespace Database_Connectivity_MVC_Refactoring.Connections
{
    public class DatabaseConnection
    {
        private static string connectionString = "Data Source=MSI;Database=db_hr;Integrated Security=True;Connect Timeout=30;";


        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
