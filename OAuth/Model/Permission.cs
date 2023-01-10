using OAuth.Properties;

namespace OAuth.Model;

public class Permission //for db
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    
    public ICollection<Permission> Permissions { get; set; }
    public ICollection<User> Users { get; set; }

}