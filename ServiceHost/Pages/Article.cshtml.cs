using _01_EventiQuery.Contracts.Article;
using _01_EventiQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class ArticleModel : PageModel
{
    public ArticleQueryModel Article;
    public List<ArticleQueryModel> LatestArticles;
    public List<ArticleCategoryQueryModel> ArticleCategories;

    private readonly IArticleQuery _articleQuery;
    private readonly IArticleCategoryQuery _articleCategoryQuery;

    public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery)
    {
        _articleQuery = articleQuery;
        _articleCategoryQuery = articleCategoryQuery;
    }

    public async Task OnGetAsync(string id)
    {
        Article = await _articleQuery.GetArticleDetailsAsync(id);
        LatestArticles = await _articleQuery.LatestArticlesAsync();
        ArticleCategories = await _articleCategoryQuery.GetArticleCategoriesAsync();
    }
}