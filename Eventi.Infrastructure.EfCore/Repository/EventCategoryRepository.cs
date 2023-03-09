using _0_Framework.Infrastructure;
using Eventi.Application.Contract.EventCategory;
using Eventi.Domain.EventCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class EventCategoryRepository : RepositoryBase<long, EventCategory>, IEventCategoryRepository
{
    private readonly EventiContext _context;

    public EventCategoryRepository(EventiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<EventCategoryViewModel>> GetEventCategoriesAsync()
    {
        return await _context.EventCategories.Select(x => new EventCategoryViewModel
        {
            CategoryId = x.CategoryId,
            CategoryName = x.CategoryName,
            EventSubcategoriesCount = x.EventSubcategories.Count
        }).ToListAsync();
    }

    public async Task<List<EventCategory>> GetAllAsync()
    {
        return await _context.EventCategories.ToListAsync();
    }

    public async Task<EditEventCategory?> GetDetailsAsync(long id)
    {
        return await _context.EventCategories.Select(x => new EditEventCategory
        {
            CategoryId = x.CategoryId,
            CategoryName = x.CategoryName,
            Slug = x.Slug
        }).FirstOrDefaultAsync(x => x.CategoryId == id);
    }

    public string GetCategorySlugById(long id)
    {
        return _context.EventCategories.Select(x => new {x.CategoryId, x.Slug})
            .FirstOrDefault(x => x.CategoryId == id)!.Slug;
    }

    public async Task<List<EventCategoryViewModel>> SearchAsync(EventCategorySearchModel searchModel)
    {
        var query = _context.EventCategories.Select(x => new EventCategoryViewModel
        {
            CategoryId = x.CategoryId,
            CategoryName = x.CategoryName,
            CreationDate = x.CreationDate.ToString()
        });

        if (!string.IsNullOrWhiteSpace(searchModel.Name))
        {
            query = query.Where(x => x.CategoryName.Contains(searchModel.Name));
        }

        return await query.OrderByDescending(x => x.CategoryId).ToListAsync();
    }
}