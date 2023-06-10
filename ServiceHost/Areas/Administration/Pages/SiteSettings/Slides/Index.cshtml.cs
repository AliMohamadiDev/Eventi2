using Eventi.Application.Contract.Slide;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.SiteSettings.Slides;

public class IndexModel : PageModel
{
    [TempData] public string Message { get; set; }

    public List<SlideViewModel> Slides;
    public EditSlide EditCommand;
    public CreateSlide CreateCommand;

    private readonly ISlideApplication _slideApplication;

    public IndexModel(ISlideApplication slideApplication)
    {
        _slideApplication = slideApplication;
    }

    public async Task OnGetAsync()
    {
        Slides = await _slideApplication.GetListAsync();
    }

    public IActionResult OnGetCreate()
    {
        var command = new CreateSlide();
        return Partial("./Create", command);
    }

    public async Task<IActionResult> OnPostCreateAsync(CreateSlide createCommand)
    {
        var result = await _slideApplication.CreateAsync(createCommand);
        return RedirectToPage("./Index");
    }

    public async Task<IActionResult> OnGetEditAsync(long id)
    {
        var slide = await _slideApplication.GetDetailsAsync(id);
        EditCommand = slide;
        return Partial("Edit", slide);
    }

    public async Task<IActionResult> OnPostEditAsync(EditSlide editCommand)
    {
        var result = await _slideApplication.EditAsync(editCommand);
        return RedirectToPage("./Index");
    }

    public async Task<IActionResult> OnGetRemoveAsync(long id)
    {
        var result = await _slideApplication.RemoveAsync(id);
        if (result.IsSucceeded)
        {
            return RedirectToPage("./Index");
        }

        Message = result.Message;
        return RedirectToPage("./Index");
    }
    
    public async Task<IActionResult> OnGetRestoreAsync(long id)
    {
        var result = await _slideApplication.RestoreAsync(id);
        if (result.IsSucceeded)
        {
            return RedirectToPage("./Index");
        }

        Message = result.Message;
        return RedirectToPage("./Index");
    }

}