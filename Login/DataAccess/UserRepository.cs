using Microsoft.Data.SqlClient;
using CustomExceptions;
using Models;
using System.Data;
namespace DataAccess;

public class UserRepository : IUserRepository
{
    private readonly ConnectionFactory _connectionFactory;
    public UserRepository(ConnectionFactory factory)
    {
    _connectionFactory = factory; 
    }

    public List<User> GetAllUsers()
    {
    // Used to store data in the temp list
    List<User> users = new List<User>();
    // next is the sql statement
    string sql = "SELECT * FROM ERS.UserRepo;";
    SqlConnection connection = _connectionFactory.GetConnection();
    connection.Open();
    // Next Line includws the commands to use sql and the connection string
    SqlCommand command = new SqlCommand(sql, connection);
    SqlDataReader reader = command.ExecuteReader(); 

    while(reader.Read())
    {
        users.Add(new User
        {
            UserId = (int)reader["UserID"],
            Username = (string)reader["Username"],
            Password = (string)reader["Password"],
            Role = (string)reader["Role"]
        });
        reader.Close();
        connection.Close();
    }
        return users; 
    }
    public async Task<User> GetUserByUsername(string _username)
    {
        using SqlConnection connection = _connectionFactory.GetConnection();
        connection.Open();

        using SqlCommand command = new SqlCommand("select * from ERS.UserRepo WHERE Username = @Username", connection);
        command.Parameters.AddWithValue("@Username", _username);
        
        using SqlDataReader reader = command.ExecuteReader();

            while(await reader.ReadAsync())
            {
                return new User
                {
                    UserId = (int)reader["UserID"],
                    Username = (string)reader["Username"],
                    Password = (string)reader["Password"],
                    Role = (string)reader["Role"]
                };
            }

            throw new RecordNotFoundException("Sorry! We could not find Username.");
    }

    public User AddUser(User newUserToRegister)
    {
        DataSet newUserSet = new DataSet();
        SqlConnection connection = _connectionFactory.GetConnection();
        connection.Open();
        SqlDataAdapter userAdapter = new SqlDataAdapter("Select * From ERS.UserRepo;", connection);   
        userAdapter.Fill(newUserSet, "UserTable");
        DataTable? UserTable = newUserSet.Tables["UserTable"];

        if(UserTable != null)
        {
        DataRow newUser = UserTable.NewRow();
        newUser["UserID"] = newUserToRegister.UserId;
        newUser["Username"] = newUserToRegister.Username;
        newUser["Password"] = newUserToRegister.Password;
        newUser["Roles"] = newUserToRegister.Role;
        
        UserTable.Rows.Add(newUser);

        using SqlCommand insertCommand = new SqlCommand("INSERT INTO UserRepo (Username, Password, Role) OUTPUT INSERTED.UserID (@Username, @Password, @Role)", connection);
        insertCommand.Parameters.Add("@Username", SqlDbType.VarChar, 50, "Username");      
        insertCommand.Parameters.Add("@Password", SqlDbType.VarChar, 50, "Password");
        insertCommand.Parameters.Add("@Role", SqlDbType.VarChar, 50, "Role");

        
        userAdapter.InsertCommand = insertCommand;

        userAdapter.Update(UserTable);

        newUserToRegister.UserId = (int) newUser["UserID"];
        }
        return newUserToRegister;
    }
       
}

