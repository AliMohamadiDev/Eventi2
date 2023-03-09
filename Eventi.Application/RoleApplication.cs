using _0_Framework.Application;
using Eventi.Application.Contract.Role;
using Eventi.Domain.RoleAgg;

namespace Eventi.Application;

public class RoleApplication : IRoleApplication
{
    private readonly IRoleRepository _roleRepository;

    public RoleApplication(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<OperationResult> CreateAsync(CreateRole command)
    {
        var operation = new OperationResult();
        if (_roleRepository.Exists(x => x.Name == command.Name))
            return operation.Failed(ApplicationMessages.DuplicatedRecord);

        var permissions = new List<Permission>();
        command.Permissions.ForEach(code => permissions.Add(new Permission(code)));

        var role = new Role(command.Name, permissions);
        await _roleRepository.CreateAsync(role);
        await _roleRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> EditAsync(EditRole command)
    {
        var operation = new OperationResult();

        var role =  await _roleRepository.GetAsync(command.Id);
        if (role == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        if (_roleRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            return operation.Failed(ApplicationMessages.DuplicatedRecord);

        var permissions = new List<Permission>();
        command.Permissions.ForEach(code => permissions.Add(new Permission(code)));

        role.Edit(command.Name, permissions);
        await _roleRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<List<RoleViewModel>> ListAsync()
    {
        return await _roleRepository.ListAsync();
    }

    public async Task<EditRole> GetDetailsAsync(long id)
    {
        return await _roleRepository.GetDetailsAsync(id);
    }
}