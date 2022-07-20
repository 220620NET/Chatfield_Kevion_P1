using Models;

namespace DataAccess;
        // " informationAzure database, classlib for password"

    public interface ITicketRepository
    {
      List<Ticket> GetTicketsByID(int _ticketID);
      List<Ticket> GetTicketsByAuthor(string username);
      List<Ticket> GetTicketsByStatus(Stats stats);
      public Ticket CreateTicket(Ticket Ticket);
      public Ticket UpdateTicketStatus(Stats status);
    }