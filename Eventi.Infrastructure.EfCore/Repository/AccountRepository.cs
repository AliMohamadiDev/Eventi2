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
            //ProfilePhoto = x.ProfilePhoto,
            Fullname = x.Fullname,
            Email = x.Email,
            Birthday = x.Birthday.ToFarsi(),
            State = x.State,
            City = x.City,
            Mobile = x.Mobile,
            //Role = x.Role,
            RoleId = x.RoleId,
            //CreationDate = x.CreationDate,
            IsDeactived = x.IsDeactived,
            FatherName = x.FatherName,
            EducationalCenter = x.EducationalCenter,
            NationalCode = x.NationalCode,
            PostalCode = x.PostalCode,
            Address = x.Address,
            Gender = x.Gender,
            ScientificField = x.ScientificField,
            SeminaryDegree = x.SeminaryDegree,
            UniversityDegree = x.UniversityDegree,
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

    public async Task<List<AccountViewModel>> GetPresenterAccountsAsync()
    {
        return await _context.Accounts
            .Where(x => x.RoleId == 1 || x.RoleId == 4)
            .Select(x => new AccountViewModel
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

    public async Task<Account> GetByIdAsync(long id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public void ClearDepartmentsOfAccount(long id)
    {
        var deps = _context.Accounts.Include(x => x.DepartmentAccounts).Where(x => x.Id == id).ToList();
        deps.Clear();
        _context.SaveChanges();
    }

    public void UpdateAccount(Account account)
    {
        _context.Accounts.Update(account);
        _context.SaveChanges();
    }

    public void Deactivate(long id)
    {
        _context.Accounts.Find(id).Deactivate();
    }

    public void Activate(long id)
    {
        _context.Accounts.Find(id).Activate();
    }

    public  async Task<Account?> GetByEmailAsync(string email)
    {
        return await _context.Accounts.FirstOrDefaultAsync(x => x.Email == email);
    }

    public  async Task<Account?> GetByMobileAsync(string mobile)
    {
        return await _context.Accounts.FirstOrDefaultAsync(x => x.Mobile == mobile);
    }
}