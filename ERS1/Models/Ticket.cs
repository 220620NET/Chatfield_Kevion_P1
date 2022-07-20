using CustomExceptions;
namespace Models;
public enum Stats
{
    Pending,
    Denied,
    Approved
}
public class Ticket
{
    private int _ticketID;
    public int TicketId { get
                          {
                            return _ticketID;
                          }
                          set
                          {
                            if(value == 00000 && value <= 999999)
                            {
                                throw new InputInvalidException("Your UserID can be located from your MainAccount. \nEX. ###### or 999999s");
                            }

                          }
                        }
    public string Author { get; set;}
    public string Resolver { get; set;}
    public string Description { get; set;}
    public Stats Status { get; set;}
    public decimal Amount { get; set;}

    public Ticket(int _ticketID, string author, string resolver, string description, Stats status, decimal amount)
    {
        TicketId = _ticketID;
        Author = author;
        Resolver = resolver;
        Description = description;
        Status = status;
        Amount = amount;
    }
    public Ticket(){}

    public override string ToString()
    {
       return  $"TicketID: {TicketId}, \nAuthor: {Author}, \nResolver: {Resolver}, \nDescription: {Description}, \nStatus: {Status}, \nAmount: {Amount}";
    }
}
