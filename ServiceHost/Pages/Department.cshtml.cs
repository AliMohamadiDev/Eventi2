using _01_EventiQuery.Contracts.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class DepartmentModel : PageModel
{
    public DepartmentQueryModel Department;

    private readonly IDepartmentQuery _departmentQuery;

    public DepartmentModel(IDepartmentQuery departmentQuery)
    {
        _departmentQuery = departmentQuery;
    }

    public async Task OnGet(long id)
    {
        Department = await _departmentQuery.GetDepartmentAsync(id);
    }
}