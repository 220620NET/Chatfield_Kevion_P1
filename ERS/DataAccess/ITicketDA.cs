using System.Data.SqlClient;
using System.Data;
using secretP;
using System;
using Models;

namespace DataAccess;
        string connectionString = "Server=tcp:kevionserver.database.windows.net,1433;Initial Catalog=bigstorage;Persist Security Info=False;User ID=netmain;Password=" + secretP.passie + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        // " informationAzure database, classlib for password"

    public interface ITicketsDA
    {
      public List<Ticket> GetTicketsbyID(int ticketID);
      public List<Ticket> GetTicketsbyAuthor(string username);
      public List<Ticket> GetTicketbyStatus(Stats stats);
      public void CreateTicket(Ticket Ticket);
      public void UpdateTicketStatus(Stats status);
    }