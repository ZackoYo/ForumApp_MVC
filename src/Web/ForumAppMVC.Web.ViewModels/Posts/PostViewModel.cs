using ForumAppMVC.Data.Models;
using ForumAppMVC.Services.Mapping;
using System;
using System.Linq;
using Ganss.Xss;
using AutoMapper;

namespace ForumAppMVC.Web.ViewModels.Posts
{
    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; } //to get the author of the Post

        public int VotesCount { get; set; }

        //Create custom mapping for VotesCount
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.VotesCount, options =>
                {
                    options.MapFrom(p => p.Votes.Sum(v => (int)v.Type));
                });
        }
    }
}
