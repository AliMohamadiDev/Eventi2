using Eventi.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategories;

public class IndexModel : PageModel
{
    public ArticleCategorySearchModel SearchModel;
    public List<ArticleCategoryViewModel> ArticleCategories;

    private readonly IArticleCategoryApplication _articleCategoryApplication;

    public IndexModel(IArticleCategoryApplication articleCategoryApplication)
    {
        _articleCategoryApplication = articleCategoryApplication;
    }

    public async Task OnGetAsync(ArticleCategorySearchModel searchModel)
    {
        ArticleCategories = await _articleCategoryApplication.SearchAsync(searchModel);
    }
}