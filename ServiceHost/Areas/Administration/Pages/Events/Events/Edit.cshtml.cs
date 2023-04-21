using Eventi.Application.Contract.Department;
using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.EventCategory;
using Eventi.Application.Contract.EventSubcategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.Events
{
    public class EditModel : PageModel
    {
        public EditEvent Command;
        public SelectList Categories;
        public SelectList Subcategories;
        public SelectList Departments;

        private readonly IEventApplication _eventApplication;
        private readonly IDepartmentApplication _departmentApplication;
        private readonly IEventCategoryApplication _eventCategoryApplication;
        private readonly IEventSubcategoryApplication _eventSubcategoryApplication;

        public EditModel(IEventApplication eventApplication, IEventCategoryApplication eventCategoryApplication, IEventSubcategoryApplication eventSubcategoryApplication, IDepartmentApplication departmentApplication)
        {
            _eventApplication = eventApplication;
            _eventCategoryApplication = eventCategoryApplication;
            _eventSubcategoryApplication = eventSubcategoryApplication;
            _departmentApplication = departmentApplication;
        }

        public async Task OnGet(long id)
        {
            Command = (await _eventApplication.GetDetailsAsync(id))!;
            var categories = await _eventCategoryApplication.GetEventCategoriesAsync();
            Categories = new SelectList(categories, "CategoryId", "CategoryName");

            var subcategories = await _eventSubcategoryApplication.GetEventSubcategoriesAsync();
            Subcategories = new SelectList(subcategories, "SubcategoryId", "SubcategoryName", "CategoryId");
        
            var departments = await _departmentApplication.GetDepartmentsAsync();
            Departments = new SelectList(departments, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync(EditEvent command)
        {
            var result = await _eventApplication.EditAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
