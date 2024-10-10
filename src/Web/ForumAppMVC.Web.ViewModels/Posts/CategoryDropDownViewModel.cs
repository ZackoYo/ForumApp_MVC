using ForumAppMVC.Data.Models;
using ForumAppMVC.Services.Mapping;

namespace ForumAppMVC.Web.ViewModels.Posts
{
    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}