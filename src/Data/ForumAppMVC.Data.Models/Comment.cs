﻿using ForumAppMVC.Data.Common.Models;
using ForumAppMVC.Data.Models;

namespace ForumAppMVC.Data.Models;

public class Comment : BaseDeletableModel<int>
{
	public int PostId { get; set; }

	public virtual Post Post { get; set; }

    public int? ParentId { get; set; }

    public virtual Comment Parent { get; set; }

    public string Content { get; set; }

	public string UserId { get; set; }

	public virtual ApplicationUser User { get; set; }
}