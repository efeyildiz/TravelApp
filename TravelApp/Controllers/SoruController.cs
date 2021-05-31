using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Models;
using TravelApp.Repository.Abstract;

namespace TravelApp.Controllers
{
    public class SoruController : Controller
    {
        private ISoruRepository _soruRepository;


        public SoruController(ISoruRepository soruRepo)
        {
            _soruRepository = soruRepo;
        }

        public IActionResult Index(int? id)
        {

            var query = _soruRepository.GetAll();


            return View(query.OrderByDescending(i => i.SoruId));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {

            return View(new Soru());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Soru entity)
        {
            if (ModelState.IsValid)
            {
                _soruRepository.SaveSoru(entity);
                TempData["message"] = $"{entity.soruTittle} kayıt edildi.";
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_soruRepository.GetByID(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Soru entity)
        {
            if (ModelState.IsValid)
            {
                _soruRepository.SaveSoru(entity);
                TempData["message"] = $"{entity.soruTittle} kayıt edildi";
                return RedirectToAction("Index");
            }

            return View(entity);
        }
    }
}