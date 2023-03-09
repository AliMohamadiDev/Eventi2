namespace _01_EventiQuery.Contracts.Article;

public interface IArticleQuery
{
    Task<List<ArticleQueryModel>> LatestArticlesAsync();
    Task<ArticleQueryModel> GetArticleDetailsAsync(string slug);
}