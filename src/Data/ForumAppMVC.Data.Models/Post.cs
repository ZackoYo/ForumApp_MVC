using System.Collections.Generic;
using ForumAppMVC.Data.Common.Models;
using ForumAppMVC.Data.Models;

namespace ForumAppMvc.Data.Models;

public class Post : BaseDeletableModel<int>
{
	public Post()
	{
		this.Comments = new HashSet<Comment>();
	}
	public string Title { get; set; }
	public string Content { get; set; }
	public string UserId { get; set; }
	public virtual ApplicationUser User { get; set; }

	public int CategoryId { get; set; }
	public virtual Category Category{ get; set; }

	public virtual ICollection<Comment> Comments { get; set; }
}