using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Event;
using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class EventRepository : RepositoryBase<long, Event>, IEventRepository
{
    private readonly EventiContext _context;

    public EventRepository(EventiContext context) : base(context)
    {
        _context = context;
    }

    public Event GetEvent(long id)
    {
        return _context.Events.Find(id)!;
    }

    public async Task<EditEvent?> GetDetailsAsync(long id)
    {
        return await _context.Events.Select(x => new EditEvent
        {
            Id = x.Id,
            Name = x.Name,
            SubcategoryId = x.SubcategoryId,
            Slug = x.Slug,
            //PresenterId = x.PresenterId,
            DepartmentId = x.DepartmentId,
            //ImageCover = x.ImageCover,
            ImageCoverTitle = x.ImageCoverTitle,
            ImageCoverAlt = x.ImageCoverAlt,
            Tags = x.Tags,
            Address = x.Address,
            Description = x.Description,
            EventType = x.EventType,
            SupportNumber = x.SupportNumber,
            IsConfirmed = x.IsConfirmed
        }).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<EventViewModel>> GetEventsAsync()
    {
        return await _context.Events.Select(x => new EventViewModel
        {
            Id = x.Id,
            Name = x.Name,
            ImageCover = x.ImageCover,
            //PresenterId = x.PresenterId,
            //Presenter = x.Presenter.Name,
            SubcategoryId = x.SubcategoryId,
            Subcategory = x.Subcategory.SubcategoryName,
            AccountSideId = x.DepartmentId,
            AccountSide = x.Department.NationalCode.ToString(),
            Address = x.Address,
            Description = x.Description,
            EventType = x.EventType,
            SupportNumber = x.SupportNumber,
            IsConfirmed = x.IsConfirmed
        }).ToListAsync();
    }

    public async Task<List<EventViewModel>> SearchAsync(EventSearchModel searchModel)
    {
        var query = _context.Events.Select(x => new EventViewModel
        {
            Id = x.Id,
            Name = x.Name,
            ImageCover = x.ImageCover,
            //PresenterId = x.PresenterId,
            //Presenter = x.Presenter.Name,
            SubcategoryId = x.SubcategoryId,
            Subcategory = x.Subcategory.SubcategoryName,
            AccountSideId = x.DepartmentId,
            AccountSide = x.Department.NationalCode.ToString(),
            Address = x.Address,
            Description = x.Description,
            EventType = x.EventType,
            SupportNumber = x.SupportNumber,
            IsConfirmed = x.IsConfirmed
        });

        //if (searchModel.IsWebinar)
        //{
        //    query = query.Where(x => x.IsWebinar);
        //}

        if (searchModel.Name != null)
        {
            query = query.Where(x => x.Name.Contains(searchModel.Name));
        }

        if (searchModel.PresenterId != 0)
        {
            query = query.Where(x => x.PresenterId == searchModel.PresenterId);
        }

        if (searchModel.SubcategoryId != 0)
        {
            query = query.Where(x => x.SubcategoryId == searchModel.SubcategoryId);
        }

        if (searchModel.AccountSideId != 0)
        {
            query = query.Where(x => x.AccountSideId == searchModel.AccountSideId);
        }

        return await query.OrderByDescending(x => x.Id).ToListAsync();
    }

    public void Remove(long id)
    {
        _context.Events.Find(id).Remove();
    }

    public void Restore(long id)
    {
        _context.Events.Find(id).Restore();
    }
}