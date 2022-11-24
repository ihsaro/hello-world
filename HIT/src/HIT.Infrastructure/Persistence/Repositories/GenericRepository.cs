using HIT.Domain.Attributes;
using HIT.Domain.Entities;
using HIT.Domain.Repositories;
using HIT.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

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
        var entities = await table
                        .Skip(offset)
                        .Take(limit)
                        .OrderBy(x => x.LastUpdatedTimestamp)
                        .ToListAsync();

        foreach (var entity in entities)
        {
            PropertyInfo[] props = entity.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    AnonymizeAttribute attribute = attr as AnonymizeAttribute;
                    if (attribute != null)
                    {
                        string propName = prop.Name;

                        prop.SetValue(entity, ApplicationDbContext.DecryptString(prop.GetValue(entity).ToString()));
                    }
                }
            }
        }

        return entities;
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