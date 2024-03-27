using BlogProject.Domain.Entities.Abstract;
using BlogProject.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Entities.Concrete
{
	public class Post : EntityBase,IEntity<Guid>
	{
        public string Title { get; set; }
		public string Body { get; set; }
		public string Summary { get; set; }
        public byte[] Picture { get; set; }
        public int? ViewCount { get; set; }
        public Guid AuthorId { get; set; }

		public virtual List<Likes> Likes { get; set; }
		public virtual List<PostCategories> PostCategories { get; set; }
        public virtual Author Author { get; set; }
    }
}
