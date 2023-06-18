using Database_Connectivity_MVC_Refactoring.Models;

namespace Database_Connectivity_MVC_Refactoring.Views
{
    public class RegionView
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

        public static List<Region> GetAllData()
        {
            Region regions = new Region();

            List<Region> regionList = regions.GetAllRegion();

            return regionList;
        }
    }
}
