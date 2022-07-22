// using Microsoft.Data.SqlClient;
// using Models;
// using CustomExceptions;
// using System.Data;


// namespace DataAccess;

//     public class TicketRepository : ITicketRepository
//     {
//        private readonly ConnectionFactory _connectionFactory;
//        public TicketRepository(ConnectionFactory factory)
//        {
//           _connectionFactory = factory; 
//        }
     
     
     
     
//         public List<Ticket> GetAllTickets()
//         {
//         // Used to store data in the temp list
//         List<Ticket> tickets = new List<Ticket>();
//         // next is the sql statement
//         string sql = "SELECT * FROM ERS.TicketRepo;";
//         SqlConnection connection = _connectionFactory.GetConnection();
//         connection.Open();
//         // Next Line includws the commands to use sql and the connection string
//         SqlCommand command = new SqlCommand(sql, connection);
//         SqlDataReader reader = command.ExecuteReader(); 

//         while(reader.Read())
//         {
//             tickets.Add(new Ticket
//             {
//                 TicketId = (int)reader["TicketID"],
//                 Author = (string)reader["Author"],
//                 Resolver = (string)reader["Resolver"],
//                 Description = (string)reader["Description"],
//                 Status = (Stats)reader["Role"],
//                 Amount = (decimal)reader["Amount"]
//             });
//             reader.Close();
//             connection.Close();
//         }
//             return tickets; 
//         }

//         public List<Ticket> GetTicketsByAuthor(string status)
//         {
//             List<Ticket> ticketList = new List<Ticket>();
//             SqlConnection connection = _connectionFactory.GetConnection();
//             connection.Open();

//             SqlCommand command = new SqlCommand("Select * From Ticket.repo Where Author = {author}", connection);
            
//             command.Parameters.AddWithValue("@Author", author);
//             SqlDataReader reader =command.ExecuteReader();

//             while(reader.Read())
//             {
//                 ticketList.Add(new Ticket
//                 {
//                     TicketId = (int)reader["TicketID"],
//                     Author = (string)reader["Author"],
//                     Resolver = (string)reader["Resolver"],
//                     Description = (string)reader["Description"],
//                     Status = (string)reader["Status"],
//                     Amount = (decimal)reader["Amount"]
//                 });
//             }
//             throw new RecordNotFoundException("Author was not found. Try Again.");
        
//         }


//         public List<Ticket> GetTicketsByID(int _ticketId)
//         {               
//             List<Ticket> ticketList = new List<Ticket>();
//             command.Connection.Open();

//             using SqlCommand command = new SqlCommand("Select * From Ticket.repo Where TicketID = {ticketID}", _connectionFactory.GetConnection());
            
//             command.Parameters.AddWithValue("@TicktID", _ticketId);
//             SqlDataReader reader = command.ExecuteReader();

//             if(reader.Read())
//             {
//               ticketList.Add(new Ticket
//                 {
//                     TicketId = (int)reader["TicketID"],
//                     Author = (string)reader["Author"],
//                     Resolver = (string)reader["Resolver"],
//                     Description = (string)reader["Description"],
//                     Status = (Stats)reader["Role"],
//                     Amount = (decimal)reader["Amount"]
//                 });
//             }
            
//             throw new RecordNotFoundException("TicketID was not found. Try Again.");
//         }
        
//         public List<Ticket> GetTicketsByStatus(string status)
//         {   
//             List<Ticket> ticketList = new List<Ticket>();
//             using SqlCommand command = new SqlCommand("select * from ERS.TicketRepo WHERE Status = @Status;", _connectionFactory.GetConnection());
//             command.Connection.Open();
           
//             using SqlDataReader reader = command.ExecuteReader();

//             while (reader.Read())
//             {
//                 ticketList.Add(new Ticket
//                 {
//                     TicketId = (int)reader["TicketID"],
//                     Author = (string)reader["Author"],
//                     Resolver = (string)reader["Resolver"],
//                     Description = (string)reader["Description"],
//                     Status = (Stats)reader["Role"],
//                     Amount = (decimal)reader["Amount"]
                   
//                 });
//             }
//             return ticketList;
//         }

        
//         public bool AddTicket(Ticket addedTicket)
//         {
//         DataSet newUserSet = new DataSet();
//         SqlConnection connection = _connectionFactory.GetConnection();
//         connection.Open();
//         SqlDataAdapter ticketAdapter = new SqlDataAdapter("Select * From ERS.TicketRepo;", connection);   
//         ticketAdapter.Fill(newUserSet, "TicketTable");
//         DataTable? UserTable = newUserSet.Tables["TicketTable"];

//         if(UserTable != null)
//         {
//         DataRow newTicket = UserTable.NewRow();
//         newTicket["TicketID"] = addedTicket.TicketId;
//         newTicket["Author"] = addedTicket.Author;
//         newTicket["Description"] = addedTicket.Description;
//         newTicket["Resolver"] = addedTicket.Resolver;
//         newTicket["Status"] = addedTicket.Status;
//         newTicket["Amount"] = addedTicket.Amount;
        
//         UserTable.Rows.Add(newTicket);

//         SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ticketAdapter);
//         SqlCommand insertCommand = commandBuilder.GetInsertCommand();
//         ticketAdapter.InsertCommand = insertCommand;

//         ticketAdapter.Update(UserTable);

//         addedTicket.UserId = (int) newTicket["UserID"];
//         }
//         return true;
//          }
       

//     public bool UpdateTicketStatus(Ticket ticket)
//     {
//         using SqlCommand command = new SqlCommand("Update ERS.TicketRepo (Resolver, Status) values (@Resolver, @Status", _connectionFactory.GetConnection());
        
//         command.Parameters.AddWithValue("@Resolver", ticket.Resolver);
//         command.Parameters.AddWithValue("@Status", ticket.Status);
        
//         command.Connection.Open();

//         try
//         {
//             command.ExecuteReader();
//             int rowsAffected = (int) command.ExecuteNonQuery();
//         }
//         catch(InputInvalidException)
//         {
//             return false;
//         }
//         return true;
//     }

// }
