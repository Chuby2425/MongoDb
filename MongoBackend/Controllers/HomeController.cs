﻿using Microsoft.AspNetCore.Mvc;
using MongoBackend.Models;
using System.Diagnostics;

namespace MongoBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DatabaseHelper.Database db = new DatabaseHelper.Database();

            db.insertUser(new User()
            {
                name = "laura",
                email = "lau25@gmail.com",
                phone = 63908750,
                address = "Texas",
                dateIn = DateTime.Now
            });

            ViewBag.UserList = db.getUsers();

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