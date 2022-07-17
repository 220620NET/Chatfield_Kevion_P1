namespace Models;
enum Roles
{
    Associate,
    Manager
}
public class User
{
	public int Userid { get; set; }
    private string username;
    public string Username { 
                            get{
                                  return username;
                               }
                            set
                            {
                                if(String.IsNullOrWhiteSpace(username))
                                {
                                    Console.WriteLine("Hey. Try again. Invaild Name Entry.");
                                }
                               else
                               {
                                    Username = username;
                               } 
                            }
                         }
	public string Password { get; set; }
	public string Role { get; set; }
    public User(int userid, string username, string password, string role)
        {
            Userid = userid;
            Username = username;
            Password = password;
            Role = role;
        }
    public User(int userid, string username, string role)
        {
            Userid = userid;
            Username = username;
            Role = role;
        }
    public User(string username, string password)
    {    
        Username = username;
        Password = password;
    }
    public User(string username)
    {
        Username = username;
    }
    public override string ToString()
    {
        return "ID: "+ Userid + 
               "username: " + Username +
               "password: " + Password + 
               "role: " + Role;
    }






}   

