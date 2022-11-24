using HIT.Domain.Entities;
using HIT.Domain.Repositories;
using HIT.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HIT.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext context;
    private readonly DbSet<T> table;

    public GenericRepository(ApplicationDbContext context)
    {
        this.context = context;
        table = this.context.Set<T>();
    }

    public async Task<T> Create(T entity, CancellationToken token = default)
    {
        await table.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(int id, CancellationToken token = default)
    {
        try
        {
            var entity = await GetById(id, token);

            if (entity == null)
                return false;

            table.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IEnumerable<T>> GetAll(int limit = int.MaxValue, int offset = 0, CancellationToken token = default)
    {
        return await table
                        .Skip(offset)
                        .Take(limit)
                        .OrderBy(x => x.LastUpdatedTimestamp)
                        .ToListAsync();
    }

    public async Task<T?> Get(Expression<Func<T, bool>> expression, CancellationToken token = default)
    {
        return await table.FirstOrDefaultAsync(expression);
    }

    public async Task<T?> GetById(int id, CancellationToken token = default)
    {
        return await table.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> Update(T entity, CancellationToken token = default)
    {
        await context.SaveChangesAsync();
        return entity;
    }
}