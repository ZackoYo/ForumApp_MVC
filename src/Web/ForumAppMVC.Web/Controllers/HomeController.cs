﻿using ForumAppMVC.Web.ViewModels.Home;
using System.Diagnostics;
using ForumAppMVC.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ForumAppMVC.Services.Data;

namespace ForumAppMVC.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Categories =
                    this.categoriesService.GetAll<IndexCategoryViewModel>(),
            };
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
