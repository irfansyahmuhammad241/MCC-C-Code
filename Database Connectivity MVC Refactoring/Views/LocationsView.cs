using Database_Connectivity_MVC_Refactoring.Models;

namespace Database_Connectivity_MVC_Refactoring.Views
{
    public class LocationsView
    {
        public static List<Locations> GetAllData()
        {
            Locations locations = new Locations();

            List<Locations> locationList = locations.GetAllLocations();

            return locationList;
        }
    }
}
