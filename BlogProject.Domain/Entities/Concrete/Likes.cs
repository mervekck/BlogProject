using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Entities.Concrete
{
	[PrimaryKey("PostId", "AppUserId")]
	public class Likes
	{
		public Guid PostId { get; set; }
		public Guid AppUserId { get; set; }

		public virtual Post Post { get; set; }
		public virtual AppUser AppUser { get; set; }
	}
}
