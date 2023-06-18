using Database_Connectivity_MVC_Refactoring.Models;

namespace Database_Connectivity_MVC_Refactoring.Views
{
    public class EmployeesView
    {
        public static List<Employees> GetAllData()
        {
            Employees employees = new Employees();

            List<Employees> employeeList = employees.GetAllEmployees();

            return employeeList;
        }
    }
}
