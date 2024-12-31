using System.Collections.Generic;

namespace ForumAppMVC.Services.Data
{
    public interface ICategoriesService
    {
        public IEnumerable<T> GetAll<T>(int? count = null);
    }
}
