using ForumAppMVC.Data.Models;
using ForumAppMVC.Services.Mapping;
using System;

namespace ForumAppMVC.Web.ViewModels.Posts
{
    public class PostViewModel : IMapFrom<Post>
    {
        public DateTime CreatedOn { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string UserUserName { get; set; } //to get the author of the Post
    }
}
