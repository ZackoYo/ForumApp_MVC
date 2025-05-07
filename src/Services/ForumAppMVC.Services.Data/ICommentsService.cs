using System.Threading.Tasks;

namespace ForumAppMVC.Services.Data
{
    public interface ICommentsService
    {
        Task Create(int postId, string userId, string content, int? parentId = null);
    }
}
