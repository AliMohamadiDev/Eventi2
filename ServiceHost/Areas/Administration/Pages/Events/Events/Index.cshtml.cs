using Eventi.Infrastructure.Configuration.Permissions;
using Eventi.Application.Contract.EventSubcategory;
using Eventi.Application.Contract.Event;
using _0_Framework.Infrastructure;
using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administration.Pages.Events.Events
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public EventSearchModel SearchModel;
        public List<EventViewModel> Events;
        public SelectList Subcategories;
        private readonly IAuthHelper _authHelper;
        public string UserRole;

        private readonly IEventApplication _eventApplication;
        private readonly IEventSubcategoryApplication _eventSubcategoryApplication;

        public IndexModel(IEventApplication eventApplication, IEventSubcategoryApplication eventSubcategoryApplication, IAuthHelper authHelper)
        {
            _eventApplication = eventApplication;
            _eventSubcategoryApplication = eventSubcategoryApplication;
            _authHelper = authHelper;
        }

        public async Task OnGet(EventSearchModel searchModel)
        {
            var userRole = _authHelper.CurrentAccountRole();
            UserRole = userRole;
            var userId = _authHelper.CurrentAccountId();

            Events = await _eventApplication.SearchAsync(searchModel, userRole, userId);

            var subcategories = await _eventSubcategoryApplication.GetEventSubcategoriesAsync();
            Subcategories = new SelectList(subcategories, "SubcategoryId", "SubcategoryName");
        }

        //[NeedPermission(EventiPermissions.ConfirmEvent)]
        public async Task<IActionResult> OnGetCancelAsync(long id)
        {
            var result = await _eventApplication.CancelAsync(id);
            if (result.IsSucceeded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        //[NeedPermission(EventiPermissions.ConfirmEvent)]
        public async Task<IActionResult> OnGetConfirmAsync(long id)
        {
            var result = await _eventApplication.ConfirmAsync(id);
            if (result.IsSucceeded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
