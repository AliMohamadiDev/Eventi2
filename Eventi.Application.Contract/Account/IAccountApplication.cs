using _0_Framework.Application;

namespace Eventi.Application.Contract.Account;

public interface IAccountApplication
{
    void Logout();
    Task<EditAccount?> GetDetailsAsync(long id);
    Task<List<AccountViewModel>> GetAccountsAsync();
    Task<OperationResult> LoginAsync(Login command);
    Task<OperationResult> EditAsync(EditAccount command);
    Task<OperationResult> RegisterAsync(RegisterAccount command);
    Task<OperationResult> ChangePasswordAsync(ChangePassword command);
    Task<List<AccountViewModel>> SearchAsync(AccountSearchModel searchModel);
    void Deactivate(long id);
    void Activate(long id);
}