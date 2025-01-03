using ForumAppMVC.Services.Data;
using ForumAppMVC.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ForumAppMVC.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }
        public IActionResult ByName(string name)
        {
            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(name);

            return this.View(viewModel);
        }
    }
}
