using AutoMapper;
using BlogProject.Application.Services.Concretes;
using BlogProject.Application.Services.Interfaces;
using BlogProject.Domain.Entities.Concrete;
using BlogProject.UI.Areas.AdminArea.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.UI.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AuthorController : Controller
    {
        IAuthorService authorService;
        IMapper mapper;
        public AuthorController(IAuthorService service, IMapper mapper)
        {
            authorService = service;
            this.mapper = mapper;
        }
        public IActionResult Index(AuthorIndexVM vm)
        {
            List<Author> authors;

            if (vm.IsEnter.HasValue)
            {
                if (!string.IsNullOrWhiteSpace(vm.Name))
                {
                    authors = authorService.GetBy(x => x.Name.Contains(vm.Name) && x.Status == Domain.Enums.Status.Active).ToList();
                    return View(vm);
                }
            }

            vm = new AuthorIndexVM();
            authors = authorService.GetBy(x => x.Status == Domain.Enums.Status.Active).ToList();
            vm.Authors = mapper.Map<List<AuthorIndexItem>>(authors);
            return View(vm);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AuthorAddVM author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Author a = mapper.Map<Author>(author);

                    a.Status = Domain.Enums.Status.Active;

                    authorService.Add(a);

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
            Author a = authorService.Find(id);
            AuthorEditVM vm = mapper.Map<AuthorEditVM>(a);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(AuthorEditVM author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Author a = authorService.Find(author.Id);
                    a.Name = author.Name;
                    a.WebsiteUrl = author.WebsiteUrl;
                    a.Biography = author.Biography;
                    a.Email = author.Email;
                    a.DateOfBirth = author.DateOfBirth;
                    a.ModifiedDate = DateTime.Now;
                    a.Status = Domain.Enums.Status.Active;

                    authorService.Edit(a);

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
                Author a = authorService.Find(id);
                authorService.Remove(a);
            }
            catch (Exception)
            {


            }
            return RedirectToAction("Index");
        }
    }
}
