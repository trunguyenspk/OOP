using di_sample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace di_sample.Controllers
{
    public class HomeController : Controller
    {
        public IRepository _myRepository;
        public HomeController(IRepository myRepository)
        {
            _myRepository = myRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Counter = _myRepository.GetHashCode();//.GetnUpdateCounter();

            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Counter = _myRepository.GetHashCode();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
