using _0_Framework.Domain;
using Eventi.Application.Contract.ArticleCategory;

namespace Eventi.Domain.ArticleCategoryAgg;

public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
{
    string GetSlugBy(long id);
    Task<EditArticleCategory?> GetDetailsAsync(long id);
    Task<List<ArticleCategoryViewModel>> GetArticleCategoriesAsync();
    Task<List<ArticleCategoryViewModel>> SearchAsync(ArticleCategorySearchModel searchModel);
}