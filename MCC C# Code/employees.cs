using System.Data.SqlClient;

namespace MCC_C__Code
{
    public class employees
    {

        SqlConnection connect = DatabaseConnection.GetConnection();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public decimal ComissionPct { get; set; }
        public int ManagerId { get; set; }
        public string JobId { get; set; }
        public int DepartmentId { get; set; }

        // GetAllLocation : Location
        public List<employees> GetAllEmployees()
        {

            SqlConnection connection;
            connection = DatabaseConnection.GetConnection();

            var employees = new List<employees>();
            try
            {
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
                        emp.Id = reader.GetInt32(0);
                        emp.FirstName = reader.GetString(1);
                        emp.LastName = reader.GetString(2);
                        emp.Email = reader.GetString(3);
                        emp.PhoneNumber = reader.GetString(4);
                        emp.HireDate = reader.GetDateTime(5);
                        emp.Salary = reader.GetInt32(6);
                        emp.ComissionPct = reader.GetDecimal(7);
                        emp.ManagerId = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                        emp.JobId = reader.GetString(9);
                        emp.DepartmentId = reader.GetInt32(10);

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

        public void EmployeesMenu()
        {
            employees employees = new employees();
            Console.Clear();
            List<employees> employeesList = employees.GetAllEmployees();
            foreach (employees emp in employeesList)
            {
                Console.WriteLine("ID : " + emp.Id +
                    ", First Name : " + emp.FirstName +
                    ", Last Name : " + emp.LastName +
                    ", Email : " + emp.Email +
                    ", Phone Number : " + emp.PhoneNumber +
                    ", Hire Date ID : " + emp.HireDate +
                    ", Salary :  " + emp.Salary +
                    ", Comission : " + emp.ComissionPct +
                    ", Manager ID : " + emp.ManagerId +
                    "Job ID : " + emp.JobId +
                    ", Department ID : " + emp.DepartmentId);



            }

            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
            Program.Menu();
        }

    }
}
