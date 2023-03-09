using Eventi.Application.Contract.Presenter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.Presenters
{
    public class EditModel : PageModel
    {
        public EditPresenter Command;

        private readonly IPresenterApplication _presenterApplication;

        public EditModel(IPresenterApplication presenterApplication)
        {
            _presenterApplication = presenterApplication;
        }

        public async Task OnGetAsync(long id)
        {
            Command = await _presenterApplication.GetDetailsAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(EditPresenter command)
        {
            var result = await _presenterApplication.EditAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
