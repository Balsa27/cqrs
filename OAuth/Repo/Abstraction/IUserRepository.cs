using OAuth.Properties;

namespace OAuth;

public interface IUserRepository
{
    User GetByEmail(string email);   
}