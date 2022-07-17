using Microsoft.Data.SqlClient;
using Models;

namespace DataAccess;

    public class TicketRepository : ITicketsDA
    {
        public string connectionString = "Server=tcp:kevionserver.database.windows.net,1433;Initial Catalog=bigstorage;Persist Security Info=False;User ID=netmain;Password=" + secretP.passie + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            // " informationAzure database, classlib for password"
        public List<Ticket> GetTicketbyID(int ticketID)
        {
            List<Ticket> ticketL = new List<Ticket>();
            string sql = "select * from ERS.Ticketrepo Order By UserID ;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
            catch (System.Exception ex)
            {
                
                throw;
            }
            return new List<Tickets>();
        }
        public List<Ticket> GetTicketsbyAuthor(string author)
        {
            List<Ticket> ticketL = new List<Ticket>();
            string sql = "select * from ERS.Ticketrepo Order By Author ;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
            catch
            {
                throw;
            }
            return new List<Ticket>();
        }
        public List<Ticket> GetTicketbyStatus(Stats status)
        {
            List<Ticket> ticketL = new List<Ticket>();
            string sql = "select * from ERS.Ticketrepo Order By Status;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
            catch
            {
                throw;
            }
            return new List<Ticket>();

        } 
        public void CreateTicket(Ticket Ticket);
        {
            string sql = "select * from ERS.Ticketrepo Order By Status ;";


        return new List<Ticket>();          
        }
        public void UpdateTicketStatus(Stats status);
        {
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

        }
        catch
        {

        }

        
        return new List<Ticket>();
        }
    }
