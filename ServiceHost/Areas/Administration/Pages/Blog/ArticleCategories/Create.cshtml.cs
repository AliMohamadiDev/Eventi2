using Eventi.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategories
{
    public class CreateModel : PageModel
    {
        public CreateArticleCategory Command;

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(CreateArticleCategory command)
        {
            var result = await _articleCategoryApplication.CreateAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
