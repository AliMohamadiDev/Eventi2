using _0_Framework.Application;

namespace Eventi.Application.Contract.Presenter;

public interface IPresenterApplication
{
    Task<EditPresenter> GetDetailsAsync(long id);
    Task<List<PresenterViewModel>> GetPresentersAsync();
    Task<OperationResult> EditAsync(EditPresenter command);
    Task<OperationResult> CreateAsync(CreatePresenter command);
    Task<List<PresenterViewModel>> SearchAsync(PresenterSearchModel searchModel);
}