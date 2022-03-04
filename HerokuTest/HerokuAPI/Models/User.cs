namespace HerokuAPI.Models;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }

    public User()
    {
        
    }
    public User(int userId, string userName)
    {
        UserId = userId;
        UserName = userName;
    }
    public User(string userName)
    {
        UserName = userName;
    }
}