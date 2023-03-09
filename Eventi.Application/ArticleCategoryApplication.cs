using _0_Framework.Application;
using Eventi.Application.Contract.ArticleCategory;
using Eventi.Domain.ArticleCategoryAgg;

namespace Eventi.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository,
            IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public async Task<OperationResult> CreateAsync(CreateArticleCategory command)
        {
            var operation = new OperationResult();
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, slug);
            var articleCategory = new ArticleCategory(command.Name, pictureName, command.PictureAlt,
                command.PictureTitle, command.Description, command.ShowOrder, slug, command.Keywords,
                command.MetaDescription, command.CanonicalAddress);

            await _articleCategoryRepository.CreateAsync(articleCategory);
            await _articleCategoryRepository.SaveChangesAsync();
            return operation.Succeeded();
        }

        public async Task<OperationResult> EditAsync(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var articleCategory = await _articleCategoryRepository.GetAsync(command.Id);

            if (articleCategory == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_articleCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, slug);
            articleCategory.Edit(command.Name, pictureName, command.PictureAlt, command.PictureTitle,
                command.Description, command.ShowOrder, slug, command.Keywords, command.MetaDescription, command.CanonicalAddress);

            await _articleCategoryRepository.SaveChangesAsync();
            return operation.Succeeded();
        }

        public async Task<EditArticleCategory?> GetDetailsAsync(long id)
        {
            return await _articleCategoryRepository.GetDetailsAsync(id);
        }

        public async Task<List<ArticleCategoryViewModel>> GetArticleCategoriesAsync()
        {
            return await _articleCategoryRepository.GetArticleCategoriesAsync();
        }

        public async Task<List<ArticleCategoryViewModel>> SearchAsync(ArticleCategorySearchModel searchModel)
        {
            return await _articleCategoryRepository.SearchAsync(searchModel);
        }
    }
}