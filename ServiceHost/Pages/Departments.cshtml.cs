using _01_EventiQuery.Contracts.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class DepartmentsModel : PageModel
{
    public List<DepartmentQueryModel> Departments;

    private readonly IDepartmentQuery _departmentQuery;

    public DepartmentsModel(IDepartmentQuery departmentQuery)
    {
        _departmentQuery = departmentQuery;
    }

    public async Task OnGet()
    {
        Departments = await _departmentQuery.GetDepartmentsAsync();
    }
}