using ModelKlasser;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Controllers
{
    class GuestController : IManageGuest
    {
        public string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HotelDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        public bool CreateGuest(Guest guest)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQueryString = $"Insert into Guest(Guest_No, Name, Address) Values({guest.GuestNr}, '{guest.Navn}', '{guest.Adresse}')";

                SqlCommand command = new SqlCommand(insertQueryString, connection);
                command.Connection.Open();

                try
                {
                    //Execute uden select (insert, delete, update)
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public Guest DeleteGuest(int guestNr)
        {
                Guest getDeletedGuest = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string deleteQueryString = $"Delete from Guest where Guest_No = {guestNr}";
                string selectedGuest = $"select * from Guest where Guest_No = {guestNr}";

                SqlCommand deleteCommand = new SqlCommand(deleteQueryString, connection);
                SqlCommand selectCommand = new SqlCommand(selectedGuest, connection);
                selectCommand.Connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    getDeletedGuest = new Guest() { GuestNr = reader.GetInt32(0), Navn = reader.GetString(1), Adresse = reader.GetString(2) };

                }
                selectCommand.Connection.Close();
                //Execute uden select (insert, delete, update)
                deleteCommand.ExecuteNonQuery();
                return getDeletedGuest;

            }
        }

        public List<Guest> GetAllGuest()
        {
            List<Guest> listOfGuests = new List<Guest>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string getAllGuestsQueryString = "select * from Guest";

                SqlCommand command = new SqlCommand(getAllGuestsQueryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listOfGuests.Add(new Guest() { GuestNr = reader.GetInt32(0), Navn = reader.GetString(1), Adresse = reader.GetString(2) });
                }
                return listOfGuests;
            }
        }

        public Guest GetGuestFromId(int guestNr)
        {
            Guest getSpecificGuest = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string getSpecificGuestQueryString = $"select * from Guest where Guest_No = {guestNr}";

                SqlCommand command = new SqlCommand(getSpecificGuestQueryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    getSpecificGuest = new Guest() { GuestNr = reader.GetInt32(0), Navn = reader.GetString(1), Adresse = reader.GetString(2) };
                }
                return getSpecificGuest;
            }
        }

        public bool UpdateGuest(Guest guest, int guestNr)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string updateGuestQueryString = $"Update Guest set Name = '{guest.Navn}', Address = '{guest.Adresse}' where Guest_No = {guestNr}";

                SqlCommand command = new SqlCommand(updateGuestQueryString, connection);
                command.Connection.Open();
                try
                {
                    //Execute uden select (insert, delete, update)
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (Exception)
                {

                    return false;
                }

            }
        }
    }
}
