using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Slide;
using Eventi.Domain.SlideAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
{
    private readonly EventiContext _context;

    public SlideRepository(EventiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<EditSlide?> GetDetailsAsync(long id)
    {
        return await _context.Slides.Select(x => new EditSlide
        {
            Id = x.Id,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            Link = x.Link,
        }).FirstOrDefaultAsync(x => x.Id == id)!;
    }

    public async Task<List<SlideViewModel>> GetListAsync()
    {
        return await _context.Slides.Select(x => new SlideViewModel
        {
            Id = x.Id,
            Picture = x.Picture,
            IsRemoved = x.IsRemoved,
            CreationDate = x.CreationDate.ToFarsi()
        }).OrderByDescending(x => x.Id).ToListAsync();
    }
}