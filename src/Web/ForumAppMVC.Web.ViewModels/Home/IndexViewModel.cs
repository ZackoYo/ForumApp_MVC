using System.Collections.Generic;

namespace ForumAppMVC.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<IndexCategoryViewModel> Categories { get; set; }
    }
}
