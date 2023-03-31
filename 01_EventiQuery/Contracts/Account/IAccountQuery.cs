namespace _01_EventiQuery.Contracts.Account;

public interface IAccountQuery
{
    Task<AccountQueryModel?> GetAccountDetailsAsync(long id);
}