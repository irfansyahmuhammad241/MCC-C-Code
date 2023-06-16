using System.Data.SqlClient;

namespace MCC_C__Code
{
    public class DatabaseConnection
    {
        static string connectionString = "Data Source=MSI;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public static SqlConnection GetConnection()
        {
            connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
