using _0_Framework.Domain;
using Eventi.Application.Contract.Role;

namespace Eventi.Domain.RoleAgg;

public interface IRoleRepository : IRepository<long, Role>
{
    Task<List<RoleViewModel>> ListAsync();
    Task<EditRole> GetDetailsAsync(long id);
    Role? GetById(long id);
}