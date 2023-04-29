using _01_EventiQuery.Contracts.Article;
using _01_EventiQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleCategoriesModel : PageModel
    {
        public List<ArticleQueryModel> LatestArticles;
        public List<ArticleCategoryQueryModel> ArticleCategories;

        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public ArticleCategoriesModel(IArticleCategoryQuery articleCategoryQuery, IArticleQuery articleQuery)
        {
            _articleCategoryQuery = articleCategoryQuery;
            _articleQuery = articleQuery;
        }

        public async Task OnGet()
        {
            LatestArticles = await _articleQuery.LatestArticlesAsync();
            ArticleCategories = await _articleCategoryQuery.GetArticleCategoriesAsync();
        }
    }
}
