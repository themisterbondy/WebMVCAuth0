using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVCAuth0.Models;

namespace WebMVCAuth0.Controllers
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
            return View();
        }

        [Authorize(Roles = "create:messages")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "read:messages")]
        public IActionResult Read()
        {
            return View();
        }

        [Authorize(Roles = "edit:messages")]
        public IActionResult Edit()
        {
            return View();
        }

        [Authorize(Roles = "delete:messages")]
        public IActionResult Delete()
        {
            return View();
        }


        // This is a helper action. It allows you to easily view all the claims of the token.
        public IActionResult Claims()
        {
            var c = User.Claims.Select(c =>
                new
                {
                    c.Type,
                    c.Value
                });
            ViewData["Message"] = Json(c.ToList()).ToString();
            return Json(c);
        }

        // Get User information from Auth0

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
