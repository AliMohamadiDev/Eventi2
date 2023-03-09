using _0_Framework.Domain;
using Eventi.Application.Contract.Presenter;

namespace Eventi.Domain.EventAgg;

public interface IPresenterRepository : IRepository<long, Presenter>
{
    Presenter GetPresenter(long id);
    Task<EditPresenter?> GetDetailsAsync(long id);
    Task<List<PresenterViewModel>> GetPresentersAsync();
    Task<List<PresenterViewModel>> SearchAsync(PresenterSearchModel searchModel);
}