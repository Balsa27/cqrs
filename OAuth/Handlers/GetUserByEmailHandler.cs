using MediatR;
using OAuth.Properties;
using OAuth.Queries;

namespace OAuth.Handlers;

public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_userRepository.GetByEmail(request.email));
    }
}