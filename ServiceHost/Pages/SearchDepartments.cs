using _01_EventiQuery.Contracts.Department;
using _01_EventiQuery.Contracts.Presenter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class SearchDepartmentsModel : PageModel
{
    public string Value;
    public List<DepartmentQueryModel> Departments;
    private readonly IDepartmentQuery _departmentQuery;

    public SearchDepartmentsModel(IDepartmentQuery departmentQuery)
    {
        _departmentQuery = departmentQuery;
    }


    public async Task OnGet(string value)
    {
        Value = value;
        Departments = await _departmentQuery.SearchAsync(value);
    }
}