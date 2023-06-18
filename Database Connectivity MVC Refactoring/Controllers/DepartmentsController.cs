using Database_Connectivity_MVC_Refactoring.Models;
using Database_Connectivity_MVC_Refactoring.Views;

namespace Database_Connectivity_MVC_Refactoring.Controllers
{
    public class DepartmentsController
    {
        private Models.Departments _departments = new Models.Departments();

        public void GetAllData()
        {
            bool result = false;
            var list = DepartmentsView.GetAllData();

            if (list != null)
            {
                result = true;
                foreach (Departments department in list)
                {
                    Console.WriteLine($"ID: {department.id} | " +
                        $"Department Name: {department.name} | " +
                        $"Location ID: {department.location_id}" +
                        $"Manager ID: {department.manager_id}");
                }
            }
            else
            {
                Console.WriteLine("Data Not Found");
            }
        }
    }
}
