using _01_EventiQuery.Contracts.Event;
using _01_EventiQuery.Contracts.Presenter;
using Eventi.Domain.EventAgg;
using Eventi.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_EventiQuery.Query;

public class PresenterQuery : IPresenterQuery
{
    private readonly EventiContext _eventContext;

    public PresenterQuery(EventiContext eventContext)
    {
        _eventContext = eventContext;
    }

    public async Task<PresenterQueryModel> GetPresenterAsync(string slug)
    {
        return await _eventContext.Presenters
            .Include(x => x.EventPresenters)
            .Select(x => new PresenterQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Logo = x.Logo,
                LogoTitle = x.LogoTitle,
                LogoAlt = x.LogoAlt,
                Description = x.Description,
                Number = x.Number,
                Policy = x.Policy,
                Website = x.Website,
                Slug = x.Slug,
            }).FirstOrDefaultAsync(x => x.Slug == slug) ?? new PresenterQueryModel();
    }

    public async Task<List<PresenterQueryModel>> GetPresentersAsync()
    {
        return await _eventContext.Presenters
            .Include(x => x.EventPresenters)
            .Select(x => new PresenterQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Logo = x.Logo,
                LogoTitle = x.LogoTitle,
                LogoAlt = x.LogoAlt,
                Description = x.Description,
                Number = x.Number,
                Policy = x.Policy,
                Website = x.Website,
                Slug = x.Slug,
                //Events = MapEvents(x.Events)
            }).OrderByDescending(x => x.Id).ToListAsync();
    }

    private static List<EventQueryModel> MapEvents(List<Event>? events)
    {
        return new List<EventQueryModel>();
        return events.Select(x => new EventQueryModel
        {
            Id = x.Id,
            Name = x.Name,
            Slug = x.Slug,
            ImageCover = x.ImageCover,
            ImageCoverAlt = x.ImageCoverAlt,
            ImageCoverTitle = x.ImageCoverTitle,
            Subcategory = x.Subcategory.SubcategoryName
        }).ToList();
    }
}