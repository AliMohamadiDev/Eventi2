using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Account;
using Eventi.Application.Contract.Role;
using Eventi.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.Configuration;

public class SeedData
{
    private readonly IRoleApplication _roleApplication;
    private readonly IAccountApplication _accountApplication;

    private readonly EventiContext _context;

    public SeedData(IRoleApplication roleApplication, IAccountApplication accountApplication, EventiContext context)
    {
        _roleApplication = roleApplication;
        _accountApplication = accountApplication;
        _context = context;
    }

    public async void SeedDatabase()
    {
        await _context.Database.MigrateAsync();

        if (!_context.Accounts.Any() && !_context.Roles.Any())
        {
            await _roleApplication.CreateAsync(new CreateRole()
                {Name = "ادمین سایت", Permissions = new List<int>(), MappedPermissions = new List<PermissionDto>()});
            await _roleApplication.CreateAsync(new CreateRole()
                {Name = "کاربر سایت", Permissions = new List<int>(), MappedPermissions = new List<PermissionDto>()});
            await _roleApplication.CreateAsync(new CreateRole()
                {Name = "مدیر وبلاگ", Permissions = new List<int>(), MappedPermissions = new List<PermissionDto>()});
            await _roleApplication.CreateAsync(new CreateRole()
                {Name = "برگزارکننده", Permissions = new List<int>(), MappedPermissions = new List<PermissionDto>()});

            const string sql = "INSERT INTO [dbo].[RolePermissions] ([Code] ,[RoleId]) VALUES " +
                               "(0,2), " +
                               "(10,1), " +
                               "(11,1), " +
                               "(12,1), " +
                               "(20,1), " +
                               "(21,1), " +
                               "(22,1), " +
                               "(30,1), " +
                               "(31,1), " +
                               "(32,1), " +
                               "(40,1), " +
                               "(41,1), " +
                               "(42,1), " +
                               "(50,1), " +
                               "(51,1), " +
                               "(52,1), " +
                               "(60,1), " +
                               "(61,1), " +
                               "(62,1), " +
                               "(30,3), " +
                               "(31,3), " +
                               "(32,3), " +
                               "(40,3), " +
                               "(41,3), " +
                               "(42,3), " +
                               "(10,4), " +
                               "(11,4), " +
                               "(12,4)";

            await _context.Database.ExecuteSqlRawAsync(sql);

            var acc = new RegisterAccount()
            {
                Fullname = "ali",
                Gender = true,
                IsDeactived = false,
                Password = "1234",
                Mobile = "09123456789",
                Email = "test@example.com",
                NationalCode = "1234567890",
                RoleId = 1
            };
            await _accountApplication.RegisterAsync(acc);
        }
    }
}