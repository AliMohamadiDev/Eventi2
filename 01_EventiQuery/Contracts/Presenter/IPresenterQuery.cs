namespace _01_EventiQuery.Contracts.Presenter;

public interface IPresenterQuery
{
    Task<PresenterQueryModel> GetPresenterAsync(string slug);
    Task<List<PresenterQueryModel>> GetPresentersAsync();
    Task<List<PresenterQueryModel>> SearchAsync(string value);
}