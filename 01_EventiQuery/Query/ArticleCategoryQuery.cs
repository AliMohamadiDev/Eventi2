using _0_Framework.Application;
using _01_EventiQuery.Contracts.Article;
using _01_EventiQuery.Contracts.ArticleCategory;
using Eventi.Domain.ArticleAgg;
using Eventi.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_EventiQuery.Query;

public class ArticleCategoryQuery : IArticleCategoryQuery
{
    private readonly EventiContext _blogContext;

    public ArticleCategoryQuery(EventiContext blogContext)
    {
        _blogContext = blogContext;
    }

    public async Task<ArticleCategoryQueryModel> GetArticleCategoryAsync(string slug)
    {
        var articleCategory = await _blogContext.ArticleCategories
            .Include(x => x.Articles)
            .Select(x => new ArticleCategoryQueryModel
            {
                Slug = x.Slug,
                Name = x.Name,
                Description = x.Description,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress,
                ArticlesCount = x.Articles.Count,
                Articles = MapArticles(x.Articles)
            }).FirstOrDefaultAsync(x => x.Slug == slug);

        articleCategory!.KeywordList = articleCategory.Keywords.Split(",").ToList();

        return articleCategory;
    }

    public async Task<List<ArticleCategoryQueryModel>> GetArticleCategoriesAsync()
    {
        return await _blogContext.ArticleCategories
            .Include(x => x.Articles)
            .Select(x => new ArticleCategoryQueryModel
            {
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                ArticlesCount = x.Articles.Count
            }).ToListAsync();
    }

    private static List<ArticleQueryModel> MapArticles(List<Article> articles)
    {
        return articles.Select(x => new ArticleQueryModel
        {
            Slug = x.Slug,
            ShortDescription = x.ShortDescription,
            Title = x.Title,
            Picture = x.Picture,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            PublishDate = x.PublishDate.ToFarsi()
        }).ToList();
    }
}