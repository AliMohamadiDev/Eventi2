using _0_Framework.Application;

namespace Eventi.Application.Contract.ArticleCategory;

public interface IArticleCategoryApplication
{
    Task<OperationResult> CreateAsync(CreateArticleCategory command);
    Task<OperationResult> EditAsync(EditArticleCategory command);
    Task<EditArticleCategory?> GetDetailsAsync(long id);
    Task<List<ArticleCategoryViewModel>> GetArticleCategoriesAsync();
    Task<List<ArticleCategoryViewModel>> SearchAsync(ArticleCategorySearchModel searchModel);
}