using ForumAppMVC.Data.Models;
using ForumAppMVC.Services.Mapping;

namespace ForumAppMVC.Web.ViewModels.Home;

public class IndexCategoryViewModel : IMapFrom<Category>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int PostsCount { get; set; }
    public string Url => $"/f/{Name.Replace(' ', '-')}";
}