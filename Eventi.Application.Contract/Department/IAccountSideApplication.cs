using _0_Framework.Application;

namespace Eventi.Application.Contract.Department;

public interface IAccountSideApplication
{
    Task<EditDepartment?> GetDetailsAsync(long id);
    Task<List<DepartmentViewModel>> GetAccountSidesAsync();
    Task<OperationResult> EditAsync(EditDepartment command);
    Task<OperationResult> CreateAsync(CreateDepartment command);
    Task<List<DepartmentViewModel>> SearchAsync(DepartmentSearchModel searchModel);
}