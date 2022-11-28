using HIT.REST.BL.Interfaces;
using HIT.REST.Infrastructure.Entities;
using HIT.REST.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HIT.REST.BL;

public class CandidateBL : ICandidateBL
{
    private readonly ApplicationDbContext context;

    public CandidateBL(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Candidate>> GetAll(CancellationToken token = default)
    {
        return await context.Candidates.ToListAsync(cancellationToken: token);
    }
}