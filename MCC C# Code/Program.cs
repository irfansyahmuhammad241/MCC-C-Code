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
        Console.WriteLine("Pilih table yang ingin dilihat");
        Console.WriteLine("1.Regions");
        Console.WriteLine("2.Countries");
        Console.WriteLine("3.Locations");
        Console.WriteLine("4.Departments");
        Console.WriteLine("5.Employees");
        Console.WriteLine("6.Jobs");
        Console.WriteLine("7.Histories");
        Console.WriteLine("Silahkan Pilih Table: ");
        int input = int.Parse(Console.ReadLine());

        switch (input)
        {
            case 1:
                //GETALL Region
                List<Region> regions = Region.GetAllRegion();
                foreach (Region region in regions)
                {
                    Console.WriteLine($"Id: {region.Id}  Name: {region.Name}");
                }
                break;
            case 2:
                List<Countries> countries = Countries.GetAllCountries();
                foreach (Countries country in countries)
                {
                    Console.WriteLine($"Id: {country.id}  Name: {country.nama} " +
                        $"Region Id: {country.region_id}");
                }
                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            case 8:
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
