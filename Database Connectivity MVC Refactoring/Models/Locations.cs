using System.Data.SqlClient;
using Database_Connectivity_MVC_Refactoring.Connections;

namespace Database_Connectivity_MVC_Refactoring.Models
{
    public class Locations
    {
        public int id { get; set; }
        public string street_address { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string country_id { get; set; }

        public List<Locations> GetAllLocations()
        {

            SqlConnection connection;
            connection = DatabaseConnection.GetConnection();

            var locations = new List<Locations>();
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
                        var location = new Locations();
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
            Locations locations = new Locations();
            Console.Clear();
            List<Locations> locationsList = locations.GetAllLocations();
            foreach (Locations loc in locationsList)
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
        }

    }
}
