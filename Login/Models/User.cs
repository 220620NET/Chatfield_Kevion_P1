using CustomExceptions;
namespace Models;

public class User
{
    public User()
    {
        _userID = 0;
        _username = "";
        Password = "";
        Role = "";
    }
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
   	public string Role { get; set; }
    // public User(int _userd, string username, string password, string role)
    //     {
    //         UserId = _userd;
    //         Username = username;
    //         Password = password;
    //         Role = role;
    //     }
    // public User(int _userid,
    //             string username,
    //             string role) 
    //     {
    //         UserId = _userid;
    //         Username = username;
    //         Role = _role;
    //     }
    // public User(string _username, string password)
    // {    
    //     Username = _username;
    //     Password = password;
    // }
    // public User(string _username)
    // {
    //     Username = _username;
    // }
    
    public override string ToString()
    {
        return "username: " + Username +
               "password: " + Password + 
               "role: " + Role;
    }
    
    public override bool Equals(object? obj)
    {
        if(obj == null) return false;
        if(obj.GetType() == this.GetType())
        {
            User userToCompare = (User) obj;

            if(this.Username == userToCompare.Username && this.Password == userToCompare.Password && this.Role == userToCompare.Role)
            {
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}   

