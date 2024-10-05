namespace ForumAppMVC.Data.Models;

using ForumAppMVC.Data.Common.Models;

public class Setting : BaseDeletableModel<int>
{
	public string Name { get; set; }

	public string Value { get; set; }
}