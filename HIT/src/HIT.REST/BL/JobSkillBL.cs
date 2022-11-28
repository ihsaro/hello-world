using HIT.REST.Infrastructure.Entities;
using HIT.REST.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HIT.REST.BL.Interfaces;

public class JobSkillBL : IJobSkillBL
{
    private readonly ApplicationDbContext context;

    public JobSkillBL(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    public async Task<JobSkill> Create(JobSkill entity, CancellationToken token = default)
    {
        context.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<JobSkill>> GetAll(CancellationToken token = default)
    {
        return await context.JobSkills.ToListAsync();
    }
}