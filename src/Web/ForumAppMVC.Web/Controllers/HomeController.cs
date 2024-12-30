using ForumAppMVC.Web.ViewModels.Home;
using System.Diagnostics;
using System.Linq;
using ForumAppMVC.Data;
using ForumAppMVC.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ForumAppMVC.Data.Models;
using ForumAppMVC.Data.Common.Repositories;

namespace ForumAppMVC.Web.Controllers
{
	public class HomeController : BaseController
	{
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public HomeController(IDeletableEntityRepository<Category> categoriesRepository)
		{
            this.categoriesRepository = categoriesRepository;
        }

		public IActionResult Index()
		{
			var viewModel = new IndexViewModel();
			var categories = this.categoriesRepository.All().Select(x => new IndexCategoryViewModel
			{
				Description = x.Description,
				ImageUrl = x.ImageUrl,
				Name = x.Name,
				Title = x.Title
			}).ToList();

			viewModel.Categories = categories;

			return this.View(viewModel);
		}

		public IActionResult Privacy()
		{
			return this.View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return this.View(
				new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
		}
	}
}
