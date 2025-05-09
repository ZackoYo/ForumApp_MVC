using ForumAppMVC.Data.Models;
using ForumAppMVC.Services.Mapping;
using System;

namespace ForumAppMVC.Web.ViewModels.Posts
{
    internal class PostCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }
    }
}
