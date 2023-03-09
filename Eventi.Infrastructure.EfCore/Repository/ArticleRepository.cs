using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Article;
using Eventi.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
{
    private readonly EventiContext _blogContext;
    public ArticleRepository(EventiContext context) : base(context)
    {
        _blogContext = context;
    }

    public async Task<EditArticle?> GetDetailsAsync(long id)
    {
        return await _blogContext.Articles.Select(x => new EditArticle
        {
            Id = x.Id,
            CanonicalAddress = x.CanonicalAddress,
            CategoryId = x.CategoryId,
            Description = x.Description,
            Keywords = x.Keywords,
            MetaDescription = x.MetaDescription,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            PublishDate = x.PublishDate.ToFarsi(),
            ShortDescription = x.ShortDescription,
            Slug = x.Slug,
            Title = x.Title
        }).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Article?> GetWithCategoryAsync(long id)
    {
        return await _blogContext.Articles.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ArticleViewModel>> SearchAsync(ArticleSearchModel searchModel)
    {
        var query = _blogContext.Articles.Select(x => new ArticleViewModel
        {
            Id = x.Id,
            Category = x.Category.Name,
            Picture = x.Picture,
            PublishDate = x.PublishDate.ToFarsi(),
            ShortDescription = x.ShortDescription.Substring(Math.Min(x.ShortDescription.Length, 50)) + "...",
            Title = x.Title
        });

        if (!string.IsNullOrWhiteSpace(searchModel.Title))
        {
            query = query.Where(x => x.Title.Contains(searchModel.Title));
        }

        if (searchModel.CategoryId > 0)
        {
            query = query.Where(x => x.CategoreyId == searchModel.CategoryId);
        }

        return await query.OrderByDescending(x => x.Id).ToListAsync();
    }
}