using System.Data.SqlClient;

namespace MCC_C__Code
{
    public class locations
    {
        static string connectionString = "Data Source=MSI;Database=db_hr;Integrated Security=True;Connect Timeout=30;";


        static SqlConnection connection;

        public int id { get; set; }
        public string street_address { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string country_id { get; set; }

        public static List<locations> GetAllLocations()
        {

            SqlConnection connection;
            connection = new SqlConnection(connectionString);

            var locations = new List<locations>();
            try
            {

                connection = new SqlConnection(connectionString);

                //membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_locations";

                //membuka koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var location = new locations();
                        location.id = reader.GetInt32(0);
                        location.street_address = reader.GetString(1);
                        location.postal_code = reader.GetString(2);
                        location.city = reader.GetString(3);
                        location.state_province = reader.GetString(4);
                        location.country_id = reader.GetString(5);
                        locations.Add(location);
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
            return locations;
        }
    }
}
