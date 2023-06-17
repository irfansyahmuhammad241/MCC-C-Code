using System.Data.SqlClient;
using Database_Connectivity_MVC_Refactoring.Connections;

namespace Database_Connectivity_MVC_Refactoring.Models
{
    public class Departments
    {
        public int id { get; set; }
        public string name { get; set; }
        public int location_id { get; set; }
        public int? manager_id { get; set; }

        public List<Departments> GetAllDepartments()
        {

            SqlConnection connection;
            connection = DatabaseConnection.GetConnection(); ;

            var departments = new List<Departments>();
            try
            {

                connection = DatabaseConnection.GetConnection(); ;

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
                        var department = new Departments();
                        department.id = reader.GetInt32(0);
                        department.name = reader.GetString(1);
                        department.location_id = reader.GetInt32(2);
                        department.manager_id = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
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

        public void DepartmentMenu()
        {
            Departments departments = new Departments();
            Console.Clear();
            List<Departments> departmentsList = departments.GetAllDepartments();
            foreach (Departments dep in departmentsList)
            {

                Console.WriteLine("Id : " + dep.id + ", Department Name : " + dep.name + ", Location ID : " + dep.location_id + ", Manager ID : " + dep.manager_id);
            }

            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
        }
    }
}
