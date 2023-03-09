using Eventi.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategories;

public class EditModel : PageModel
{
    public EditArticleCategory Command;

    private readonly IArticleCategoryApplication _articleCategoryApplication;

    public EditModel(IArticleCategoryApplication articleCategoryApplication)
    {
        _articleCategoryApplication = articleCategoryApplication;
    }

    public async Task OnGetAsync(long id)
    {
        Command = await _articleCategoryApplication.GetDetailsAsync(id);
    }

    public async Task<IActionResult> OnPostAsync(EditArticleCategory command)
    {
        var result = await _articleCategoryApplication.EditAsync(command);
        return RedirectToPage("./Index");
    }
}