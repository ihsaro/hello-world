using FastEndpoints;
using HIT.Domain.Entities;
using HIT.Domain.Repositories;

namespace HIT.API.Endpoints;

public class CreateCandidateEndpoint : Endpoint<Candidate, Candidate>
{
    private IGenericRepository<Candidate> repository { get; set; }

    public CreateCandidateEndpoint(IGenericRepository<Candidate> repository)
    {
        this.repository = repository;
    }

    public override void Configure()
    {
        Post("/api/v1/candidates");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Candidate request, CancellationToken ct)
    {
        await SendAsync(await repository.Create(request, token: ct), cancellation: ct);
    }
}