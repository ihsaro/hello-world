using HIT.Domain.Entities;
using System.Linq.Expressions;

namespace HIT.Domain.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> Create(T entity, CancellationToken token = default);
    Task<bool> Delete(int id, CancellationToken token = default);
    Task<IEnumerable<T>> GetAll(int limit = int.MaxValue, int offset = 0, CancellationToken token = default);
    Task<T?> Get(Expression<Func<T, bool>> expression, CancellationToken token = default);
    Task<T?> GetById(int id, CancellationToken token = default);
    Task<T> Update(T entity, CancellationToken token = default);
}