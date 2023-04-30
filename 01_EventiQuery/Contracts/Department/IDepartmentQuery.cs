namespace _01_EventiQuery.Contracts.Department;

public interface IDepartmentQuery
{
    Task<DepartmentQueryModel> GetDepartmentAsync(long id);
    Task<List<DepartmentQueryModel>> GetDepartmentsAsync(int number = 1000);
    Task<List<DepartmentQueryModel>> SearchAsync(string value);
}