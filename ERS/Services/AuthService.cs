//Using CustomExceptions;
using DataAccess;

namespace Serves;

public class AuthService
{
    private readonly IUserDA _repo;
    public AuthServices(IUserDA repository)
    {
        _repo = repository;
    }

}

