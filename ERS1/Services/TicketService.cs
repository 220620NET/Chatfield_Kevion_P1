using Models;
using DataAccess;

namespace Services;

public class TicketService
{
    private readonly ITicketRepository _repo;
    public TicketService(ITicketRepository repo)
    {
        _repo = repo;
    }


      List<Ticket> GetTicketsByID(int _ticketID)
      {
            return _repo.GetTicketsByID();
      }
      List<Ticket> GetTicketsByAuthor(string username)
      {
            return _repo.GetTicketsByAuthor;
      }
      List<Ticket> GetTicketsByStatus(Stats stats)
      {
            return _repo.GetTicketsByStatus;
      }
      Ticket CreateTicket(Ticket Ticket)
      {
            return _repo.CreateTicket();
      }
      Ticket UpdateTicketStatus(Stats status)
      {
            return _repo.UpdateTicketStatus();
      }



   
}

