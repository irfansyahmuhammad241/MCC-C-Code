using Database_Connectivity_MVC_Refactoring.Models;
using Database_Connectivity_MVC_Refactoring.Views;

namespace Database_Connectivity_MVC_Refactoring.Controllers
{
    public class CountriesController
    {
        private Models.Countries _countries = new Models.Countries();

        public void GetAllData()
        {
            bool result = false;
            var list = CountriesView.GetAllData();

            if (list != null)
            {
                result = true;
                foreach (Countries countries in list)
                {
                    Console.WriteLine($"ID: {countries.id} | Country Name: {countries.nama} | Region ID: {countries.region_id}");
                }
            }
            else
            {
                Console.WriteLine("Data Not Found");
            }
        }

        public void GetByID()
        {
            CountriesView.InputID();
            string id = Console.ReadLine();

            var data = _countries.GetCountriesByID(id);

            if (data != null)
            {
                Console.WriteLine($"ID: {data.id} | Country Name: {data.nama} | Region ID: {data.id}");
            }
            else
            {
                StatusViews.DataNotFoundByID(id);
            }
        }

        public void InsertNewData()
        {

            CountriesView.InputName();
            string name = Console.ReadLine();

            CountriesView.InputRegionID();
            int regionId = Convert.ToInt32(Console.ReadLine());

            _countries.InsertCountries(name, regionId);
        }

        public void Update()
        {
            CountriesView.InputID();
            _countries.id = Console.ReadLine();

            CountriesView.InputName();
            _countries.nama = Console.ReadLine();

            CountriesView.InputRegionID();
            _countries.region_id = Int32.Parse(Console.ReadLine());

            _countries.GetCountriesByID(_countries.id);
            _countries.UpdateCountryByID(_countries.id, _countries.nama, _countries.region_id);
        }

        public void Delete()
        {

            CountriesView.InputID();
            _countries.id = Console.ReadLine();
            var data = _countries.GetCountriesByID(_countries.id);
            if (data != null)
            {
                int status = _countries.DeleteCountriesByID(data.id);
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
