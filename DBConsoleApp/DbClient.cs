using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConsoleApp
{
    class DbClient : IDelete, ISelect, IInsert, IUpdate
    {
        public string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HotelDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"Delete from Hotel where Hotel_No = {id}";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                //Execute uden select (insert, delete, update)
                command.ExecuteNonQuery();

            }
        }

        public void Insert(int hotelNo, string name, string address)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"Insert into Hotel(Hotel_No, Name, Address) Values({hotelNo}, '{name}', '{address}')";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                //Execute uden select (insert, delete, update)
                command.ExecuteNonQuery();
            }
        }

        public void SelectAllHotels()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
            string queryString = "select * from Hotel";

            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0); //Get integer from first column

                string name = reader.GetString(1); //Get string from second column

                Console.WriteLine($"{id} - {name}");
            }
            }
        }

        public void SelectSpecificHotel(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"select * from Hotel where Hotel_No = {id}";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int HotelNo = reader.GetInt32(0); //Get integer from first column

                    string name = reader.GetString(1); //Get string from second column

                    Console.WriteLine($"{HotelNo} - {name}");
                }
            }
        }

        public void UpdateAddress(int id, string address)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"Update Hotel set address = '{address}' where Hotel_No = {id}";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                //Execute uden select (insert, delete, update)
                command.ExecuteNonQuery();

            }
        }

        public void UpdateHotel(int id, string name, string address)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"Update Hotel set Name = '{name}', Address = '{address}' where Hotel_No = {id}";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                //Execute uden select (insert, delete, update)
                command.ExecuteNonQuery();

            }
        }

        public void UpdateName(int id, string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"Update Hotel set Name = '{name}' where Hotel_No = {id}";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                //Execute uden select (insert, delete, update)
                command.ExecuteNonQuery();

            }
        }
    }
}
