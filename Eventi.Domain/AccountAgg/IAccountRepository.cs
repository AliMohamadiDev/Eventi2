using _0_Framework.Domain;
using Eventi.Application.Contract.Account;

namespace Eventi.Domain.AccountAgg;

public interface IAccountRepository : IRepository<long, Account>
{
    Task<Account?> GetByAsync(string username);
    Task<EditAccount?> GetDetailsAsync(long id);
    Task<List<AccountViewModel>> GetAccountsAsync();
    Task<List<AccountViewModel>> SearchAsync(AccountSearchModel searchModel);
    Task<Account> GetByIdAsync(long id);
    void UpdateAccount(Account account);
    void ClearDepartmentsOfAccount(long id);
    void Deactivate(long id);
    void Activate(long id);
}