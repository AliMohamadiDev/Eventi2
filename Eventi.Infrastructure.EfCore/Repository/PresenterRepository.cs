using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Presenter;
using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class PresenterRepository : RepositoryBase<long, Presenter>, IPresenterRepository
{
    private readonly EventiContext _context;

    public PresenterRepository(EventiContext context) : base(context)
    {
        _context = context;
    }

    public Presenter GetPresenter(long id)
    {
        return _context.Presenters.Find(id);
    }

    public async Task<EditPresenter?> GetDetailsAsync(long id)
    {
        return await _context.Presenters.Select(x => new EditPresenter
        {
            Id = x.Id,
            Name = x.Name,
            //Logo = x.Logo,
            LogoAlt = x.LogoAlt,
            LogoTitle = x.LogoTitle,
            Slug = x.Slug,
            Number = x.Number,
            Description = x.Description,
            Policy = x.Policy,
            Website = x.Website
        }).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PresenterViewModel>> GetPresentersAsync()
    {
        return await _context.Presenters.Select(x => new PresenterViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Logo = x.Logo,
            Number = x.Number,
            Website = x.Website,
            CreationDate = x.CreationDate.ToString()
        }).ToListAsync();
    }

    public async Task<List<PresenterViewModel>> SearchAsync(PresenterSearchModel searchModel)
    {
        var query = _context.Presenters.Select(x => new PresenterViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Logo = x.Logo,
            Number = x.Number,
            Website = x.Website,
            CreationDate = x.CreationDate.ToString()
        });

        if (searchModel.Id != 0)
        {
            query = query.Where(x => x.Id == searchModel.Id);
        }

        if (searchModel.Name != null)
        {
            query = query.Where(x => x.Name.Contains(searchModel.Name));
        }

        return await query.OrderByDescending(x => x.Id).ToListAsync();
    }
}