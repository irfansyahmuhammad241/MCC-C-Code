using Database_Connectivity_MVC_Refactoring.Models;
using Database_Connectivity_MVC_Refactoring.Views;

namespace Database_Connectivity_MVC_Refactoring.Controllers
{
    public class EmployeesController
    {
        public void GetAllData()
        {
            bool result = false;
            var list = EmployeesView.GetAllData();

            if (list != null)
            {
                result = true;
                foreach (Employees employee in list)
                {
                    Console.WriteLine($"ID: {employee.Id} | " +
                        $"Nama: {employee.FirstName} {employee.LastName} | " +
                        $"Email: {employee.Email} | " +
                        $"Phone Number: {employee.PhoneNumber} | " +
                        $"Hire Date {employee.HireDate} | " +
                        $"Salary: {employee.Salary} | " +
                        $"Commision: {employee.ComissionPct} | " +
                        $"ManagerID: {employee.ManagerId} | " +
                        $"JobID: {employee.JobId} | " +
                        $"DepartmentID: {employee.DepartmentId}");
                }
            }
            else
            {
                Console.WriteLine("Data Not Found");
            }
        }
    }
}
