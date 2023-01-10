using System.Windows.Input;
using MediatR;

namespace OAuth.Commands;

public record LogInCommand(string email, string password) : IRequest<string>;