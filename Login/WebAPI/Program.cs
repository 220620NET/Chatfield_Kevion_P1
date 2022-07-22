using Services;
using DataAccess;
using Models;
using CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Json;
using WebAPI.Controllers;


var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});



builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("UserDB")));

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<AuthController>();
builder.Services.AddScoped<UserController>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapPost("/Auth/Register", async (User user, [FromServices]AuthController controller) => await controller.Register(user));


app.MapPost("/Auth/Login", async (User userToLogin, AuthController controller) => await controller.Login(userToLogin)
);

app.MapGet("/User", (UserController controller) => controller.GetAllUsers());

app.Run();
