using Services;
using Models;
using CustomExceptions;

namespace WebAPI.Controllers;

public class AuthController
{
    private readonly AuthService _service;
    public AuthController(AuthService service)
    {
        _service = service;
    }
    public async Task<IResult> Register(User userToRegister)
    {
        if(userToRegister.Username == null)
        {
            return Results.BadRequest("Name cannot be null");
        }
        try
        {
            await _service.Register(userToRegister);
            return Results.Created("/register", userToRegister);
        }
        catch(DuplicateRecordException)
        {
            return Results.Conflict("SORRY, Username is taken. Try Again.");
        }
    }
    public async Task<IResult> Login(User userLogin)
    
    {
        if(userLogin.Username == null)
        {
         return Results.BadRequest("Please Enter a Username. Username cannot be Null.");
        }
        try
        {
            return Results.Ok(await _service.LogIn(userLogin));
        }
        catch (InvalidCredentialException)
        {
            
            return Results.NoContent();
        }
    }
}