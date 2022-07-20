using Models;

namespace DataAccess;

public interface IUserRepository
{
    List<User> GetAllUsers();
    public User GetUserByUsername(string _username);
    public User CreateUser(User newUserToRegister);
}