using BlogProject.Domain.Entities.Concrete;
using BlogProject.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Application.Services.Interfaces
{
	public interface ICategoryService : IRepository<Category>
	{
	}
}
