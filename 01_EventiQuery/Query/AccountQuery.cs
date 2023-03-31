using _01_EventiQuery.Contracts.Account;
using Eventi.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_EventiQuery.Query;

public class AccountQuery : IAccountQuery
{
    private readonly EventiContext _context;

    public AccountQuery(EventiContext context)
    {
        _context = context;
    }

    public async Task<AccountQueryModel?> GetAccountDetailsAsync(long id)
    {
        var account = await _context.Accounts
            .Include(x => x.AccountTickets)
            .Select(x => new AccountQueryModel
            {
                Id = x.Id,
                ProfilePhoto = x.ProfilePhoto,
                Fullname = x.Fullname,
                Email = x.Email,
                Birthday = x.Birthday,
                State = x.State,
                City = x.City,
                Mobile = x.Mobile,
                Role = x.Role,
                RoleId = x.RoleId,
                CreationDate = x.CreationDate,
                IsDeactived = x.IsDeactived
            }).FirstOrDefaultAsync(x => x.Id == id);

        return account;
    }
}