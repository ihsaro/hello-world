using FastEndpoints;
using HIT.Application.Architecture;
using HIT.Application.Models;
using HIT.Application.Services.Interfaces;
using HIT.Domain.Entities;
using HIT.Domain.Repositories;

namespace HIT.API.Endpoints;

public class GetCandidatesEndpoint : EndpointWithoutRequest<IEnumerable<Candidate>>
{
    private IGenericRepository<Candidate> repository { get; set; }

    public GetCandidatesEndpoint(IGenericRepository<Candidate> repository)
    {
        this.repository = repository;
    }

    public override void Configure()
    {
        Get("/api/v1/candidates");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(await repository.GetAll(token: ct), cancellation: ct);
    }
}