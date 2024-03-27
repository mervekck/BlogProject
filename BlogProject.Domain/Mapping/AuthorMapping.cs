using BlogProject.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Mapping
{
	public class AuthorMapping : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			builder.ToTable("Authors");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name).IsRequired().HasMaxLength(250).HasColumnName("Name").HasColumnType("varchar");

			builder.Property(x => x.Biography).IsRequired(false).HasMaxLength(2000).HasColumnName("Biography").HasColumnType("varchar");

			builder.Property(x => x.Email).IsRequired().HasMaxLength(250);

			builder.Property(x => x.WebsiteUrl).IsRequired(false).HasMaxLength(500);

			builder.Property(x => x.DateOfBirth).IsRequired(false);

			builder.Property(x => x.AutoId).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
		}
	}
}
