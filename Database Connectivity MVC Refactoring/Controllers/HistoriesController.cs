using Database_Connectivity_MVC_Refactoring.Models;
using Database_Connectivity_MVC_Refactoring.Views;

namespace Database_Connectivity_MVC_Refactoring.Controllers
{
    public class HistoriesController
    {
        public void GetAllData()
        {
            bool result = false;
            var list = HistoriesView.GetAllData();

            if (list != null)
            {
                result = true;
                foreach (Histories histories in list)
                {
                    Console.WriteLine($"Start Date: {histories.StartDate} | " +
                        $"EmployeeID: {histories.EmployeeId} | " +
                        $"End Date: {histories.EndDate}" +
                        $"Job ID: {histories.JobId}" +
                        $"Department ID: {histories.DepartmentId}");
                }
            }
            else
            {
                Console.WriteLine("Data Not Found");
            }
        }
    }
}
