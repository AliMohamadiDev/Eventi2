using _01_EventiQuery.Contracts.Common;
using Eventi.Infrastructure.EfCore;

namespace _01_EventiQuery.Query;

public class IndexQuery : IIndexQuery
{
    private readonly EventiContext _context;

    public IndexQuery(EventiContext context)
    {
        _context = context;
    }

    public int AccountsCount()
    {
        return _context.Accounts.Count();
    }

    public int OrdersCount()
    {
        return _context.Orders.Count();
    }

    public int ArticlesCount()
    {
        return _context.Articles.Count();
    }

    public int DepartmentsCount()
    {
        return _context.Departments.Count();
    }
}