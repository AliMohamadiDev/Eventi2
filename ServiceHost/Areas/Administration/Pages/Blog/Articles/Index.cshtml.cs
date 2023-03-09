using Eventi.Application.Contract.Article;
using Eventi.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles;

public class IndexModel : PageModel
{
    public ArticleSearchModel SearchModel;
    public List<ArticleViewModel> Articles;
    public SelectList ArticleCategories;

    private readonly IArticleApplication _articleApplication;
    private readonly IArticleCategoryApplication _articleCategoryApplication;

    public IndexModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
    {
        _articleApplication = articleApplication;
        _articleCategoryApplication = articleCategoryApplication;
    }

    public async Task OnGetAsync(ArticleSearchModel searchModel)
    {
        Articles = await _articleApplication.SearchAsync(searchModel);
        var articleCategories = await _articleCategoryApplication.GetArticleCategoriesAsync();
        ArticleCategories = new SelectList(articleCategories, "Id", "Name");
    }
}