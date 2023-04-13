using _0_Framework.Domain;
using Eventi.Application.Contract.Department;

namespace Eventi.Domain.EventAgg;

public interface IDepartmentRepository : IRepository<long, Department>
{
    Department GetDepartment(long id);
    Task<EditDepartment?> GetDetailsAsync(long id);
    Task<List<DepartmentViewModel>> GetAccountSidesAsync();
    Task<List<DepartmentViewModel>> SearchAsync(DepartmentSearchModel searchModel);
}