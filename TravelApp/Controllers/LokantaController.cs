using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelApp.Models;
using TravelApp.Repository.Abstract;

namespace TravelApp.Controllers
{
    public class LokantaController : Controller
    {
        private ILokantaRepository _lokantaRepository;
        private ISehirRepository _sehirRepository;

        public LokantaController(ILokantaRepository lokantaRepo, ISehirRepository sehirRepo)
        {
            _lokantaRepository = lokantaRepo;
            _sehirRepository = sehirRepo;
        }

        public IActionResult Index(int? id)
        {
            var query = _lokantaRepository.GetAll();

            if (id != null)
            {
                query = query
                    .Where(i => i.SehirId == id);
            }

            return View(query.OrderByDescending(i => i.LokantaId));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult List()
        {
            return View(_lokantaRepository.GetAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Sehirs = new SelectList(_sehirRepository.GetAll(), "SehirId", "sehirAd");

            return View(new Lokanta());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Lokanta entity)
        {
            if (ModelState.IsValid)
            {
                _lokantaRepository.SaveLokanta(entity);
                TempData["message"] = $"{entity.lokantaAd} kayıt edildi.";
                return RedirectToAction("List");
            }

            ViewBag.Categories = new SelectList(_sehirRepository.GetAll(), "SehirId", "sehirAd");
            return View(entity);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Sehirs = new SelectList(_sehirRepository.GetAll(), "SehirId", "sehirAd");

            return View(_lokantaRepository.GetByID(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Lokanta entity, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                        entity.lokantaImage = file.FileName;
                    }
                }

                _lokantaRepository.SaveLokanta(entity);
                TempData["message"] = $"{entity.lokantaAd} kayıt edildi.";
                return RedirectToAction("List");
            }

            ViewBag.Sehirs = new SelectList(_sehirRepository.GetAll(), "SehirId", "sehirAd");
            return View(entity);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_lokantaRepository.GetByID(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int LokantaId)
        {
            _lokantaRepository.DeleteLokanta(LokantaId);
            TempData["message"] = $"{LokantaId} numaralı kayıt edildi.";
            return RedirectToAction("List");
        }

    }
}