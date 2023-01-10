using MediatR;
using OAuth.Commands;
using OAuth.Properties;

namespace OAuth.Handlers;

public class LoginCommandHandler
    : IRequestHandler<LogInCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public Task<string> Handle(LogInCommand request, CancellationToken cancellationToken) 
        //TODO: create a custom result class (custom ResponseEntity equivalent) 
    {
        // Get member 
        User? user = _userRepository.GetByEmail(request.email);
        
        if(user == null)
            throw new Exception("User not found"); //this could be replaced with a custom result class or forwarded to an interceptor
        
        string token = _jwtProvider.Generate(user);

        return Task.FromResult(token); 
    }
}