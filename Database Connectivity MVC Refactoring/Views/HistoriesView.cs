using Database_Connectivity_MVC_Refactoring.Models;

namespace Database_Connectivity_MVC_Refactoring.Views
{
    public class HistoriesView
    {
        public static List<Histories> GetAllData()
        {
            Histories histories = new Histories();

            List<Histories> historyList = histories.GetAllHistories();

            return historyList;
        }
    }
}
