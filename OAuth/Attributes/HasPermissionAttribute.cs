using Microsoft.AspNetCore.Authorization;

namespace OAuth.Attributes;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permissions permission)
    : base(policy: permission.ToString()) { }   
}