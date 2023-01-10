using MediatR;
using OAuth.Properties;

namespace OAuth.Queries;

public record GetUserByEmailQuery(string email) : IRequest<User>;
