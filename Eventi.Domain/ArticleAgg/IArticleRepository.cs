using _0_Framework.Domain;
using Eventi.Application.Contract.Article;

namespace Eventi.Domain.ArticleAgg;

public interface IArticleRepository : IRepository<long, Article>
{
    Task<EditArticle?> GetDetailsAsync(long id);
    Task<Article?> GetWithCategoryAsync(long id);
    Task<List<ArticleViewModel>> SearchAsync(ArticleSearchModel searchModel);
}