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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Public()
        {
            ViewData["Message"] = "Hello from a public endpoint! You don't need to be authenticated to see this.";
            return View();
        }

        [Authorize]
        public IActionResult Private()
        {
            if (User.Identity.IsAuthenticated)
            {
                string sUserId = User.Claims.Last()?.Value;


                //Task<Auth0.ManagementApi.Models.User> _taskUserInfo = GetUserInformationAsync(sUserId);
            }
            ViewData["Message"] = "Hello from a private endpoint! You need to be authenticated to see this.";
        return View();
        }

        [Authorize("read:messages")]
        public IActionResult Scoped()
        {
            ViewData["Message"] = "Hello from a private endpoint! You need to be authenticated and have a scope of read:messages to see this.";
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
            return View();
        }

              // Get User information from Auth0


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
