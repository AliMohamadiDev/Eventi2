using System.Linq.Expressions;

namespace _0_Framework.Domain;

public interface IRepository<in TKey, T> where T : class
{
    Task SaveChangesAsync();
    Task<List<T>> GetAsync();
    Task<T?> GetAsync(TKey id);
    Task CreateAsync(T entity);
    bool Exists(Expression<Func<T, bool>> expression);
}