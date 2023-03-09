using Eventi.Application.Contract.EventInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.EventInfos
{
    public class IndexModel : PageModel
    {
        public EventInfoSearchModel SearchModel;
        public List<EventInfoViewModel> EventInfos;

        private readonly IEventInfoApplication _eventInfoApplication;

        public IndexModel(IEventInfoApplication eventInfoApplication)
        {
            _eventInfoApplication = eventInfoApplication;
        }

        public async Task OnGetAsync(EventInfoSearchModel searchModel)
        {
            EventInfos = await _eventInfoApplication.SearchAsync(searchModel);
        }
    }
}
