using Microsoft.Data.SqlClient;
using Models;

namespace DataAccess;
    public class UserRepository : IUserDA
    {
      

        public List<User> GetAllUsers()
        {
        // Used to store data in the temp list
        List<User> userL = new List<User>();
        // next is the sql statement
        string sql = "select * from ERS.Userrepo;";

        // Using Microsoft.Data.SQLClient.SqlConnection -
        // Input the saved connection to the database here
        SqlConnection connection = new SqlConnection(connectionString);


        // Next Line includws the commands to use sql and the connection string
        SqlCommand command = new SqlCommand(sql, connection);

        try{
            // opening the connection to the database
            connection.Open();
            //storing the result set of a DQL statement into a variable
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("\t{0},\t{1},\t{2},\t{3},\t{4},\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);



            }
            
                userL.Add(new User);

            reader.Close();
            connection.Close();
            }
        catch(Exception e)
            {
                Console.WriteLine(e.Message);    
            }
        return user;
        }

        public List<User> GetUsersbyID(int id){
        // Used to store data in the temp list
        List<User> user = new List<User>();
        // next is the sql statement
        string sql = "select * from ERS.Userrepo order by UserID;";

        // Using Data.SQLClient.SqlConnection -
        // Input the saved connection to the database here
        SqlConnection connection = new SqlConnection(connectionString);


        // Next Line includes the commands to use sql and the connection string
        SqlCommand command = new SqlCommand(sql, connection);

        try{
            // opening the connection to the database
            connection.Open();
            //storing the result set of a DQL statement into a variable
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("\t{0},\t{1},\t{2},\t{3},\t{4},\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
            }

            reader.Close();
            connection.Close();
            }
        catch(Exception e)
            {
                Console.WriteLine(e.Message);    
            }
            return user;
        }
        public List<User> GetUsersbyUsername(string username){
        // Used to store data in the temp list
        List<User> user = new List<User>();
        // next is the sql statement
        string sql = "select * from ERS.Userrepo order by username;";

        // Using Data.SQLClient.SqlConnection -
        // Input the saved connection to the database here
        SqlConnection connection = new SqlConnection(connectionString);


        // Next Line includws the commands to use sql and the connection string
        SqlCommand command = new SqlCommand(sql, connection);

        try{
            // opening the connection to the database
            connection.Open();
            //storing the result set of a DQL statement into a variable
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("\t{0},\t{1},\t{2},\t{3},\t{4},\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
            }

            

            reader.Close();
            connection.Close();
            }
        catch(Exception e)
            {
                Console.WriteLine(e.Message);    
            }
            return user;
        }
    public List<User> CreateUser(User user)
    {
        string sql = "insert into ERS.Users (UserID, Username, Password, Role) VALUES (@UserID, @Username, @Password, @Role);";

        SqlConnection connection = new SqlConnection(connectionString);
        
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue(@UserID, user.userid);
        command.Parameters.AddWithValue(@Username, user.username);
        command.Parameters.AddWithValue(@Password, user.password);
        command.Parameters.AddWithValue(@Role, user.role);

        try
        {
            connection.Open();

        }
        catch
        {

        }
    }
    
     public void UpdateTicketStatus(int TicketID)
     {
        
     }
    
    }