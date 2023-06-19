using Database_Connectivity_MVC_Refactoring.Controllers;

namespace Database_Connectivity_MVC_Refactoring
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuController menuController = new MenuController();
            menuController.MainMenu();
        }
    }
}