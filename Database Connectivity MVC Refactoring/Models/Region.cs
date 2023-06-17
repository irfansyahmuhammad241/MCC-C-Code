using System.Data;
using System.Data.SqlClient;
using Database_Connectivity_MVC_Refactoring.Connections;

namespace Database_Connectivity_MVC_Refactoring.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Region> GetAllRegion()
        {

            SqlConnection connection;
            connection = DatabaseConnection.GetConnection();

            var region = new List<Region>();
            try
            {

                connection = DatabaseConnection.GetConnection();

                //membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_regions";

                //membuka koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new Region();
                        reg.Id = reader.GetInt32(0);
                        reg.Name = reader.GetString(1);
                        region.Add(reg);
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
            return region;
        }

        public List<Region> GetRegionByID(int id)
        {

            SqlConnection connection;
            connection = DatabaseConnection.GetConnection();

            connection.Open();

            //Command Database
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * From tb_m_regions WHERE id = @id";

            //Buat Parameter untuk ID
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@id";
            pName.Value = id;
            pName.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(pName);

            var regionList = new List<Region>();
            Region region = new Region();
            try
            {
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        region.Id = reader.GetInt32(0);
                        region.Name = reader.GetString(1);
                        regionList.Add(region);

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
            return regionList;

        }



        public int InsertRegion(string nama)
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
                command.CommandText = "insert into tb_m_regions (nama) values (@region_name)";
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@region_name";
                pName.Value = nama;
                pName.SqlDbType = SqlDbType.VarChar;

                //Menambahkan parameter ke command
                command.Parameters.Add(pName);

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


        public int UpdateRegionByID(int id, string regionName)
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
                command.CommandText = "UPDATE tb_m_regions SET nama = @region_name WHERE id = @id";

                //Buat Parameter untuk ID
                SqlParameter pName1 = new SqlParameter();
                pName1.ParameterName = "@id";
                pName1.Value = id;
                pName1.SqlDbType = SqlDbType.Int;

                //Buat Parameter untuk Name
                SqlParameter pName2 = new SqlParameter();
                pName2.ParameterName = "@region_name";
                pName2.Value = regionName;
                pName2.SqlDbType = SqlDbType.VarChar;

                command.Parameters.Add(pName1);
                command.Parameters.Add(pName2);

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

        public int DeleteRegionByID(int id)
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
                command.CommandText = "DELETE FROM tb_m_regions WHERE id = @id";

                //Buat Parameter untuk ID
                SqlParameter pName1 = new SqlParameter();
                pName1.ParameterName = "@id";
                pName1.Value = id;
                pName1.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(pName1);

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

        public void RegionMenu()
        {
            Console.Clear();
            Region region = new Region();
            //GETALL Region
            List<Region> regionList = region.GetAllRegion();
            foreach (Region reg in regionList)
            {
                Console.WriteLine($"Id: {reg.Id}  Name: {reg.Name}");
            }

            Console.WriteLine("1. Get Region By ID");
            Console.WriteLine("2. Insert Region");
            Console.WriteLine("3. Update Region By ID");
            Console.WriteLine("4. Delete Region By ID");
            Console.WriteLine("5. Back To Main Menu");
            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Masukan ID Region yang ingin dicari: ");
                    int inputCase1 = Int32.Parse(Console.ReadLine());
                    List<Region> regionByID = region.GetRegionByID(inputCase1);
                    foreach (Region reg in regionByID)
                    {
                        Console.WriteLine($"Id: {reg.Id}  Name: {reg.Name}");
                    }
                    RegionMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Masukan Nama Region: ");
                    string regionName = Console.ReadLine();
                    int insertSuccess = InsertRegion(regionName);
                    if (insertSuccess > 0)
                    {
                        Console.WriteLine("Data Was Added Succesfully ");
                    }
                    else
                    {
                        Console.WriteLine("Insert Data Failed");
                    }
                    Console.ReadKey();
                    RegionMenu();
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Masukan ID Region yang ingin di update");
                    int updateRegionID = Int32.Parse(Console.ReadLine());
                    Console.Write("Masukan Nama Region Baru");
                    string updateRegionName = Console.ReadLine();
                    int updatedResult = UpdateRegionByID(updateRegionID, updateRegionName);
                    if (updatedResult > 0)
                    {
                        Console.WriteLine("Data Was Updated Succesfull");
                    }
                    else
                    {
                        Console.WriteLine("Data Update Failed");
                    }
                    Console.ReadKey();
                    RegionMenu();
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("Masukan ID Region yang ingin di delete: ");
                    int deletedRegionID = Int32.Parse(Console.ReadLine());
                    int deletedResult = DeleteRegionByID(deletedRegionID);
                    if (deletedResult > 0)
                    {
                        Console.WriteLine("Data Delete Succesfully");
                    }
                    else
                    {
                        Console.WriteLine("Data Deletion Failed");
                    }
                    Console.ReadKey();
                    RegionMenu();
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
