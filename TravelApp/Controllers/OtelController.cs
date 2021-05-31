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
    public class OtelController : Controller
    {
        private IOtelRepository _otelRepository;
        private ISehirRepository _sehirRepository;

        public OtelController(IOtelRepository otelRepo, ISehirRepository sehirRepo)
        {
            _otelRepository = otelRepo;
            _sehirRepository = sehirRepo;
        }

        public IActionResult Index(int? id)
        {
            var query = _otelRepository.GetAll();

            if (id != null)
            {
                query = query
                    .Where(i => i.SehirId == id);
            }

            return View(query.OrderByDescending(i => i.OtelId));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult List()
        {
            return View(_otelRepository.GetAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Sehirs = new SelectList(_sehirRepository.GetAll(), "SehirId", "sehirAd");

            return View(new Otel());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Otel entity)
        {
            if (ModelState.IsValid)
            {
                _otelRepository.SaveOtel(entity);
                TempData["message"] = $"{entity.otelAd} kayıt edildi.";
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

            return View(_otelRepository.GetByID(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Otel entity, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                        entity.otelImage = file.FileName;
                    }
                }

                _otelRepository.SaveOtel(entity);
                TempData["message"] = $"{entity.otelAd} kayıt edildi.";
                return RedirectToAction("List");
            }

            ViewBag.Categories = new SelectList(_sehirRepository.GetAll(), "SehirId", "sehirAd");
            return View(entity);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_otelRepository.GetByID(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int OtelId)
        {
            _otelRepository.DeleteOtel(OtelId);
            TempData["message"] = $"{OtelId} numaralı kayıt edildi.";
            return RedirectToAction("List");
        }

    }
}