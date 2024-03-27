using AutoMapper;
using BlogProject.Domain.Entities.Concrete;
using BlogProject.UI.Areas.AdminArea.Models.VM;

namespace BlogProject.UI.Profiles
{
	public class MapperProfile : Profile
	{
        public MapperProfile()
        {
            this.CreateMap<Category, CategoryAddVM>().ReverseMap();
            this.CreateMap<Category, CategoryEditVM>().ReverseMap();
            this.CreateMap<Category, CategoryIndexItem>().ReverseMap();

            this.CreateMap<Author, AuthorIndexItem>().ReverseMap();
            this.CreateMap<Author, AuthorAddVM>().ReverseMap();
            this.CreateMap<Author, AuthorEditVM>().ReverseMap();

            this.CreateMap<Post, PostIndexItem>().ReverseMap();
            this.CreateMap<Post, PostAddVM>().ReverseMap();
            this.CreateMap<Post, PostEditVM>().ReverseMap();
        }
    }
}
