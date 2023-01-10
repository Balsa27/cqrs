namespace OAuth.Properties;

public class Burek
{
    public string Name { get; set; }
    public double Price  { get; set; }

    public Burek(string name, double price)
    {
        Name = name;
        Price = price;    
    }

    public Burek() { }
}