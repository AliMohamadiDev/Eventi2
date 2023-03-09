using System.Linq.Expressions;
using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _0_Framework.Infrastructure;

public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
{
    private readonly DbContext _context;

    public RepositoryBase(DbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
    }

    public async Task<T?> GetAsync(TKey id)
    {
        return await _context.FindAsync<T>(id);
    }

    public async Task<List<T>> GetAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public bool Exists(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Any(expression);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}