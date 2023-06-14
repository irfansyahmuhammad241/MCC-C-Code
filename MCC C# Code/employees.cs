using System.Data.SqlClient;

namespace MCC_C__Code
{
    public class employees
    {

        static string connectionString = "Data Source=MSI;Database=db_hr;Integrated Security=True;Connect Timeout=30;";


        static SqlConnection connection;

        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime hire_date { get; set; }
        public double salary { get; set; }
        public decimal commission_pct { get; set; }
        public int manager_id { get; set; }
        public int job_id { get; set; }
        public int department_id { get; set; }

        public static List<employees> GetAllEmployees()
        {

            SqlConnection connection;
            connection = new SqlConnection(connectionString);

            var employees = new List<employees>();
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
                        var employee = new employees();
                        employee.id = reader.GetInt32(0);
                        employee.first_name = reader.GetString(1);
                        employee.last_name = reader.GetString(2);
                        employee.email = reader.GetString(3);
                        employee.phone = reader.GetString(4);
                        employee.hire_date = reader.GetDateTime(5);
                        employee.salary = reader.GetDouble(6);
                        employee.commission_pct = reader.GetDecimal(7);
                        employee.manager_id = reader.GetInt32(8);
                        employee.job_id = reader.GetInt32(9);
                        employee.department_id = reader.GetInt32(10);
                        employees.Add(employee);
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
            return employees;
        }

    }
}
