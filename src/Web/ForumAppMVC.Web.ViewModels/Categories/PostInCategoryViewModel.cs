using ForumAppMVC.Data.Models;
using ForumAppMVC.Services.Mapping;
using System;
using System.Text.RegularExpressions;

namespace ForumAppMVC.Web.ViewModels.Categories
{
    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                var content = Regex.Replace(this.Content, @"<[^>]+>", string.Empty);
                return content.Length > 300
                    ? content.Substring(0, 300) + "..."
                    : content;
            }
        }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CommentsCount { get; set; }
    }
}