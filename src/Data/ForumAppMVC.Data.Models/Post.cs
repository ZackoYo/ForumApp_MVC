using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ForumAppMVC.Data.Common.Models;

namespace ForumAppMVC.Data.Models;

public class Post : BaseDeletableModel<int>
{
	public Post()
	{
		this.Comments = new HashSet<Comment>();
	}

	public string Title { get; set; }

	public string Content { get; set; }

	[Required]
	public string UserId { get; set; }

	public virtual ApplicationUser User { get; set; }

	public int CategoryId { get; set; }

	public virtual Category Category{ get; set; }

	public virtual ICollection<Comment> Comments { get; set; }
}