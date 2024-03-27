using BlogProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Entities.Interfaces
{
	public interface IEntityBase
	{
		Status Status { get; set; }
		DateTime CreatedDate { get; set; }
		DateTime ModifiedDate { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)] //*Bu özellik veritabanı tarafından otomatik olarak oluşturulduğunu belirtir.
		int AutoId { get; set; }
	}
}
