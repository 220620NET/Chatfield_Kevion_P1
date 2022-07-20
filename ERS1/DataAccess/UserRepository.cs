using Microsoft.Data.SqlClient;
using CustomExceptions;
using Models;
using System.Data;
namespace DataAccess;

public class UserRepository : IUserRepository
{
    private readonly ConnectionFactory _connectionFactory;
    public UserRepository(ConnectionFactory connection)
    {
    _connectionFactory = connection; 
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
            Role = (Roles)reader["Role"]
        });
        reader.Close();
        connection.Close();
    }
        return users; 
    }
    public User GetUserByUsername(string _username)
    {
        SqlConnection connection = _connectionFactory.GetConnection();
        connection.Open();
        SqlCommand command = new SqlCommand("select * from ERS.UserRepo WHERE Username = {_username}", connection);
        SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                return new User
                {
                    UserId = (int)reader["UserID"],
                    Username = (string)reader["Username"],
                    Password = (string)reader["Password"],
                    Role = (Roles)reader["Role"]
                };
            }

            throw new RecordNotFoundException("Sorry! We could not find Username.");
    }

    public User CreateUser(User newUserToRegister)
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

        SqlCommand insertCommand = new SqlCommand("Insert into ERS.UserRepo (Username, Password, Role) OUTPUT Inserted.UserID values @Username, @Password, @Role", connection);
        insertCommand.Parameters.Add("@Username", SqlDbType.VarChar,50,"Username");
        insertCommand.Parameters.Add("@Password", SqlDbType.VarChar,50,"Password");
        insertCommand.Parameters.Add("@Role",SqlDbType.VarChar,50,"ROle");

        userAdapter.InsertCommand = insertCommand;

        userAdapter.Update(UserTable);

        newUserToRegister.UserId = (int) newUser["UserID"];
        }
        return newUserToRegister;
    }
       
}

