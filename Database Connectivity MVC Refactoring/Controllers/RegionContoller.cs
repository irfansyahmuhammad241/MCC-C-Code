using Database_Connectivity_MVC_Refactoring.Models;
using Database_Connectivity_MVC_Refactoring.Views;

namespace Database_Connectivity_MVC_Refactoring.Controllers
{
    public class RegionContoller
    {
        private Models.Region _regions = new Models.Region();

        public void GetAllData()
        {
            bool result = false;
            var list = RegionView.GetAllData();

            if (list != null)
            {
                result = true;
                foreach (Region regions in list)
                {
                    Console.WriteLine($"ID: {regions.Id} | Country Name: {regions.Name}");
                }
            }
            else
            {
                Console.WriteLine("Data Not Found");
            }
        }

        public void GetByID()
        {
            RegionView.InputID();
            int id = Int32.Parse(Console.ReadLine());

            var data = _regions.GetRegionByID(id);

            if (data != null)
            {
                Console.WriteLine($"ID: {data.Id} | Region Name: {data.Name}");
            }
            else
            {
                StatusViews.DataNotFoundByID(id);
            }
        }

        public void InsertNewData()
        {

            RegionView.InputName();
            string name = Console.ReadLine();

            _regions.InsertRegion(name);
        }

        public void Update()
        {
            RegionView.InputID();
            _regions.Id = Int32.Parse(Console.ReadLine());

            RegionView.InputName();
            _regions.Name = Console.ReadLine();

            _regions.GetRegionByID(_regions.Id);
            _regions.UpdateRegionByID(_regions.Id, _regions.Name);
        }

        public void Delete()
        {

            RegionView.InputID();
            _regions.Id = Int32.Parse(Console.ReadLine());
            var data = _regions.GetRegionByID(_regions.Id);
            if (data != null)
            {
                int status = _regions.DeleteRegionByID(_regions.Id);
                if (status != 0)
                {
                    StatusViews.DeleteSuccess();
                }
                else
                {
                    StatusViews.ProcessFailed();
                }
            }
            else
            {
                StatusViews.DeleteFailed();
            }
        }
    }
}
