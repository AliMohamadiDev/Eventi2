using _01_EventiQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleCategoriesModel : PageModel
    {
        public List<ArticleCategoryQueryModel> ArticleCategories;

        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public ArticleCategoriesModel(IArticleCategoryQuery articleCategoryQuery)
        {
            _articleCategoryQuery = articleCategoryQuery;
        }

        public async Task OnGet()
        {
            ArticleCategories = await _articleCategoryQuery.GetArticleCategoriesAsync();
        }
    }
}
