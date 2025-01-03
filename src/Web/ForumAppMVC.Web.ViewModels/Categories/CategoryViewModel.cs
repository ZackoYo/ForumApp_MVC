using ForumAppMVC.Data.Models;
using ForumAppMVC.Services.Mapping;
using System.Collections.Generic;

namespace ForumAppMVC.Web.ViewModels.Categories
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<PostInCategoryViewModel> Posts { get; set; }
    }
}
