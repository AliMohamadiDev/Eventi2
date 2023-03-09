using _0_Framework.Application;

namespace Eventi.Application.Contract.Role;

public interface IRoleApplication
{
    Task<OperationResult> CreateAsync(CreateRole command);
    Task<OperationResult> EditAsync(EditRole command);
    Task<List<RoleViewModel>> ListAsync();
    Task<EditRole> GetDetailsAsync(long id);
}