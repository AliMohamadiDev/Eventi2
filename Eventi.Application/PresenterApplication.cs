using _0_Framework.Application;
using Eventi.Application.Contract.Presenter;
using Eventi.Domain.EventAgg;

namespace Eventi.Application;

public class PresenterApplication : IPresenterApplication
{
    private readonly IPresenterRepository _presenterRepository;
    private readonly IFileUploader _fileUploader;

    public PresenterApplication(IPresenterRepository presenterRepository, IFileUploader fileUploader)
    {
        _presenterRepository = presenterRepository;
        _fileUploader = fileUploader;
    }

    public async Task<EditPresenter> GetDetailsAsync(long id)
    {
        return await _presenterRepository.GetDetailsAsync(id);
    }

    public async Task<List<PresenterViewModel>> GetPresentersAsync()
    {
        return await _presenterRepository.GetPresentersAsync();
    }

    public async Task<OperationResult> EditAsync(EditPresenter command)
    {
        var operation = new OperationResult();
        var presenter = _presenterRepository.GetPresenter(command.Id);

        if (_presenterRepository.Exists(x => x.Number == command.Number && x.Id != command.Id))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        var logoTitle = $"لوگوی {command.Name}";
        var logoAlt = $"لوگوی {command.Name}";
        var slug = $"{command.Name} {command.Number}".Slugify();

        var path = $"Presenters/{command.Name}";
        var logo = _fileUploader.Upload(command.Logo, path);

        presenter.Edit(command.Name, logo, logoTitle, logoAlt, command.Website,
            command.Number, command.Policy, command.Description, slug);

        await _presenterRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> CreateAsync(CreatePresenter command)
    {
        var operation = new OperationResult();

        if (_presenterRepository.Exists(x => x.Number == command.Number))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        var logoTitle = $"لوگوی {command.Name}";
        var logoAlt = $"لوگوی {command.Name}";
        var slug = $"{command.Name} {command.Number}".Slugify();

        var path = $"Presenters/{command.Name}";
        var logo = _fileUploader.Upload(command.Logo, path);

        var presenter = new Presenter(command.Name, logo, logoTitle, logoAlt, command.Website,
            command.Number, command.Policy, command.Description, slug);

        await _presenterRepository.CreateAsync(presenter);
        await _presenterRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<List<PresenterViewModel>> SearchAsync(PresenterSearchModel searchModel)
    {
        return await _presenterRepository.SearchAsync(searchModel);
    }
}