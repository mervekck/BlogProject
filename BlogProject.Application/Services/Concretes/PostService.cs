using BlogProject.Application.Services.Interfaces;
using BlogProject.Domain.Entities.Concrete;
using BlogProject.Infrastucture.BaseRepositories;
using BlogProject.Infrastucture.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Application.Services.Concretes
{
	public class PostService : BaseRepository<Post>, IPostService
	{
		public PostService(AppDbContext db) : base(db)
		{
		}
	}
}
