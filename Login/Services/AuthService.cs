using CustomExceptions;
using Models;
using DataAccess;
namespace Services;
using System.Text.Json;

public class AuthService
{
    private readonly IUserRepository _repo;
    public AuthService(IUserRepository repo)
    {
        _repo = repo;
    }
    public async Task<User> Register(User newUser)
    {
        try
        {
            await _repo.GetUserByUsername(newUser.Username);
            throw new DuplicateRecordException();
        }
        catch(RecordNotFoundException)
        {
            return  _repo.AddUser(newUser);
        }
    }

    public async Task<User> LogIn(User userToLogin)
    {   
        try
        {
            User foundTrainer = await _repo.GetUserByUsername(userToLogin.Username);
            return foundTrainer;
        }
        catch(RecordNotFoundException)
        {
            throw new InvalidCredentialException();
        }
    }

        
    
}    
