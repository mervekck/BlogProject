using BlogProject.Domain.Entities.Abstract;
using BlogProject.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Entities.Concrete
{
	public class Category : EntityBase, IEntity<Guid>
	{
        public string Name { get; set; }
		public string? Description { get; set; }

		public virtual List<PostCategories> PostCategories { get; set; }
    }
}
