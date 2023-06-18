using Database_Connectivity_MVC_Refactoring.Models;

namespace Database_Connectivity_MVC_Refactoring.Views
{
    public class DepartmentsView
    {
        public static List<Departments> GetAllData()
        {
            Departments departments = new Departments();

            List<Departments> departmentList = departments.GetAllDepartments();

            return departmentList;
        }
    }
}
