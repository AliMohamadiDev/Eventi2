using _0_Framework.Application;
using Eventi.Application.Contract.Slide;
using Eventi.Domain.SlideAgg;

namespace Eventi.Application;

public class SlideApplication : ISlideApplication
{
    private readonly ISlideRepository _slideRepository;
    private readonly IFileUploader _fileUploader;

    public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
    {
        _slideRepository = slideRepository;
        _fileUploader = fileUploader;
    }

    public async Task<OperationResult> CreateAsync(CreateSlide command)
    {
        var operation = new OperationResult();

        var pictureName = _fileUploader.Upload(command.Picture, "slides");

        var slide = new Slide(pictureName, command.PictureAlt, command.PictureTitle, command.Link);

        await _slideRepository.CreateAsync(slide);
        await _slideRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> EditAsync(EditSlide command)
    {
        var operation = new OperationResult();
        var slide = await _slideRepository.GetAsync(command.Id);

        if (slide is null)
        {
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

        var pictureName = _fileUploader.Upload(command.Picture, "slides");

        slide.Edit(pictureName, command.PictureAlt, command.PictureTitle, command.Link);
        await _slideRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> RemoveAsync(long id)
    {
        var operation = new OperationResult();
        var slide = await _slideRepository.GetAsync(id);

        if (slide is null)
        {
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

        slide.Remove();
        await _slideRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> RestoreAsync(long id)
    {
        var operation = new OperationResult();
        var slide = await _slideRepository.GetAsync(id);

        if (slide is null)
        {
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

        slide.Restore();
        await _slideRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<EditSlide?> GetDetailsAsync(long id)
    {
        return await _slideRepository.GetDetailsAsync(id);
    }

    public async Task<List<SlideViewModel>> GetListAsync()
    {
        return await _slideRepository.GetListAsync();
    }
}