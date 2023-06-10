using _0_Framework.Application;

namespace Eventi.Application.Contract.Slide;

public interface ISlideApplication
{
    Task<OperationResult> CreateAsync(CreateSlide command);
    Task<OperationResult> EditAsync(EditSlide command);
    Task<OperationResult> RemoveAsync(long id);
    Task<OperationResult> RestoreAsync(long id);
    Task<EditSlide?> GetDetailsAsync(long id);
    Task<List<SlideViewModel>> GetListAsync();
}