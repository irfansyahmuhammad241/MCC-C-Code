using System.Data.SqlClient;
using MCC_C__Code;

//Materi Database Connectivity

public class Program
{
    static string connectionString = "Data Source=MSI;Database=db_hr;Integrated Security=True;Connect Timeout=30;";


    static SqlConnection connection;


    public static void Main(string[] args)
    {
        connection = new SqlConnection(connectionString);
        Menu();
    }

    public static void Menu()
    {
        Region region1 = new Region();
        LINQ linq = new LINQ();
        Countries countries = new Countries();
        employees employee = new employees();
        departments deparment = new departments();
        locations location = new locations();
        jobs jobs = new jobs();
        histories histories = new histories();

        Console.WriteLine("Pilih table yang ingin dilihat");
        Console.WriteLine("1.Regions");
        Console.WriteLine("2.Countries");
        Console.WriteLine("3.Locations");
        Console.WriteLine("4.Departments");
        Console.WriteLine("5.Employees");
        Console.WriteLine("6.Jobs");
        Console.WriteLine("7.Histories");
        Console.WriteLine("8.LINQ");
        Console.WriteLine("9.Exit");
        Console.WriteLine("Silahkan Pilih Table: ");
        int input = int.Parse(Console.ReadLine());

        switch (input)
        {
            case 1:
                region1.RegionMenu();
                break;
            case 2:
                countries.CountryMenu();
                break;
            case 3:
                List<locations> locationsList = location.GetAllLocations();
                foreach (locations loc in locationsList)
                {
                    Console.WriteLine();
                }
                break;
            case 4:
                List<departments> departmentsList = deparment.GetAllDepartments();
                foreach (departments dep in departmentsList)
                {
                    Console.WriteLine();
                }
                break;
            case 5:
                List<employees> employeesList = employee.GetAllEmployees();
                foreach (employees emp in employeesList)
                {
                    Console.WriteLine();
                }
                break;
            case 6:
                List<jobs> jobsList = jobs.GetAllJobs();
                foreach (jobs job in jobsList)
                {
                    Console.WriteLine();
                }
                break;
            case 7:
                List<histories> historiesList = histories.GetAllHistories();
                foreach (histories historiy in historiesList)
                {
                    Console.WriteLine();
                }
                break;
            case 8:
                linq.Menu();
                break;
            case 9:
                System.Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Salah input ulang lagi");
                break;


        }

    }



    //GetBy ID : Region
    //Update : Region
    //Delete : Region

    //GetAllCountry : Country
    //InsertCountry : Country
    //Update : Countries
    //Delete : Countries

    //Table sisanya hanya Get All saja


}
