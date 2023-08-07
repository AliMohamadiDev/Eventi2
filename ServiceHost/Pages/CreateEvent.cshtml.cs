using Eventi.Application.Contract.Department;
using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.EventCategory;
using Eventi.Application.Contract.EventSubcategory;
using Eventi.Application.Contract.Presenter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Pages;

public class CreateEventModel : PageModel
{
    public CreateEvent Command;
    public SelectList Categories;
    public SelectList Subcategories;
    public SelectList Presenters;
    public SelectList Departments;

    private readonly IEventApplication _eventApplication;
    private readonly IPresenterApplication _presenterApplication;
    private readonly IDepartmentApplication _departmentApplication;
    private readonly IEventCategoryApplication _eventCategoryApplication;
    private readonly IEventSubcategoryApplication _eventSubcategoryApplication;

    public CreateEventModel(IEventApplication eventApplication, IDepartmentApplication departmentApplication, IEventCategoryApplication eventCategoryApplication, IEventSubcategoryApplication eventSubcategoryApplication, IPresenterApplication presenterApplication)
    {
        _eventApplication = eventApplication;
        _presenterApplication = presenterApplication;
        _departmentApplication = departmentApplication;
        _eventCategoryApplication = eventCategoryApplication;
        _eventSubcategoryApplication = eventSubcategoryApplication;
    }

    public async Task OnGetAsync()
    {
        var categories = await _eventCategoryApplication.GetEventCategoriesAsync();
        Categories = new SelectList(categories, "CategoryId", "CategoryName");

        var subcategories = await _eventSubcategoryApplication.GetEventSubcategoriesAsync();
        Subcategories = new SelectList(subcategories, "SubcategoryId", "SubcategoryName", "CategoryId");

        var presenters = await _presenterApplication.GetPresentersAsync();
        Presenters = new SelectList(presenters, "Id", "Name");

        var departments = await _departmentApplication.GetDepartmentsAsync();
        Departments = new SelectList(departments, "Id", "Name");
    }

    public async Task<IActionResult> OnPostAsync(CreateEvent command)
    {
        var result = await _eventApplication.CreateAsync(command);
        return RedirectToPage("/Profile");
    }
}