﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TravelApp.Controllers
{
    public class SehirController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}