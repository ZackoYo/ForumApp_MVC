using ForumAppMVC.Data.Models;
using ForumAppMVC.Services.Mapping;
using Ganss.Xss;
using System;

namespace ForumAppMVC.Web.ViewModels.Posts
{
    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }
    }
}
