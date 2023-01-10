using OAuth.Properties;

namespace OAuth;

public interface IJwtProvider
{
    string Generate(User user);
}