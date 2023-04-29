using _0_Framework.Application;
using _01_EventiQuery.Contracts.Article;
using Eventi.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_EventiQuery.Query;

public class ArticleQuery : IArticleQuery
{
    private readonly EventiContext _blogContext;

    public ArticleQuery(EventiContext blogContext)
    {
        _blogContext = blogContext;
    }

    public async Task<List<ArticleQueryModel>> LatestArticlesAsync()
    {
        return await _blogContext.Articles
            .Include(x => x.Category)
            .Where(x => x.PublishDate <= DateTime.Now)
            .Select(x => new ArticleQueryModel
            {
                Title = x.Title,
                Slug = x.Slug,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription
            }).Take(5).ToListAsync() ?? new List<ArticleQueryModel>();
    }

    public async Task<ArticleQueryModel> GetArticleDetailsAsync(string slug)
    {
        var article = await _blogContext.Articles
            .Include(x => x.Category)
            .Where(x => x.PublishDate <= DateTime.Now)
            .Select(x => new ArticleQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                CategoryId = x.CategoryId,
                CategorySlug = x.Category.Slug,
                CategoryName = x.Category.Name,
                Slug = x.Slug,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription
            }).FirstOrDefaultAsync(x => x.Slug == slug);
        article.keywordList = article.Keywords.Split(",").ToList();

        return article;
    }
}