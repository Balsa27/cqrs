using OAuth.Infrastructure;

namespace OAuth.Properties.Enums;

public sealed class Role : Enumeration<Role>
{
    public static readonly Role Registered = new Role(1, nameof(Registered));
    public Role(int id, string name) 
        : base(id, name)
    {
    }
}