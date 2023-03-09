using Eventi.Application.Contract.Presenter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.Presenters
{
    public class CreateModel : PageModel
    {
        public CreatePresenter Command;

        private readonly IPresenterApplication _presenterApplication;

        public CreateModel(IPresenterApplication presenterApplication)
        {
            _presenterApplication = presenterApplication;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(CreatePresenter command)
        {
            var result = await _presenterApplication.CreateAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
