using System.Data.SqlClient;

namespace MCC_C__Code
{
    public class jobs
    {
        static string connectionString = "Data Source=MSI;Database=db_hr;Integrated Security=True;Connect Timeout=30;";


        static SqlConnection connection;

        public string id { get; set; }
        public string title { get; set; }
        public double min_salary { get; set; }
        public double max_salary { get; set; }

        public List<jobs> GetAllJobs()
        {


            SqlConnection connection;
            connection = new SqlConnection(connectionString);

            var jobs = new List<jobs>();
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
                        var job = new jobs();
                        job.id = reader.GetString(0);
                        job.title = reader.GetString(1);
                        job.min_salary = reader.GetDouble(2);
                        job.max_salary = reader.GetDouble(3);
                        jobs.Add(job);
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
            return jobs;
        }
    }
}
