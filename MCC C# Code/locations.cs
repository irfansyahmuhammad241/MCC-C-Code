using System.Data.SqlClient;

namespace MCC_C__Code
{
    public class locations
    {
        SqlConnection connect = DatabaseConnection.GetConnection();

        public int id { get; set; }
        public string street_address { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string country_id { get; set; }

        public List<locations> GetAllLocations()
        {

            SqlConnection connection;
            connection = DatabaseConnection.GetConnection();

            var locations = new List<locations>();
            try
            {

                connection = DatabaseConnection.GetConnection();

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
                        location.postal_code = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        location.city = reader.GetString(3);
                        location.state_province = reader.IsDBNull(4) ? " " : reader.GetString(4);
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

        public void LocationsMenu()
        {
            locations locations = new locations();
            Console.Clear();
            List<locations> locationsList = locations.GetAllLocations();
            foreach (locations loc in locationsList)
            {

                Console.WriteLine("Id : " + loc.id +
                    ", Street Addres : " + loc.street_address +
                    ", Postal Code : " + loc.postal_code +
                    ", City : " + loc.city +
                    ", State Province : " + loc.state_province +
                    ", Country ID : " + loc.country_id);
            }

            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
            Program.Menu();
        }
    }
}
