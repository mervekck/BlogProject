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
	public class CategoryMapping : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(x => x.Name).IsRequired().HasMaxLength(250).HasColumnName("Name").HasColumnType("varchar");
			builder.Property(x => x.Description).IsRequired().HasMaxLength(550).HasColumnName("Description").HasColumnType("varchar");
			builder.Property(x => x.AutoId).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
			//otomatik artan ifade
			//PropertySaveBehavior.Ignore değer daha sonradan değiştirilemez
		}
	}
}
