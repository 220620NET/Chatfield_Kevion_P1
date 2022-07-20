using CustomExceptions;
namespace Models;
public enum Roles
{
    Associate,
    Manager
}
public class User
{
    private int _userID;
	public int UserId { get
                            {
                                return _userID;
                            } 
                        set
                            {
                                if(value == 0 && value <= 999999)
                                {
                                    throw new InputInvalidException("Userid is out Range. Please use assigned number.");
                                }
                            } 
                      }
    private string _username;
    public string Username { 
                            get{
                                  return _username;
                               }
                            set
                            {
                                if(String.IsNullOrWhiteSpace(value))
                                {
                                    throw new InputInvalidException("Hey. Try again. Invaild Name Entry.");
                                }
                                else if(value.Length == 0 && value.Length >= 20)
                                {
                                    throw new InputInvalidException("The Username can not be longer than 20 characters.");
                                }
                                else
                                {
                                    _username = value;
                                } 
                            }
                         }
	public string Password { get; set; }
	public Roles Role { get; set;}
    public User(int _userid, string username, string password, Roles role)
        {
            UserId = _userid;
            Username = username;
            Password = password;
            Role = role;
        }
    public User(int userid,
                string username,
                Roles role)
        {
            UserId = userid;
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
    public User(){}
    
    public override string ToString()
    {
        return "ID: "+ UserId + 
               "username: " + Username +
               "password: " + Password + 
               "role: " + Role;
    }






}   

