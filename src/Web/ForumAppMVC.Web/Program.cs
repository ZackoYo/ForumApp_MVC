using System.Reflection;
using ForumAppMVC.Data;
using ForumAppMVC.Data.Common;
using ForumAppMVC.Data.Common.Repositories;
using ForumAppMVC.Data.Models;
using ForumAppMVC.Data.Repositories;
using ForumAppMVC.Data.Seeding;
using ForumAppMVC.Services.Data;
using ForumAppMVC.Services.Mapping;
using ForumAppMVC.Services.Messaging;
using ForumAppMVC.Web.ViewModels;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ForumAppMVC.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			ConfigureServices(builder.Services, builder.Configuration);
			var app = builder.Build();
			Configure(app);
			app.Run();
		}

		private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(
				options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
				.AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

			services.Configure<CookiePolicyOptions>(
				options =>
				{
					options.CheckConsentNeeded = context => true;
					options.MinimumSameSitePolicy = SameSiteMode.None;
				});

			services.AddControllersWithViews(
				options =>
				{
					//options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
				}).AddRazorRuntimeCompilation();

            services.AddRazorPages();
			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddSingleton(configuration);

			// Data repositories
			services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
			services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
			services.AddScoped<IDbQueryRunner, DbQueryRunner>();

			// Application services
			services.AddTransient<IEmailSender>(s => new SendGridEmailSender("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"));
			services.AddTransient<ISettingsService, SettingsService>();
			services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IPostsService, PostsService>();
			services.AddTransient<IVotesService, VotesService>();
        }

		private static void Configure(WebApplication app)
		{
			// Seed data on application startup
			using (var serviceScope = app.Services.CreateScope())
			{
				var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
				dbContext.Database.Migrate();
				new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
			}

			AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
			app.MapControllerRoute("forumCategory", "f/{name:minlength(3)}", new {controller = "Categories", action = "ByName"});
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();
		}
	}
}
