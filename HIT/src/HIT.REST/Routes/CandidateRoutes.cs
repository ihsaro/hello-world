using Microsoft.AspNetCore.Mvc;

using HIT.REST.Routes.Configuration;
using HIT.REST.BL.Interfaces;

namespace HIT.REST.Routes;

public sealed class CandidateRoutes : IRoute
{
    public void ConfigureRoutes(WebApplication app)
    {
        app
            .MapGet("api/v1/candidates", GetAll)
            .AllowAnonymous();
    }

    private async Task<IResult> GetAll([FromServices] ICandidateBL candidateBL, CancellationToken token = default)
    {
        var result = await candidateBL.GetAll(token: token);
        return Results.Ok(result);
    }
}