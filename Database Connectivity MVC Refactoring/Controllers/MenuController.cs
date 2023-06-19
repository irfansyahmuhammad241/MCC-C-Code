using Database_Connectivity_MVC_Refactoring.Views;

namespace Database_Connectivity_MVC_Refactoring.Controllers
{
    public class MenuController
    {
        private CountriesController _countryControllers = new CountriesController();
        private RegionContoller _regionControllers = new RegionContoller();
        private DepartmentsController _departmentControllers = new DepartmentsController();
        private EmployeesController _employeeControllers = new EmployeesController();
        private HistoriesController _historyControllers = new HistoriesController();
        private JobsController _jobControllers = new JobsController();
        private LocationsController _locationControllers = new LocationsController();


        public void MainMenu()
        {
            bool status = true;
            do
            {
                Console.Clear();

                MenuViews.MainMenu();
                int SelectMenu = Convert.ToInt32(Console.ReadLine());
                switch (SelectMenu)
                {
                    case 1:
                        //Country
                        SubMenuCountry();
                        break;
                    case 2:
                        //Department
                        SubMenuDepartment();
                        break;
                    case 3:
                        //Employee
                        SubMenuEmployee();
                        break;
                    case 4:
                        //History
                        SubMenuHistory();
                        break;
                    case 5:
                        //Job
                        SubMenuJob();
                        break;
                    case 6:
                        //Location
                        SubMenuLocation();
                        break;
                    case 7:
                        //Region
                        SubMenuRegion();
                        break;
                    case 0:
                        status = false;
                        break;
                }
            } while (status);
        }

        public void SubMenuDepartment()
        {
            Console.Clear();
            _departmentControllers.GetAllData();

            MenuViews.ExitMenu();
            Console.ReadKey();
        }

        public void SubMenuEmployee()
        {

            Console.Clear();
            _employeeControllers.GetAllData();

            MenuViews.ExitMenu();
            Console.ReadKey();
        }

        public void SubMenuHistory()
        {
            Console.Clear();
            _historyControllers.GetAllData();

            MenuViews.ExitMenu();
            Console.ReadKey();
        }
        public void SubMenuJob()
        {
            Console.Clear();
            _jobControllers.GetAllData();

            MenuViews.ExitMenu();
            Console.ReadKey();
        }
        public void SubMenuLocation()
        {
            Console.Clear();
            _locationControllers.GetAllData();

            MenuViews.ExitMenu();
            Console.ReadKey();
        }

        public void SubMenuCountry()
        {
            bool status = true;
            do
            {
                Console.Clear();
                _countryControllers.GetAllData();

                MenuViews.SubMenu();
                int SelectMenu = Convert.ToInt32(Console.ReadLine());
                switch (SelectMenu)
                {
                    case 1:
                        //Get All Data By ID
                        _countryControllers.GetByID();
                        Console.ReadLine();
                        break;
                    case 2:
                        //Create Data
                        _countryControllers.InsertNewData();
                        Console.ReadLine();
                        break;
                    case 3:
                        //Update Data By ID
                        _countryControllers.Update();
                        Console.ReadLine();
                        break;
                    case 4:
                        //Delete Data By ID
                        _countryControllers.Delete();
                        Console.ReadLine();
                        break;
                    case 0:
                        status = false;
                        break;
                    default:
                        StatusViews.InputInvalid();
                        Console.ReadLine();
                        break;
                }
            } while (status);
        }

        public void SubMenuRegion()
        {
            bool status = true;
            do
            {
                Console.Clear();
                _regionControllers.GetAllData();


                MenuViews.SubMenu();
                int SelectMenu = Convert.ToInt32(Console.ReadLine());
                switch (SelectMenu)
                {
                    case 1:
                        //Get All Data By ID
                        _regionControllers.GetByID();
                        Console.ReadLine();
                        break;
                    case 2:
                        //Create Data
                        _regionControllers.InsertNewData();
                        Console.ReadLine();
                        break;
                    case 3:
                        //Update Data By ID
                        _regionControllers.Update();
                        Console.ReadLine();
                        break;
                    case 4:
                        //Delete Data By ID
                        _regionControllers.Delete();
                        Console.ReadLine();
                        break;
                    case 0:
                        status = false;
                        break;
                    default:
                        StatusViews.InputInvalid();
                        Console.ReadLine();
                        break;
                }
            } while (status);
        }
    }
}
