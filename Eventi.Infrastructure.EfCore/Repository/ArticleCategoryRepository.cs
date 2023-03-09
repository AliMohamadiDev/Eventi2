using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Eventi.Application.Contract.ArticleCategory;
using Eventi.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
{
    private readonly EventiContext _blogContext;
    public ArticleCategoryRepository(EventiContext context) : base(context)
    {
        _blogContext = context;
    }

    public string GetSlugBy(long id)
    {
        return _blogContext.ArticleCategories.Select(x => new {x.Id, x.Slug}).FirstOrDefault(x => x.Id == id)!.Slug;
    }

    public async Task<EditArticleCategory?> GetDetailsAsync(long id)
    {
        return await _blogContext.ArticleCategories.Select(x => new EditArticleCategory
        {
            Id = x.Id,
            Name = x.Name,
            CanonicalAddress = x.CanonicalAddress!,
            Description = x.Description,
            Keywords = x.Keywords,
            MetaDescription = x.MetaDescription,
            ShowOrder = x.ShowOrder,
            Slug = x.Slug,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle
        }).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ArticleCategoryViewModel>> GetArticleCategoriesAsync()
    {
        return await _blogContext.ArticleCategories.Select(x => new ArticleCategoryViewModel
        {
            Id = x.Id,
            Name = x.Name
        }).ToListAsync();
    }

    public async Task<List<ArticleCategoryViewModel>> SearchAsync(ArticleCategorySearchModel searchModel)
    {
        var query = _blogContext.ArticleCategories
            .Include(x=>x.Articles)
            .Select(x => new ArticleCategoryViewModel
        {
            Id = x.Id,
            Description = x.Description,
            Name = x.Name,
            Picture = x.Picture!,
            ShowOrder = x.ShowOrder,
            CreationDate = x.CreationDate.ToFarsi(),
            ArticlesCount = x.Articles.Count
        });

        if (!string.IsNullOrWhiteSpace(searchModel.Name))
        {
            query = query.Where(x => x.Name.Contains(searchModel.Name));
        }

        return await query.OrderByDescending(x => x.ShowOrder).ToListAsync();
    }
}