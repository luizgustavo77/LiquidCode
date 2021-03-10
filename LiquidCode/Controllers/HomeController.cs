using LiquidCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidCode.Controllers
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

        public IActionResult About()
        {
            return View();
        }

        [Route("[controller]/Error/{statusCode}")]
        public IActionResult Error([FromRoute] string statusCode)
        {
            ErrorViewModel error = new ErrorViewModel();
            error.RequestId = statusCode;
            return View("Error", error);
        }
    }
}
