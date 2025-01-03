using ForumAppMVC.Data.Models;
using ForumAppMVC.Services.Mapping;
using System;

namespace ForumAppMVC.Web.ViewModels.Categories
{
    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent =>   
            this.Content?.Length > 100 
            ? this.Content?.Substring(0,100) + "..."
            : this.Content;

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CommentsCount { get; set; }
    }
}