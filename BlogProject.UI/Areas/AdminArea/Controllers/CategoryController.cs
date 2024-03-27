using AutoMapper;
using BlogProject.Application.Services.Interfaces;
using BlogProject.Domain.Entities.Concrete;
using BlogProject.UI.Areas.AdminArea.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.UI.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        IMapper mapper;
        public CategoryController(ICategoryService service, IMapper mapper)
        {
            categoryService = service;
            this.mapper = mapper;
        }


        public IActionResult Index(CategoryIndexVm vm)
        {
            List<Category> categoryList;

            if (vm.IsEnter.HasValue)
            {
                if (!string.IsNullOrWhiteSpace(vm.Ad))
                {
                    categoryList = categoryService.GetBy(x => x.Name.Contains(vm.Ad) && x.Status == Domain.Enums.Status.Active).ToList();
                    return View(vm);
                }
            }

            vm = new CategoryIndexVm();
            categoryList = categoryService.GetBy(x => x.Status == Domain.Enums.Status.Active).ToList();
            vm.Categories = mapper.Map<List<CategoryIndexItem>>(categoryList);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Add()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryAddVM category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Category c = mapper.Map<Category>(category);

                    c.Status = Domain.Enums.Status.Active;

                    categoryService.Add(c);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                }
            }
            TempData["message"] = $"Bir Hata Oluştu";
            return View();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Category c = categoryService.Find(id);
            CategoryEditVM vm = mapper.Map<CategoryEditVM>(c);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditVM category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Category c = categoryService.Find(category.Id);
                    c.Name = category.Name;
                    c.Description = category.Description;
                    c.ModifiedDate = DateTime.Now;
                    c.Status = Domain.Enums.Status.Active;

                    categoryService.Edit(c);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                }
            }
            TempData["message"] = $"Bir Hata Oluştu";
            return View();
        }

        public IActionResult Remove(Guid id)
        {
            try
            {
                Category c = categoryService.Find(id);
                categoryService.Remove(c);
            }
            catch (Exception)
            {


            }
            return RedirectToAction("Index");
        }
    }
}
