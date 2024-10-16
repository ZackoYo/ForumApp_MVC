using ForumAppMVC.Data.Common.Repositories;
using ForumAppMVC.Data.Models;
using System.Linq;
using System.Threading.Tasks;
using ForumAppMVC.Services.Mapping;

namespace ForumAppMVC.Services.Data
{
    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepo;
        public PostsService(IDeletableEntityRepository<Post> postsRepo)
        {
            this.postsRepo = postsRepo;
        }

        public async Task<int> CreateAsync(string title, string content, int categoryId, string userId)
        {
            var post = new Post
            {
                CategoryId = categoryId,
                Content = content,
                Title = title,
                UserId = userId,
            };

            await this.postsRepo.AddAsync(post);
            await this.postsRepo.SaveChangesAsync();

            return post.Id;
        }

        public T GetById<T>(int id)
        {
            var post = this.postsRepo.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return post;
        }
    }
}
