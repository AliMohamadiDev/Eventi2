using _0_Framework.Application;
using Eventi.Application.Contract.Article;
using Eventi.Domain.ArticleAgg;
using Eventi.Domain.ArticleCategoryAgg;

namespace Eventi.Application;

public class ArticleApplication : IArticleApplication
{
    private readonly IFileUploader _fileUploader;
    private readonly IArticleRepository _articleRepository;
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleApplication(IFileUploader fileUploader, IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository)
    {
        _fileUploader = fileUploader;
        _articleRepository = articleRepository;
        _articleCategoryRepository = articleCategoryRepository;
    }

    public async Task<OperationResult> CreateAsync(CreateArticle command)
    {
        var operation = new OperationResult();
        if (_articleRepository.Exists(x => x.Title == command.Title))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        var slug = command.Slug.Slugify();
        var categorySlug = _articleCategoryRepository.GetSlugBy(command.CategoryId);
        var path = $"{categorySlug}/{slug}";
        var pictureName = _fileUploader.Upload(command.Picture!, path);
        var publishDate = command.PublishDate.ToGeorgianDateTime();

        var article = new Article(command.Title, command.ShortDescription, command.Description, pictureName,
            command.PictureAlt, command.PictureTitle, publishDate, slug, command.Keywords, command.MetaDescription,
            command.CanonicalAddress, command.CategoryId);

        await _articleRepository.CreateAsync(article);
        await _articleRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> EditAsync(EditArticle command)
    {
        var operation = new OperationResult();
        var article = await _articleRepository.GetWithCategoryAsync(command.Id);

        if (article is null)
        {
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

        if (_articleRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        var slug = command.Slug.Slugify();
        var path = $"{article.Category.Slug}/{slug}";
        var pictureName = _fileUploader.Upload(command.Picture!, path);
        var publishDate = command.PublishDate.ToGeorgianDateTime();

        article.Edit(command.Title, command.ShortDescription, command.Description, pictureName,
            command.PictureAlt, command.PictureTitle, publishDate, slug, command.Keywords, command.MetaDescription,
            command.CanonicalAddress, command.CategoryId);

        await _articleRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<EditArticle?> GetDetailsAsync(long id)
    {
        return await _articleRepository.GetDetailsAsync(id);
    }

    public async Task<List<ArticleViewModel>> SearchAsync(ArticleSearchModel searchModel)
    {
        return await _articleRepository.SearchAsync(searchModel);
    }

    public void Remove(long id)
    {
        _articleRepository.Remove(id);
    }

    public void Restore(long id)
    {
        _articleRepository.Restore(id);
    }
}