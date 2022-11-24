using HIT.Domain.Entities;
using HIT.Domain.Repositories;
using HIT.Infrastructure.Repositories;

namespace HIT.Infrastructure.Persistence.Repositories;

public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
{
    public CandidateRepository(ApplicationDbContext context) : base(context)
    {
    }
}