using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Account;
using Eventi.Application.Contract.Department;
using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.EventSubcategory;
using Eventi.Application.Contract.Presenter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.Events;

public class CreateModel : PageModel
{
    public CreateEvent Command;
    public SelectList Subcategories;
    public SelectList Presenters;
    public SelectList Departments;
    public SelectList EventAccounts;

    private readonly IEventApplication _eventApplication;
    private readonly IAccountApplication _accountApplication;
    private readonly IPresenterApplication _presenterApplication;
    private readonly IDepartmentApplication _departmentApplication;
    private readonly IEventSubcategoryApplication _eventSubcategoryApplication;

    public CreateModel(IEventApplication eventApplication, IEventSubcategoryApplication eventSubcategoryApplication, IDepartmentApplication departmentApplication, IPresenterApplication presenterApplication, IAccountApplication accountApplication)
    {
        _eventApplication = eventApplication;
        _presenterApplication = presenterApplication;
        _accountApplication = accountApplication;
        _departmentApplication = departmentApplication;
        _eventSubcategoryApplication = eventSubcategoryApplication;
    }

    public async Task OnGet()
    {
        var subcategories = await _eventSubcategoryApplication.GetEventSubcategoriesAsync();
        Subcategories= new SelectList(subcategories, "SubcategoryId", "SubcategoryName", "CategoryId");

        var departments = await _departmentApplication.GetDepartmentsAsync();
        Departments = new SelectList(departments, "Id", "Name");

        var presenters = await _presenterApplication.GetPresentersAsync();
        Presenters = new SelectList(presenters, "Id", "Name");

        var eventAccounts = await _accountApplication.GetPresenterAccountsAsync();
        EventAccounts = new SelectList(eventAccounts, "Id", "Fullname");
    }

    public async Task<IActionResult> OnPostAsync(CreateEvent command)
    {
        var result = await _eventApplication.CreateAsync(command);
        return RedirectToPage("./Index");
    }
}