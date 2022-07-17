using Models;

namespace DataAccess;

public interface IUser
{
    public List<User> GetAllUsers(int Userid);
    public List<User> CreateUser(User user);
    
    public void UpdateTicketStatus(int TicketID);
    
}