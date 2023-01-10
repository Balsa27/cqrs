using MediatR;
using OAuth.Properties;
using OAuth.Queries;

namespace OAuth.Handlers;

public class GetAllBureksHandler : IRequestHandler<GetAllBureksQuery, HashSet<Burek>>
{
    private readonly IBurekRepository _burekRepository;

    public GetAllBureksHandler(IBurekRepository burekRepository)
    {
        _burekRepository = burekRepository;
    }

    public Task<HashSet<Burek>> Handle(GetAllBureksQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_burekRepository.GetBureks());
    }
}