using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumAppMVC.Data;
using ForumAppMVC.Data.Models;
using ForumAppMVC.Data.Seeding;

namespace ForumAppMVC.Data.Seeding
{
	public class CategoriesSeeder : ISeeder
	{
		public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
		{
			if (dbContext.Categories.Any())
			{
				return;
			}

			var categories = new List<string> { "News", "Sport", "Music", "Animals", "World" };

			foreach (var category in categories)
			{
				await dbContext.Categories.AddAsync(new Category
				{
					Name = category,
					Description = category,
					Title = category
				});
			}
		}
	}
}
