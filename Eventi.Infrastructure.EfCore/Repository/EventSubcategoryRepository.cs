using _0_Framework.Infrastructure;
using Eventi.Application.Contract.EventSubcategory;
using Eventi.Domain.EventCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class EventSubcategoryRepository : RepositoryBase<long, EventSubcategory>, IEventSubcategoryRepository
{
    private readonly EventiContext _context;

    public EventSubcategoryRepository(EventiContext context) : base(context)
    {
        _context = context;
    }
    

    public async Task<List<EventSubcategoryViewModel>> GetEventSubcategoriesAsync()
    {
        return await _context.EventSubcategories.Select(x => new EventSubcategoryViewModel
        {
            SubcategoryId = x.SubcategoryId,
            SubcategoryName = x.SubcategoryName,
            CreationDate = x.CreationDate.ToString(),
        }).ToListAsync();
    }

    public async Task<List<EventSubcategory>> GetAllAsync()
    {
        return await _context.EventSubcategories.ToListAsync();
    }

    public async Task<EditEventSubcategory?> GetDetailsAsync(long id)
    {
        return await _context.EventSubcategories.Select(x => new EditEventSubcategory
        {
            SubcategoryId = x.SubcategoryId,
            SubcategoryName = x.SubcategoryName,
            Slug = x.Slug,
        }).FirstOrDefaultAsync(x => x.SubcategoryId == id);
    }

    public string GetSubcategorySlugById(long id)
    {
        return _context.EventSubcategories.Select(x => new {x.SubcategoryId, x.Slug})
            .FirstOrDefault(x => x.SubcategoryId == id)!.Slug;
    }

    public async Task<List<EventSubcategoryViewModel>> SearchAsync(EventSubcategorySearchModel searchModel)
    {
        var query = _context.EventSubcategories.Select(x => new EventSubcategoryViewModel
        {
            SubcategoryId = x.SubcategoryId,
            SubcategoryName = x.SubcategoryName,
            CreationDate = x.CreationDate.ToString(),
        });

        if (!string.IsNullOrWhiteSpace(searchModel.Name))
        {
            query = query.Where(x => x.SubcategoryName.Contains(searchModel.Name));
        }

        return await query.OrderByDescending(x => x.SubcategoryId).ToListAsync();
    }
}