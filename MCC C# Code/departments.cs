using System.Data.SqlClient;

namespace MCC_C__Code
{
    public class departments
    {
        static string connectionString = "Data Source=MSI;Database=db_hr;Integrated Security=True;Connect Timeout=30;";


        static SqlConnection connection;

        public int id { get; set; }
        public string name { get; set; }
        public int location_id { get; set; }
        public int? manager_id { get; set; }

        public static List<departments> GetAllDepartments()
        {

            SqlConnection connection;
            connection = new SqlConnection(connectionString);

            var departments = new List<departments>();
            try
            {

                connection = new SqlConnection(connectionString);

                //membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_departments";

                //membuka koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var department = new departments();
                        department.id = reader.GetInt32(0);
                        department.name = reader.GetString(1);
                        department.location_id = reader.GetInt32(2);
                        department.manager_id = reader.GetInt32(3);
                        departments.Add(department);
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
            return departments;
        }
    }
}
