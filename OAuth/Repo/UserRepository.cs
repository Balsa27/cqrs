using OAuth.Properties;

namespace OAuth;

public class UserRepository : IUserRepository
{
    HashSet<User> _users = new ();

    public UserRepository()
    {
        _users.Add(new User()
        {
            Name = "balsa",
            Email = "balsa@gmail"
        });
    }

    public User GetByEmail(string email)
    {
        var user = _users.FirstOrDefault(user => user.Email == email);
        if(user is null)
            throw new Exception("User not found");
        return user;
    } 
}