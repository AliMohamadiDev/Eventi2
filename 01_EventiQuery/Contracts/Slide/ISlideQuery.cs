namespace _01_EventiQuery.Contracts.Slide;

public interface ISlideQuery
{
    Task<List<SlideQueryModel>> GetSlidesAsync();
}