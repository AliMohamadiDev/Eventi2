namespace _01_EventiQuery.Contracts.ArticleCategory;

public interface IArticleCategoryQuery
{
    Task<ArticleCategoryQueryModel> GetArticleCategoryAsync(string slug);
    Task<List<ArticleCategoryQueryModel>> GetArticleCategoriesAsync();
}