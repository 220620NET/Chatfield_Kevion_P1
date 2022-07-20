using CustomExceptions;
using Models;
using DataAccess;
namespace Services;

public class AuthService
{
    private readonly IUserRepository _repo;
    public AuthService(IUserRepository repo)
    {
        _repo = repo;
    }
    public User Register(User newUser)
    {
        //No Duplicates and Unique Username Method
        // if not any of the above, saved to the LIst????????????
        Console.Writeline("Congrats! You have Registered Succesfully!");
        try
        {
            _repo.GetUserByUsername(newUser.Username);
            throw new DuplicateRecordException();
        }
        catch(RecordNotFoundException)
        {
            Console.WriteLine("We didn't find the record.");
            return new User();
        }

    }
}    
