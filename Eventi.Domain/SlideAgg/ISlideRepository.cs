using _0_Framework.Domain;
using Eventi.Application.Contract.Slide;

namespace Eventi.Domain.SlideAgg;

public interface ISlideRepository : IRepository<long, Slide>
{
    Task<EditSlide?> GetDetailsAsync(long id);
    Task<List<SlideViewModel>> GetListAsync();
}