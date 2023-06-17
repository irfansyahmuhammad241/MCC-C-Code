using System.Data.SqlClient;
using Database_Connectivity_MVC_Refactoring.Connections;

namespace Database_Connectivity_MVC_Refactoring.Models
{
    public class Jobs
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }

        public List<Jobs> GetAllJobs()
        {
            SqlConnection connection;
            connection = DatabaseConnection.GetConnection();

            var jobs = new List<Jobs>();
            try
            {

                connection = DatabaseConnection.GetConnection();

                //membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT id, title, min_salary, max_salary FROM tb_m_jobs";

                //membuka koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var job = new Jobs();
                        job.Id = reader.GetString(0);
                        job.Title = reader.GetString(1);
                        job.MinSalary = Convert.ToDouble(reader.GetInt32(2));
                        job.MaxSalary = Convert.ToDouble(reader.GetInt32(3));
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

        public void JobsMenu()
        {
            Jobs jobs = new Jobs();
            Console.Clear();
            List<Jobs> jobsList = jobs.GetAllJobs();
            foreach (Jobs job in jobsList)
            {
                Console.WriteLine("ID : " + job.Id +
                    ", Title : " + job.Title +
                    ", Min Salary : " + job.MinSalary +
                    ",  Max Salary : " + job.MaxSalary);

            }

            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
        }
    }
}
