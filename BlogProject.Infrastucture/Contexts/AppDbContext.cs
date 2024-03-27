using BlogProject.Domain.Entities.Concrete;
using BlogProject.Domain.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrastucture.Contexts
{
	public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid>
	{
        public AppDbContext(DbContextOptions option):base(option)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<PostCategories> PostCategories { get; set; }
		public DbSet<Likes> Likes { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new CategoryMapping());
			builder.ApplyConfiguration(new AuthorMapping());
			builder.ApplyConfiguration(new PostMapping());
			builder.ApplyConfiguration(new PostCategoriesMapping());
			base.OnModelCreating(builder);
		}
	}
}
