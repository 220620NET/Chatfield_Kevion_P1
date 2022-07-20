using Microsoft.Data.SqlClient;
using Models;
using CustomExceptions;
using System.Data;


namespace DataAccess;

    public class TicketRepository : ITicketRepository
    {
       private readonly ConnectionFactory _connectionFactory;
       public TicketRepository(ConnectionFactory connection)
       {
          _connectionFactory = connection; 
       }
        public List<Ticket> GetAllTickets()
        {
        // Used to store data in the temp list
        List<Ticket> tickets = new List<Ticket>();
        // next is the sql statement
        string sql = "SELECT * FROM ERS.TicketRepo;";
        SqlConnection connection = _connectionFactory.GetConnection();
        connection.Open();
        // Next Line includws the commands to use sql and the connection string
        SqlCommand command = new SqlCommand(sql, connection);
        SqlDataReader reader = command.ExecuteReader(); 

        while(reader.Read())
        {
            tickets.Add(new Ticket
            {
                TicketId = (int)reader["TicketID"],
                Author = (string)reader["Author"],
                Resolver = (string)reader["Resolver"],
                Description = (string)reader["Description"],
                Status = (Stats)reader["Role"],
                Amount = (decimal)reader["Amount"]
            });
            reader.Close();
            connection.Close();
        }
            return tickets; 
        }

        public List<Ticket> GetTicketsByAuthor(string author)
        {
            List<Ticket> ticketList = new List<Ticket>();
            SqlConnection connection = _connectionFactory.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("Select * From Ticket.repo Where Author = {author}", connection);
            
            command.Parameters.AddWithValue("@Author", author);
            SqlDataReader reader =command.ExecuteReader();

            while(reader.Read())
            {
                ticketList.Add(new Ticket
                {
                    TicketId = (int)reader["TicketID"],
                    Author = (string)reader["Author"],
                    Resolver = (string)reader["Resolver"],
                    Description = (string)reader["Description"],
                    Status = (Stats)reader["Role"],
                    Amount = (decimal)reader["Amount"]
                });
            }
            throw new RecordNotFoundException("Author was not found. Try Again.");
        
        }


        public List<Ticket> GetTicketsByID(int _ticketId)
        {               
            List<Ticket> ticketList = new List<Ticket>();
            SqlConnection connection = _connectionFactory.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("Select * From Ticket.repo Where TicketID = {ticketID}", connection);
            
            command.Parameters.AddWithValue("@TicktID", _ticketId);
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ticketList.Add(new Ticket
                {
                    TicketId = (int)reader["TicketID"],
                    Author = (string)reader["Author"],
                    Resolver = (string)reader["Resolver"],
                    Description = (string)reader["Description"],
                    Status = (Stats)reader["Role"],
                    Amount = (decimal)reader["Amount"]
                });
            }
            throw new RecordNotFoundException("TicketID was not found. Try Again.");
        }
        
        public List<Ticket> GetTicketsByStatus(Stats status)
        {   
            List<Ticket> ticketList = new List<Ticket>();
            SqlConnection connection = _connectionFactory.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("select * from ERS.TicketRepo WHERE Status = '{status}';", connection);
            
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ticketList.Add(new Ticket
                {
                    TicketId = (int)reader["TicketID"],
                    Author = (string)reader["Author"],
                    Resolver = (string)reader["Resolver"],
                    Description = (string)reader["Description"],
                    Status = (Stats)reader["Role"],
                    Amount = (decimal)reader["Amount"]
                   
                });
            }

            throw new RecordNotFoundException("Sorry! We could not find Username.");
        }

        
        public Ticket CreateTicket(Ticket ticketToRegister)
        {
        DataSet newTicketSet = new DataSet();
        SqlConnection connection = _connectionFactory.GetConnection();
        connection.Open();

        SqlDataAdapter ticketAdapter = new SqlDataAdapter("Select * From ERS.TicketRepo;", connection);   
        ticketAdapter.Fill(newTicketSet, "TicketTable");
        DataTable? ticketTable = newTicketSet.Tables["TicketTable"];

        if(ticketTable != null)
        {
        DataRow newTicket = ticketTable.NewRow();
        newTicket["TicketID"] = ticketToRegister.TicketId;
        newTicket["Author"] = ticketToRegister.Author;
        newTicket["Resolver"] = ticketToRegister.Resolver;
        newTicket["Description"] = ticketToRegister.Description;
        newTicket["Status"] = ticketToRegister.Status;
        newTicket["Amount"] = ticketToRegister.Amount;
        
        ticketTable.Rows.Add(newTicket);

        
        SqlCommand insertCommand = new SqlCommand("Insert into ERS.TicketRepo (Author, Resolver, Description, Status, Amount) OUTPUT Inserted.UserID values @Author, @Resolver, @Description, @Status, @Amount", connection);
        insertCommand.Parameters.Add("@Author", SqlDbType.VarChar,50,"Author");
        insertCommand.Parameters.Add("@Resolver", SqlDbType.VarChar,50,"Resolver");
        insertCommand.Parameters.Add("@Description",SqlDbType.VarChar,50,"Description");
        insertCommand.Parameters.Add("@Status", SqlDbType.VarChar, 50, "Status");
        insertCommand.Parameters.Add("@Amount", SqlDbType.Float, 2, "Amount");

        ticketAdapter.InsertCommand = insertCommand;

        ticketAdapter.Update(ticketTable);

        ticketToRegister.TicketId = (int) newTicket["TicketID"];
        }
        return ticketToRegister;
    }    

    public List<Ticket> UpdateTicketStatus(Stats status)
    {
        List<Ticket> ticketList = new List<Ticket>();
        SqlConnection connection = _connectionFactory.GetConnection();
        connection.Open();
        SqlCommand command = new SqlCommand("UPDATE ERS.TicketRepo SET Status = {status} WHERE TicketID = {TicketId} ", connection);

        command.Parameters.AddWithValue("@Status", status);
        SqlDataReader reader = command.ExecuteReader();

        while(reader.Read())
        {
            ticketList.Add(new Ticket
        {
            TicketId = (int)reader["TicketID"],
            Author = (string)reader["Author"],
            Resolver = (string)reader["Resolver"],
            Description = (string)reader["Description"],
            Status = (Stats)reader["Status"],
            Amount = (decimal)reader["Amount"]
        });
        }
            throw new RecordNotFoundException("Update was not made!");

    }

    Ticket ITicketRepository.UpdateTicketStatus(Stats status)
    {
        throw new NotImplementedException();
    }
}
