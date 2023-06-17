using System.Data;
using System.Data.SqlClient;
using Database_Connectivity_MVC_Refactoring.Connections;

namespace Database_Connectivity_MVC_Refactoring.Models
{
    public class Countries
    {
        public string id { get; set; }

        public string nama { get; set; }

        public int region_id { get; set; }


        public List<Countries> GetAllCountries()
        {

            SqlConnection connection;
            connection = DatabaseConnection.GetConnection();

            var countries = new List<Countries>();
            try
            {
                //membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_countries";

                //membuka koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Countries();
                        country.id = reader.GetString(0);
                        country.nama = reader.GetString(1);
                        country.region_id = reader.GetInt32(2);
                        countries.Add(country);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return countries;
        }

        public List<Countries> GetAllCountriesByID(int Id)
        {

            SqlConnection connection;
            connection = DatabaseConnection.GetConnection();

            var countries = new List<Countries>();
            try
            {
                //membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_countries WHERE id = @id";

                //Buat Parameter untuk ID
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@id";
                pName.Value = Id;
                pName.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(pName);
                //membuka koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Countries();
                        country.id = reader.GetString(0);
                        country.nama = reader.GetString(1);
                        country.region_id = reader.GetInt32(2);
                        countries.Add(country);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return countries;
        }

        public int InsertCountries(string countryName, int regionID)
        {
            int result = 0;
            SqlConnection connection;
            connection = DatabaseConnection.GetConnection();


            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "insert into tb_m_countries (nama), (region_id) values (@country_name), (@region_id)";
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pCountryName = new SqlParameter();
                pCountryName.ParameterName = "@country_name";
                pCountryName.Value = countryName;
                pCountryName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@region_id";
                pRegionId.Value = regionID;
                pRegionId.SqlDbType = SqlDbType.Int;

                //Menambahkan parameter ke command
                command.Parameters.Add(pCountryName);
                command.Parameters.Add(pRegionId);

                //Menjalankan command 
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            connection.Close();
            return result;
        }


        public int UpdateCountryByID(string id, string countryName, int region_id)
        {
            int result = 0;
            SqlConnection connection;
            connection = DatabaseConnection.GetConnection();

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                //Command Database
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_countries SET nama = @country_name,  " +
                    "SET region_id = @ region_id WHERE id = @id";

                //Buat Parameter untuk ID
                SqlParameter pName1 = new SqlParameter();
                pName1.ParameterName = "@id";
                pName1.Value = id;
                pName1.SqlDbType = SqlDbType.VarChar;

                //Buat Parameter untuk Name
                SqlParameter pName2 = new SqlParameter();
                pName2.ParameterName = "@country_name";
                pName2.Value = countryName;
                pName2.SqlDbType = SqlDbType.VarChar;

                SqlParameter pName3 = new SqlParameter();
                pName3.ParameterName = "@region_id";
                pName3.Value = region_id;
                pName3.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(pName1);
                command.Parameters.Add(pName2);

                //Menjalankan command 
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            connection.Close();
            return result;
        }

        public int DeleteCountriesByID(int id)
        {
            int result = 0;
            SqlConnection connection;
            connection = DatabaseConnection.GetConnection();

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                //Command Database
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tb_m_countries WHERE id = @id";

                //Buat Parameter untuk ID
                SqlParameter pName1 = new SqlParameter();
                pName1.ParameterName = "@id";
                pName1.Value = id;
                pName1.SqlDbType = SqlDbType.VarChar;

                command.Parameters.Add(pName1);

                //Menjalankan command 
                result = command.ExecuteNonQuery();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            connection.Close();
            return result;
        }

        public void CountryMenu()
        {
            Console.Clear();
            Countries country = new Countries();
            List<Countries> countries = country.GetAllCountries();
            foreach (Countries coun in countries)
            {
                Console.WriteLine($"Id: {coun.id}  Name: {coun.nama} " +
                    $"Region Id: {coun.region_id}");
            }

            Console.WriteLine("1. Get Country By ID");
            Console.WriteLine("2. Insert Country");
            Console.WriteLine("3. Update Country By ID");
            Console.WriteLine("4. Delete Country By ID");
            Console.WriteLine("5. Back To Main Menu");
            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Masukan ID Country yang ingin dicari: ");
                    int inputCase1 = Int32.Parse(Console.ReadLine());
                    List<Countries> countriesByID = country.GetAllCountriesByID(inputCase1);
                    foreach (Countries coun in countriesByID)
                    {
                        Console.WriteLine($"Id: {coun.id}  Name: {coun.nama} " +
                            $"Region Id: {coun.region_id}");
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Masukan Nama Country: ");
                    string countryName = Console.ReadLine();
                    Console.Write("Masukan Region ID untuk Country: ");
                    int regionID = Int32.Parse(Console.ReadLine());
                    int insertSuccess = InsertCountries(countryName, regionID);
                    if (insertSuccess > 0)
                    {
                        Console.WriteLine("Data Was Added Succesfully ");
                    }
                    else
                    {
                        Console.WriteLine("Insert Data Failed");
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Masukan ID Country yang ingin di update");
                    int updateCountryID = Int32.Parse(Console.ReadLine());
                    Console.Write("Masukan Nama Country Baru");
                    string updateCountryName = Console.ReadLine();
                    Console.Write("Masukan Region ID untuk Country: ");
                    int updatedregionID = Int32.Parse(Console.ReadLine());
                    int updatedResult = UpdateCountryByID(updateCountryName, updateCountryName, updatedregionID);
                    if (updatedResult > 0)
                    {
                        Console.WriteLine("Data Was Updated Succesfull");
                    }
                    else
                    {
                        Console.WriteLine("Data Update Failed");
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("Masukan ID Country yang ingin di delete: ");
                    int deletedCountryID = Int32.Parse(Console.ReadLine());
                    int deletedResult = DeleteCountriesByID(deletedCountryID);
                    if (deletedResult > 0)
                    {
                        Console.WriteLine("Data Delete Succesfully");
                    }
                    else
                    {
                        Console.WriteLine("Data Deletion Failed");
                    }
                    Console.ReadKey();
                    break;
                case 5:

                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;

            }
        }
    }
}
