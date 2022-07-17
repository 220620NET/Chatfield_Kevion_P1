namespace Models;

public class Ticket
{
    public int TicketID { get; set;}
    public string Author { get; set;}
    public string Resolver { get; set;}
    public string Description { get; set;}
    public Stats Status { get; set;}
    public decimal Amount { get; set;}

    public Ticket(int ticketID, string author, string resolver, string description, Stats status, decimal amount)
    {
        TicketID = ticketID;
        Author = author;
        Resolver = resolver;
        Description = description;
        Status = status;
        Amount = amount;
    }

    public override string ToString()
    {
       return  "ticketID " + TicketID +
                "author " + Author +
                "resolver " + Resolver +
                "description " + Description +
                "status " + Status +
                "amount " + Amount;
    }
}
