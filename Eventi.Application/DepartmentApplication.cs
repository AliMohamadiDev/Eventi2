using _0_Framework.Application;
using Eventi.Application.Contract.Department;
using Eventi.Domain.EventAgg;

namespace Eventi.Application;

public class DepartmentApplication: IDepartmentApplication
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentApplication(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<EditDepartment?> GetDetailsAsync(long id)
    {
        return await _departmentRepository.GetDetailsAsync(id);
    }

    public async Task<List<DepartmentViewModel>> GetDepartmentsAsync()
    {
        return await _departmentRepository.GetAccountSidesAsync();
    }

    public async Task<OperationResult> EditAsync(EditDepartment command)
    {
        var operation = new OperationResult();
        var department = _departmentRepository.GetDepartment(command.Id);

        if (_departmentRepository.Exists(x => x.NationalCode == command.NationalCode && x.Id != command.Id))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        department.Edit(command.Name, command.NationalCode, command.PostalCode, command.Address);

        await _departmentRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> CreateAsync(CreateDepartment command)
    {
        var operation = new OperationResult();
        if (_departmentRepository.Exists(x => x.NationalCode == command.NationalCode))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        var department = new Department(command.Name, command.NationalCode, command.PostalCode, command.Address);

        await _departmentRepository.CreateAsync(department);
        await _departmentRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<List<DepartmentViewModel>> SearchAsync(DepartmentSearchModel searchModel)
    {
        return await _departmentRepository.SearchAsync(searchModel);
    }
}