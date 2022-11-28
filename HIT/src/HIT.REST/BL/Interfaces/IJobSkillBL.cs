using HIT.REST.Infrastructure.Entities;

namespace HIT.REST.BL.Interfaces;

public interface IJobSkillBL
{
    Task<JobSkill> Create(JobSkill entity, CancellationToken token = default);
    Task<IEnumerable<JobSkill>> GetAll(CancellationToken token = default);
}