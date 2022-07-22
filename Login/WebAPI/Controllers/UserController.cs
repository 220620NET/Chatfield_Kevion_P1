using Models;
using Services;
using CustomExceptions;

namespace WebAPI.Controllers;

public class UserController
{
    private readonly UserService _service;
    public UserController(UserService service)
    {
        _service = service;
    }

    public List<User> GetAllUsers()
    {
        return _service.GetAllUsers();
    }
}

