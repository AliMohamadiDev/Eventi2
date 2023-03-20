using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Account;
using Eventi.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
{
    private readonly EventiContext _context;

    public AccountRepository(EventiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<EditAccount?> GetDetailsAsync(long id)
    {
        return await _context.Accounts.Select(x => new EditAccount
        {
            Id = x.Id,
            Fullname = x.Fullname,
            Mobile = x.Mobile,
            RoleId = x.RoleId,
            Email = x.Email
        }).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<AccountViewModel>> GetAccountsAsync()
    {
        return await _context.Accounts.Select(x => new AccountViewModel
        {
            Id = x.Id,
            Fullname = x.Fullname,
        }).ToListAsync();
    }

    public async Task<List<AccountViewModel>> SearchAsync(AccountSearchModel searchModel)
    {
        var query = _context.Accounts
            .Include(x=>x.Role)
            .Select(x => new AccountViewModel
        {
            Id = x.Id,
            Fullname = x.Fullname,
            Mobile = x.Mobile,
            ProfilePhoto = x.ProfilePhoto,
            Role = x.Role.Name,
            RoleId = x.RoleId,
            Email = x.Email,
            CreationDate = x.CreationDate.ToFarsi()
        });

        if (!string.IsNullOrWhiteSpace(searchModel.Fullname))
        {
            query = query.Where(x =>
                x.Fullname.Contains(searchModel.Fullname));
        }

        if (!string.IsNullOrWhiteSpace(searchModel.Email))
        {
            query = query.Where(x => x.Email!.Contains(searchModel.Email));
        }

        if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
        {
            query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));
        }

        if (searchModel.RoleId > 0)
        {
            query = query.Where(x => x.RoleId == searchModel.RoleId);
        }

        return await query.OrderByDescending(x => x.Id).ToListAsync();
    }

    public  async Task<Account?> GetByAsync(string email)
    {
        return await _context.Accounts.FirstOrDefaultAsync(x => x.Email == email);
    }
}