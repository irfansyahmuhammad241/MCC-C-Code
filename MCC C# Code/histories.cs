using System.Data.SqlClient;

namespace MCC_C__Code
{
    public class histories
    {
        static string connectionString = "Data Source=MSI;Database=db_hr;Integrated Security=True;Connect Timeout=30;";


        static SqlConnection connection;

        public DateTime start_date { get; set; }
        public int employee_id { get; set; }
        public DateTime end_date { get; set; }
        public int department_id { get; set; }
        public string job_id { get; set; }

        public static List<histories> GetAllHistories()
        {

            SqlConnection connection;
            connection = new SqlConnection(connectionString);

            var histories = new List<histories>();
            try
            {

                connection = new SqlConnection(connectionString);

                //membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_countries";

                //membuka koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var history = new histories();
                        history.start_date = reader.GetDateTime(0);
                        history.employee_id = reader.GetInt32(1);
                        history.end_date = reader.GetDateTime(2);
                        history.department_id = reader.GetInt32(3);
                        history.job_id = reader.GetString(4);
                        histories.Add(history);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return histories;
        }
    }
}
