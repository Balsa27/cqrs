using MediatR;
using OAuth.Properties;

namespace OAuth.Queries;

public record GetAllBureksQuery() :IRequest<HashSet<Burek>>;

