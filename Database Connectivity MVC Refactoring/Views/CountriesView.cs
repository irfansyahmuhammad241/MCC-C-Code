using Database_Connectivity_MVC_Refactoring.Models;

namespace Database_Connectivity_MVC_Refactoring.Views
{
    public class CountriesView
    {
        public static void InputID()
        {
            Console.Write("Input the ID               : ");
        }
        public static void InputName()
        {
            Console.Write("Enter the Name of Country  : ");
        }
        public static void InputRegionID()
        {
            Console.Write("Enter the ID of Region     : ");
        }
        public static List<Countries> GetAllData()
        {
            Countries countries = new Countries();

            List<Countries> countryList = countries.GetAllCountries();

            return countryList;
        }

    }
}
