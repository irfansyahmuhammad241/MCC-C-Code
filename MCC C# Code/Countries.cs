using System.Data;
using System.Data.SqlClient;

namespace MCC_C__Code
{
    public class Countries
    {
        static string connectionString = "Data Source=MSI;Database=db_hr;Integrated Security=True;Connect Timeout=30;";


        static SqlConnection connection;


        public string id { get; set; }

        public string nama { get; set; }

        public int region_id { get; set; }

        public List<Countries> GetAllCountries()
        {

            SqlConnection connection;
            connection = new SqlConnection(connectionString);

            var countries = new List<Countries>();
            try
            {

                connection = new SqlConnection(connectionString);

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

        public int InsertCountries(string countryName, string regionID)
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
                command.CommandText = "insert into tb_m_countries (nama), (region_id) values (@country_name), (@region_id)";
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pCountryName = new SqlParameter();
                pCountryName.ParameterName = "@country_name";
                pCountryName.Value = countryName;
                pCountryName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@region_id";
                pRegionId.Value = countryName;
                pRegionId.SqlDbType = SqlDbType.VarChar;

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
            connection = new SqlConnection(connectionString);

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
    }
}
