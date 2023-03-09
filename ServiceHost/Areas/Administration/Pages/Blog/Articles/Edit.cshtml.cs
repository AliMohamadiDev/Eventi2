using Eventi.Application.Contract.Article;
using Eventi.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles;

public class EditModel : PageModel
{
    public EditArticle Command;
    public SelectList ArticleCategories;

    private readonly IArticleApplication _articleApplication;
    private readonly IArticleCategoryApplication _articleCategoryApplication;

    public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
    {
        _articleApplication = articleApplication;
        _articleCategoryApplication = articleCategoryApplication;
    }

    public async Task OnGet(long id)
    {
        Command = (await _articleApplication.GetDetailsAsync(id))!;

        var articleCategories = await _articleCategoryApplication.GetArticleCategoriesAsync();
        ArticleCategories = new SelectList(articleCategories, "Id", "Name");
    }

    public async Task<IActionResult> OnPostAsync(EditArticle command)
    {
        var result = await _articleApplication.EditAsync(command);
        return RedirectToPage("./Index");
    }
}