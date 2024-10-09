using System.Threading.Tasks;

namespace ForumAppMVC.Services.Data
{
    public interface IPostsService
    {
        Task<int> CreateAsync(string title, string content, int categoryId, string userId);
    }
}
