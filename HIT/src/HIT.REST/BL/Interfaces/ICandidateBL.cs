using HIT.REST.Infrastructure.Entities;

namespace HIT.REST.BL.Interfaces;

public interface ICandidateBL
{
    Task<IEnumerable<Candidate>> GetAll(CancellationToken token = default);
}