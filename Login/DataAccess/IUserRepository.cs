using Models;

namespace DataAccess;

public interface IUserRepository
{
    List<User> GetAllUsers();
    public Task<User> GetUserByUsername(string _username);
    public User AddUser(User newUserToRegister);
}