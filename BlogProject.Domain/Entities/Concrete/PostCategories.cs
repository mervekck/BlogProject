using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Entities.Concrete
{
	public class PostCategories
	{
		public Guid PostId { get; set; }
		public Guid CategoryId { get; set; }

		public virtual Post Post { get; set; }
		public virtual Category Category { get; set; }
		
		//virtual anahtar kelimesi, bir sınıfın alt sınıflarında bu özelliğin ezilebileceğini belirtir. 
	}
}
