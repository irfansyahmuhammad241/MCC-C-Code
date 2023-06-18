using Database_Connectivity_MVC_Refactoring.Models;
using Database_Connectivity_MVC_Refactoring.Views;

namespace Database_Connectivity_MVC_Refactoring.Controllers
{
    public class LocationsController
    {
        public void GetAllData()
        {
            bool result = false;
            var list = LocationsView.GetAllData();

            if (list != null)
            {
                result = true;
                foreach (Locations locations in list)
                {
                    Console.WriteLine($"ID: {locations.id} | " +
                        $"Street Address: {locations.street_address} | " +
                        $"Postal Code: {locations.postal_code} | " +
                        $"City: {locations.city} | " +
                        $"Country ID: {locations.country_id}");
                }
            }
            else
            {
                Console.WriteLine("Data Not Found");
            }
        }
    }
}
