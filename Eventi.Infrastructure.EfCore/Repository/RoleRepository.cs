using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Role;
using Eventi.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class RoleRepository : RepositoryBase<long, Role>, IRoleRepository
{
    private readonly EventiContext _accountContext;

    public RoleRepository(EventiContext accountContext) : base(accountContext)
    {
        _accountContext = accountContext;
    }

    public async Task<List<RoleViewModel>> ListAsync()
    {
        return await _accountContext.Roles.Select(x => new RoleViewModel
        {
            Id = x.Id,
            Name = x.Name,
            CreationDate = x.CreationDate.ToFarsi()
        }).ToListAsync();
    }

    public async Task<EditRole> GetDetailsAsync(long id)
    {
        var role = await _accountContext.Roles.Select(x => new EditRole
            {
                Id = x.Id,
                Name = x.Name,
                MappedPermissions = MapPermissions(x.Permissions)
            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        role!.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();

        return role;
    }

    public Role? GetById(long id)
    {
        return _accountContext.Find<Role>(id);
    }

    private static List<PermissionDto> MapPermissions(List<Permission> permissions)
    {
        return permissions.Select(x => new PermissionDto(x.Code, x.Name)).ToList();
    }
}