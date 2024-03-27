using BlogProject.Domain.Entities.Abstract;
using BlogProject.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Entities.Concrete
{
	public class Author : EntityBase,IEntity<Guid>
	{
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public virtual List<Post> Posts { get; set; }

    }
}
