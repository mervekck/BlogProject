using BlogProject.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Mapping
{
	public class PostMapping : IEntityTypeConfiguration<Post>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Post> builder)
		{
			builder.ToTable("Posts");

			builder.Property(x => x.Title).IsRequired().HasMaxLength(350).HasColumnType("varchar");

			builder.Property(x => x.Summary).IsRequired().HasMaxLength(650).HasColumnType("varchar");

			builder.Property(x => x.Body).IsRequired().HasMaxLength(2000).HasColumnType("varchar");

			builder.HasOne(x => x.Author).WithMany(x => x.Posts).HasForeignKey(x => x.AuthorId).IsRequired();

			//WithMany = Yazarların birden fazla gönderisi (post) olabileceğini belirtir.
		}
	}
}
