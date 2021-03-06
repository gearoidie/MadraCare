﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MadraCare.Website.Models;
using MadraCare.Clients;
using MadraCare.Models;

namespace MadraCare.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMadraService _madraApiClient;

        public HomeController(IMadraService madraApiClient)
        {
            _madraApiClient = madraApiClient;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = String.Join(',',(await _madraApiClient.GetKennels()).Select(x=>x.Name));
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
