using _0_Framework.Application;

namespace Eventi.Application.Contract.Article;

public interface IArticleApplication
{
    Task<OperationResult> CreateAsync(CreateArticle command);
    Task<OperationResult> EditAsync(EditArticle command);
    Task<EditArticle?> GetDetailsAsync(long id);
    Task<List<ArticleViewModel>> SearchAsync(ArticleSearchModel searchModel);
    void Remove(long id);
    void Restore(long id);
}