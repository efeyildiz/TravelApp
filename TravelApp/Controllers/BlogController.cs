using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Models;
using TravelApp.Repository.Abstract;

namespace TravelApp.Controllers
{
    public class BlogController : Controller
    {

        private IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepo)
        {
            _blogRepository = blogRepo;
        }

        public IActionResult Index(int? id)
        {
            var query = _blogRepository.GetAll()
                         .Where(i => i.isShared);

            return View(query.OrderByDescending(i => i.BlogId));
        }

        public IActionResult Details(int id)
        {
            return View(_blogRepository.GetByID(id));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult List()
        {
            return View(_blogRepository.GetAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Blog());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Blog entity)
        {
            if (ModelState.IsValid)
            {
                _blogRepository.SaveBlog(entity);
                TempData["message"] = $"{entity.BlogTittle} kayıt edildi.";
                return RedirectToAction("List");
            }

            return View(entity);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_blogRepository.GetByID(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Blog entity, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                        entity.BlogImage = file.FileName;
                    }
                }

                _blogRepository.SaveBlog(entity);
                TempData["message"] = $"{entity.BlogTittle} kayıt edildi.";
                return RedirectToAction("List");
            }

            return View(entity);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_blogRepository.GetByID(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int BlogId)
        {
            _blogRepository.DeleteBlog(BlogId);
            TempData["message"] = $"{BlogId} numaralı kayıt edildi.";
            return RedirectToAction("List");
        }

    }
}