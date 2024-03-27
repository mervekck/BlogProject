using AutoMapper;
using BlogProject.Application.Services.Concretes;
using BlogProject.Application.Services.Interfaces;
using BlogProject.Domain.Entities.Concrete;
using BlogProject.UI.Areas.AdminArea.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace BlogProject.UI.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class PostController : Controller
    {
        IPostService postService;
        IPostCategoriesService pcService;
        ICategoryService categoryService;
        IAuthorService authorService;
        IMapper mapper;
        public PostController(IPostService service, IMapper mapper, ICategoryService categoryService, IAuthorService authorService, IPostCategoriesService pcService)
        {
            postService = service;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.authorService = authorService;
            this.pcService = pcService;
        }
        public IActionResult Index(PostIndexVM vm)
        {
            var posts = postService.GetBy(x => string.IsNullOrWhiteSpace(vm.Title) || x.Title.Contains(vm.Title) && x.Status == Domain.Enums.Status.Active).ToList();

            var authors = authorService.GetAll().ToDictionary(a => a.Id, a => a.Name);
            ViewBag.Authors = authors;

            vm.PostIndexItems = mapper.Map<List<PostIndexItem>>(posts);

            return View(vm);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var authors = authorService.GetAll().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
            var categories = categoryService.GetAll().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            ViewBag.Author = authors;
            ViewBag.Category = categories;
            return View();
        }
        [HttpPost]
        public IActionResult Add(PostAddVM vm, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Post post = mapper.Map<Post>(vm);
                    post.Status = Domain.Enums.Status.Active;
                    post.CreatedDate= DateTime.Now;
                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureFile.CopyTo(ms);
                            post.Picture = ms.ToArray();
                        }
                    }
                    postService.Add(post);
                    if (vm.CategoryId != null)
                    {
                        if (vm.CategoryId != null)
                        {
                            var postId = post.Id;
                            if (vm.CategoryId.HasValue)
                            {
                                var postCategory = new PostCategories
                                {
                                    PostId = postId,
                                    CategoryId = vm.CategoryId.Value
                                };
                                pcService.Add(postCategory);
                            }
                        }

                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata oluştu: {ex.Message}");
                }
            }
            var categories = categoryService.GetAll().ToDictionary(c => c.Id, c => c.Name);
            var authors = authorService.GetAll().ToDictionary(a => a.Id, a => a.Name);

            categories.Add(Guid.Empty, "Yeni Ekle");
            ViewBag.Categories = new SelectList(categories, "Key", "Value", vm.CategoryId);
            ViewBag.Authors = new SelectList(authors, "Key", "Value", vm.AuthorId);

            TempData["message"] = $"Bir Hata Oluştu";
            return View(vm);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Post post = postService.Find(id);
            PostEditVM vm = mapper.Map<PostEditVM>(post);
            var authors = authorService.GetAll().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
            var categories = categoryService.GetAll().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            ViewBag.Author = authors;
            ViewBag.Category = categories;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(PostEditVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var post = postService.Find(vm.Id);
                    post = mapper.Map(vm, post);
                    if (vm.Picture_ != null && vm.Picture_.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            vm.Picture_.CopyTo(ms);
                            post.Picture = ms.ToArray();
                        }
                    }
                    postService.Edit(post);
                    if (vm.CategoryId.HasValue)
                    {
                        var postCategory = new PostCategories
                        {
                            PostId = post.Id,
                            CategoryId = vm.CategoryId.Value
                        };
                        pcService.Edit(postCategory);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                }
            }
            var categories = categoryService.GetAll().ToDictionary(c => c.Id, c => c.Name);
            var authors = authorService.GetAll().ToDictionary(a => a.Id, a => a.Name);

            categories.Add(Guid.Empty, "Yeni Ekle");
            ViewBag.Categories = new SelectList(categories, "Key", "Value", vm.CategoryId);
            ViewBag.Authors = new SelectList(authors, "Key", "Value", vm.AuthorId);

            TempData["message"] = $"Bir Hata Oluştu";
            return View();
        }
        public IActionResult Remove(Guid id)
        {
            try
            {
                Post post = postService.Find(id);
                postService.Remove(post);
            }
            catch (Exception)
            {


            }
            return RedirectToAction("Index");
        }
    }
}
