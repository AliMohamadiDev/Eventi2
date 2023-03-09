using Eventi.Application.Contract.Article;
using Eventi.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles;

public class CreateModel : PageModel
{
    public CreateArticle Command;
    public SelectList ArticleCategories;

    private readonly IArticleApplication _articleApplication;
    private readonly IArticleCategoryApplication _articleCategoryApplication;

    public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
    {
        _articleApplication = articleApplication;
        _articleCategoryApplication = articleCategoryApplication;
    }

    public async Task OnGetAsync()
    {
        var articleCategories = await _articleCategoryApplication.GetArticleCategoriesAsync();
        ArticleCategories = new SelectList(articleCategories, "Id", "Name");
    }

    public async Task<IActionResult> OnPostAsync(CreateArticle command)
    {
        var result = await _articleApplication.CreateAsync(command);
        return RedirectToPage("./Index");
    }
}