using OAuth.Properties;

namespace OAuth;

public class BurekRepository : IBurekRepository
{
    HashSet<Burek> _bureks = new ();

    public BurekRepository()
    {
        _bureks.Add(new Burek()
        {
            Name = "Burek sa sirom",
            Price = 1.5,
        });
    }

    public HashSet<Burek> GetBureks() => _bureks;
    
}