using Eventi.Application.Contract.Account;
using Eventi.Application.Contract.Department;
using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.EventSubcategory;
using Eventi.Application.Contract.Presenter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.Events;

public class EditModel : PageModel
{
    public EditEvent Command;
    public SelectList Subcategories;
    public SelectList Departments;
    public List<SelectListItem> EventAccounts;
    public List<SelectListItem> Presenters;

    private readonly IEventApplication _eventApplication;
    private readonly IAccountApplication _accountApplication;
    private readonly IPresenterApplication _presenterApplication;
    private readonly IDepartmentApplication _departmentApplication;
    private readonly IEventSubcategoryApplication _eventSubcategoryApplication;

    public EditModel(IEventApplication eventApplication, IEventSubcategoryApplication eventSubcategoryApplication, IDepartmentApplication departmentApplication, IPresenterApplication presenterApplication, IAccountApplication accountApplication)
    {
        _eventSubcategoryApplication = eventSubcategoryApplication;
        _departmentApplication = departmentApplication;
        _presenterApplication = presenterApplication;
        _accountApplication = accountApplication;
        _eventApplication = eventApplication;
    }

    public async Task OnGet(long id)
    {
        Command = (await _eventApplication.GetDetailsAsync(id))!;
        
        var subcategories = await _eventSubcategoryApplication.GetEventSubcategoriesAsync();
        Subcategories = new SelectList(subcategories, "SubcategoryId", "SubcategoryName", "CategoryId");
        
        var departments = await _departmentApplication.GetDepartmentsAsync();
        Departments = new SelectList(departments, "Id", "Name");

        var presenters = await _presenterApplication.GetPresentersAsync();
        Presenters = new List<SelectListItem>();
        foreach (var item in presenters)
        {
            bool selected = Command.PresenterIdList.Contains(item.Id);
            Presenters.Add(new SelectListItem(item.Name, item.Id.ToString(), selected: selected));
        }

        var eventAccounts = await _accountApplication.GetPresenterAccountsAsync();
        EventAccounts = new List<SelectListItem>();
        foreach (var item in eventAccounts)
        {
            bool selected = Command.AccountIdList.Contains(item.Id);
            EventAccounts.Add(new SelectListItem(item.Fullname, item.Id.ToString(), selected: selected));
        }
    }

    public async Task<IActionResult> OnPostAsync(EditEvent command)
    {
        var result = await _eventApplication.EditAsync(command);
        return RedirectToPage("./Index");
    }
}