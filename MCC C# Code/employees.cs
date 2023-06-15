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
        public string phone_number { get; set; }
        public DateTime hire_date { get; set; }
        public int salary { get; set; }
        public decimal comission { get; set; }
        public int manager_id { get; set; }
        public string job_id { get; set; }
        public int department_id { get; set; }

        // GetAllLocation : Location
        public List<employees> GetAllEmployees()
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
                command.CommandText = "Select * From tb_m_employees";

                //membuka koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var emp = new employees();
                        emp.id = reader.GetInt32(0);
                        emp.first_name = reader.GetString(1);
                        emp.last_name = reader.GetString(2);
                        emp.email = reader.GetString(3);
                        emp.phone_number = reader.GetString(4);
                        emp.hire_date = reader.GetDateTime(5);
                        emp.salary = reader.GetInt32(6);
                        emp.comission = reader.GetDecimal(7);
                        emp.manager_id = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                        emp.job_id = reader.GetString(9);
                        emp.department_id = reader.GetInt32(10);

                        employees.Add(emp);// Menambahkan objek Location ke dalam list
                    }
                }
                else
                {
                    Console.WriteLine("Data not found!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            connection.Close();
            return employees; // Mengembalikan list regions yang berisi objek-objek Region
        }

    }
}
