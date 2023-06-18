using Database_Connectivity_MVC_Refactoring.Models;

namespace Database_Connectivity_MVC_Refactoring.Views
{
    public class JobsView
    {
        public static List<Jobs> GetAllData()
        {
            Jobs jobs = new Jobs();

            List<Jobs> jobList = jobs.GetAllJobs();

            return jobList;
        }
    }
}
