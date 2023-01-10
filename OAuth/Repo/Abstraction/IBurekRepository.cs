using OAuth.Properties;

namespace OAuth;

public interface IBurekRepository
{
    HashSet<Burek> GetBureks();
}