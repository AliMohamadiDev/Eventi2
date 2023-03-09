using Eventi.Application.Contract.Presenter;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.Presenters
{
    public class IndexModel : PageModel
    {
        public PresenterSearchModel SearchModel;
        public List<PresenterViewModel> Presenters;

        private readonly IPresenterApplication _presenterApplication;

        public IndexModel(IPresenterApplication presenterApplication)
        {
            _presenterApplication = presenterApplication;
        }

        public async Task OnGet(PresenterSearchModel searchModel)
        {
            Presenters = await _presenterApplication.SearchAsync(searchModel);
        }
    }
}
