using System.Data;
using System.Data.SqlClient;

namespace MCC_C__Code
{
    public class Region
    {
        static string connectionString = "Data Source=MSI;Database=db_hr;Integrated Security=True;Connect Timeout=30;";


        static SqlConnection connection;

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Region> GetAllRegion()
        {

            SqlConnection connection;
            connection = new SqlConnection(connectionString);

            var region = new List<Region>();
            try
            {

                connection = new SqlConnection(connectionString);

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
            connection = new SqlConnection(connectionString);

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
            connection = new SqlConnection(connectionString);

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
            connection = new SqlConnection(connectionString);

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
            connection = new SqlConnection(connectionString);

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
    }
}
