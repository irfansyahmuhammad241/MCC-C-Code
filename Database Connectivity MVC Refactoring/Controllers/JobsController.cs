using Database_Connectivity_MVC_Refactoring.Models;
using Database_Connectivity_MVC_Refactoring.Views;

namespace Database_Connectivity_MVC_Refactoring.Controllers
{
    public class JobsController
    {
        public void GetAllData()
        {
            bool result = false;
            var list = JobsView.GetAllData();

            if (list != null)
            {
                result = true;
                foreach (Jobs job in list)
                {
                    Console.WriteLine($"ID: {job.Id} | " +
                        $"Job Title: {job.Title} | " +
                        $"Min Salary: {job.MinSalary}" +
                        $"Max Salary: {job.MaxSalary}");
                }
            }
            else
            {
                Console.WriteLine("Data Not Found");
            }
        }
    }
}
