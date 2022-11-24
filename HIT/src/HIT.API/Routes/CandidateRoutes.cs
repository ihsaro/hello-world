using Microsoft.AspNetCore.Mvc;

using HIT.API.Routes.Configuration;
using HIT.Domain.Repositories;
using HIT.Domain.Entities;

namespace HIT.API.Routes;

public sealed class CandidateRoutes : IRoute
{
    public void ConfigureRoutes(WebApplication app)
    {
        app
            .MapGet("api/v1/candidates", GetAll)
            .AllowAnonymous();
    }

    private async Task<IResult> GetAll([FromServices] IGenericRepository<Candidate> repository, CancellationToken token = default)
    {
        var result = await repository.GetAll(token: token);
        return Results.Ok(result);
    }
}
