using Services;
using DataAccess;
using Models;
using CustomExceptions;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection by ASP>NET CORE
//Different wys to add your dependencies: Singleton, Scoped, Transient
builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetCOnnectionString("UserDB")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<TicketService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapGet("/redCarpet", (string celeb, string location) => { 
    if(String.IsNullOrWhiteSpace(location))
        return $"Hi {celeb}!";
    return $"Hello {celeb} from {location}";  
    }
);

app.MapPost("/stocks", (string position) => {
    return $"Which direction was the market trending {position}";
});

app.MapGet("/User",() => 
{
    var scope = app.Scopes.CreateScope();
    UserService service = scope.ServiceProvider.GetRequired<UserService>();

    return service.GetAllUsers();
});

app.MapPost("/Register", (User user) => 
{
    var scope = app.Scopes.CreateScope();
    AuthService service = scope.ServiceProvider.GetRequired<AuthService>();

    try
    {
        service.Register(user);
        return Results.CreatedAtRoute();
    }
    catch(DuplicateRecordException)
    {
        // something
        return Results.Conflict("User with this username already exists");
    }
});

app.Run();
