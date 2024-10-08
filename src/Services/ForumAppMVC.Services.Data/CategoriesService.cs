using ForumAppMVC.Data.Common.Repositories;
using ForumAppMVC.Data.Models;
using ForumAppMVC.Services.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace ForumAppMVC.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepo;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepo)
        {
            this.categoriesRepo = categoriesRepo;
        }
        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Category> query = this.categoriesRepo.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
            var category = this.categoriesRepo.All().Where(c => c.Name == name).To<T>().FirstOrDefault();

                return category;
        }
    }
}
