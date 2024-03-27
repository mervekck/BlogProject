using BlogProject.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Mapping
{
	public class PostCategoriesMapping : IEntityTypeConfiguration<PostCategories>
	{
		public void Configure(EntityTypeBuilder<PostCategories> builder)
		{
			builder.HasKey(x => new {x.PostId, x.CategoryId});

			builder.HasOne(x => x.Post).WithMany(x => x.PostCategories).HasForeignKey(x => x.PostId).IsRequired();

			builder.HasOne(x => x.Category).WithMany(x => x.PostCategories).HasForeignKey(x => x.PostId).IsRequired();
		}
	}
}
