using MCC_C__Code;

//Materi Database Connectivity

public class Program
{
    public static void Main(string[] args)
    {
        Menu();
    }

    public static void Menu()
    {
        Console.Clear();
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
                location.LocationsMenu();
                break;
            case 4:
                deparment.DepartmentMenu();
                break;
            case 5:
                employee.EmployeesMenu();
                break;
            case 6:
                jobs.JobsMenu();
                break;
            case 7:
                histories.HistoriesMenu();
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
