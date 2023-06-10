using _01_EventiQuery.Contracts.Slide;
using Eventi.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_EventiQuery.Query;

public class SlideQuery : ISlideQuery
{
    private readonly EventiContext _eventiContext;

    public SlideQuery(EventiContext eventiContext)
    {
        _eventiContext = eventiContext;
    }

    public async Task<List<SlideQueryModel>> GetSlidesAsync()
    {
        return await _eventiContext.Slides
            .Where(x => !x.IsRemoved)
            .Select(x => new SlideQueryModel
            {
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Link = x.Link,
            }).ToListAsync();
    }
}