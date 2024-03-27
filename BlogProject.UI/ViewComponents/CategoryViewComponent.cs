using BlogProject.Application.Services.Concretes;
using BlogProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.UI.ViewComponents
{
	public class CategoryViewComponent : ViewComponent
	{
		private readonly ICategoryService categoryService;

		public CategoryViewComponent(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}
		public IViewComponentResult Invoke()
		{
			var categories = categoryService.GetAll();
			return View(categories);
		}
		

	}
}
