using System.Data.SqlClient;
using Database_Connectivity_MVC_Refactoring.Connections;

namespace Database_Connectivity_MVC_Refactoring.Models
{
    public class Histories
    {
        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime EndDate { get; set; }
        public int DepartmentId { get; set; }
        public string JobId { get; set; }

        public List<Histories> GetAllHistories()
        {

            SqlConnection connection;
            connection = DatabaseConnection.GetConnection();

            var histories = new List<Histories>();
            try
            {

                connection = DatabaseConnection.GetConnection();

                //membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT start_date, employee_id, end_date, department_id, job_id FROM tb_tr_histories";
                //membuka koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var history = new Histories();
                        history.StartDate = reader.GetDateTime(0);
                        history.EmployeeId = reader.GetInt32(1);
                        history.EndDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        history.DepartmentId = reader.GetInt32(3);
                        history.JobId = reader.GetString(4);

                        histories.Add(history);// Menambahkan objek Department ke dalam list
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

        public void HistoriesMenu()
        {
            Histories histories = new Histories();
            Console.Clear();
            List<Histories> historyList = histories.GetAllHistories();
            foreach (Histories history in historyList)
            {

                Console.WriteLine("Start_Date : " + history.StartDate +
                    "Employee_ID : " + history.EmployeeId +
                    ", End_Date : " + history.EndDate +
                    ",  Department ID : " + history.DepartmentId +
                    ", Job_ID : " + history.JobId);

            }

            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
        }
    }
}
