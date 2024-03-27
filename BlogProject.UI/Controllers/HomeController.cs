using AutoMapper;
using BlogProject.Application.Services.Interfaces;
using BlogProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BlogProject.UI.Controllers
{
    public class HomeController : Controller
    {
        IPostService postService;
        IPostCategoriesService pcService;
        ICategoryService categoryService;
        IAuthorService authorService;
        IMapper mapper;
        public HomeController(IPostService service, IMapper mapper, ICategoryService categoryService, IAuthorService authorService, IPostCategoriesService pcService)
        {
            postService = service;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.authorService = authorService;
            this.pcService = pcService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var categories = categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            var authors = authorService.GetAll().ToDictionary(a => a.Id, a => a.Name);
            ViewBag.Authors = authors;

            var allPosts = postService.GetAll();
            return View(allPosts);
        }

        [HttpPost]
        public IActionResult Index(Guid categoryId)
        {
            var postCategoriesInCategory = pcService.GetBy(pc => pc.CategoryId == categoryId);
            var postIdsInCategory = postCategoriesInCategory.Select(pc => pc.PostId).ToList();
            var postsInCategory = postService.GetBy(post => postIdsInCategory.Contains(post.Id));

            foreach (var post in postsInCategory)
            {
                post.Author = authorService.Find(post.AuthorId);
            }

            var categories = categoryService.GetAll().ToDictionary(a => a.Id, a => a.Name);
            ViewBag.Categories = new SelectList(categories, "Key", "Value");

            return View(postsInCategory);
        }

    }
}
