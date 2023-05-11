using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BScodeWeb.Controllers
{
    public class WebContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
        public IActionResult Events()
        {
            return View();
        }
        public IActionResult Trainers()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
