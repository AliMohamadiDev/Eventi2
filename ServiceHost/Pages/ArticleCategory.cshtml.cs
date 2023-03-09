using _01_EventiQuery.Contracts.Article;
using _01_EventiQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class ArticleCategoryModel : PageModel
{
    public ArticleCategoryQueryModel ArticleCategory;
    public List<ArticleCategoryQueryModel> ArticleCategories;
    public List<ArticleQueryModel> LatestArticles;

    private readonly IArticleQuery _articleQuery;
    private readonly IArticleCategoryQuery _articleCategoryQuery;

    public ArticleCategoryModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery)
    {
        _articleQuery = articleQuery;
        _articleCategoryQuery = articleCategoryQuery;
    }

    public async Task OnGetAsync(string id)
    {
        LatestArticles = await _articleQuery.LatestArticlesAsync();
        ArticleCategory = await _articleCategoryQuery.GetArticleCategoryAsync(id);
        ArticleCategories = await _articleCategoryQuery.GetArticleCategoriesAsync();
    }
}